/// <reference path="Scripts\typings\jquery\jquery.d.ts" />
/// <reference path="Scripts\typings\jqueryui\jqueryui.d.ts" />
/// <reference path="Scripts\typings\webaudioapi\waa.d.ts"/>
/// <reference path="colors.ts"/>
var musicCanvas;

var OscillatorGain = (function () {
    function OscillatorGain(oscillator, gainNode) {
        this.oscillator = oscillator;
        this.gainNode = gainNode;
    }
    return OscillatorGain;
})();

var MusicItem = (function () {
    function MusicItem(volume, timbre) {
        this.volume = volume;
        this.timbre = timbre;
    }
    return MusicItem;
})();

var colorConverter = (function () {
    function colorConverter() {
    }
    colorConverter.hslToRgb = function (h, s, l) {
        var r, g, b;

        if (s == 0) {
            r = g = b = l; // achromatic
        } else {
            function hue2rgb(p, q, t) {
                if (t < 0)
                    t += 1;
                if (t > 1)
                    t -= 1;
                if (t < 1 / 6)
                    return p + (q - p) * 6 * t;
                if (t < 1 / 2)
                    return q;
                if (t < 2 / 3)
                    return p + (q - p) * (2 / 3 - t) * 6;
                return p;
            }

            var q = l < 0.5 ? l * (1 + s) : l + s - l * s;
            var p = 2 * l - q;
            r = hue2rgb(p, q, h + 1 / 3);
            g = hue2rgb(p, q, h);
            b = hue2rgb(p, q, h - 1 / 3);
        }

        return [Math.round(r * 255), Math.round(g * 255), Math.round(b * 255)];
    };

    colorConverter.rgbToHsl = function (r, g, b) {
        r /= 255, g /= 255, b /= 255;
        var max = Math.max(r, g, b), min = Math.min(r, g, b);
        var h, s, l = (max + min) / 2;

        if (max == min) {
            h = s = 0; // achromatic
        } else {
            var d = max - min;
            s = l > 0.5 ? d / (2 - max - min) : d / (max + min);
            switch (max) {
                case r:
                    h = (g - b) / d + (g < b ? 6 : 0);
                    break;
                case g:
                    h = (b - r) / d + 2;
                    break;
                case b:
                    h = (r - g) / d + 4;
                    break;
            }
            h /= 6;
        }

        return [h, s, l];
    };
    return colorConverter;
})();

var MusicCanvas = (function () {
    function MusicCanvas(element) {
        this.canvas = document.getElementById('canvas');
        this.boundingRect = this.canvas.getBoundingClientRect();
        this.context = this.canvas.getContext('2d');
        this.imageData = this.context.createImageData(this.canvas.width, this.canvas.height);
        this.data = this.imageData.data;
        this.context.strokeStyle = '#0000FF';
        this.context.fillStyle = '#EAE9DA';
        this.defaultMsPerNote = 300;
        this.defaultNotesCount = 16;
        this.defaultTonesCount = 16;
        this.defaultVolume = 10;

        this.bckColorR = 255; // parseInt('EA', 16);
        this.bckColorG = 255; // parseInt('E9', 16);
        this.bckColorB = 255; // parseInt('DA', 16);
        this.brushColorR = 255;
        this.brushColorG = 0;
        this.brushColorB = 0;
        this.sideColorR = 100;
        this.sideColorG = 100;
        this.sideColorB = 100;
        this.sideWidth = 0.03;
        this.timerInterval = 50;
        this.baseOctave = 4;
        this.baseNote = 60;
        this.curTempOsc = 0;
        this.tempOscCount = 5;

        var str = localStorage.getItem("msPerNote");
        this.msPerNote = str == null ? this.defaultMsPerNote : parseInt(str);
        this.curVolume = this.defaultVolume / 100.0;

        this.audioContext = new (webkitAudioContext || AudioContext)();
        this.compressor = this.audioContext.createDynamicsCompressor();
        this.compressor.connect(this.audioContext.destination);
        this.tmpOscGains = this.initOscillators(this.tempOscCount);

        this.notesCount = this.defaultNotesCount;
        this.tonesCount = this.defaultTonesCount;
        this.clearCells();

        this.canvas.onmousedown = function (e) {
            if (e.which == 1) {
                this.leftMouseIsDown = true;
                this.onmousemove(e);
            } else if (e.which == 3) {
                this.rightMouseIsDown = true;
                this.onmousemove(e);
            }
        };

        this.canvas.onmousemove = function (e) {
            if (this.leftMouseIsDown || this.rightMouseIsDown) {
                var c = musicCanvas.boundingRect;
                var x = e.x - c.left;
                var y = e.y - c.top;
                var brushSizeX = this.width / musicCanvas.notesCount;
                var brushSizeY = this.height / musicCanvas.tonesCount;
                var y_ind = Math.floor(y / brushSizeY);
                var x_ind = Math.floor(x / brushSizeX);
                var newValue = this.leftMouseIsDown ? musicCanvas.curVolume : 0;

                var curCell = musicCanvas.cells[y_ind][x_ind];
                if (curCell.volume != newValue) {
                    curCell.volume = newValue;

                    if (newValue != 0) {
                        var curOscGain = musicCanvas.tmpOscGains[musicCanvas.curTempOsc];
                        musicCanvas.curTempOsc = (musicCanvas.curTempOsc + 1) % musicCanvas.tmpOscGains.length;
                        curOscGain.oscillator.frequency.value = musicCanvas.oscillatorGains[y_ind].oscillator.frequency.value;
                        curOscGain.oscillator.type = musicCanvas.oscillatorGains[y_ind].oscillator.type;
                        musicCanvas.playTone(curOscGain, curCell.volume);
                    }
                }

                musicCanvas.refresh();
            }
        };

        this.canvas.onmouseup = this.canvas.onmouseleave = function (e) {
            if (e.which == 1)
                this.leftMouseIsDown = false;
            else if (e.which == 3)
                this.rightMouseIsDown = false;
        };

        this.recalculateItems();
    }
    MusicCanvas.prototype.restart = function () {
        this.localMs = 0;
        this.globalMs = 0;
        this.prevNote = -1;
        this.curNote = 0;
        this.timelinePos = 0;

        this.play();
    };

    MusicCanvas.prototype.play = function () {
        var _this = this;
        this.timerToken = setInterval(function () {
            _this.refresh();
            musicCanvas.localMs += musicCanvas.timerInterval;
            musicCanvas.globalMs += musicCanvas.timerInterval;
            musicCanvas.localMs = musicCanvas.localMs % musicCanvas.msPerNote;
            musicCanvas.globalMs = musicCanvas.globalMs % (musicCanvas.msPerNote * musicCanvas.notesCount);
            $('#curNoteNumber').text(musicCanvas.curNote);
            musicCanvas.prevNote = musicCanvas.curNote;
            musicCanvas.curNote = Math.floor(musicCanvas.globalMs / musicCanvas.msPerNote);
        }, this.timerInterval);
    };

    MusicCanvas.prototype.refresh = function () {
        for (var i = 0; i < musicCanvas.data.length; i += 4) {
            musicCanvas.data[i + 3] = 255;
        }

        //var brushSizeX = musicCanvas.canvas.width / musicCanvas.notesCount;
        //var brushSizeY = musicCanvas.canvas.height / musicCanvas.tonesCount;
        var brushSizeX = 20;
        var brushSizeY = 20;
        var volumeMax = $('#volume').slider("option", "max") / 100.0;
        var volumeMin = $('#volume').slider("option", "min") / 100.0;
        var volumeCoef = 1 / (volumeMax - volumeMin);

        for (var i = 0; i < musicCanvas.tonesCount; i++) {
            for (var j = 0; j < musicCanvas.notesCount; j++) {
                var filledCount = 0;
                var startIndY = Math.floor(i * brushSizeY);
                var endIndY = Math.floor((i + 1) * brushSizeY);
                var startIndX = Math.floor(j * brushSizeX);
                var endIndX = Math.floor((j + 1) * brushSizeX);
                var r, g, b;

                // musicCanvas.brushColorR
                if (musicCanvas.cells[i][j].volume != 0.0) {
                    var rgb = colorConverter.hslToRgb(1, 1, (musicCanvas.cells[i][j].volume - volumeMin) * volumeCoef);
                    r = rgb[0];
                    g = rgb[1];
                    b = rgb[2];
                } else {
                    r = musicCanvas.bckColorR;
                    g = musicCanvas.bckColorG;
                    b = musicCanvas.bckColorB;
                }

                for (var k = startIndY; k < endIndY; k++) {
                    for (var l = startIndX; l < endIndX; l++) {
                        var index = (k * musicCanvas.canvas.width + l) * 4;
                        musicCanvas.data[index + 0] = r;
                        musicCanvas.data[index + 1] = g;
                        musicCanvas.data[index + 2] = b;
                    }
                }

                var sideWidth = Math.round(musicCanvas.sideWidth * musicCanvas.canvas.width / musicCanvas.notesCount);
                if (sideWidth <= 0)
                    sideWidth = 1;
                for (var k = 0; k < sideWidth; k++) {
                    for (var l = startIndX; l < endIndX; l++) {
                        var index = ((startIndY + k) * musicCanvas.canvas.width + l) * 4;
                        musicCanvas.data[index + 0] = musicCanvas.sideColorR;
                        musicCanvas.data[index + 1] = musicCanvas.sideColorG;
                        musicCanvas.data[index + 2] = musicCanvas.sideColorB;
                        index = ((endIndY - 1 - k) * musicCanvas.canvas.width + l) * 4;
                        musicCanvas.data[index + 0] = musicCanvas.sideColorR;
                        musicCanvas.data[index + 1] = musicCanvas.sideColorG;
                        musicCanvas.data[index + 2] = musicCanvas.sideColorB;
                    }

                    for (var l = startIndY; l < endIndY; l++) {
                        var index = (l * musicCanvas.canvas.width + (startIndX + k)) * 4;
                        musicCanvas.data[index + 0] = musicCanvas.sideColorR;
                        musicCanvas.data[index + 1] = musicCanvas.sideColorG;
                        musicCanvas.data[index + 2] = musicCanvas.sideColorB;
                        index = (l * musicCanvas.canvas.width + (endIndX - 1 - k)) * 4;
                        musicCanvas.data[index + 0] = musicCanvas.sideColorR;
                        musicCanvas.data[index + 1] = musicCanvas.sideColorG;
                        musicCanvas.data[index + 2] = musicCanvas.sideColorB;
                    }
                }
            }
        }

        if (musicCanvas.curNote != musicCanvas.prevNote) {
            for (var i = 0; i < musicCanvas.tonesCount; i++) {
                if (musicCanvas.cells[i][musicCanvas.curNote].volume != 0.0) {
                    musicCanvas.playTone(musicCanvas.oscillatorGains[i], musicCanvas.cells[i][musicCanvas.curNote].volume);
                }
            }
        }

        musicCanvas.timelinePos = musicCanvas.globalMs / (musicCanvas.msPerNote * musicCanvas.notesCount) * musicCanvas.canvas.width;
        musicCanvas.context.lineWidth = 2;
        musicCanvas.context.putImageData(musicCanvas.imageData, 0, 0);
        musicCanvas.context.beginPath();
        musicCanvas.context.moveTo(musicCanvas.timelinePos, 0);
        musicCanvas.context.lineTo(musicCanvas.timelinePos, musicCanvas.canvas.height);
        musicCanvas.context.stroke();
    };

    MusicCanvas.prototype.stop = function () {
        clearTimeout(this.timerToken);
        for (var i = 0; i < this.tonesCount; i++) {
            this.stopTone(this.oscillatorGains[i]);
        }
    };

    MusicCanvas.prototype.recalculateItems = function () {
        var brushSizeX = this.canvas.width / this.notesCount;
        var brushSizeY = this.canvas.height / this.tonesCount;
        var squareCount = brushSizeX * brushSizeY;

        this.cells = [];
        for (var i = 0; i < this.tonesCount; i++) {
            this.cells[i] = [];
        }

        for (var i = 0; i < this.tonesCount; i++) {
            for (var j = 0; j < this.notesCount; j++) {
                var filledCount = 0;
                var startIndY = Math.floor(i * brushSizeY);
                var endIndY = Math.floor((i + 1) * brushSizeY);
                var startIndX = Math.floor(j * brushSizeX);
                var endIndX = Math.floor((j + 1) * brushSizeX);

                for (var k = startIndY; k < endIndY; k++) {
                    for (var l = startIndX; l < endIndX; l++) {
                        var index = (k * this.canvas.width + l) * 4;
                        if (this.data[index + 0] != this.bckColorR && this.data[index + 1] != this.bckColorG && this.data[index + 2] != this.bckColorB)
                            filledCount++;
                    }
                }

                //var fillSquare = filledCount / squareCount >= 0.5;
                //this.cells[i][j] = new MusicItem(fillSquare ? this.curVolume : 0, 0);
                this.cells[i][j] = new MusicItem(0, 0);
            }
        }

        this.oscillatorGains = this.initOscillators(this.tonesCount);

        this.recalculateFrequences();
    };

    MusicCanvas.prototype.initOscillators = function (count) {
        var result = new Array();
        for (var i = 0; i < count; i++) {
            var oscillator = this.audioContext.createOscillator();
            var gainNode = this.audioContext.createGain();
            gainNode.gain.value = 0;
            oscillator.connect(gainNode);
            gainNode.connect(this.compressor);
            oscillator.start(0);
            result[i] = new OscillatorGain(oscillator, gainNode);
        }
        return result;
    };

    MusicCanvas.prototype.recalculateFrequences = function () {
        var octave = parseInt($("#startOctave option:selected").text());
        var noteStr = $("#startNode option:selected").text();

        // ionian, dorian, phrygian, lydian, mixolydian, aeolian, locrian, majorpentatonic, minorpentatonic, chromatic, major, minor
        var scaleStr = $("#scale option:selected").text();
        var tone = $("#tone option:selected").text();

        var note = teoria.note(noteStr + octave);
        var scale = note.scale(scaleStr).simple();

        var octaveInd = octave;
        for (var i = 0; i < this.tonesCount; i++) {
            var ind = i % scale.length;
            if (i > 0 && this.noteToInd(scale[ind]) < this.noteToInd(scale[(i - 1) % scale.length])) {
                octaveInd++;
            }
            this.oscillatorGains[this.tonesCount - 1 - i].oscillator.frequency.value = teoria.note(scale[ind] + octaveInd).fq();
            this.oscillatorGains[this.tonesCount - 1 - i].oscillator.type = tone;
        }
    };

    MusicCanvas.prototype.noteToInd = function (note) {
        var ind = note.charCodeAt(0) - 'a'.charCodeAt(0) + 7;
        return (ind - 2) % 7;
    };

    MusicCanvas.prototype.startTone = function (oscillatorGain) {
        var now = this.audioContext.currentTime;
        oscillatorGain.gainNode.gain.cancelScheduledValues(now);
        oscillatorGain.gainNode.gain.setValueAtTime(oscillatorGain.gainNode.gain.value, now);
        oscillatorGain.gainNode.gain.linearRampToValueAtTime(0.2, this.audioContext.currentTime + 0.1);
    };

    MusicCanvas.prototype.stopTone = function (oscillatorGain) {
        var now = this.audioContext.currentTime;
        oscillatorGain.gainNode.gain.cancelScheduledValues(now);
        oscillatorGain.gainNode.gain.setValueAtTime(oscillatorGain.gainNode.gain.value, now);
        oscillatorGain.gainNode.gain.linearRampToValueAtTime(0.0, this.audioContext.currentTime + 0.3);
    };

    MusicCanvas.prototype.playTone = function (oscillatorGain, volume) {
        var duration = musicCanvas.msPerNote / 1000.0;
        var now = this.audioContext.currentTime;
        oscillatorGain.gainNode.gain.cancelScheduledValues(now);
        oscillatorGain.gainNode.gain.setValueAtTime(oscillatorGain.gainNode.gain.value, now);
        oscillatorGain.gainNode.gain.linearRampToValueAtTime(volume, this.audioContext.currentTime + 0.1);
        oscillatorGain.gainNode.gain.linearRampToValueAtTime(volume, this.audioContext.currentTime + duration);
        oscillatorGain.gainNode.gain.linearRampToValueAtTime(0.0, this.audioContext.currentTime + duration + 0.3);
    };

    MusicCanvas.prototype.clearCells = function () {
        this.cells = new Array();
        for (var i = 0; i < this.tonesCount; i++) {
            this.cells[i] = [];
            for (var j = 0; j < this.notesCount; j++) {
                this.cells[i][j] = new MusicItem(0, 0);
            }
        }
    };

    MusicCanvas.prototype.generateScale = function () {
        this.clearCells();
        for (var i = 0; i < Math.min(this.notesCount, this.tonesCount); i++) {
            this.cells[this.tonesCount - 1 - i][i].volume = this.curVolume;
        }
    };
    return MusicCanvas;
})();

$(function () {
    var el = document.getElementById('content');
    musicCanvas = new MusicCanvas(el);
    musicCanvas.restart();

    $('body').on('contextmenu', '#canvas', function (e) {
        return false;
    });

    $("#sliderSpeed").slider({
        min: 25,
        max: 1000,
        step: 25,
        value: musicCanvas.msPerNote,
        create: function (event, ui) {
            $('#speed').text(musicCanvas.msPerNote);
        },
        change: function (event, ui) {
            $('#speed').text(ui.value);
            musicCanvas.msPerNote = ui.value;
            localStorage.setItem("msPerNote", musicCanvas.msPerNote.toString());
        }
    });

    $("#tonesCount").spinner({
        min: 2,
        max: 32,
        create: function (event, ui) {
            //$('#brushSize').text(musicCanvas.defaultNotesCount);
        },
        spin: function (event, ui) {
            //$('#brushSize').text(ui.value);
            musicCanvas.stop();
            musicCanvas.canvas.height = 20 * ui.value;
            musicCanvas.imageData = musicCanvas.context.createImageData(musicCanvas.canvas.width, musicCanvas.canvas.height);
            musicCanvas.data = musicCanvas.imageData.data;
            musicCanvas.tonesCount = ui.value;
            musicCanvas.recalculateItems();
            musicCanvas.clearCells();
            musicCanvas.restart();
        }
    }).val(musicCanvas.defaultTonesCount);

    $("#notesCount").spinner({
        min: 2,
        max: 128,
        create: function (event, ui) {
            //$('#brushSize').text(musicCanvas.defaultNotesCount);
        },
        spin: function (event, ui) {
            //$('#brushSize').text(ui.value);
            musicCanvas.stop();
            musicCanvas.canvas.width = 20 * ui.value;
            musicCanvas.imageData = musicCanvas.context.createImageData(musicCanvas.canvas.width, musicCanvas.canvas.height);
            musicCanvas.data = musicCanvas.imageData.data;
            musicCanvas.notesCount = ui.value;
            musicCanvas.recalculateItems();
            musicCanvas.clearCells();
            musicCanvas.restart();
        }
    }).val(musicCanvas.defaultNotesCount);

    $("#volume").slider({
        min: 1,
        max: 50,
        step: 1,
        value: musicCanvas.defaultVolume,
        create: function (event, ui) {
            //$('#volume').text(musicCanvas.defaultVolume);
        },
        change: function (event, ui) {
            //$('#volume').text(ui.value);
            musicCanvas.curVolume = ui.value / 100.0;
        }
    });

    $("#scale").selectmenu({
        change: function (event, ui) {
            musicCanvas.recalculateFrequences();
        }
    });

    $("#startNode").selectmenu({
        change: function (event, ui) {
            musicCanvas.recalculateFrequences();
        }
    });

    $("#startOctave").selectmenu({
        change: function (event, ui) {
            musicCanvas.recalculateFrequences();
        }
    });

    $("#tone").selectmenu({
        change: function (event, ui) {
            musicCanvas.recalculateFrequences();
        }
    });

    $('#clearCells').button();
    $(document).on('click', "#clearCells", function () {
        musicCanvas.clearCells();
    });

    $('#generateScale').button();
    $(document).on('click', "#generateScale", function () {
        musicCanvas.generateScale();
    });

    $('#generateRandom').button();

    $('#stopStart').button();
    $(document).on('click', "#stopStart", function () {
        if ($('#stopStart').text() == "Stop") {
            musicCanvas.stop();
            $('#stopStart').text("Start");
        } else {
            musicCanvas.play();
            $('#stopStart').text("Stop");
        }
    });
});
//# sourceMappingURL=app.js.map
