unit UnitTochy;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, ExtCtrls, Buttons, StdCtrls, ComCtrls, Gauges;

type
  TForm1 = class(TForm)
    SpeedButton1: TSpeedButton;
    SpeedButton2: TSpeedButton;
    SpeedButton3: TSpeedButton;
    SpeedButton4: TSpeedButton;
    SpeedButton5: TSpeedButton;
    New: TPanel;
    Load: TPanel;
    About: TPanel;
    Rools: TPanel;
    Panel8: TPanel;
    Label1: TLabel;
    ListBox1: TListBox;
    Label2: TLabel;
    ListBox2: TListBox;
    SpeedButton10: TSpeedButton;
    SpeedButton11: TSpeedButton;
    Panel9: TPanel;
    SpeedButton15: TSpeedButton;
    Image1: TImage;
    Label7: TLabel;
    SpeedButton16: TSpeedButton;
    SpeedButton17: TSpeedButton;
    SpeedButton18: TSpeedButton;
    SpeedButton19: TSpeedButton;
    Label8: TLabel;
    Label9: TLabel;
    UpDown1: TUpDown;
    Edit4: TEdit;
    UpDown2: TUpDown;
    Edit5: TEdit;
    Label10: TLabel;
    Label11: TLabel;
    SpeedButton21: TSpeedButton;
    ListBox3: TListBox;
    Edit3: TEdit;
    Edit6: TEdit;
    Label12: TLabel;
    UpDown3: TUpDown;
    UpDown4: TUpDown;
    SpeedButton23: TSpeedButton;
    Panel10: TPanel;
    Label14: TLabel;
    Label15: TLabel;
    Label16: TLabel;
    SpeedButton27: TSpeedButton;
    Panel11: TPanel;
    Label17: TLabel;
    ListBox6: TListBox;
    Image2: TImage;
    Label18: TLabel;
    Save: TPanel;
    SpeedButton24: TSpeedButton;
    SpeedButton25: TSpeedButton;
    ListBox7: TListBox;
    Edit8: TEdit;
    Panel12: TPanel;
    Label19: TLabel;
    Label20: TLabel;
    Label21: TLabel;
    Image3: TImage;
    Label22: TLabel;
    Panel13: TPanel;
    Label23: TLabel;
    ListBox9: TListBox;
    Glavnoe: TPanel;
    Label13: TLabel;
    Exit: TSpeedButton;
    SpeedButton6: TSpeedButton;
    Panel5: TPanel;
    Label24: TLabel;
    Label25: TLabel;
    Panel1: TPanel;
    Label26: TLabel;
    Color1: TPanel;
    ColorDialog2: TColorDialog;
    Panel2: TPanel;
    Panel6: TPanel;
    Panel15: TPanel;
    Label27: TLabel;
    ColorDialog3: TColorDialog;
    Panel17: TPanel;
    Label28: TLabel;
    Edit2: TEdit;
    UpDown5: TUpDown;
    Label29: TLabel;
    Label30: TLabel;
    Edit7: TEdit;
    UpDown6: TUpDown;
    Label31: TLabel;
    Panel18: TPanel;
    Label32: TLabel;
    Panel19: TPanel;
    Panel20: TPanel;
    Label34: TLabel;
    Label35: TLabel;
    Label36: TLabel;
    Image6: TImage;
    Image7: TImage;
    Image8: TImage;
    SpeedButton13: TSpeedButton;
    SpeedButton14: TSpeedButton;
    SpeedButton7: TSpeedButton;
    Label3: TLabel;
    RadioButton4: TRadioButton;
    SpeedButton8: TSpeedButton;
    ListBox4: TListBox;
    RadioButton6: TRadioButton;
    RadioButton7: TRadioButton;
    RadioButton8: TRadioButton;
    RadioButton9: TRadioButton;
    Label4: TLabel;
    Edit1: TEdit;
    UpDown7: TUpDown;
    Label5: TLabel;
    Edit9: TEdit;
    UpDown8: TUpDown;
    Label38: TLabel;
    CheckBox2: TCheckBox;
    RadioButton1: TRadioButton;
    RadioButton2: TRadioButton;
    RadioButton3: TRadioButton;
    Image4: TImage;
    Label33: TLabel;
    Image9: TImage;
    Label39: TLabel;
    Bevel1: TBevel;
    Bevel2: TBevel;
    Label41: TLabel;
    Panel14: TPanel;
    Bevel3: TBevel;
    Label42: TLabel;
    Image11: TImage;
    Label43: TLabel;
    Label44: TLabel;
    Image12: TImage;
    Label45: TLabel;
    Image13: TImage;
    Label46: TLabel;
    Bevel4: TBevel;
    Bevel5: TBevel;
    Label47: TLabel;
    Panel16: TPanel;
    ListBox5: TListBox;
    Label48: TLabel;
    Panel21: TPanel;
    ListBox8: TListBox;
    Panel4: TPanel;
    Label49: TLabel;
    Label50: TLabel;
    Panel7: TPanel;
    Label52: TLabel;
    Label53: TLabel;
    Panel22: TPanel;
    Image10: TImage;
    Label40: TLabel;
    Label54: TLabel;
    Label55: TLabel;
    Image16: TImage;
    Panel23: TPanel;
    Panel24: TPanel;
    Image17: TImage;
    Memo1: TMemo;
    Memo2: TMemo;
    Game: TPanel;
    SpeedButton12: TSpeedButton;
    SpeedButton22: TSpeedButton;
    Image14: TImage;
    Image15: TImage;
    Label57: TLabel;
    Label58: TLabel;
    ScrollBar1: TScrollBar;
    ScrollBar2: TScrollBar;
    Panel3: TPanel;
    Image5: TImage;
    GroupBox1: TGroupBox;
    Gauge1: TGauge;
    Label6: TLabel;
    Label37: TLabel;
    Edit10: TEdit;
    Edit11: TEdit;
    GroupBox2: TGroupBox;
    Gauge3: TGauge;
    Label60: TLabel;
    Label64: TLabel;
    Edit14: TEdit;
    Edit15: TEdit;
    Timer1: TTimer;
    Timer2: TTimer;
    Label59: TLabel;
    procedure SpeedButton1Click(Sender: TObject);
    procedure SpeedButton2Click(Sender: TObject);
    procedure SpeedButton3Click(Sender: TObject);
    procedure SpeedButton4Click(Sender: TObject);
    procedure SpeedButton5Click(Sender: TObject);
    procedure ExitClick(Sender: TObject);
    procedure CheckBox2Click(Sender: TObject);
    procedure SpeedButton6Click(Sender: TObject);
    procedure SpeedButton11Click(Sender: TObject);
    procedure ListBox2Enter(Sender: TObject);
    procedure ListBox2Exit(Sender: TObject);
    procedure SpeedButton10Click(Sender: TObject);
    procedure SpeedButton20Click(Sender: TObject);
    procedure ListBox2DblClick(Sender: TObject);
    procedure ListBox1DblClick(Sender: TObject);
    procedure ListBox1Exit(Sender: TObject);
    procedure SpeedButton15Click(Sender: TObject);
    procedure SpeedButton9Click(Sender: TObject);
    procedure SpeedButton24Click(Sender: TObject);
    procedure SpeedButton25Click(Sender: TObject);
    procedure FormShow(Sender: TObject);
    procedure ListBox3Click(Sender: TObject);
    procedure ListBox3Exit(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure SpeedButton27Click(Sender: TObject);
    procedure ListBox7Click(Sender: TObject);
    procedure ListBox7Exit(Sender: TObject);
    procedure Color1Click(Sender: TObject);
    procedure Panel17Click(Sender: TObject);
    procedure SpeedButton21Click(Sender: TObject);
    procedure SpeedButton16Click(Sender: TObject);
    procedure SpeedButton17Click(Sender: TObject);
    procedure SpeedButton18Click(Sender: TObject);
    procedure SpeedButton19Click(Sender: TObject);
    procedure FormPaint(Sender: TObject);
    procedure Color1Enter(Sender: TObject);
    procedure ScrollBar1Change(Sender: TObject);
    procedure ScrollBar2Change(Sender: TObject);
    procedure UpDown5Click(Sender: TObject; Button: TUDBtnType);
    procedure UpDown6Changing(Sender: TObject; var AllowChange: Boolean);
    procedure UpDown4Changing(Sender: TObject; var AllowChange: Boolean);
    procedure UpDown3Click(Sender: TObject; Button: TUDBtnType);
    procedure ListBox2DragOver(Sender, Source: TObject; X, Y: Integer;
      State: TDragState; var Accept: Boolean);
    procedure ListBox2DragDrop(Sender, Source: TObject; X, Y: Integer);
    procedure ListBox1DragDrop(Sender, Source: TObject; X, Y: Integer);
    procedure ListBox1DragOver(Sender, Source: TObject; X, Y: Integer;
      State: TDragState; var Accept: Boolean);
    procedure Image5MouseMove(Sender: TObject; Shift: TShiftState; X,
      Y: Integer);
    procedure RadioButton6Click(Sender: TObject);
    procedure RadioButton8Click(Sender: TObject);
    procedure UpDown7Click(Sender: TObject; Button: TUDBtnType);
    procedure Edit9Change(Sender: TObject);
    procedure RadioButton9Click(Sender: TObject);
    procedure SpeedButton8Click(Sender: TObject);
    procedure Edit1KeyPress(Sender: TObject; var Key: Char);
    procedure Edit6Change(Sender: TObject);
    procedure Edit2Change(Sender: TObject);
    procedure Edit7Change(Sender: TObject);
    procedure Edit4Change(Sender: TObject);
    procedure Edit5Change(Sender: TObject);
    procedure Edit3Change(Sender: TObject);
    procedure UpDown6Click(Sender: TObject; Button: TUDBtnType);
    procedure ListBox2Click(Sender: TObject);
    procedure FormKeyDown(Sender: TObject; var Key: Word;
      Shift: TShiftState);
    procedure Image5Click(Sender: TObject);
    procedure ScrollBar2KeyPress(Sender: TObject; var Key: Char);
    procedure ScrollBar1KeyPress(Sender: TObject; var Key: Char);
    procedure ListBox1Enter(Sender: TObject);
    procedure Timer1Timer(Sender: TObject);
    procedure Timer2Timer(Sender: TObject);
    procedure Image5MouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
      private
    { Private declarations }
    public
    { Public declarations }
    end;
  TTime = record
    Resim : (space, koniec, shach,shachkoniec);
    gamemin : smallint;
    gamesec : byte;
    igrmin : smallint;
    igrsec : byte;
    ShowTime : boolean;
   end;

  TIgrok = record
    Prinad : (AI, Rasum);
    name : string;
    color : TColor;
    conturcolor : TColor;
    ShowContur : boolean;
    ShowTocka : boolean;
    Photo : TImage;
    Zalivka: (net, cvet, liniya);
    Zalivkacolor : TColor;
    ZalivkaType : (gor, v, dv, dvn, r, kr);
    Instrument : (Pen, Pencil, Phlom, Kist, Pero);
    Voice : (Van, Ars, Pasha, Il, Masha);
    focus : boolean;
  end;

  TTocka = record
    Igrok : TIgrok;
    xcoor : smallint;
    ycoor : smallint;
    active : boolean;
    used : boolean;
    zan : boolean;
    begint : boolean;
    side : byte;
  end;

  TPole = record
    vert : smallint;
    goriz : smallint;
    LineWidth : byte;
    KletkaSize : smallint;
    Background : TColor;
    LineColor : TColor;
  end;
    
  var
  Form1: TForm1;
  p : TPole;
  rez: TModalResult;
  Chel, Comp : TBitmap;
  x1: string;
   igr, igr1 : TIgrok;
  i, i1, a, b, n, g, s1, m1, s2, m2, f1, f, qwe2, qwe1 : integer;
  tpr, tb, toc, toc1 : TTocka;
  pole : array of array of TTocka;
  polex, poley : array of integer;
  po, po1 : TPoint;
  bf : boolean;

implementation

uses Unit2Tochy, Unit3Tochy;

label 10;

{$R *.dfm}

procedure BuiltPole(Image: TImage; StandartMode : boolean; PoleHeight : smallint;
                      PoleLenght  : smallint;  PoleBackground : TColor;
                      PoleBorders : boolean; KletkaSize : smallint;
                      PoleLineWidth : Byte; PoleLineColor : TColor);

 var i, i1 : integer;
 begin
 TImage(Image).ClientWidth := KletkaSize * PoleLenght + KletkaSize;
 TImage(Image).ClientHeight := KletkaSize * PoleHeight + KletkaSize;
 with  TImage(Image).Canvas do begin
 Pen.Color := clWhite;
 Brush.Color := PoleBackground;
 Rectangle(0, 0, TImage(Image).ClientWidth, TImage(Image).ClientHeight);
 If StandartMode = true then begin
   for i := 1 to PoleLenght do begin
    if PoleBorders = false then begin
     if (i = 1) or (i = PoleLenght) then begin
       Pen.Color := PoleBackground;
       pen.Width := 0;
       MoveTo(0, 0); LineTo(0, 0);
       end
      else begin
       Pen.Width := PoleLineWidth;
       Pen.Color := PoleLineColor;
       MoveTo(KletkaSize * i, KletkaSize);
       LineTo(KletkaSize * i, KletkaSize * PoleHeight);
      end;
     end;
    If PoleBorders = true then begin
       Pen.Width := PoleLineWidth;
       Pen.Color := PoleLineColor;
       MoveTo(KletkaSize * i, KletkaSize);
       LineTo(KletkaSize * i, KletkaSize * PoleHeight);
    end;

   for i1 := 1 to PoleHeight do begin
    If PoleBorders = false then begin
     If (i1 = 1) or (i1 = PoleHeight) then begin
       Pen.Color := PoleBackground;
       pen.Width := 0;
       MoveTo(0, 0); LineTo(0, 0);
       end
     else begin
       Pen.Width := PoleLineWidth;
       Pen.Color := PoleLineColor;
       MoveTo(KletkaSize, KletkaSize * i1);
       LineTo(KletkaSize * PoleLenght, KletkaSize * i1);
     end;
    end;
    If PoleBorders = true then begin
       Pen.Width := PoleLineWidth;
       Pen.Color := PoleLineColor;
       MoveTo(KletkaSize, KletkaSize * i1);
       LineTo(KletkaSize * PoleLenght, KletkaSize * i1);
      end;
    end;
   end;
  end;
 end;
end;

procedure DrawBase(image: TImage; points : array of TPoint; t : TTocka);
var i : integer;
begin
for i := 0 to High(points) do begin
if i <> high(points) then begin
With Image.Canvas do begin
pen.Color := t.Igrok.color;
pen.Width := p.LineWidth;
brush.Color := t.Igrok.Zalivkacolor;
MoveTo(points[i].X, points[i].Y);
LineTo(points[i + 1].X, points[i + 1].Y);
end;
end else begin
With Image.Canvas do begin
pen.Color := t.Igrok.color;
pen.Width := p.LineWidth;
brush.Color := t.Igrok.Zalivkacolor;
MoveTo(points[i].X, points[i].Y);
LineTo(points[0].X, points[0].Y);
end;
end;
end;
end;

procedure DrawTocka(igrok : TIgrok; x, y : integer; image : TImage);
begin
with image.Canvas do begin
if igrok.ShowTocka = true then  brush.Color := igrok.color else
brush.Style := bsClear;
if igrok.ShowContur = true then  pen.Color := igrok.conturcolor else
pen.Color := igrok.color;
pen.Width := p.LineWidth;
Ellipse(x - p.KletkaSize div 4, y - p.KletkaSize div 4, x + p.KletkaSize div 4, y + p.KletkaSize div 4);
end;
end;

procedure CheckPoints(t : TTocka; image: TImage);
label 1, 2, 3, 4, 5, 6, 7, 8, 9, 10;
var tp, t1, t2, t3 : TTocka;
    i, i1, a : integer;
    points : array[0..50] of TPoint;
begin
 {TTocka = record
    Igrok : TIgrok;
    xcoor : smallint;
    ycoor : smallint;
    active : boolean;
    used : boolean;
    begint : boolean;
    side : byte;
    zan : boolean;
  end;   }

a := 0;

for i := 0 to 50 do begin
points[i].X := t.xcoor * p.KletkaSize;
points[i].y := t.ycoor * p.KletkaSize;
end;

t2 := t;
t3 := t;
t1.begint := true;
tp.begint := false;
tp.active := true;
tp.used := true;
tp.xcoor := t.xcoor;
tp.ycoor := t.ycoor;


1:
tp.xcoor := t2.xcoor;
tp.ycoor := t2.ycoor - 1;
if (tp.xcoor = t3.xcoor) and (tp.ycoor = t3.ycoor) then goto 10;
if (tp.ycoor < 0)
or (pole[tp.xcoor, tp.ycoor].Igrok.color <> t.Igrok.color)  then goto 2 else goto 9;


2:
tp.xcoor := t2.xcoor + 1;
tp.ycoor := t2.ycoor - 1;
if (tp.xcoor = t3.xcoor) and (tp.ycoor = t3.ycoor) then goto 10;
if (tp.xcoor > High(polex)) or (tp.ycoor < High(poley))
//or (pole[tp.xcoor, tp.ycoor].active = false)
or (pole[tp.xcoor, tp.ycoor].Igrok.color <> t.Igrok.color)  then goto 3 else goto 9;

3:
tp.xcoor := t2.xcoor + 1;
tp.ycoor := t2.ycoor;
if (tp.xcoor = t3.xcoor) and (tp.ycoor = t3.ycoor) then goto 10;
if (tp.xcoor > High(polex))
or (pole[tp.xcoor, tp.ycoor].Igrok.color <> t.Igrok.color) then goto 4 else goto 9;

4:
tp.xcoor := t2.xcoor + 1;
tp.ycoor := t2.ycoor + 1;
if (tp.xcoor = t3.xcoor) and (tp.ycoor = t3.ycoor) then goto 10;
if (tp.xcoor > High(polex)) or (tp.ycoor > High(poley))
or (pole[tp.xcoor, tp.ycoor].active = false)
or (pole[tp.xcoor, tp.ycoor].Igrok.color <> t.Igrok.color) then goto 5 else goto 9;

5:
tp.xcoor := t2.xcoor;
tp.ycoor := t2.ycoor + 1;
if (tp.xcoor = t3.xcoor) and (tp.ycoor = t3.ycoor) then goto 10;
if (tp.ycoor > High(poley))
or (pole[tp.xcoor, tp.ycoor].Igrok.color <> t.Igrok.color) then goto 6 else goto 9;

6:
tp.xcoor := t2.xcoor - 1;
tp.ycoor := t2.ycoor + 1;
if (tp.xcoor = t3.xcoor) and (tp.ycoor = t3.ycoor) then goto 10;
if (tp.xcoor < High(polex)) or (tp.ycoor > High(poley))
or (pole[tp.xcoor, tp.ycoor].active = false)
or (pole[tp.xcoor, tp.ycoor].Igrok.color <> t.Igrok.color) then goto 7 else goto 9;

7:
tp.xcoor := t2.xcoor - 1;
tp.ycoor := t2.ycoor;
if (tp.xcoor = t3.xcoor) and (tp.ycoor = t3.ycoor) then goto 10;
if (tp.xcoor < High(polex))
or (pole[tp.xcoor, tp.ycoor].Igrok.color <> t.Igrok.color) then goto 8 else goto 9;

8:
tp.xcoor := t2.xcoor - 1;
tp.ycoor := t2.ycoor - 1;
if (tp.xcoor = t3.xcoor) and (tp.ycoor = t3.ycoor) then goto 10;
if (tp.xcoor < High(polex)) or (tp.ycoor < High(poley))
or (pole[tp.xcoor, tp.ycoor].active = false) 
or (pole[tp.xcoor, tp.ycoor].Igrok.color <> t.Igrok.color) then goto 10 else goto 9;

9:
pole[tp.xcoor, tp.ycoor].zan := true;
t2.xcoor := tp.xcoor;
t2.ycoor := tp.ycoor;
a := a + 1;
points[a] := Point(t2.xcoor * p.KletkaSize, t2.ycoor * p.KletkaSize);
goto 1;

10:
t3.begint := false;
with Image.Canvas do begin
pen.Color := t.Igrok.color;
pen.Width := p.LineWidth;
brush.Style := bsClear;
Polygon(points);

end;
end;



procedure Hod (Panel: TPanel; Igrok1 : TIgrok; Igrok2 : TIgrok; xcoor : integer; ycoor : integer;
              x, y: integer);
begin

end;

procedure LoadIgr (FileName : string; Igrok : TIgrok; ListBox : TListBox);
begin
TListBox(listBox).Clear;
TListBox(listBox).Items.LoadFromFile('Игроки\' + FileName + '.igr');
 If TListBox(listBox).Items[0] = 'игрок' then begin
 Tigrok(igrok).Prinad := Rasum;
end;
 If TListBox(listBox).Items[0] = 'компьютер' then begin
 Tigrok(igrok).Prinad := AI;
end;
Tigrok(igrok).name := TListBox(listBox).Items[1];
Tigrok(igrok).color := StrToInt(TListBox(listBox).Items[2]);
If TListBox(listBox).Items[3] = '0' then begin
Tigrok(igrok).ShowTocka := false;
end else begin
Tigrok(igrok).ShowTocka := true;
end;
If TListBox(listBox).Items[4] = '0' then begin
Tigrok(igrok).ShowContur := false
end else begin
Tigrok(igrok).ShowContur := true;
Tigrok(igrok).conturcolor := StrToInt(TListBox(listBox).Items[4]);
end;
If TListBox(listBox).Items[6] = 'Нет залики' then begin
Tigrok(igrok).Zalivka := net;
end;
if TListBox(listBox).Items[6] = 'Сплошной цвет' then begin
Tigrok(igrok).Zalivkacolor := StrToInt(TListBox(listBox).Items[7]);
end;
If TListBox(listBox).Items[6] = 'Заливка из линий' then begin
Tigrok(igrok).Zalivkacolor := StrToInt(TListBox(listBox).Items[7]);
 If TListBox(listBox).Items[8] = 'Горизонтальные линии'then begin
  Tigrok(igrok).ZalivkaType := gor;
 end;
 If TListBox(listBox).Items[8] = 'Вертикальные линии'then begin
  Tigrok(igrok).ZalivkaType := v;
 end;
 If TListBox(listBox).Items[8] = 'Диаг. вверх'then begin
  Tigrok(igrok).ZalivkaType := dv;
 end;
 If TListBox(listBox).Items[8] = 'Диаг. вниз'then begin
  Tigrok(igrok).ZalivkaType := dvn;
 end;
 If TListBox(listBox).Items[8] = 'Решётка'then begin
  Tigrok(igrok).ZalivkaType := r;
 end;
 If TListBox(listBox).Items[8] = 'Косая решётка'then begin
  Tigrok(igrok).ZalivkaType := kr;
 end;
 If TListBox(listBox).Items[9] = 'Голос Вани' then begin
  Tigrok(igrok).Voice := Van;
 end;
  If TListBox(listBox).Items[9] = 'Голос Арсения' then begin
  Tigrok(igrok).Voice := Ars;
 end;
  If TListBox(listBox).Items[9] = 'Голос Паши' then begin
  Tigrok(igrok).Voice := Pasha;
 end;
  If TListBox(listBox).Items[9] = 'Голос Ильи' then begin
  Tigrok(igrok).Voice := Il;
 end;
  If TListBox(listBox).Items[9] = 'Голос Маши' then begin
  Tigrok(igrok).Voice := Masha;
 end;
end;
end;

procedure TForm1.SpeedButton1Click(Sender: TObject);
begin
About.Hide;
Game.Hide;
Load.Hide;
Save.Hide;
Rools.Hide;
New.Show;
Panel8.Visible := true;
Panel9.Visible := true;
Panel1.Visible := true;
Panel20.Visible := true;
end;

procedure TForm1.SpeedButton2Click(Sender: TObject);
begin
About.Hide;
Game.Hide;
Load.Show;
Save.Hide;
Rools.Hide;
New.Hide;
end;

procedure TForm1.SpeedButton3Click(Sender: TObject);
begin
About.Hide;
Game.Hide;
Load.Hide;
Save.Show;
Rools.Hide;
New.Hide;
end;

procedure TForm1.SpeedButton4Click(Sender: TObject);
begin
About.Show;
Game.Hide;
Load.Hide;
Save.Hide;
Rools.Hide;
New.Hide;
end;

procedure TForm1.SpeedButton5Click(Sender: TObject);
begin
About.Hide;
Game.Hide;
Load.Hide;
Save.Hide;
Rools.Show;
New.Hide;
end;

procedure TForm1.ExitClick(Sender: TObject);
var rez : TModalResult;
begin
rez := MessageDlg('Вы действительно хотите выйти?'#10#13,
mtWarning,[mbYes, mbNo], 0);
if rez = mrYes then begin
Form1.Close;
Form1.Free;
end;
if rez = mrNo then begin
Form1.SetFocus;
end;
end;

procedure TForm1.CheckBox2Click(Sender: TObject);
begin
Label6.Visible := true;
Edit5.Enabled := true;
Edit4.Enabled := true;
UpDown1.Enabled := true;
UpDown2.Enabled := true;
Label9.Enabled := true;
Label4.Enabled := false;
Edit1.Enabled := false;
UpDown7.Enabled := false;
UpDown8.Enabled := false;
Edit9.Enabled := false;
Label5.Enabled := false;
Label10.Enabled := true;
Label11.Enabled := true;
Label38.Enabled := false;
end;



procedure TForm1.SpeedButton6Click(Sender: TObject);
begin
About.Hide;
Game.Show;
Load.Hide;
Save.Hide;
Rools.Hide;
New.Hide;
end;

procedure TForm1.SpeedButton11Click(Sender: TObject);
var i:integer;
rez: TModalResult;
begin
for i := ListBox2.Items.Count - 1 downto 0 do
If ListBox2.Selected[i] then begin
rez := MessageDlg('Вы действительно хотите удалить этого игрока?'#10#13,
mtWarning,[mbYes, mbNo], 0);
If rez = mrYes then begin
DeleteFile('Игроки\' + ListBox2.Items[i] + '.igr');
ListBox2.Items.Delete(i);
ListBox8.Items.LoadFromFile('Игроки\Список.igr');
ListBox8.Items.Delete(i);
ListBox8.Items.SaveToFile('Игроки\Список.igr');
end;
If rez = mrNo then begin ListBox2.SetFocus;
end;
end;
end;

procedure TForm1.ListBox2Enter(Sender: TObject);
var i : integer;
begin
SpeedButton11.Enabled := true;
for i := ListBox2.Items.Count - 1 downto 0 do
If ListBox2.Selected[i] then begin
ListBox8.Items.LoadFromFile('Игроки\' + ListBox2.Items[i] + '.igr');
If ListBox8.Items[0] = 'игрок' then begin
igr.Prinad := Rasum;
Image9.Picture.Bitmap.LoadFromFile('Разное\Игрок - Человек.bmp');
end;
If ListBox8.Items[0] = 'компьютер' then begin
igr.Prinad := AI;
Image9.Picture.Bitmap.LoadFromFile('Разное\Игрок - Компьютер.bmp');
end;
Label13.Caption := ListBox8.Items[1];
igr.name := ListBox8.Items[1];
Panel14.Color := StrToInt(ListBox8.Items[2]);
igr.color := StrToInt(ListBox8.Items[2]);
If ListBox8.Items[3] = '0' then begin
Label40.Visible := true;
Panel4.Visible := false;
end else begin
Label40.Visible := false;
Panel4.Visible := true;
Panel4.Color := Panel14.Color;
end;
If ListBox8.Items[4] = '0' then begin
Label54.Visible := true;
Panel7.Visible := false;
end else begin
Label54.Visible := false;
Panel7.Visible := true;
Panel7.Color := StrToInt(ListBox8.Items[4]);
end;
If ListBox8.Items[6] = 'Нет залики' then begin
Panel22.Visible := false;
Image10.Visible := false;
end;
if ListBox8.Items[6] = 'Сплошной цвет' then begin
Panel22.Visible := true;
Image10.Visible := false;
Panel22.Color := StrToInt(ListBox8.Items[7]);
end;
If ListBox8.Items[6] = 'Заливка из линий' then begin
Panel22.Visible := true;
Image10.Visible := true;
Panel22.Color := StrToInt(ListBox8.Items[7]);
 If ListBox8.Items[8] = 'Горизонтальные линии'then begin
  Image10.Picture.Bitmap.LoadFromFile('Разное\Горизонтальные линии.bmp');
 end;
 If ListBox8.Items[8] = 'Вертикальные линии'then begin
  Image10.Picture.Bitmap.LoadFromFile('Разное\Вертикальные линии.bmp');
 end;
 If ListBox8.Items[8] = 'Диаг. вверх'then begin
  Image10.Picture.Bitmap.LoadFromFile('Разное\Диаг. вверх.bmp');
 end;
 If ListBox8.Items[8] = 'Диаг. вниз'then begin
  Image10.Picture.Bitmap.LoadFromFile('Разное\Диаг. вниз.bmp');
 end;
 If ListBox8.Items[8] = 'Решётка'then begin
  Image10.Picture.Bitmap.LoadFromFile('Разное\Решётка.bmp');
 end;
 If ListBox8.Items[8] = 'Косая решётка'then begin
  Image10.Picture.Bitmap.LoadFromFile('Разное\Косая решётка.bmp');
 end;
end;
Label47.Caption := ListBox8.Items[9];
end;
end;

procedure TForm1.ListBox2Exit(Sender: TObject);
begin
SpeedButton11.Enabled := false;
end;

procedure TForm1.SpeedButton10Click(Sender: TObject);
begin
form2.Show;


end;

procedure TForm1.SpeedButton20Click(Sender: TObject);
begin
label13.Visible := true;
end;

procedure TForm1.ListBox2DblClick(Sender: TObject);
var i:integer;
begin
for i := ListBox2.Items.Count - 1 downto 0 do
If ListBox2.Selected[i] then begin
ListBox1.Items.Add(ListBox2.Items[i]);
ListBox2.Items.Delete(i);
end;
If ListBox1.Items.Count > 1 then begin
SpeedButton15.Enabled := true;
end
else
If ListBox1.Items.Count  < 2 then begin
SpeedButton15.Enabled := False;
end;
If ListBox1.Items.Count  > 2 then begin
SpeedButton15.Enabled := False;
end;
end;

procedure TForm1.ListBox1DblClick(Sender: TObject);
var i:integer;
begin
for i := ListBox1.Items.Count - 1 downto 0 do
If ListBox1.Selected[i] then begin
ListBox2.Items.Add(ListBox1.Items[i]);
ListBox1.Items.Delete(i);
end;
If ListBox1.Items.Count > 1 then begin
SpeedButton15.Enabled := true;
end
else
If ListBox1.Items.Count  < 2 then begin
SpeedButton15.Enabled := False;
end;
 end;

procedure TForm1.ListBox1Exit(Sender: TObject);
begin
If ListBox1.Items.Count > 1 then begin
SpeedButton15.Enabled := true;
end
else
If ListBox1.Items.Count  < 2 then begin
SpeedButton15.Enabled := False;
end;
end;

procedure TForm1.SpeedButton15Click(Sender: TObject);
var qwe, wer : integer;
begin
If RadioButton1.Checked then begin
Glavnoe.Hide;
Game.Left := 0;
Game.Top := 0;
Game.ClientHeight := Screen.Height;
Game.ClientWidth := Screen.Width;
Panel3.Left := 30;
Panel3.Top := 30;
Panel3.ClientWidth := 1400;
Panel3.ClientHeight := 1100;
ScrollBar1.Top := Panel3.Top + Panel3.ClientHeight;
ScrollBar2.Left := Panel3.Left + Panel3.ClientWidth;
ScrollBar1.Left := Panel3.Left;
ScrollBar2.Top :=   Panel3.Top;
Form1.BorderStyle := bsNone;
Form1.Align := alClient;
Form1.ClientHeight := Screen.Height;
Form1.ClientWidth := Screen.Width;
ScrollBar1.ClientWidth := Panel3.ClientWidth;
ScrollBar2.ClientHeight := Panel3.ClientHeight;
SpeedButton12.Left := ScrollBar2.Left + ScrollBar2.ClientWidth + 30;
SpeedButton22.Left := ScrollBar2.Left + ScrollBar2.ClientWidth + 30;
SpeedButton12.Top := ScrollBar2.ClientHeight - SpeedButton12.ClientHeight;
SpeedButton22.Top := SpeedButton12.Top - 60;
Label6.Left :=  ScrollBar2.Left + ScrollBar2.ClientWidth + 20;
Label37.Left := ScrollBar2.Left + ScrollBar2.ClientWidth + 20;
end;

ListBox8.Clear;
ListBox8.Items.LoadFromFile('Игроки\' + ListBox1.Items[0] + '.igr');
 If ListBox8.Items[0] = 'игрок' then begin
 igr.Prinad := Rasum;
end;
 If ListBox8.Items[0] = 'компьютер' then begin
 igr.Prinad := AI;
end;
igr.name :=  ListBox8.Items[1];
igr.color := StrToInt( ListBox8.Items[2]);
If ListBox8.Items[3] = '0' then begin
igr.ShowTocka := false;
end else begin
igr.ShowTocka := true;
end;
If ListBox8.Items[4] = '0' then begin
igr.ShowContur := false
end else begin
igr.ShowContur := true;
igr.conturcolor := StrToInt( ListBox8.Items[4]);
end;
If ListBox8.Items[6] = 'Нет залики' then begin
igr.Zalivka := net;
end;
if ListBox8.Items[6] = 'Сплошной цвет' then begin
igr.Zalivkacolor := StrToInt( ListBox8.Items[7]);
end;
If ListBox8.Items[6] = 'Заливка из линий' then begin
igr.Zalivkacolor := StrToInt( ListBox8.Items[7]);
 If ListBox8.Items[8] = 'Горизонтальные линии'then begin
  igr.ZalivkaType := gor;
 end;
 If ListBox8.Items[8] = 'Вертикальные линии'then begin
  igr.ZalivkaType := v;
 end;
 If ListBox8.Items[8] = 'Диаг. вверх'then begin
  igr.ZalivkaType := dv;
 end;
 If ListBox8.Items[8] = 'Диаг. вниз'then begin
  igr.ZalivkaType := dvn;
 end;
 If ListBox8.Items[8] = 'Решётка'then begin
  igr.ZalivkaType := r;
 end;
 If ListBox8.Items[8] = 'Косая решётка'then begin
  igr.ZalivkaType := kr;
 end;
 If ListBox8.Items[9] = 'Голос Вани' then begin
  igr.Voice := Van;
 end;
  If ListBox8.Items[9] = 'Голос Арсения' then begin
  igr.Voice := Ars;
 end;
  If ListBox8.Items[9] = 'Голос Паши' then begin
  igr.Voice := Pasha;
 end;
  If ListBox8.Items[9] = 'Голос Ильи' then begin
  igr.Voice := Il;
 end;
  If ListBox8.Items[9] = 'Голос Маши' then begin
  igr.Voice := Masha;
 end;
end;

ListBox8.Clear;
ListBox8.Items.LoadFromFile('Игроки\' + ListBox1.Items[1] + '.igr');
 If ListBox8.Items[0] = 'игрок' then begin
 igr1.Prinad := Rasum;
end;
 If ListBox8.Items[0] = 'компьютер' then begin
 igr1.Prinad := AI;
end;
igr1.name :=  ListBox8.Items[1];
igr1.color := StrToInt( ListBox8.Items[2]);
If ListBox8.Items[3] = '0' then begin
igr1.ShowTocka := false;
end else begin
igr1.ShowTocka := true;
end;
If ListBox8.Items[4] = '0' then begin
igr1.ShowContur := false
end else begin
igr1.ShowContur := true;
igr1.conturcolor := StrToInt( ListBox8.Items[4]);
end;
If ListBox8.Items[6] = 'Нет залики' then begin
igr1.Zalivka := net;
end;
if ListBox8.Items[6] = 'Сплошной цвет' then begin
igr1.Zalivkacolor := StrToInt( ListBox8.Items[7]);
end;
If ListBox8.Items[6] = 'Заливка из линий' then begin
igr1.Zalivkacolor := StrToInt( ListBox8.Items[7]);
 If ListBox8.Items[8] = 'Горизонтальные линии'then begin
  igr1.ZalivkaType := gor;
 end;
 If ListBox8.Items[8] = 'Вертикальные линии'then begin
  igr1.ZalivkaType := v;
 end;
 If ListBox8.Items[8] = 'Диаг. вверх'then begin
  igr1.ZalivkaType := dv;
 end;
 If ListBox8.Items[8] = 'Диаг. вниз'then begin
  igr1.ZalivkaType := dvn;
 end;
 If ListBox8.Items[8] = 'Решётка'then begin
  igr1.ZalivkaType := r;
 end;
 If ListBox8.Items[8] = 'Косая решётка'then begin
  igr1.ZalivkaType := kr;
 end;
 If ListBox8.Items[9] = 'Голос Вани' then begin
  igr1.Voice := Van;
 end;
  If ListBox8.Items[9] = 'Голос Арсения' then begin
  igr1.Voice := Ars;
 end;
  If ListBox8.Items[9] = 'Голос Паши' then begin
  igr1.Voice := Pasha;
 end;
  If ListBox8.Items[9] = 'Голос Ильи' then begin
  igr1.Voice := Il;
 end;
  If ListBox8.Items[9] = 'Голос Маши' then begin
  igr1.Voice := Masha;
 end;
end;


If RadioButton6.Checked then begin
GroupBox2.Visible := false;
GroupBox1.Visible := false;
end;

If igr.Prinad = Rasum then begin
Image14.Picture.Bitmap.LoadFromFile('Разное\Игрок - человек.bmp');
end;
If igr.Prinad = AI then begin
Image14.Picture.Bitmap.LoadFromFile('Разное\Игрок - компьютер.bmp');
end;
Label57.Caption := igr.name;

If igr1.Prinad = Rasum then begin
Image15.Picture.Bitmap.LoadFromFile('Разное\Игрок - человек.bmp');
end;
If igr1.Prinad = AI then begin
Image15.Picture.Bitmap.LoadFromFile('Разное\Игрок - компьютер.bmp');
end;
Label58.Caption := igr1.name;
 label58.Font.Color := igr1.color;
 label57.Font.Color := igr.color;

If RadioButton2.Checked then begin
Glavnoe.Hide;
Game.Left := 0;
Game.Top := 0;
Form1.BorderStyle := bsSizeable;
Form1.Position := poScreenCenter;
end;

If RadioButton7.Checked then begin
GroupBox1.Visible := true;
Gauge3.Hide;
m1 := StrToInt(Edit4.Text);
s1 := StrToInt(Edit5.Text);
Timer1.Enabled := true;
f := m1 * 60 + s1;
Gauge1.MaxValue := f;
qwe2 := f;
end;

If RadioButton8.Checked then begin
GroupBox2.Visible := true;
GroupBox2.Top := GroupBox1.Top;
Gauge1.Hide;
m2 := StrToInt(Edit1.Text);
s2 := StrToInt(Edit9.Text);
timer2.Enabled := true;
f1 := m2 * 60 + s2;
Gauge3.MaxValue :=  f1;
qwe1 := f1;
end;

If RadioButton9.Checked then begin
GroupBox1.Visible := true;
GroupBox2.Visible := true;
GroupBox2.Top := GroupBox1.Top + GroupBox1.ClientHeight + 8;
timer1.Enabled := true;
timer2.Enabled := true;
m1 := StrToInt(Edit4.Text);
s1 := StrToInt(Edit5.Text);
m2 := StrToInt(Edit1.Text);
s2 := StrToInt(Edit9.Text);
f1 := m2 * 60 + s2;
Gauge3.MaxValue :=  f1;
qwe1 := f1;
f := m1 * 60 + s1;
Gauge1.MaxValue := f;
qwe2 := f;
end;

If RadioButton3.Checked then begin
If SpeedButton19.Down then begin
p.vert := 78;
p.goriz := 57;
p.KletkaSize := 18;
p.LineWidth := 1;
p.LineColor := clBlack;
p.Background := clWhite;
BuiltPole(Image5, true, 78, 57, clWhite, true, 18, 1, clBlack);
end;
If SpeedButton18.Down then begin
p.vert := 39;
p.goriz := 57;
p.KletkaSize := 18;
p.LineWidth := 1;
p.LineColor := clBlack;
p.Background := clWhite;
BuiltPole(Image5, true, 39, 57, clWhite, true, 18, 1, clBlack);
end;
If SpeedButton17.Down then begin
p.vert := 68;
p.goriz := 40;
p.KletkaSize := 18;
p.LineWidth := 2;
p.LineColor := clBlack;
p.Background := clWhite;
BuiltPole(Image5, true, 68, 40, clWhite, true, 18, 1, clBlack);
end;
If SpeedButton16.Down then begin
p.vert := 34;
p.goriz := 40;
p.KletkaSize := 18;
p.LineWidth := 2;
p.LineColor := clBlack;
p.Background := clWhite;
BuiltPole(Image5, true, 34, 57, clWhite, true, 18, 1, clBlack);
end;
If SpeedButton21.Down then begin
p.vert := StrToInt(Edit3.Text);
p.goriz := StrToInt(Edit6.Text);
p.KletkaSize := StrToInt(Edit7.Text);
p.LineWidth := StrToInt(Edit2.Text);
p.LineColor := Panel17.Color;
p.Background := Color1.Color;
BuiltPole(Image5, true, StrToInt(Edit3.Text), StrToInt(Edit6.Text),
Color1.Color, true, StrToInt(Edit7.Text), StrToInt(Edit2.Text), Panel17.Color);
end;

n := p.KletkaSize div 2;
{with kart do begin
Left := p.KletkaSize * 2 - n;
Top := p.KletkaSize * 2 - n;
Width := n + n ;
Height := Width;
a := 2; b := 2;
 with Canvas do begin
 pen.Color := RGB(24, 54, 166);
 pen.Width := 1;
 Brush.Color := pen.Color;
 Rectangle(0,0, kart.ClientWidth, kart.ClientHeight);
 pen.Color := p.LineColor;
 pen.Width := p.LineWidth;
 brush.Color := Pixels[0, 0];
 ellipse(0, 0, ClientWidth, ClientHeight);
end;
Transparent := true;
end; }


If SpeedButton6.Down = true then begin
rez := MessageDlg('Вы хотите начать новую игру. Сохранить прошлую?', mtWarning, [mbYes, mbNo], 0);
If rez = mrYes then begin
SpeedButton3.Click;
end;
If rez = mrNo then begin
About.Hide;
Game.Show;
Load.Hide;
Save.Hide;
Rools.Hide;
New.Hide;
SpeedButton6.Visible := true;
SpeedButton6.Down := true;
end;
end
else begin
About.Hide;
Game.Show;
Load.Hide;
Save.Hide;
Rools.Hide;
New.Hide;
SpeedButton6.Visible := true;
SpeedButton6.Down := true;
end;
end;
igr.focus := true;
igr1.focus := false;

with tb do begin
 xcoor := 0; ycoor := 0;
active := false; side := 0;  used := false; begint := false;
end;

 SetLength(pole, p.goriz + 1, p.vert + 1);

for wer := 0 to p.vert  do begin
 for qwe := 0 to p.goriz  do begin

pole[qwe, wer] := tb;
end;
end;
SetLength(polex, p.goriz + 1);
SetLength(poley, p.vert + 1);

end;


//////////----------------------------------------------------------
//////////----------------------------------------------------------
//////////----------------------------------------------------------
//////////----------------------------------------------------------
//////////----------------------------------------------------------
//////////----------------------------------------------------------
//////////----------------------------------------------------------
//////////----------------------------------------------------------
//////////----------------------------------------------------------
//////////----------------------------------------------------------
//////////----------------------------------------------------------
//////////----------------------------------------------------------
//////////----------------------------------------------------------
//////////----------------------------------------------------------
//////////----------------------------------------------------------
//////////----------------------------------------------------------


//////////----------------------------------------------------------
//////////----------------------------------------------------------
//////////----------------------------------------------------------
//////////----------------------------------------------------------
//////////----------------------------------------------------------
//////////----------------------------------------------------------
//////////----------------------------------------------------------
//////////----------------------------------------------------------
//////////----------------------------------------------------------
//////////----------------------------------------------------------
//////////----------------------------------------------------------
//////////----------------------------------------------------------
//////////----------------------------------------------------------
//////////----------------------------------------------------------
//////////----------------------------------------------------------
//////////----------------------------------------------------------



























procedure TForm1.SpeedButton9Click(Sender: TObject);
var i : integer;
begin
for i := ListBox4.Items.Count - 1 downto 0 do
If ListBox4.Selected[i] then begin
Label48.Caption := ListBox4.Items[i];
end;
end;

procedure TForm1.SpeedButton24Click(Sender: TObject);
var rez: TModalResult;
begin
if length(Edit8.Text) = 0 then begin
rez := MessageDlg('Введите имя сохраняемой игры'#10,
mtError,[mbOk], 0);
If rez = mrOk then begin
Edit8.SetFocus;
end;
end;
If length(Edit8.Text) > 0 then begin
ListBox7.Items.Add(Edit8.Text + '; дата: ' + DateToStr(Date) + ', время: ' +
TimeToStr(Time) + '.');
Edit8.Clear;
end;
ListBox3.Items := ListBox7.Items;
end;

procedure TForm1.SpeedButton25Click(Sender: TObject);
var i:integer;
rez: TModalResult;
begin
for i := ListBox7.Items.Count - 1 downto 0 do
If ListBox7.Selected[i] then begin
rez := MessageDlg('Вы действительно хотите удалить эту игру?'#10#13,
mtWarning,[mbYes, mbNo], 0);
If rez = mrYes then begin
ListBox7.Items.Delete(i);
end;
If rez = mrNo then begin ListBox7.SetFocus;
end;
end;
ListBox3.Items := ListBox7.Items;
end;

procedure TForm1.FormShow(Sender: TObject);

var i : integer;
begin
for i := ListBox3.Items.Count - 1 downto 0 do
If ListBox3.Selected[i] then begin
Label24.Caption := ListBox3.Items[i];
end;
end;

procedure TForm1.ListBox3Click(Sender: TObject);
var i : integer;
begin
for i := ListBox3.Items.Count - 1 downto 0 do
If ListBox3.Selected[i] then begin
Label24.Caption := 'Игра: ' + ListBox3.Items[i];
end;
ListBox7.Items := ListBox3.Items;
end;

procedure TForm1.ListBox3Exit(Sender: TObject);
begin
Label24.Caption := 'Игра не выбрана';
end;

procedure TForm1.FormCreate(Sender: TObject);
var i : integer;
begin
ListBox2.Items.LoadFromFile('Игроки\Список.igr');
Label35.Caption := '57';
Label34.Caption := '78';
Label36.Caption := '18';
Label24.Caption := 'Игра не выбрана';
ListBox3.Items := ListBox7.Items;
Image5.Align := alClient;
Image5.Align := alNone;
ScrollBar2.Min := 0;
ScrollBar1.Min := 0;
Chel := TBitmap.Create; Comp := TBitmap.Create;
Chel.LoadFromFile('Разное\Игрок - человек(small).bmp');
Comp.LoadFromFile('Разное\Игрок - компьютер(small).bmp');
for i := ListBox2.Items.Count - 1 downto 0 do
If ListBox2.Selected[i] then begin
ListBox8.Items.LoadFromFile('Игроки\' + ListBox2.Items[i] + '.igr');

end;
end;

procedure TForm1.SpeedButton27Click(Sender: TObject);
var i:integer;
rez: TModalResult;
begin
for i := ListBox3.Items.Count - 1 downto 0 do
If ListBox3.Selected[i] then begin
rez := MessageDlg('Вы действительно хотите удалить эту игру?'#10#13,
mtWarning,[mbYes, mbNo], 0);
If rez = mrYes then begin
ListBox3.Items.Delete(i);
Label24.Caption := 'Игра не выбрана';
end;
If rez = mrNo then begin ListBox3.SetFocus;
end;
end;
ListBox7.Items := ListBox3.Items;
end;

procedure TForm1.ListBox7Click(Sender: TObject);
begin
ListBox3.Items := ListBox7.Items;
end;

procedure TForm1.ListBox7Exit(Sender: TObject);
begin
ListBox3.Items := ListBox7.Items;
end;

procedure TForm1.Color1Click(Sender: TObject);
begin
If ColorDialog2.Execute then begin
Color1.Color := ColorDialog2.Color;
p.Background := Color1.Color;
end;
BuiltPole(Image1, true, StrToInt(Edit3.Text), StrToInt(Edit6.Text),
Color1.Color, true, StrToInt(Edit7.Text), StrToInt(Edit2.Text), Panel17.Color);
end;



procedure TForm1.Panel17Click(Sender: TObject);
begin
If ColorDialog3.Execute then begin
Panel17.Color := ColorDialog3.Color;
end;
BuiltPole(Image1, true, StrToInt(Edit3.Text), StrToInt(Edit6.Text),
Color1.Color, true, StrToInt(Edit7.Text), StrToInt(Edit2.Text), Panel17.Color);
end;



procedure TForm1.SpeedButton21Click(Sender: TObject);
begin
Image1.Refresh;
If SpeedButton21.Down then begin
Label28.Enabled := true;
Label30.Enabled := true;
Label27.Enabled := true;
Edit3.Enabled := true;
Edit7.Enabled := true;
Edit2.Enabled := true;
Panel17.Enabled := true;
Edit6.Enabled := true;
Label26.Enabled := true;
Color1.Enabled := true;
UpDown3.Enabled := true;
UpDown4.Enabled := true;
UpDown5.Enabled := true;
UpDown6.Enabled := true;
Label31.Enabled := true;
Label29.Enabled := true;
Label12.Enabled := true;
Label25.Enabled := true;
Label32.Enabled := true;
CheckBox2.Enabled := true;
p.LineColor := Panel17.Color;
p.LineColor := Color1.Color;
p.LineWidth := StrToInt(Edit2.Text);
BuiltPole(Image1, true, StrToInt(Edit3.Text), StrToInt(Edit6.Text),
Color1.Color, true, StrToInt(Edit7.Text), StrToInt(Edit2.Text), Panel17.Color);
end;
RadioButton6.Enabled := true;
RadioButton7.Enabled := true;
RadioButton8.Enabled := true;
RadioButton9.Enabled := true;
RadioButton4.Enabled := true;
ListBox4.Enabled := true;
SpeedButton8.Enabled := true;
end;

procedure TForm1.SpeedButton16Click(Sender: TObject);
begin
Label35.Caption := '40';
Label34.Caption := '34';
Label36.Caption := '18';
Image1.Refresh;
p.KletkaSize := 18;
p.LineWidth := 1;
p.LineColor := clBlack;
p.Background := clWhite;
If SpeedButton16.Down then begin
RadioButton6.Enabled := false;
RadioButton7.Enabled := false;
RadioButton8.Enabled := false;
RadioButton9.Enabled := false;
RadioButton4.Enabled := false;
ListBox4.Enabled := false;
SpeedButton8.Enabled := false;
RadioButton9.Enabled := false;
CheckBox2.Enabled := false;
Label28.Enabled := false;
Label30.Enabled := false;
Label27.Enabled := false;
Edit3.Enabled := false;
Edit7.Enabled := false;
Edit2.Enabled := false;
Panel17.Enabled := false;
Edit6.Enabled := false;
Label26.Enabled := false;
Color1.Enabled := false;
UpDown3.Enabled := false;
UpDown4.Enabled := false;
UpDown5.Enabled := false;
UpDown6.Enabled := false;
Label31.Enabled := false;
Label29.Enabled := false;
Label12.Enabled := false;
Label25.Enabled := false;
Label32.Enabled := false;
BuiltPole(Image1, true, 34, 40, clWhite, true, 18, 1, clBlack);
end;
end;

procedure TForm1.SpeedButton17Click(Sender: TObject);
begin
Label35.Caption := '40';
Label34.Caption := '68';
Label36.Caption := '18';
Image1.Refresh;
p.KletkaSize := 18;
p.LineWidth := 1;
p.LineColor := clBlack;
p.Background := clWhite;
If SpeedButton17.Down then begin
RadioButton6.Enabled := false;
RadioButton7.Enabled := false;
RadioButton8.Enabled := false;
RadioButton9.Enabled := false;
RadioButton4.Enabled := false;
ListBox4.Enabled := false;
SpeedButton8.Enabled := false;
RadioButton9.Enabled := false;
Label28.Enabled := false;
CheckBox2.Enabled := false;
Label30.Enabled := false;
Label27.Enabled := false;
Edit3.Enabled := false;
Edit7.Enabled := false;
Edit2.Enabled := false;
Panel17.Enabled := false;
Edit6.Enabled := false;
Label26.Enabled := false;
Color1.Enabled := false;
UpDown3.Enabled := false;
UpDown4.Enabled := false;
UpDown5.Enabled := false;
UpDown6.Enabled := false;
Label31.Enabled := false;
Label29.Enabled := false;
Label12.Enabled := false;
Label25.Enabled := false;
Label32.Enabled := false;
BuiltPole(Image1, true, 68, 40, clWhite, true, 18, 1, clBlack);
end;
end;

procedure TForm1.SpeedButton18Click(Sender: TObject);
begin
Label35.Caption := '57';
Label34.Caption := '39';
Label36.Caption := '18';
Image1.Refresh;
p.KletkaSize := 18;
p.LineWidth := 1;
p.LineColor := clBlack;
p.Background := clWhite;
If SpeedButton18.Down then begin
RadioButton6.Enabled := false;
RadioButton7.Enabled := false;
RadioButton8.Enabled := false;
RadioButton9.Enabled := false;
RadioButton4.Enabled := false;
ListBox4.Enabled := false;
SpeedButton8.Enabled := false;
RadioButton9.Enabled := false;
RadioButton6.Enabled := false;
RadioButton7.Enabled := false;
RadioButton8.Enabled := false;
RadioButton9.Enabled := false;
RadioButton4.Enabled := false;
ListBox4.Enabled := false;
SpeedButton8.Enabled := false;
RadioButton9.Enabled := false;
Label28.Enabled := false;
Label30.Enabled := false;
CheckBox2.Enabled := false;
Label27.Enabled := false;
Edit3.Enabled := false;
Edit7.Enabled := false;
Edit2.Enabled := false;
Panel17.Enabled := false;
Edit6.Enabled := false;
Label26.Enabled := false;
Color1.Enabled := false;
UpDown3.Enabled := false;
UpDown4.Enabled := false;
UpDown5.Enabled := false;
UpDown6.Enabled := false;
Label31.Enabled := false;
Label29.Enabled := false;
Label12.Enabled := false;
Label25.Enabled := false;
Label32.Enabled := false;
BuiltPole(Image1, true, 39, 57, clWhite, true, 18, 1, clBlack);
end;
end;


procedure TForm1.SpeedButton19Click(Sender: TObject);
begin
p.KletkaSize := 18;
p.LineWidth := 1;
p.LineColor := clBlack;
p.Background := clWhite;
If SpeedButton19.Down then begin
Label28.Enabled := false;
CheckBox2.Enabled := false;
Label30.Enabled := false;
Label27.Enabled := false;
Edit3.Enabled := false;
Edit7.Enabled := false;
Edit2.Enabled := false;
Panel17.Enabled := false;
Edit6.Enabled := false;
Label26.Enabled := false;
Color1.Enabled := false;
UpDown3.Enabled := false;
UpDown4.Enabled := false;
UpDown5.Enabled := false;
UpDown6.Enabled := false;
Label31.Enabled := false;
Label29.Enabled := false;
Label12.Enabled := false;
Label25.Enabled := false;
Label32.Enabled := false;
Label35.Caption := '57';
Label34.Caption := '78';
Label36.Caption := '18';
RadioButton6.Enabled := false;
RadioButton7.Enabled := false;
RadioButton8.Enabled := false;
RadioButton9.Enabled := false;
RadioButton4.Enabled := false;
ListBox4.Enabled := false;
SpeedButton8.Enabled := false;
RadioButton9.Enabled := false;
BuiltPole(Image1, true, 78, 57, clWhite, true, 18, 1, clBlack);
end;
end;

procedure TForm1.FormPaint(Sender: TObject);
begin
BuiltPole(Image1, true, 78, 57, clWhite, true, 18, 1, clBlack);

end;

procedure TForm1.Color1Enter(Sender: TObject);
begin
p.Background := Color1.Color;
end;

procedure TForm1.ScrollBar1Change(Sender: TObject);
begin
ScrollBar1.Max := Image5.Left + Image5.ClientWidth;
Image5.Left := -ScrollBar1.Position;
{kart.Left := image5.Left + p.KletkaSize * a - n;  }

end;

procedure TForm1.ScrollBar2Change(Sender: TObject);
begin
ScrollBar2.Max := Image5.Top + Image5.ClientHeight;
Image5.Top := -ScrollBar2.Position;
{kart.Top := image5.Top + p.KletkaSize * b - n; }

end;

procedure TForm1.UpDown5Click(Sender: TObject; Button: TUDBtnType);
begin
Image1.Refresh;
BuiltPole(Image1, true, StrToInt(Edit3.Text), StrToInt(Edit6.Text),
Color1.Color, true, StrToInt(Edit7.Text), StrToInt(Edit2.Text), Panel17.Color);
end;

 procedure TForm1.UpDown6Changing(Sender: TObject;
  var AllowChange: Boolean);
begin

Label36.Caption := Edit7.Text;
end;

procedure TForm1.UpDown4Changing(Sender: TObject;
  var AllowChange: Boolean);
begin
Label35.Caption := Edit6.Text;
end;

procedure TForm1.UpDown3Click(Sender: TObject; Button: TUDBtnType);
begin
Label34.Caption := Edit3.Text;
end;


procedure TForm1.ListBox2DragOver(Sender, Source: TObject; X, Y: Integer;
  State: TDragState; var Accept: Boolean);
begin
If Source = ListBox1 then accept := true else Accept := false;
If ListBox1.Items.Count > 1 then begin
SpeedButton15.Enabled := true;
end
else
If ListBox1.Items.Count  < 2 then begin
SpeedButton15.Enabled := False;
end;
end;

procedure TForm1.ListBox2DragDrop(Sender, Source: TObject; X, Y: Integer);
begin
with Source as TListBox do begin
ListBox2.Items.Add(Items[ItemIndex]);
Items.Delete(ItemIndex);
end;
If ListBox1.Items.Count > 1 then begin
SpeedButton15.Enabled := true;
end
else
If ListBox1.Items.Count  < 2 then begin
SpeedButton15.Enabled := False;
end;
end;

procedure TForm1.ListBox1DragDrop(Sender, Source: TObject; X, Y: Integer);
begin
with Source as TListBox do begin
ListBox1.Items.Add(Items[ItemIndex]);
Items.Delete(ItemIndex);
end;
If ListBox1.Items.Count > 1 then begin
SpeedButton15.Enabled := true;
end
else
If ListBox1.Items.Count  < 2 then begin
SpeedButton15.Enabled := False;
end;
end;

procedure TForm1.ListBox1DragOver(Sender, Source: TObject; X, Y: Integer;
  State: TDragState; var Accept: Boolean);
begin
If Source = ListBox2 then accept := true else Accept := false;
If ListBox1.Items.Count > 1 then begin
SpeedButton15.Enabled := true;
end
else
If ListBox1.Items.Count  < 2 then begin
SpeedButton15.Enabled := False;
end;
end;

procedure TForm1.Image5MouseMove(Sender: TObject; Shift: TShiftState; X,
  Y: Integer);
var wi : integer;
begin
Image5.cursor := crNone;
If Shift = [ssMiddle] then begin
ScrollBar1.Position := X;
ScrollBar2.Position := Y;
end;
If Shift = [] then begin
po.X := po1.X;
po.Y := po1.Y;
po1.X := x;
po1.Y := y;
po1.X := round(po1.X / p.KletkaSize) * p.KletkaSize;
po1.y := round(po1.y / p.KletkaSize) * p.KletkaSize;
if po1.X = 0  then po1.X := p.KletkaSize;
{if po1.X = round(image5.ClientWidth / p.KletkaSize) * p.KletkaSize then begin
po1.X := p.goriz + 1;
end; }
if po1.y = 0 then po1.y := p.KletkaSize;
with Image5.Canvas do begin
pen.Color := p.Background;
wi := p.KletkaSize div 3;
Ellipse(po.X - wi, po.Y - wi, po.X + wi, po.Y + wi);
pen.Color := p.LineColor;
if po1.X <> p.KletkaSize then begin
MoveTo(po.X - wi, po.Y); LineTo(po.X - wi + p.LineWidth, po.Y);
MoveTo(po.X + wi - p.LineWidth, po.Y); LineTo(po.x + wi, po.Y);
end else begin MoveTo(po.X + wi - p.LineWidth, po.Y); LineTo(po.x + wi, po.Y); end;
if po1.y <> p.KletkaSize then begin
MoveTo(po.x, po.y - wi); LineTo(po.x, po.y - wi + p.LineWidth);
MoveTo(po.x, po.y + wi - p.LineWidth); LineTo(po.x, po.y + wi);
end else begin MoveTo(po.x, po.y + wi - p.LineWidth); LineTo(po.x, po.y + wi); end;
brush.Style := bsClear;
Ellipse(po1.X - wi, po1.Y - wi, po1.X + wi, po1.Y + wi);
end;
end;
end;

procedure TForm1.RadioButton6Click(Sender: TObject);
begin
Label9.Enabled := false;
Label4.Enabled := false;
Edit5.Enabled := false;
Edit1.Enabled := false;
UpDown1.Enabled := false;
UpDown2.Enabled := false;
UpDown7.Enabled := false;
UpDown8.Enabled := false;
Edit4.Enabled := false;
Edit9.Enabled := false;
Label5.Enabled := false;
Label10.Enabled := false;
Label11.Enabled := false;
Label38.Enabled := false;
end;

procedure TForm1.RadioButton8Click(Sender: TObject);
begin
Label9.Enabled := false;
Label4.Enabled := true;
Edit5.Enabled := false;
Edit1.Enabled := true;
UpDown1.Enabled := false;
UpDown2.Enabled := false;
UpDown7.Enabled := true;
UpDown8.Enabled := true;
Edit4.Enabled := false;
Edit9.Enabled := true;
Label5.Enabled := false;
Label10.Enabled := false;
Label11.Enabled := false;
Label38.Enabled := true;
Label5.Enabled := true;
end;

procedure TForm1.UpDown7Click(Sender: TObject; Button: TUDBtnType);
begin
If (Edit1.Text = '0') and (Edit9.Text = '0') then begin
ShowMessage('Ход не может длиться 0 минут, 0 секунд!');
Edit9.Text := '5';
end;
end;

procedure TForm1.Edit9Change(Sender: TObject);
begin
g := StrToInt(Edit5.Text);
If g > 59 then begin g := 59 end;
Edit5.Text := IntToStr(g);
If g < 0 then begin  g := 0 end;
Edit5.Text := IntToStr(g);
If (Edit1.Text = '0') and (Edit9.Text = '0') then begin
ShowMessage('Ход не может длиться 0 минут, 0 секунд!');
Edit9.Text := '5';
end;
end;

procedure TForm1.RadioButton9Click(Sender: TObject);
begin
Label9.Enabled := true;
Label4.Enabled := true;
Edit5.Enabled := true;
Edit1.Enabled := true;
UpDown1.Enabled := true;
UpDown2.Enabled := true;
UpDown7.Enabled := true;
UpDown8.Enabled := true;
Edit4.Enabled := true;
Edit9.Enabled := true;
Label5.Enabled := true;
Label10.Enabled := true;
Label11.Enabled := true;
Label38.Enabled := true;
end;

procedure TForm1.SpeedButton8Click(Sender: TObject);
begin
Form3.Show;
ListBox5.Clear;
ListBox5.Items.Add(Edit6.Text);
ListBox5.Items.Add(Edit3.Text);
ListBox5.Items.Add(Edit2.Text);
ListBox5.Items.Add(Edit7.Text);
x := IntToStr(Color1.Color);
ListBox5.Items.Add(x);
x := IntToStr(Panel17.Color);
ListBox5.Items.Add(x);

If RadioButton6.Checked = true then begin
ListBox5.Items.Add('Бесконечная игра');
ListBox5.Items.Add('---');
ListBox5.Items.Add('---');
ListBox5.Items.Add('---');
ListBox5.Items.Add('---');
ListBox5.Items.Add('---');
end;

If RadioButton7.Checked = true then begin
ListBox5.Items.Add('Конечная игра');
ListBox5.Items.Add(Edit4.Text);
ListBox5.Items.Add(Edit5.Text);
ListBox5.Items.Add('---');
ListBox5.Items.Add('---');
end;

If RadioButton8.Checked = true then begin
ListBox5.Items.Add('Шахматный режим');
ListBox5.Items.Add('---');
ListBox5.Items.Add('---');
ListBox5.Items.Add(Edit1.Text);
ListBox5.Items.Add(Edit9.Text);
end;

If RadioButton9.Checked = true then begin
ListBox5.Items.Add('Шахматный режим с конечной игрой');
ListBox5.Items.Add(Edit4.Text);
ListBox5.Items.Add(Edit5.Text);
ListBox5.Items.Add(Edit1.Text);
ListBox5.Items.Add(Edit9.Text);
end;

end;

procedure TForm1.Edit1KeyPress(Sender: TObject; var Key: Char);
begin
If not (Key in [#8, '0'..'9']) then key := #0;
end;

procedure TForm1.Edit6Change(Sender: TObject);
begin
g := StrToInt(Edit6.Text);
If g > 100 then begin g := 100 end;
Edit6.Text := IntToStr(g);
If g < 5 then begin  g := 5 end;
Edit6.Text := IntToStr(g);
end;

procedure TForm1.Edit2Change(Sender: TObject);
begin
g := StrToInt(Edit2.Text);
If g > 5 then begin g := 5 end;
Edit2.Text := IntToStr(g);
If g < 1 then begin  g := 1 end;
Edit2.Text := IntToStr(g);
end;

procedure TForm1.Edit7Change(Sender: TObject);
begin
g := StrToInt(Edit7.Text);
If g > 40 then begin g := 40 end;
Edit7.Text := IntToStr(g);
If g < 3 then begin  g := 3 end;
Edit7.Text := IntToStr(g);
end;

procedure TForm1.Edit4Change(Sender: TObject);
begin
g := StrToInt(Edit4.Text);
If g > 500 then begin g := 500 end;
Edit4.Text := IntToStr(g);
If g < 1 then begin  g := 1 end;
Edit4.Text := IntToStr(g);
end;

procedure TForm1.Edit5Change(Sender: TObject);
begin
g := StrToInt(Edit5.Text);
If g > 59 then begin g := 59 end;
Edit5.Text := IntToStr(g);
If g < 0 then begin  g := 0 end;
Edit5.Text := IntToStr(g);
end;

procedure TForm1.Edit3Change(Sender: TObject);
begin
g := StrToInt(Edit3.Text);
If g > 100 then begin g := 100 end;
Edit3.Text := IntToStr(g);
If g < 5 then begin  g := 5 end;
Edit3.Text := IntToStr(g);
end;

procedure TForm1.UpDown6Click(Sender: TObject; Button: TUDBtnType);
begin
BuiltPole(Image1, true, StrToInt(Edit3.Text), StrToInt(Edit6.Text),
Color1.Color, true, StrToInt(Edit7.Text), StrToInt(Edit2.Text), Panel17.Color);
end;

procedure TForm1.ListBox2Click(Sender: TObject);
var i : integer;
begin
for i := ListBox2.Items.Count - 1 downto 0 do
If ListBox2.Selected[i] then begin
ListBox8.Items.LoadFromFile('Игроки\' + ListBox2.Items[i] + '.igr');
end;
end;

procedure TForm1.FormKeyDown(Sender: TObject; var Key: Word;
  Shift: TShiftState);
begin
{ If Game.Visible = true then begin
  If kart <> nil then begin
   If Key = VK_RIGHT then begin
    If a <> p.goriz  then begin
    If Kart.Left + n <= p.KletkaSize * p.goriz then begin
     Kart.Left := Kart.Left + p.KletkaSize; a := a + 1;
     end;
    end;
   end;
   If Key = VK_Left then begin
     If a <> 1 then begin
      Kart.Left := Kart.Left - p.KletkaSize; a := a - 1;
     end;
   end;
   If Key = VK_Up then begin
    If b <> 1 then begin
     Kart.Top := Kart.Top - p.KletkaSize; b := b - 1;
    end;
   end;
   If Key = VK_Down then begin
    if b <> p.vert  then begin
    tpr := pole[b + 1, a + 1 ];
    if tpr.side = 0 then begin
    Kart.Top := Kart.Top + p.KletkaSize; b := b + 1;
    end;
    end;
   end;
   If Key = VK_Return then begin
    toc.Igrok := igr;
    toc.xcoor := a;
    toc.ycoor := b;
    toc.x := a * p.KletkaSize;
    toc.y := b * p.KletkaSize;
    toc.side := 1;
    pole[a, b] := toc;
   with stavt do begin
    Parent := Panel3;
    Left := toc.x - 5; Top := toc.y - 5;
    ClientWidth := 10; ClientHeight := 10;
    Name := 'Stavt';
    with Canvas do begin
    If Igr.ShowTocka = false then begin
    If Igr.ShowContur = true then begin
    pen.Color := RGB(13,124,43);
    Brush.Color := pen.Color;
    pen.Width := 1;
    Rectangle(0, 0, ClientWidth, ClientHeight);
    Pen.Color := igr.conturcolor;
    Pen.Width := p.LineWidth;
    Brush.Color := RGB(13,124,43);
    Brush.Style := bsClear;
    Ellipse(0, 0, ClientWidth, ClientHeight);
    end;
    end;
    If Igr.ShowTocka = true then begin
    If Igr.ShowContur = true then begin
    pen.Color := RGB(13,124,43);
    Brush.Color := pen.Color;
    pen.Width := 1;
    Rectangle(0, 0, ClientWidth, ClientHeight);
    Pen.Color := igr.conturcolor;
    Pen.Width := p.LineWidth;
    Brush.Color := Igr.color;
    Ellipse(0, 0, ClientWidth, ClientHeight);
    end;
    If Igr.ShowContur = false then begin
    pen.Color := RGB(13,124,43);
    Brush.Color := pen.Color;
    pen.Width := 1;
    Rectangle(0, 0, ClientWidth, ClientHeight);
    Pen.Color := Igr.color;
    Brush.Color := Igr.color;
    Pen.Width := p.LineWidth;
    Ellipse(0, 0, ClientWidth, ClientHeight);
    end;
    end;
   end;
   transparent := true;
  end;
 end;
end;
end; }
end;

procedure TForm1.Image5Click(Sender: TObject);
begin
form1.SetFocus;
Panel3.SetFocus;
end;

procedure TForm1.ScrollBar2KeyPress(Sender: TObject; var Key: Char);
begin
Key := #0;
end;

procedure TForm1.ScrollBar1KeyPress(Sender: TObject; var Key: Char);
begin
Key := #0;
end;

procedure TForm1.ListBox1Enter(Sender: TObject);
var i : integer;
begin
for i := ListBox1.Items.Count - 1 downto 0 do
 If ListBox1.Selected[i] then begin
 ListBox8.Items.LoadFromFile('Игроки\' + ListBox1.Items[i] + '.igr');
 If ListBox8.Items[0] = 'игрок' then begin
 igr.Prinad := Rasum;
 Image9.Picture.Bitmap.LoadFromFile('Разное\Игрок - Человек.bmp');
 end;
 If ListBox8.Items[0] = 'компьютер' then begin
 igr.Prinad := AI;
Image9.Picture.Bitmap.LoadFromFile('Разное\Игрок - Компьютер.bmp');
end;
Label13.Caption := ListBox8.Items[1];
igr.name := ListBox8.Items[1];
Panel14.Color := StrToInt(ListBox8.Items[2]);
igr.color := StrToInt(ListBox8.Items[2]);
If ListBox8.Items[3] = '0' then begin
Label40.Visible := true;
Panel4.Visible := false;
end else begin
Label40.Visible := false;
Panel4.Visible := true;
Panel4.Color := Panel14.Color;
end;
If ListBox8.Items[4] = '0' then begin
Label54.Visible := true;
Panel7.Visible := false;
end else begin
Label54.Visible := false;
Panel7.Visible := true;
Panel7.Color := StrToInt(ListBox8.Items[4]);
end;
If ListBox8.Items[6] = 'Нет залики' then begin
Panel22.Visible := false;
Image10.Visible := false;
end;
if ListBox8.Items[6] = 'Сплошной цвет' then begin
Panel22.Visible := true;
Image10.Visible := false;
Panel22.Color := StrToInt(ListBox8.Items[7]);
end;
If ListBox8.Items[6] = 'Заливка из линий' then begin
Panel22.Visible := true;
Image10.Visible := true;
Panel22.Color := StrToInt(ListBox8.Items[7]);
 If ListBox8.Items[8] = 'Горизонтальные линии'then begin
  Image10.Picture.Bitmap.LoadFromFile('Разное\Горизонтальные линии.bmp');
 end;
 If ListBox8.Items[8] = 'Вертикальные линии'then begin
  Image10.Picture.Bitmap.LoadFromFile('Разное\Вертикальные линии.bmp');
 end;
 If ListBox8.Items[8] = 'Диаг. вверх'then begin
  Image10.Picture.Bitmap.LoadFromFile('Разное\Диаг. вверх.bmp');
 end;
 If ListBox8.Items[8] = 'Диаг. вниз'then begin
  Image10.Picture.Bitmap.LoadFromFile('Разное\Диаг. вниз.bmp');
 end;
 If ListBox8.Items[8] = 'Решётка'then begin
  Image10.Picture.Bitmap.LoadFromFile('Разное\Решётка.bmp');
 end;
 If ListBox8.Items[8] = 'Косая решётка'then begin
  Image10.Picture.Bitmap.LoadFromFile('Разное\Косая решётка.bmp');
 end;
end;
Label47.Caption := ListBox8.Items[9];
end;
end;

procedure TForm1.Timer1Timer(Sender: TObject);
begin
qwe2 := qwe2 - 1;
s1 := s1 - 1;
If s1 = -1 then begin
s1 := 59;
m1 :=  m1 - 1;
end;
Edit10.Text := IntToStr(m1);
Edit11.Text := IntToStr(s1);
Gauge1.Progress := f - qwe2;
end;

procedure TForm1.Timer2Timer(Sender: TObject);
begin
qwe1 := qwe1 - 1;
s2 := s2 - 1;
If s2 = -1 then begin
s2 := 59;
m2 :=  m2 - 1;
end;
Edit14.Text := IntToStr(m2);
Edit15.Text := IntToStr(s2);
Gauge3.Progress :=  qwe1;
end;

procedure TForm1.Image5MouseDown(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin
toc.xcoor := po1.X div p.KletkaSize;
toc.ycoor := po1.Y div p.KletkaSize;
if pole[toc.xcoor, toc.ycoor].used <> true then begin
toc.used := true;
toc.active := true;
toc.begint := true;

if igr.focus = true then begin
igr.focus := false;
igr1.focus := true;
DrawTocka(igr, po1.X, po1.Y, Image5);
toc.Igrok := igr;

pole[po1.X div p.KletkaSize, po1.Y div p.KletkaSize] := toc;
CheckPoints(toc, Image5);
end else begin
igr1.focus := false;
igr.focus := true;
DrawTocka(igr1, po1.X, po1.Y, Image5);
toc.Igrok := igr1;

pole[po1.X div p.KletkaSize, po1.Y div p.KletkaSize] := toc;
CheckPoints(toc, Image5);
end;

end;
end;

end.



