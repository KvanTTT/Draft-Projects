unit Unit2;

interface

uses SysUtils, Types, GLCanvas, VectorGeometry, GLTexture;

type

TMouseButton = (mbLeft, mbRight, mbMiddle);

TSize = record
x , y : word;
end;

T2dpos = record
x, y : smallint;
end;

TPole = class;
TGamePole = class;

TPlayer = class
protected
FName : string;
FColor, FConturColor : TColorVector;
FAlpha : byte;
FFillTocka : boolean;
Fradius : byte;
FFillColor : TColorVector;
FFillAlpha : byte;
FFill : boolean;
public
property Name  : string read FName  write FName ;
property Color : TColorVector read FColor write FColor;
property ConturColor : TColorVector read FConturColor write FConturColor;
property Alpha : byte read FAlpha write FAlpha;
property FillTocka : boolean read FFillTocka write FFillTocka;
property Fill : boolean read FFill write FFill;
property radius : byte read Fradius;
property FillColor : TColorVector read FFillColor write FFillColor;
property FillAlpha : byte read FFillAlpha write FFillAlpha;
constructor Create(); overload;
constructor Create(Name : string; Color : TColorVector; Alpha : byte;
Fill : boolean; radius : byte); overload;
destructor Destroy(); override;
procedure SavePlayer(Dir : string);
procedure LoadPlayer(name : string);
end;

TPlayers = array of TPlayer;

TTocka = class
protected
Fx, Fy, Fxpos, Fypos : word;
FEnable, FInBase, Fbt, FUsed : boolean;
FPlayer : byte;
procedure GetXY(KletkaSize : byte);
public
property x : word read Fx write Fx;
property y : word read Fy write Fy;
property xpos : word read Fxpos;
property ypos : word read Fypos;
property Enable : boolean read FEnable;
property InBase : boolean read FInBase;
constructor Create(); overload;
constructor Create(xpos, ypos : word; Player : byte; KletkaSize : byte); overload;
destructor Destroy(); override;
procedure DrawTocka(canvas : TGLCanvas; pole : TGamePole; x, y : word);
end;

TTocki2d = array of array of TTocka;
TTocki1d = array of TTocka;

TPole = class
protected
FColor, FLineColor : TColorVector;
FAlpha : byte;
FLineWidth : byte;
FKletkaSize : byte;
FPoleSize : TSize;
FCanvas : TGLCanvas;
public
property Color : TColorVector read FColor write FColor;
property LineColor : TColorVector read FLineColor write FLineColor;
property Alpha : byte read FAlpha write FAlpha;
property LineWidth : byte read FLineWidth write FLineWidth;
property KletkaSize : byte read FKletkaSize write FKletkaSize;
property PoleSize : TSize read FPoleSize write FPoleSize;
constructor Create(); overload;
constructor Create(Color, LineColor : TColorVector; Alpha : byte;
LineWidth, KletkaSize : byte; PoleSize : TSize); overload;
destructor Destroy(); override;
procedure SavePole(Name, Dir : string);
procedure LoadPole(Name : string);
procedure DrawPole(Canvas : TGLCanvas; x, y : integer);
end;

TSimpleBasa = class
protected
FLTpos, FBPpos : t2dpos;
FPlayer : byte;
FNumber : byte;
FTocki : TTocki1d;
FGamePole : ^TGamePole;
public
constructor Create(); overload;
constructor Create(GamePole : TGamePole; Player : byte; Tocki : TTocki1d); overload;
procedure FindAndDisableTovkiInBase;
procedure FindLTandBPPos;
procedure DrawBasa(canvas : TGLCanvas);
end;

TGamePole = class
protected
FTocki : TTocki2d;
FPlayers : TPlayers;
FFocusePlayer : byte;
FPole : TPole;
FBases : array of TSimpleBasa;
FCanvas : TGLCanvas;
public
property Tocki : TTocki2d read FTocki write FTocki;
property Players : TPlayers read FPlayers write FPlayers;
property FocusePlayer : byte read FFocusePlayer write FFocusePlayer;
property Pole : TPole read FPole write FPole;
constructor Create(); overload;
constructor Create(Pole : TPole; Tocki : TTocki2d; Players : TPlayers;
FocusePlayer : byte); overload;
destructor Destroy(); override;
procedure SaveGame(Name, Dir : string);
procedure LoadGame(Name : string);
procedure NextPlayer;
function CheckPlace(pos : T2dpos): boolean;
procedure AddTocka(pos : t2dpos; Player : byte);
function CheckTaroundT(pos : t2dpos; Player : byte; n : byte = 0; OnRight : boolean = true) : t2dpos;
function CheckTocka(xpos, ypos : smallint; Player : byte) : boolean;
procedure CheckTocki(bpos : t2dpos);
procedure OnMouseDown(x, y : smallint; button : TMouseButton);
function OnMouseMove(x, y : smallint) : TPoint;
procedure CreateBasa(tocki : TTocki1d; Player : byte);

procedure UpdatePole(canvas : TGLCanvas);
end;

function MakeSize(x, y: word) : TSize;
function Make2dpos(x, y : smallint) : T2dpos;

function Min2dpos(const t : array of TTocka) : t2dpos;
function Max2dpos(const t : array of TTocka) : t2dpos;
function ConventTockaToPoint(t : TTocka):TPoint;
{function MinVInTockaAr(const t : TTocki1d; const n : word; const OnX : boolean = true) : word;
function MaxVInTockaAr(const t : TTocki1d; const n : word; const OnX : boolean = true) : word;
}

function Distance(const p1, p2 : TTocka) : single;

const
PosNone : t2dpos = (x:-1; y:-1);
PosEmpty : t2dpos = (x:0; y:0);

implementation

var
RM : boolean;
TimeTocki : TTocki1d;
timer : word;
bp : ttocka;
bases : smallint;

function Distance(const p1, p2 : TTocka) : single;
begin
result := sqrt(sqr(p2.x - p1.x) + sqr(p2.y - p1.y));
end;
{
function MinVInTockaAr(const t : TTocki1d; const n : word; const OnX : boolean = true) : word;
var i : word;
begin
if Length(t)>0 then begin
if onx = true then begin
Result:= t[n, 0].y;
    for i:=1 to High(t) do
        if t[n, i].ypos < Result then Result := t[n, i].y;
end else begin
Result:= t[0, n].x;
    for i:=1 to High(t) do
        if t[i, n].xpos < Result then Result := t[i, n].x;
end;
end else result := 0;
end;

function MaxVInTockaAr(const t : TTocki1d; const n : word; const OnX : boolean = true) : word;
var i : word;
begin
if Length(t)>0 then begin
if onx = true then begin
Result:= t[n, 0].y;
    for i:=1 to High(t) do
        if t[n, i].ypos > Result then Result := t[n, i].y;
end else begin
Result:= t[0, n].x;
    for i:=1 to High(t) do
        if t[i, n].xpos > Result then Result := t[i, n].x;
end;
end else result := 0;
end; }

function ConventTockaToPoint(t : TTocka):TPoint;

begin
result.X := t.x;
result.y := t.y;
end;

function Min2dpos(const t : array of TTocka) : t2dpos;
var
   i : Integer;
begin
   if Length(t)>0 then begin
      Result:= Make2dpos(t[0].x, t[0].y);
      for i:=1 to High(t) do begin
         if t[i].xpos < Result.x then Result.x := t[i].x;
         if t[i].ypos < Result.y then Result.y := t[i].y;
        end;
   end else Result:= PosNone;
end;


function Max2dpos(const t : array of TTocka) : t2dpos;
var
   i : Integer;
begin
   if Length(t)>0 then begin
      Result:= Make2dpos(t[0].x, t[0].y);
      for i:=1 to High(t) do begin
         if t[i].xpos > Result.x then Result.x := t[i].x;
         if t[i].ypos > Result.y then Result.y := t[i].y;
        end;
   end else Result:= PosNone;
end;

function MakeSize(x, y: word) : TSize;
begin
result.x := x;
result.y := y;
end;

function Make2dpos(x, y : smallint) : T2dpos;
begin
result.x := x;
result.y := y;
end;

constructor TPlayer.Create();
begin
inherited;
end;

constructor TPlayer.Create(Name : string; Color : TColorVector;
Alpha : byte; Fill : boolean; radius : byte);
begin
inherited Create;
end;

destructor TPlayer.Destroy();
begin
inherited;
end;

procedure TPlayer.SavePlayer(Dir : string);
var f : TextFile;
begin
AssignFile(f, Dir + '\' + FName + '.player');
Rewrite(f);
{WriteLn(f, FName, FColor, FConturColor, FAlpha, FFillTocka, FFillColor,
FFillAlpha);}
CloseFile(f);
end;

procedure TPlayer.LoadPlayer(name : string);
var f : TextFile;
    b : string;
begin
Assign(f, Name + '.player');
Reset(f);
//ReadLn(f, FName, FColor, FConturColor, FAlpha, b, FFillColor, FFillAlpha);
FFillTocka := StrToBool(b);
CloseFile(f);
end;

constructor TTocka.Create();
begin
inherited;
fx := 0;
fy := 0;
fxpos := 0;
fypos := 0;
FPlayer := 0;
end;

constructor TTocka.Create(xpos, ypos : word; Player : byte; KletkaSize : byte);
begin
inherited Create;
fxpos := xpos;
fypos := ypos;
fPlayer := Player;
GetXY(KletkaSize);
end;

destructor TTocka.Destroy();
begin
inherited;
end;

constructor TPole.Create();
begin
inherited;
end;

constructor TPole.Create(Color, LineColor : TColorVector; Alpha : byte;
LineWidth, KletkaSize : byte; PoleSize : TSize);
begin
inherited Create;
FColor := Color;
FLineColor := LineColor;
FAlpha := Alpha;
FLineWidth := LineWidth;
FKletkaSize := KletkaSize;
FPoleSize := PoleSize;
end;

destructor TPole.Destroy();
begin
inherited;
end;

constructor TGamePole.Create();
begin
inherited;
FPole := nil;
FTocki := nil;
FPlayers := nil;
FFocusePlayer := 0;
end;

constructor TGamePole.Create(Pole : TPole; Tocki : TTocki2d; Players : TPlayers;
FocusePlayer : byte);
begin
inherited Create;
FPole := Pole;
FTocki := Tocki;
FPlayers := Players;
FFocusePlayer := FocusePlayer;
SetLength(FTocki, pole.PoleSize.x + 1, pole.PoleSize.y + 1);
SetLength(FBases, 30);
end;

destructor TGamePole.Destroy();
begin
FPole := nil;
FTocki := nil;
FPlayers := nil;
FFocusePlayer := 0;
inherited;
end;

procedure TGamePole.NextPlayer;
begin
If FocusePlayer <> high(players) then
FocusePlayer := FocusePlayer + 1 else FocusePlayer := 0;
end;

function TGamePole.CheckPlace(pos : T2dpos): boolean;
begin
if (pos.x > Pole.PoleSize.x) or (pos.x < 0) or
(pos.y > Pole.PoleSize.y) or (pos.y < 0) then result := false
else if Tocki[pos.x, pos.y] = nil then result := true else result := false;
end;

procedure TGamePole.AddTocka(pos : t2dpos; Player : byte);
begin
if CheckPlace(pos) = true then begin
Tocki[pos.x, pos.y] := TTocka.Create(pos.x, pos.y, FocusePlayer, pole.KletkaSize);
end;
end;

function TGamePole.CheckTocka(xpos, ypos : smallint; Player : byte) : boolean;
begin
result := false;
If CheckPlace(Make2dpos(xpos, ypos)) = true then begin
If Tocki[xpos, ypos] <> nil then begin
If (Tocki[xpos, ypos].FEnable = true) and (Tocki[xpos, ypos].FUsed = false)
and (Tocki[xpos, ypos].FPlayer = Player) then
result := true;
end;
end;
end;

function TGamePole.CheckTaroundT(pos : t2dpos; Player : byte; n : byte = 0; OnRight : boolean = true) : t2dpos;
label 1, end1;
var p : t2dpos;
    n1 : byte;
begin
n1 := n;
1:
case n1 of
  0 : begin if CheckTocka(pos.x, pos.y - 1, Player) = true then  begin
   p := Make2dpos(pos.x, pos.y -1); goto end1; end else begin
   if onright = true then n1 := 1 else begin
   result := posnone; exit; end; goto 1;
   end;
   end;
  1 : begin if CheckTocka(pos.x + 1, pos.y - 1, Player) = true then  begin
   p := Make2dpos(pos.x + 1, pos.y - 1); goto end1; end else begin
   if onright = true then n1 := 2 else n1 := 0; goto 1;
   end;
   end;
  2 : begin if CheckTocka(pos.x + 1, pos.y, Player) = true then  begin
   p := Make2dpos(pos.x + 1, pos.y); goto end1; end else begin
   if onright = true then n1 := 3 else n1 := 1; goto 1;
   end;
   end;
  3 : begin if CheckTocka(pos.x + 1, pos.y + 1, Player) = true then  begin
   p := Make2dpos(pos.x + 1, pos.y + 1); goto end1; end else begin
   if onright = true then n1 := 4 else n1 := 2; goto 1;
   end;
   end;
  4 : begin if CheckTocka(pos.x, pos.y + 1, Player) = true then  begin
   p := Make2dpos(pos.x, pos.y + 1); goto end1; end else begin
   if onright = true then n1 := 5 else n1 := 3; goto 1;
   end;
   end;
  5 : begin if CheckTocka(pos.x - 1, pos.y + 1, Player) = true then  begin
   p := Make2dpos(pos.x - 1, pos.y + 1); goto end1; end else begin
   if onright = true then n1 := 6 else n1 := 4; goto 1;
   end;
   end;
  6 : begin if CheckTocka(pos.x - 1, pos.y, Player) = true then  begin
   p := Make2dpos(pos.x - 1, pos.y); goto end1; end else begin
   if onright = true then n1 := 7 else n1 := 5; goto 1;
   end;
   end;
  7 : begin if CheckTocka(pos.x - 1, pos.y - 1, Player) = true then  begin
   p := Make2dpos(pos.x - 1, pos.y - 1); goto end1; end else begin
   if onright = true then begin result := posnone; exit; end
    else n1 := 6; goto 1;
   end;
   end else begin n1 := 7; goto 1; end;
   end;
end1:
result := p;
end;

procedure TGamePole.CheckTocki(bpos : t2dpos);
var p, p1 : t2dpos;
    a : array[0..100] of t2dpos;
    i, player  : word;
begin
i := 0;
player := Tocki[bpos.x, bpos.y].FPlayer;
p := bpos;
p1 := p;
while (p.x <> -1) and (p.x <> p1.x) and (p.x <> p1.x) do begin
p := CheckTaroundT(bpos, player);
a[i] := p;
i := i + 1;
end;

if (p.x = p1.x) and (p.y = p1.y) then begin end;
i := 0;
while (p.x <> -1) and (p.x <> p1.x) and (p.x <> p1.x) do begin
p := CheckTaroundT(bpos, player, 7, false);
a[i] := p;
i := i + 1;
end;

end;

procedure TGamePole.OnMouseDown(x, y : smallint; button : TMouseButton);
var xpos, ypos : word;
begin
if (x >= 0) and (x <= (pole.PoleSize.x + 1)*Pole.KletkaSize) and
(y >= 0) and (y <= (pole.PoleSize.y + 1)*Pole.KletkaSize) then  begin
if button = mbleft then begin
xpos := x div Pole.KletkaSize;
ypos := y div Pole.KletkaSize;
If CheckPlace(Make2dpos(xpos - 1, ypos - 1)) = true then begin
Tocki[xpos - 1, ypos - 1] := TTocka.Create(xpos, ypos, FocusePlayer, pole.KletkaSize);
NextPlayer;
end;
end;
if button = mbright then begin
bp := TTocka.Create(x div Pole.KletkaSize, y div Pole.KletkaSize, FocusePlayer, pole.KletkaSize);
if RM = true then begin
If {(CheckTocka(bp.xpos, bp.ypos, FocusePlayer) = true) and  }
(Distance(bp, TimeTocki[timer]) <= 1.5*pole.KletkaSize) then begin
if (bp.x = TimeTocki[0].x) and (bp.y = TimeTocki[0].y) then begin
CreateBasa(TimeTocki, FocusePlayer);
RM := false; timer := 0; SetLength(TimeTocki, 30);
exit;
end;
timer := timer + 1;
TimeTocki[timer] := bp;
end;
end else begin
RM := true;
timer := 0;
TimeTocki[timer] := bp;
end;
end;
end else begin RM := false; timer := 0; SetLength(TimeTocki, 30); end;
end;

function TGamePole.OnMouseMove(x, y : smallint) : TPoint;
begin
x := x div Pole.KletkaSize;
y := y div Pole.KletkaSize;
if (x = 0) then x := 1;
if (y = 0) then y := 1;
if (x = pole.PoleSize.x + 1) then x := pole.PoleSize.x;
if (y = pole.PoleSize.y + 1) then y := pole.PoleSize.y;
result.x := x * Pole.KletkaSize;
result.y  := y * Pole.KletkaSize;
if RM = true then begin
bp := TTocka.Create(x div Pole.KletkaSize, y div Pole.KletkaSize, FocusePlayer, pole.KletkaSize);
{if result.x > bp.x + pole.KletkaSize then  result.x := bp.x + pole.KletkaSize;
if result.y > bp.y + pole.KletkaSize then  result.y := bp.y + pole.KletkaSize;
if result.x < bp.x - pole.KletkaSize then  result.x := bp.x - pole.KletkaSize;
if result.y < bp.y - pole.KletkaSize then  result.y := bp.y - pole.KletkaSize; }
end;
end;

procedure TGamePole.CreateBasa(tocki : TTocki1d; Player : byte);
begin
bases := bases + 1;
FBases[bases] := TSimpleBasa.Create(self, Player, tocki);
end;

procedure TGamePole.UpdatePole(canvas : TGLCanvas);
var i, i1 : word;
begin
with canvas do begin
if RM  = true then begin
PenColor := $000000;
PenAlpha := 255;
PenWidth := pole.LineWidth;
for i := 0 to timer do begin
if i <> timer then
line(TimeTocki[i].x, TimeTocki[i].y, TimeTocki[i + 1].x, TimeTocki[i + 1].y)
else
line(TimeTocki[i].x, TimeTocki[i].y, bp.x* pole.KletkaSize, bp.y* pole.KletkaSize);
end;
end;
if bases <> -1 then
for i := 0 to bases do begin
FBases[i].DrawBasa(canvas);
end;
for i := 0 to pole.PoleSize.x do begin
 for i1 := 0 to pole.PoleSize.y do begin
  if Tocki[i, i1] <> nil then
   Tocki[i, i1].DrawTocka(canvas, self, (i + 1)*pole.KletkaSize, (i1 + 1)*pole.KletkaSize);
 end;
end;
end;
end;

procedure TTocka.DrawTocka(canvas : TGLCanvas; pole : TGamePole; x, y : word);
var d, b : byte;
begin
with canvas do begin
b := Pole.Pole.LineWidth;
d := Pole.pole.KletkaSize div 3;
PenAlpha := Pole.Players[FPlayer].Alpha;
PenColor := ConvertColorVector(Pole.Players[FPlayer].ConturColor);
PenWidth := b;
FillEllipse(x + (d - b) div 2, y + (d - b) div 2, d + b, d + b);
PenColor := ConvertColorVector(Pole.Players[FPlayer].Color);
FillEllipse(x + d div 2, y + d div 2, d, d);
end;
end;

procedure TTocka.GetXY(KletkaSize : byte);
begin
x := xpos * KletkaSize;
y := ypos * KletkaSize;
end;

procedure TGamePole.SaveGame(Name, Dir : string);
var f : TextFile;
    i, i1 : word;
begin
AssignFile(f, Dir + '\' + Name + '.tocsave');
Rewrite(f);
WriteLn(f, FPole.PoleSize.x, FPole.PoleSize.y, High(Fplayers), FFocusePlayer);
for i := 0 to FPole.PoleSize.x do begin
 for i1 := 0 to FPole.PoleSize.y do
 WriteLn(f, Tocki[i, i1].x, Tocki[i, i1].y, Tocki[i, i1].FPlayer);
end;
for i := 0 to High(Players) do
WriteLn(f, Players[i].name);
CloseFile(f);
end;

procedure TGamePole.LoadGame(Name : string);
{var f : TextFile;
    a, b, c, i : word; }
begin
{Assign(f, Name);
Reset(f);
ReadLn(f, a, b, c, FFocusePlayer);
SetLength(FPlayers, c + 1);
for i := 0 to High(Tocki) do begin
ReadLn(f, a, b, n);
FTocki[i].x := a;
FTocki[i].y := b;
FTocki[i].Player.name := n;
end;
for i := 0 to High(FPlayers) do begin
ReadLn(f, n);
FPlayers[i].name := n;
end;
CloseFile(f); }
end;

procedure TPole.SavePole(Name, Dir : string);
var f : TextFile;
begin
AssignFile(f, Dir + '\' + Name + '.pole');
Rewrite(f);
{WriteLn(f, FColor, FLineColor, FAlpha,
FLineWidth, FKletkaSize, FPoleSize.x, FPoleSize.y);   }
CloseFile(f);
end;

procedure TPole.LoadPole(Name : string);
var f : TextFile;
begin
Assign(f, Name);
Reset(f);
{ReadLn(f, FColor, FLineColor, FAlpha,
FLineWidth, FKletkaSize, FPoleSize.x, FPoleSize.y); }
CloseFile(f);
end;

procedure TPole.DrawPole(Canvas : TGLCanvas; x, y : integer);
var i : integer;
begin
with canvas do begin
PenAlpha := Alpha;
PenColor := ConvertColorVector(color, 1);
FillRect(x, y, x + KletkaSize*(PoleSize.x + 1), y + KletkaSize*(PoleSize.y + 1));
PenColor := ConvertColorVector(LineColor, 1);
PenWidth := LineWidth;
for i := 1 to PoleSize.x do
line(x + KletkaSize * i, y + KletkaSize, x + KletkaSize * i, y + KletkaSize*PoleSize.y);
for i := 1 to PoleSize.y do
line(x + KletkaSize, y + KletkaSize * i, x + KletkaSize*PoleSize.x, y + KletkaSize * i);
end;
end;

constructor TSimpleBasa.Create();
begin
FBPPos := posEmpty;
FLTPos := posEmpty;
FPlayer := 0;
end;

constructor TSimpleBasa.Create(GamePole : TGamePole; Player : byte; Tocki : TTocki1d);
begin
FBPPos := posEmpty;
FLTPos := posEmpty;
FPlayer := Player;
New(FGamePole);
FGamePole^ := GamePole;
SetLength(FTocki, high(Tocki) + 1);
FTocki := Tocki;
end;

procedure TSimpleBasa.FindAndDisableTovkiInBase;
var i, i1 : word;
begin
FindLTandBPpos;
{for i := FLTpos.x + 1 to FBPpos.x - 1 do begin
for i1 := MinValue(FGamePole^.Tocki, i) + 1 to MinValue(FGamePole^.Tocki, i) - 1 do
if (FGamePole.Tocki[i, i1].FInBase = true) and (FTocki[i, i1] <> nil) then
FGamePole.Tocki[i, i1].FEnable := false;
end;    }
end;

procedure TSimpleBasa.FindLTandBPpos;
begin
fLTpos := Min2dpos(FTocki);
fBPpos := Max2dpos(FTocki);
end;

procedure TSimpleBasa.DrawBasa(canvas : TGLCanvas);
var i : integer;
begin
with canvas do begin
if FGamePole^.players[FPlayer].FFill = true then begin
PenColor := ConvertColorVector(FGamePole^.players[FPlayer].FillColor);
PenAlpha := FGamePole^.players[FPlayer].FFillAlpha;
end;
PenWidth := FGamePole^.Pole.LineWidth;
PenAlpha := FGamePole^.players[FPlayer].Alpha;
PenColor := ConvertColorVector(FGamePole^.players[FPlayer].Color);
for i := 0 to High(FTocki) do begin
if i <> High(FTocki) then
Line(FTocki[0].x,  FTocki[0].y, FTocki[1].x,  FTocki[1].y)
else Line(FTocki[i].x,  FTocki[i].y, 0,  0);
end;
end;
end;

initialization
SetLength(TimeTocki, 30);
RM := false;
timer := 0;
bases := -1;

end.
