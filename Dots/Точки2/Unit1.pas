unit Unit1;

interface

uses
  Windows, Messages, SysUtils, tocki2, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, Jpeg, GR32_Image, GR32, GR32_RotLayer, GR32_Filters, GR32_Layers, GR32_Resamplers,
  GR32_Transforms, StdCtrls, ExtCtrls,  ComCtrls, Keyboard2, Buttons;

type
  TForm1 = class(TForm)
    Image321: TImage32;
    Image322: TImage32;
    Image323: TImage32;
    Image324: TImage32;
    Image325: TImage32;
    Image326: TImage32;
    Background: TImage32;
    NewGame: TImage32;
    Label1: TLabel;
    ListBox1: TListBox;
    ListBox2: TListBox;
    Label2: TLabel;
    Label3: TLabel;
    Label4: TLabel;
    LoadGame: TImage32;
    Label5: TLabel;
    ListBox3: TListBox;
    Label6: TLabel;
    Label7: TLabel;
    poleset: TImage32;
    Label8: TLabel;
    ListBox4: TListBox;
    Image: TImage;
    Label10: TLabel;
    Label11: TLabel;
    Label12: TLabel;
    Label13: TLabel;
    Label14: TLabel;
    Label15: TLabel;
    Label16: TLabel;
    Edit1: TEdit;
    UpDown1: TUpDown;
    Edit2: TEdit;
    UpDown2: TUpDown;
    Panel1: TPanel;
    Panel2: TPanel;
    Edit3: TEdit;
    UpDown3: TUpDown;
    Edit4: TEdit;
    UpDown4: TUpDown;
    Edit5: TEdit;
    UpDown5: TUpDown;
    playerset: TImage32;
    Label18: TLabel;
    Label19: TLabel;
    Label20: TLabel;
    Label21: TLabel;
    ListBox5: TListBox;
    Edit6: TEdit;
    UpDown6: TUpDown;
    Panel3: TPanel;
    Panel4: TPanel;
    Label28: TLabel;
    Edit11: TEdit;
    UpDown11: TUpDown;
    Label29: TLabel;
    Panel5: TPanel;
    Label30: TLabel;
    Edit12: TEdit;
    UpDown12: TUpDown;
    Bevel1: TBevel;
    Label22: TLabel;
    CheckBox1: TCheckBox;
    Edit7: TEdit;
    Edit8: TEdit;
    Edit9: TEdit;
    Edit10: TEdit;
    Label23: TLabel;
    Label24: TLabel;
    Label25: TLabel;
    Label31: TLabel;
    Label32: TLabel;
    Edit13: TEdit;
    Label33: TLabel;
    Edit14: TEdit;
    Label57: TLabel;
    ListBox6: TListBox;
    Option: TImage32;
    Label82: TLabel;
    CheckBox2: TCheckBox;
    Label83: TLabel;
    Label84: TLabel;
    Label85: TLabel;
    Label86: TLabel;
    Edit15: TEdit;
    Edit16: TEdit;
    Edit17: TEdit;
    Edit18: TEdit;
    Label87: TLabel;
    Edit19: TEdit;
    Label88: TLabel;
    Edit20: TEdit;
    Label89: TLabel;
    Edit21: TEdit;
    CheckBox3: TCheckBox;
    CheckBox4: TCheckBox;
    About: TImage32;
    Label73: TLabel;
    Label74: TLabel;
    Label75: TLabel;
    Label76: TLabel;
    Label77: TLabel;
    Label78: TLabel;
    Label81: TLabel;
    Panel15: TPanel;
    Label80: TLabel;
    Label79: TLabel;
    Panel14: TPanel;
    Panel13: TPanel;
    Label61: TLabel;
    Label62: TLabel;
    Label63: TLabel;
    Label64: TLabel;
    Label65: TLabel;
    Label66: TLabel;
    Label67: TLabel;
    Label72: TLabel;
    Label71: TLabel;
    Label70: TLabel;
    Label69: TLabel;
    Panel12: TPanel;
    Label68: TLabel;
    Panel11: TPanel;
    Label51: TLabel;
    Label50: TLabel;
    Label49: TLabel;
    Label48: TLabel;
    Label47: TLabel;
    Label46: TLabel;
    Panel8: TPanel;
    Panel9: TPanel;
    Label52: TLabel;
    Label53: TLabel;
    Panel10: TPanel;
    Label54: TLabel;
    Label34: TLabel;
    Label35: TLabel;
    Label36: TLabel;
    Label37: TLabel;
    Label38: TLabel;
    Label39: TLabel;
    Label40: TLabel;
    Label44: TLabel;
    Label43: TLabel;
    Label42: TLabel;
    Panel7: TPanel;
    Label41: TLabel;
    Panel6: TPanel;
    ListBox7: TListBox;
    Label45: TLabel;
    Label90: TLabel;
    Label93: TLabel;
    ColorDialog1: TColorDialog;
    Label56: TLabel;
    Edit22: TEdit;
    Label58: TLabel;
    Edit23: TEdit;
    gPole: TImgView32;
    ImgView321: TImgView32;
    SpeedButton1: TSpeedButton;
    SpeedButton2: TSpeedButton;
    SpeedButton3: TSpeedButton;
    SpeedButton4: TSpeedButton;
    SpeedButton5: TSpeedButton;
    SpeedButton6: TSpeedButton;
    SpeedButton7: TSpeedButton;
    Image3217: TImage;
    Label26: TLabel;
    Image3218: TImage;
    Label27: TLabel;
    Image3214: TImage;
    Label95: TLabel;
    Image328: TImage;
    Label55: TLabel;
    Image3220: TImage;
    Label59: TLabel;
    Image3221: TImage;
    Label60: TLabel;
    Image3216: TImage;
    Label9: TLabel;
    Image3211: TImage;
    Label17: TLabel;
    Image3212: TImage;
    Label91: TLabel;
    SpeedButton8: TSpeedButton;
    SpeedButton9: TSpeedButton;
    SpeedButton10: TSpeedButton;
    SpeedButton11: TSpeedButton;
    SpeedButton12: TSpeedButton;
    SpeedButton13: TSpeedButton;
    Image1: TImage;
    Image2: TImage;
    Image3: TImage;
    Label92: TLabel;
    Image4: TImage;
    procedure FormCreate(Sender: TObject);
    procedure Image326Click(Sender: TObject);
    procedure ListBox1DblClick(Sender: TObject);
    procedure ListBox2DblClick(Sender: TObject);
    procedure ListBox2Enter(Sender: TObject);
    procedure ListBox6Enter(Sender: TObject);
    procedure ListBox4Enter(Sender: TObject);
    procedure ListBox6DblClick(Sender: TObject);
    procedure ListBox5Enter(Sender: TObject);
    procedure CheckBox1Click(Sender: TObject);
    procedure CheckBox2Click(Sender: TObject);
    procedure ListBox1Enter(Sender: TObject);
    procedure Edit5KeyPress(Sender: TObject; var Key: Char);
    procedure Panel1Click(Sender: TObject);
    procedure Panel2Click(Sender: TObject);
    procedure Panel3Click(Sender: TObject);
    procedure Panel4Click(Sender: TObject);
    procedure Panel5Click(Sender: TObject);
    procedure Image327Click(Sender: TObject);
    procedure Edit6KeyPress(Sender: TObject; var Key: Char);
    procedure Edit2Exit(Sender: TObject);
    procedure Edit3Exit(Sender: TObject);
    procedure Edit6Exit(Sender: TObject);
    procedure Edit11Exit(Sender: TObject);
    procedure Edit12Exit(Sender: TObject);
    procedure Edit4Exit(Sender: TObject);
    procedure Edit5Exit(Sender: TObject);
    procedure Edit1Exit(Sender: TObject);
    procedure Image3217Click(Sender: TObject);
    procedure Image3214Click(Sender: TObject);
    procedure Image3210Click(Sender: TObject);
    procedure Image329Click(Sender: TObject);
    procedure Image3212Click(Sender: TObject);
    procedure Image3219Click(Sender: TObject);
    procedure Image3216Click(Sender: TObject);
    procedure Image3220Click(Sender: TObject);
    procedure Image328Click(Sender: TObject);
    procedure Image3218Click(Sender: TObject);
    procedure Image3211Click(Sender: TObject);
    procedure Image321Click(Sender: TObject);
    procedure Image323Click(Sender: TObject);
    procedure Image322Click(Sender: TObject);
    procedure ListBox7Enter(Sender: TObject);
    procedure ListBox3Click(Sender: TObject);
    procedure Image3221Click(Sender: TObject);
    procedure gPoleMouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer; Layer: TCustomLayer);
    procedure gPoleMouseMove(Sender: TObject; Shift: TShiftState; X,
      Y: Integer; Layer: TCustomLayer);
    procedure BackgroundMouseMove(Sender: TObject; Shift: TShiftState; X,
      Y: Integer; Layer: TCustomLayer);
    procedure SpeedButton1Click(Sender: TObject);
    procedure SpeedButton2Click(Sender: TObject);
    procedure SpeedButton3Click(Sender: TObject);
    procedure SpeedButton4Click(Sender: TObject);
    procedure SpeedButton5Click(Sender: TObject);
    procedure SpeedButton6Click(Sender: TObject);
    procedure SpeedButton7Click(Sender: TObject);
    procedure SpeedButton12Click(Sender: TObject);
    procedure SpeedButton10Click(Sender: TObject);
    procedure SpeedButton11Click(Sender: TObject);
    procedure SpeedButton13Click(Sender: TObject);
    procedure BackgroundMouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer; Layer: TCustomLayer);
    procedure SpeedButton9Click(Sender: TObject);
    procedure Image3Click(Sender: TObject);
    procedure Image324Click(Sender: TObject);
    procedure Image325Click(Sender: TObject);
    procedure Image4Click(Sender: TObject);
    procedure gPoleMouseWheelUp(Sender: TObject; Shift: TShiftState;
      MousePos: TPoint; var Handled: Boolean);
    procedure gPoleMouseWheel(Sender: TObject; Shift: TShiftState;
      WheelDelta: Integer; MousePos: TPoint; var Handled: Boolean);
    procedure gPoleScroll(Sender: TObject);
    procedure FormKeyDown(Sender: TObject; var Key: Word;
      Shift: TShiftState);
    procedure gPoleKeyDown(Sender: TObject; var Key: Word;
      Shift: TShiftState);
    procedure CheckBox4Click(Sender: TObject);
  private
    procedure LoadPanel(number: byte);
    procedure RepaintButton(number : byte);
    procedure StayPanel(image : TImage32);
    procedure LoadFiles(filei : string; ListBox : TListBox);
    procedure Perem(InListBox, OutListBox : TListBox);
    procedure EditChange(min, max : integer; edit : TEdit);
    function AssignKey(var edit : TEdit) : integer;
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  tcursor : TRotLayer;
  Pole : TPole;
  GamePole, GamePole1 : TGamePole;
  Players : TPlayers;
  GameTocki : TGameTocki;
  p, p1, mp : TPoint;
implementation

{$R *.dfm}

function TForm1.AssignKey(var edit : TEdit) : integer;
label 1;
var i : integer;
begin
edit.SetFocus;
1:
for i := 0 to 300 do begin
if IsKeyDown(i) = true then begin
edit.Text := VirtualKeyCodeToKeyName(i);
result := i;
exit;
end;
end;
goto 1;
end;

procedure TForm1.EditChange(min, max : integer; edit : TEdit);
var g : integer;
begin
if edit.Text <> '' then begin
g := StrToInt(Edit.Text);
If g > max then Edit.Text := IntToStr(max);
If g < min then Edit.Text := IntToStr(min);
end else edit.Text := IntToStr(min);
end;

procedure TForm1.Perem(InListBox, OutListBox : TListBox);
var i : byte;
begin
for i := OutListBox.Items.Count - 1 downto 0 do
If OutListBox.Selected[i] then begin
InListBox.Items.Add(OutListBox.Items[i]);
OutListBox.Items.Delete(i);
end;
end;

procedure TForm1.LoadFiles(filei : string; ListBox : TListBox);
var tsr : TSearchRec;
begin
ListBox.Clear;
if FindFirst(fileI, faAnyFile, tsr) = 0 then
repeat
ListBox.Items.add(GetFileName(tsr.name));
until FindNext(tsr) <> 0;
FindClose(tsr);
end;

procedure TForm1.StayPanel(image : TImage32);
begin
image.Left := 88;
image.Top := 8;
image.ClientWidth := 513;
image.ClientHeight := 681;
end;

procedure TForm1.LoadPanel(number: byte);
begin
NewGame.Visible := false;
LoadGame.Visible := false;
Option.Visible := false;
playerset.Visible :=false;
poleset.Visible := false;
About.Visible := false;
gpole.Visible := false;
if number = 0 then begin
NewGame.Visible := true;
end;
if number = 1 then begin
LoadGame.Visible := true;
end;
if number = 2 then begin
Option.Visible := true;
end;
if number = 3 then begin
playerset.Visible := true;
end;
if number = 4 then begin
poleset.Visible := true;
end;
if number = 5 then begin
About.Visible := true;
end;
if number = 6 then begin
gpole.Visible := true;
end;
end;

procedure TForm1.RepaintButton(number : byte);
var a : byte;
begin
a := 15;
Image321.Left := 576;
Image322.Left := 576;
Image323.Left := 576;
Image324.Left := 576;
Image325.Left := 576;
Image326.Left := 576;
if number = 0 then
Image321.Left := Image321.Left + a;
if number = 1 then
Image322.Left := Image322.Left + a;
if number = 2 then
Image323.Left := Image323.Left + a;
if number = 3 then
Image324.Left := Image324.Left + a;
if number = 4 then
Image325.Left := Image325.Left + a;
if number = 5 then
Image326.Left := Image326.Left + a;
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
gpole.Cursor := crNone;
Background.Bitmap.LoadFromFile('Ресурсы\Фон.jpg');
Image321.Bitmap.LoadFromFile('Ресурсы\Новая игра.jpg');
Image322.Bitmap.LoadFromFile('Ресурсы\Сохранить.jpg');
Image323.Bitmap.LoadFromFile('Ресурсы\Загрузить.jpg');
Image324.Bitmap.LoadFromFile('Ресурсы\Опции.jpg');
Image325.Bitmap.LoadFromFile('Ресурсы\Авторы.jpg');
Image326.Bitmap.LoadFromFile('Ресурсы\Выход.jpg');
NewGame.Bitmap.LoadFromFile('Ресурсы\Листочек.jpg');
LoadGame.Bitmap.LoadFromFile('Ресурсы\Листочек.jpg');
Option.Bitmap.LoadFromFile('Ресурсы\Листочек.jpg');
playerset.Bitmap.LoadFromFile('Ресурсы\Листочек.jpg');
poleset.Bitmap.LoadFromFile('Ресурсы\Листочек.jpg');
About.Bitmap.LoadFromFile('Ресурсы\Листочек.jpg');
StayPanel(NewGame);
StayPanel(LoadGame);
StayPanel(Option);
StayPanel(playerset);
StayPanel(poleset);
StayPanel(About);
gpole.Left := 88;
gpole.Top := 8;
gpole.ClientWidth := 513;
gpole.ClientHeight := 681;
LoadPanel(6);
Label60.Font.Color := clInfoBk;
Label60.Font.Style := [fsUnderline];
GameTocki := TGameTocki.Create();
GamePole := TGamePole.Create();
GamePole1 := TGamePole.Create();
GameTocki.LoadFromFile('Options');
GPOLE.Visible := FALSE;
end;

procedure TForm1.Image326Click(Sender: TObject);
begin
RepaintButton(5);
GameTocki.SaveToFile('Options');
Close;
end;

procedure TForm1.ListBox1DblClick(Sender: TObject);
begin
Perem(ListBox2, ListBox1);
if (ListBox1.items.Count < 2) or (Label57.Caption = '') then begin
Label60.Font.Color := clInfoBk;
Label60.Font.Style := [fsUnderline];
end else begin
Label60.Font.Color := clRed;
Label60.Font.Style := [fsBold];
end;
end;

procedure TForm1.ListBox2DblClick(Sender: TObject);
begin
if ListBox1.Items.Count < 5 then
Perem(ListBox1, ListBox2);
if (ListBox1.items.Count < 2) or (Label57.Caption = '') then begin
Label60.Font.Color := clInfoBk;
Label60.Font.Style := [fsUnderline];
end else begin
Label60.Font.Color := clRed;
Label60.Font.Style := [fsBold];
end;
end;

procedure TForm1.ListBox2Enter(Sender: TObject);
var i : byte;
player : TPlayer;
begin
if ListBox2.Items.Count > 0 then
for i := ListBox2.Items.Count - 1 downto 0 do begin
If ListBox2.Selected[i] then begin
player := TPlayer.Create;
player.LoadPlayer('Игроки\', ListBox2.Items[i]);
Panel8.Color := WinColor(player.Color);
Panel9.Color := WinColor(player.ConturColor);
Label52.Caption := IntToStr(AlphaComponent(player.Color));
Label53.Caption := IntToStr(AlphaComponent(player.ConturColor));
Panel10.Color := WinColor(player.FillColor);
Label54.Caption := IntToStr(AlphaComponent(player.FillColor));
end;
end;
end;

procedure TForm1.ListBox6Enter(Sender: TObject);
var i : byte;
pole : TPole;
begin
if ListBox6.Items.Count > 0 then
for i := ListBox6.Items.Count - 1 downto 0 do begin
If ListBox6.Selected[i] then begin
pole := TPole.Create;
pole.LoadPole('Поля\', ListBox6.Items[i]);
Panel6.Color := WinColor(pole.Color);
Label41.Caption := IntToStr(AlphaComponent(pole.Color));
Panel7.Color := WinColor(pole.LineColor);
Label42.Caption := IntToStr(pole.LineWidth);
Label43.Caption := IntToStr(pole.KletkaSize);
Label44.Caption := IntToStr(pole.Size.x);
Label90.Caption := IntToStr(pole.Size.y);
end;
end;
end;

procedure TForm1.ListBox4Enter(Sender: TObject);
var i : byte;
pole : TPole;
begin
if ListBox4.Items.Count > 0 then
for i := ListBox4.Items.Count - 1 downto 0 do begin
If ListBox4.Selected[i] then begin
pole := TPole.Create;
pole.LoadPole('Поля\', ListBox4.Items[i]);
Edit23.Text := ListBox4.Items[i];
Panel1.Color := WinColor(pole.Color);
Edit1.text := IntToStr(AlphaComponent(pole.Color));
Panel2.Color := WinColor(pole.LineColor);
Edit2.text := IntToStr(pole.LineWidth);
Edit3.text := IntToStr(pole.KletkaSize);
Edit4.text := IntToStr(pole.Size.x);
Edit5.text := IntToStr(pole.Size.y);
end;
end;
end;

procedure TForm1.ListBox6DblClick(Sender: TObject);
var i : byte;
begin
for i := ListBox6.Items.Count - 1 downto 0 do begin
If ListBox6.Selected[i] then
Label57.Caption := ListBox6.Items[i]
end;
if (ListBox1.items.Count < 2) or (Label57.Caption = '') then begin
Label60.Font.Color := clInfoBk;
Label60.Font.Style := [fsUnderline];
end else begin
Label60.Font.Color := clRed;
Label60.Font.Style := [fsBold];
end;
end;

procedure TForm1.ListBox5Enter(Sender: TObject);
var i : byte;
player : TPlayer;
begin
if ListBox5.Items.Count > 0 then
for i := ListBox5.Items.Count - 1 downto 0 do begin
If ListBox5.Selected[i] then begin
player := TPlayer.Create;
player.LoadPlayer('Игроки\', ListBox5.Items[i]);
Edit22.Text := ListBox5.Items[i];
Panel3.Color := WinColor(player.Color);
Panel4.Color := WinColor(player.ConturColor);
Edit6.Text := IntToStr(AlphaComponent(player.Color));
Edit11.Text := IntToStr(AlphaComponent(player.ConturColor));
Panel5.Color := WinColor(player.FillColor);
Edit12.Text := IntToStr(AlphaComponent(player.FillColor));
CheckBox1.Checked := player.Mouse;
Edit8.Text := VirtualKeyCodeToKeyName(player.MoveUp);
Edit7.Text := VirtualKeyCodeToKeyName(player.MoveDown);
Edit10.Text := VirtualKeyCodeToKeyName(player.MoveLeft);
Edit9.Text := VirtualKeyCodeToKeyName(player.MoveRight);
Edit13.Text := VirtualKeyCodeToKeyName(player.Enter);
Edit14.Text := VirtualKeyCodeToKeyName(player.Obvodka);
end;
end;
end;

procedure TForm1.CheckBox1Click(Sender: TObject);
begin
{if CheckBox1.Checked = true then begin
Edit7.Enabled := false;
Edit8.Enabled := false;
Edit9.Enabled := false;
Edit10.Enabled := false;
Edit13.Enabled := false;
Edit14.Enabled := false;
end else begin
Edit7.Enabled := true;
Edit8.Enabled := true;
Edit9.Enabled := true;
Edit10.Enabled := true;
Edit13.Enabled := true;
Edit14.Enabled := true;
end;   }
end;

procedure TForm1.CheckBox2Click(Sender: TObject);
begin
gametocki.mouse := CheckBox2.Checked;
{if CheckBox2.Checked = true then begin
Edit15.Enabled := false;
Edit16.Enabled := false;
Edit17.Enabled := false;
Edit18.Enabled := false;
Edit19.Enabled := false;
Edit20.Enabled := false;
Edit21.Enabled := false;
end else begin
Edit15.Enabled := true;
Edit16.Enabled := true;
Edit17.Enabled := true;
Edit18.Enabled := true;
Edit19.Enabled := true;
Edit20.Enabled := true;
Edit21.Enabled := true;
end;   }
end;

procedure TForm1.ListBox1Enter(Sender: TObject);
var i : byte;
player : TPlayer;
begin
if ListBox1.Items.Count > 0 then
for i := ListBox1.Items.Count - 1 downto 0 do begin
If ListBox1.Selected[i] then begin
player := TPlayer.Create;
player.LoadPlayer('Игроки\',ListBox1.Items[i]);
Panel8.Color := WinColor(player.Color);
Panel9.Color := WinColor(player.ConturColor);
Label52.Caption := IntToStr(AlphaComponent(player.Color));
Label53.Caption := IntToStr(AlphaComponent(player.ConturColor));
Panel10.Color := WinColor(player.FillColor);
Label54.Caption := IntToStr(AlphaComponent(player.FillColor));
end;
end;
end;

procedure TForm1.Edit5KeyPress(Sender: TObject; var Key: Char);
begin
If not (Key in [#8, '0'..'9']) then key := #0;
end;

procedure TForm1.Panel1Click(Sender: TObject);
begin
If ColorDialog1.Execute then
Panel1.Color := ColorDialog1.Color;
end;

procedure TForm1.Panel2Click(Sender: TObject);
begin
If ColorDialog1.Execute then
Panel2.Color := ColorDialog1.Color;
end;

procedure TForm1.Panel3Click(Sender: TObject);
begin
If ColorDialog1.Execute then
Panel3.Color := ColorDialog1.Color;
end;

procedure TForm1.Panel4Click(Sender: TObject);
begin
If ColorDialog1.Execute then
Panel4.Color := ColorDialog1.Color;
end;

procedure TForm1.Panel5Click(Sender: TObject);
begin
If ColorDialog1.Execute then
Panel5.Color := ColorDialog1.Color;
end;

procedure TForm1.Image327Click(Sender: TObject);
begin
LoadPanel(3);
end;

procedure TForm1.Edit6KeyPress(Sender: TObject; var Key: Char);
begin
If not (Key in [#8, '0'..'9']) then key := #0;
end;

procedure TForm1.Edit2Exit(Sender: TObject);
begin
EditChange(1, 10, Edit2);
end;

procedure TForm1.Edit3Exit(Sender: TObject);
begin
EditChange(5, 30, Edit3);
end;

procedure TForm1.Edit6Exit(Sender: TObject);
begin
EditChange(20, 255, Edit6);
end;

procedure TForm1.Edit11Exit(Sender: TObject);
begin
EditChange(20, 255, Edit11);
end;

procedure TForm1.Edit12Exit(Sender: TObject);
begin
EditChange(20, 255, Edit12);
end;

procedure TForm1.Edit4Exit(Sender: TObject);
begin
EditChange(5, 500, Edit5);
end;

procedure TForm1.Edit5Exit(Sender: TObject);
begin
EditChange(5, 500, Edit4);
end;

procedure TForm1.Edit1Exit(Sender: TObject);
begin
EditChange(20, 255, Edit1);
end;

procedure TForm1.Image3217Click(Sender: TObject);
var name : string;
player : TPlayer;
b : boolean;
begin
name :='Безымянный';
b := inputQuery('', 'Введите имя игрока', name);
if b = true then begin
if ListBox5.Items.IndexOf(name) = -1 then begin
ListBox5.Items.Add(name);
player := TPlayer.Create(name, clBlue32, clBlue32, 255, 255, clBlue32, 255, true, 38, 40, 37, 39, 13, 17);
ListBox5.Selected[ListBox5.Items.IndexOf(name)] := true;
Panel3.Color := WinColor(player.Color);
Panel4.Color := WinColor(player.ConturColor);
Edit6.Text := IntToStr(AlphaComponent(player.Color));
Edit11.Text := IntToStr(AlphaComponent(player.ConturColor));
Panel5.Color := WinColor(player.FillColor);
Edit12.Text := IntToStr(AlphaComponent(player.FillColor));
player.SavePlayer('Игроки\');
end else
ShowMessage('Такой игрок уже существует!');
end;
end;

procedure TForm1.Image3214Click(Sender: TObject);
var i : byte;
rez: TModalResult;
begin
rez := MessageDlg('Вы действительно хотите удалить этого игрока?'#10#13,
mtWarning,[mbYes, mbNo], 0);
If rez = mrYes then begin
for i := ListBox5.Items.Count - 1 downto 0 do begin
If ListBox5.Selected[i] then begin
DeleteFile('Игроки\' + ListBox5.items[i] + '.player');
ListBox5.items.delete(i);
end;
end;
end else ListBox5.SetFocus;
end;

procedure TForm1.Image3210Click(Sender: TObject);
var i : byte;
rez: TModalResult;
begin
rez := MessageDlg('Вы действительно хотите удалить этого игрока?'#10#13,
mtWarning,[mbYes, mbNo], 0);
If rez = mrYes then begin
for i := ListBox2.Items.Count - 1 downto 0 do begin
If ListBox2.Selected[i] then begin
DeleteFile('Игроки\' + ListBox2.items[i] + '.player');
ListBox2.items.delete(i);
end;
end;
end else ListBox2.SetFocus;
end;

procedure TForm1.Image329Click(Sender: TObject);
var i : byte;
rez: TModalResult;
begin
rez := MessageDlg('Вы действительно хотите удалить это поле?'#10#13,
mtWarning,[mbYes, mbNo], 0);
If rez = mrYes then begin
for i := ListBox6.Items.Count - 1 downto 0 do begin
If ListBox6.Selected[i] then begin
DeleteFile('Поля\' + ListBox6.items[i] + '.pole');
ListBox6.items.delete(i);
end;
end;
end else ListBox6.SetFocus;
end;

procedure TForm1.Image3212Click(Sender: TObject);
var i : byte;
rez: TModalResult;
begin
rez := MessageDlg('Вы действительно хотите удалить это поле?'#10#13,
mtWarning,[mbYes, mbNo], 0);
If rez = mrYes then begin
for i := ListBox4.Items.Count - 1 downto 0 do begin
If ListBox4.Selected[i] then begin
DeleteFile('Поля\' + ListBox4.items[i] + '.pole');
ListBox4.items.delete(i);
end;
end;
end else ListBox4.SetFocus;
end;

procedure TForm1.Image3219Click(Sender: TObject);
begin
LoadPanel(4);
end;

procedure TForm1.Image3216Click(Sender: TObject);
var 
pole : Tpole;
b : boolean;
name : string;
begin
name := 'Безымянное';
b := inputQuery('', 'Введите имя поля', name);
if b = true then begin
if ListBox4.Items.IndexOf(name) = -1 then begin
pole := TPole.Create(name, clWhite32, clBlack32, 255, 1, 15, MakeSize(50, 50));
ListBox4.Items.Add(name);
ListBox4.Selected[ListBox4.Items.IndexOf(name)] := true;
Panel1.Color := WinColor(pole.Color);
Edit1.text := IntToStr(AlphaComponent(pole.Color));
Panel2.Color := WinColor(pole.LineColor);
Edit2.text := IntToStr(pole.LineWidth);
Edit3.text := IntToStr(pole.KletkaSize);
Edit4.text := IntToStr(pole.Size.x);
Edit5.text := IntToStr(pole.Size.y);
pole.SavePole('Поля\');
end else ShowMessage('Такое поле уже есть!');
end;
end;

procedure TForm1.Image3220Click(Sender: TObject);
begin
LoadPanel(4);
LoadFiles('Поля\*.pole', ListBox4);
end;

procedure TForm1.Image328Click(Sender: TObject);
begin
LoadPanel(3);
LoadFiles('Игроки\*.player', ListBox5);
end;

procedure TForm1.Image3218Click(Sender: TObject);
var i : byte;
player : TPlayer;
begin
for i := ListBox5.Items.Count - 1 downto 0 do begin
If ListBox5.Selected[i] then begin
player := TPlayer.Create(Edit22.Text, Color32(panel3.Color), Color32(Panel4.Color),
StrToInt(Edit6.Text), StrToInt(Edit11.Text), Color32(panel5.Color), StrToInt(Edit12.Text), CheckBox1.Checked,
KeyNameToVirtualKeyCode(Edit8.Text), KeyNameToVirtualKeyCode(Edit7.Text), KeyNameToVirtualKeyCode(Edit10.Text),
KeyNameToVirtualKeyCode(Edit9.Text), KeyNameToVirtualKeyCode(Edit13.Text), KeyNameToVirtualKeyCode(Edit14.Text));
player.SavePlayer('Игроки\');
LoadFiles('Игроки\*.player', ListBox5);
//ListBox5.Selected[ListBox5.Items.IndexOf(name)] := true;
end;
end;
end;

procedure TForm1.Image3211Click(Sender: TObject);
var i : byte;
pole : Tpole;
begin
for i := ListBox4.Items.Count - 1 downto 0 do begin
If ListBox4.Selected[i] then begin
pole := TPole.Create(Edit23.Text, Color32(panel1.Color), Color32(Panel2.Color),
StrToInt(Edit1.Text), StrToInt(Edit2.Text), StrToInt(Edit3.Text), MakeSize(StrToInt(edit4.Text), StrToInt(edit5.Text)));
pole.SavePole('Поля\');
LoadFiles('Поля\*.pole', ListBox4);
//ListBox4.Selected[ListBox4.Items.IndexOf(name)] := true;
end;
end;
end;

procedure TForm1.Image321Click(Sender: TObject);
begin
ListBox1.Clear;
ListBox2.Clear;
ListBox6.Clear;
LoadFiles('Игроки\*.player', ListBox2);
LoadFiles('Поля\*.pole', ListBox6);
RepaintButton(0);
LoadPanel(0);
end;

procedure TForm1.Image323Click(Sender: TObject);
begin
RepaintButton(2);
LoadPanel(1);
LoadFiles('Игроки\*.player', ListBox2);
LoadFiles('Поля\*.pole', ListBox6);
LoadFiles('Поля\*.pole', ListBox4);
LoadFiles('Игры\*.tocki', ListBox7);
LoadFiles('Игроки\*.player', ListBox5);
end;

procedure TForm1.Image322Click(Sender: TObject);
var b : boolean;
st : string;
rez : TModalResult;
begin
st := 'Безымянная';
RepaintButton(1);
LoadFiles('Игры\*.tocki', ListBox7);
if gamepole.Canvas <> nil then begin
b := InputQuery('Введите имя сохраняемой игры', '', st);
if b = true then begin
if ListBox7.Items.IndexOf(st) = -1 then
gamepole.SaveGamePole('Игры\' + st)
else begin
rez := MessageDlg('Такая игра уже существует! перезаписать?'#10#13,
mtWarning,[mbYes, mbNo], 0);
If rez = mrYes then
gamepole.SaveGamePole('Игры\' + st) else gpole.SetFocus;
end;
end;
end;

end;

procedure TForm1.ListBox7Enter(Sender: TObject);
var i, i1 : byte;
begin
ListBox3.Clear;
if ListBox7.Items.Count > 0 then
for i := ListBox7.Items.Count - 1 downto 0 do begin
If ListBox7.Selected[i] then begin

//ImgView321.SetupBitmap();
GamePole1 := TGamePole.Create;
GamePole1.LoadGamePole(ImgView321, 'Игры\' + ListBox7.Items[i]);
gametocki.GamePole := GamePole1;
gametocki.Image(ImgView321);
GamePole1.UpdatePole;
ImgView321.Color := WinColor(GamePole1.pole.Color);
ImgView321.ScrollBars.Increment := GamePole1.pole.KletkaSize;

for i1 := 0 to high(GamePole1.players) do
ListBox3.Items.Add(GamePole1.players[i1].Name);
label93.Caption := GamePole1.Pole.Name;

Edit23.Text := GamePole1.Pole.Name;
Panel11.Color := WinColor(GamePole1.pole.Color);
Label68.Caption := IntToStr(AlphaComponent(GamePole1.pole.Color));
Panel12.Color := WinColor(GamePole1.pole.LineColor);
Label69.Caption := IntToStr(GamePole1.pole.LineWidth);
Label70.Caption := IntToStr(GamePole1.pole.KletkaSize);
Label71.Caption := IntToStr(GamePole1.pole.Size.x);
Label72.Caption := IntToStr(GamePole1.pole.Size.y);
end;
end;
end;

procedure TForm1.ListBox3Click(Sender: TObject);
var i : byte;
player : TPlayer;
begin
if ListBox3.Items.Count > 0 then
for i := ListBox3.Items.Count - 1 downto 0 do begin
If ListBox3.Selected[i] then begin
player := TPlayer.Create;
player.LoadPlayer('Игроки\', ListBox3.Items[i]);
Panel13.Color := WinColor(player.Color);
Panel14.Color := WinColor(player.ConturColor);
Label79.Caption := IntToStr(AlphaComponent(player.Color));
Label80.Caption := IntToStr(AlphaComponent(player.ConturColor));
Panel15.Color := WinColor(player.FillColor);
Label81.Caption := IntToStr(AlphaComponent(player.FillColor));
end;
end;
end;

procedure TForm1.Image3221Click(Sender: TObject);
var i : byte;
begin
if (ListBox1.items.Count >= 2) and (Label57.Caption <> '') then begin
pole := TPole.Create;
pole.LoadPole('Поля\', Label57.caption);
SetLength(players, ListBox1.Items.Count);
for i := 0 to ListBox1.Items.Count - 1 do begin
players[i] := TPlayer.Create;
players[i].LoadPlayer('Игроки\', ListBox1.Items[i]);
end;

gamePole := TGamePole.Create(gpole, MakeSize(gpole.Width, gpole.Height), pole, nil,
players, 0, gametocki.snap, gametocki.aob);
gametocki.GamePole := gamepole;
gametocki.Image(gpole);
gametocki.GamePole.Pos := Make2dpos(gpole.OffsetHorz, gpole.offsetVert);

gpole.Color := WinColor(pole.Color);
gpole.ScrollBars.Increment := pole.KletkaSize;

LoadPanel(6);
gamepole.UpdatePole;
gpole.SetFocus;
end;
end;

procedure TForm1.gPoleMouseDown(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer; Layer: TCustomLayer);
begin
GameTocki.OnMouseDown(x, y, Button);
mp.X := x;
mp.Y := y;

end;

procedure TForm1.gPoleMouseMove(Sender: TObject; Shift: TShiftState; X,
  Y: Integer; Layer: TCustomLayer);
begin
gameTocki.OnMouseMove(x, y);
if gameTocki.mouse = true then begin
if shift = [ssMiddle] then begin
gpole.Scroll((x-mp.X)div gametocki.GamePole.Pole.KletkaSize, (y-mp.Y)div gametocki.GamePole.Pole.KletkaSize);
end;
end;

end;

procedure TForm1.BackgroundMouseMove(Sender: TObject; Shift: TShiftState;
  X, Y: Integer; Layer: TCustomLayer);
begin
if shift = [ssLeft] then begin
GetCursorPos(p1);
Form1.Left := p1.x - p.x;
Form1.Top := p1.y - p.y;
end;
end;

procedure TForm1.SpeedButton1Click(Sender: TObject);
begin
gametocki.ScrollUp := AssignKey(Edit15);
end;

procedure TForm1.SpeedButton2Click(Sender: TObject);
begin
gametocki.ScrollDown := AssignKey(Edit16);
end;

procedure TForm1.SpeedButton3Click(Sender: TObject);
begin
gametocki.ScrollLeft := AssignKey(Edit17);
end;

procedure TForm1.SpeedButton4Click(Sender: TObject);
begin
gametocki.ScrollRight := AssignKey(Edit18);
end;

procedure TForm1.SpeedButton5Click(Sender: TObject);
begin
gametocki.ZoomIn := AssignKey(Edit19);
end;

procedure TForm1.SpeedButton6Click(Sender: TObject);
begin
gametocki.ZoomOut := AssignKey(Edit20);
end;

procedure TForm1.SpeedButton7Click(Sender: TObject);
begin
gametocki.NextPlayer := AssignKey(Edit21);
end;

procedure TForm1.SpeedButton12Click(Sender: TObject);
begin
AssignKey(Edit8);
end;

procedure TForm1.SpeedButton10Click(Sender: TObject);
begin
AssignKey(Edit7);
end;

procedure TForm1.SpeedButton11Click(Sender: TObject);
begin
AssignKey(Edit9);
end;

procedure TForm1.SpeedButton13Click(Sender: TObject);
begin
AssignKey(Edit10);
end;

procedure TForm1.BackgroundMouseDown(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer; Layer: TCustomLayer);
begin
p.x := x;
p.Y := Y;
end;

procedure TForm1.SpeedButton9Click(Sender: TObject);
begin
AssignKey(Edit14);
end;

procedure TForm1.Image3Click(Sender: TObject);
var i : byte;
begin
for i := 0 to ListBox7.Items.Count - 1 do begin
if ListBox7.Selected[i] then begin
//if gamepole <> nil then gamepole.Destroy;
gpole.SetupBitmap();
gamepole := TGamePole.Create();
gamepole.LoadGamePole(gpole, 'Игры\' + ListBox7.Items[i]);
gametocki.GamePole := gamepole;
gametocki.Image(gpole);

gamepole.UpdatePole;

gpole.Color := WinColor(gamepole.pole.Color);
gpole.ScrollBars.Increment := gamepole.pole.KletkaSize;
gametocki.GamePole.Pos := Make2dpos(gpole.OffsetHorz, gpole.offsetVert);

gamepole.UpdatePole;
gamepole.DrawCursor;
LoadPanel(6);
gpole.SetFocus;
end;
end;
end;

procedure TForm1.Image324Click(Sender: TObject);
begin
CheckBox2.Checked := gametocki.mouse;
CheckBox3.Checked := gametocki.Aob;
CheckBox4.Checked := gametocki.Snap;
Edit15.Text := VirtualKeyCodeToKeyName(gametocki.ScrollUp);
Edit16.Text := VirtualKeyCodeToKeyName(gametocki.ScrollDown);
Edit17.Text := VirtualKeyCodeToKeyName(gametocki.Scrollleft);
Edit18.Text := VirtualKeyCodeToKeyName(gametocki.ScrollRight);
Edit19.Text := VirtualKeyCodeToKeyName(gametocki.ZoomIn);
Edit20.Text := VirtualKeyCodeToKeyName(gametocki.ZoomOut);
Edit21.Text := VirtualKeyCodeToKeyName(gametocki.NextPlayer);
RepaintButton(3);
LoadPanel(2);
end;

procedure TForm1.Image325Click(Sender: TObject);
begin
RepaintButton(4);
LoadPanel(5);
end;

procedure TForm1.Image4Click(Sender: TObject);
var i : byte;
rez: TModalResult;
begin
rez := MessageDlg('Вы действительно хотите удалить эту игру?'#10#13,
mtWarning,[mbYes, mbNo], 0);
If rez = mrYes then begin
for i := ListBox7.Items.Count - 1 downto 0 do begin
If ListBox7.Selected[i] then begin
if gamepole <> nil then
gamepole.Destroy;
DeleteFile('Игры\' + ListBox7.items[i] + '.tocki');
ListBox7.items.delete(i);
{if ListBox7.items.count > 0 then
ListBox7.Selected[0] := true else} ImgView321.Bitmap.Clear($ffffff);
ListBox3.Clear;
end;
end;
end else ListBox7.SetFocus;
end;

procedure TForm1.gPoleMouseWheelUp(Sender: TObject; Shift: TShiftState;
  MousePos: TPoint; var Handled: Boolean);
begin
if gamepole <> nil then begin
if gametocki.mouse = true then begin
if gametocki.GamePole.Pole.KletkaSize < 100 then
gametocki.GamePole.Pole.KletkaSize := gametocki.GamePole.Pole.KletkaSize+1;
gametocki.GamePole.Pole.GetWidthAndHeight;
gametocki.GamePole.UpdatePole;
end;
end;
end;

procedure TForm1.gPoleMouseWheel(Sender: TObject; Shift: TShiftState;
  WheelDelta: Integer; MousePos: TPoint; var Handled: Boolean);
begin
if gamepole <> nil then begin
if gametocki.mouse = true then begin
if gametocki.GamePole.Pole.KletkaSize > 1 then
gametocki.GamePole.Pole.KletkaSize := gametocki.GamePole.Pole.KletkaSize-1;
gametocki.GamePole.Pole.GetWidthAndHeight;
gametocki.GamePole.UpdatePole;
end;
end;
end;

procedure TForm1.gPoleScroll(Sender: TObject);
begin
gametocki.GamePole.Pos := Make2dpos(gpole.OffsetHorz, gpole.offsetVert);gpole.SetFocus;
end;

procedure TForm1.FormKeyDown(Sender: TObject; var Key: Word;
  Shift: TShiftState);
begin
gametocki.OnKeyDown(20);
end;

procedure TForm1.gPoleKeyDown(Sender: TObject; var Key: Word;
  Shift: TShiftState);
begin
gametocki.OnKeyDown(20);
end;

procedure TForm1.CheckBox4Click(Sender: TObject);
begin
gametocki.Snap := CheckBox4.Checked;
end;

end.
