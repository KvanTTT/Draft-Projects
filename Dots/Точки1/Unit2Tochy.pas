unit Unit2Tochy;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Buttons, ExtCtrls, ComCtrls, ExtDlgs;

type
  TForm2 = class(TForm)
    Label5: TLabel;
    Label4: TLabel;
    Label3: TLabel;
    SpeedButton14: TSpeedButton;
    Edit100: TEdit;
    SpeedButton13: TSpeedButton;
    Panel14: TPanel;
    ColorDialog1: TColorDialog;
    Bevel1: TBevel;
    Bevel2: TBevel;
    Label1: TLabel;
    Label2: TLabel;
    Image1: TImage;
    SpeedButton1: TSpeedButton;
    SpeedButton2: TSpeedButton;
    Bevel3: TBevel;
    Bevel4: TBevel;
    Bevel5: TBevel;
    Bevel6: TBevel;
    Label7: TLabel;
    RadioButton1: TRadioButton;
    RadioButton2: TRadioButton;
    RadioButton3: TRadioButton;
    RadioButton4: TRadioButton;
    Bevel9: TBevel;
    Panel1: TPanel;
    Panel2: TPanel;
    Panel3: TPanel;
    RadioButton5: TRadioButton;
    RadioButton6: TRadioButton;
    RadioButton7: TRadioButton;
    RadioButton8: TRadioButton;
    RadioButton9: TRadioButton;
    Label11: TLabel;
    RadioButton10: TRadioButton;
    RadioButton11: TRadioButton;
    Label12: TLabel;
    RadioButton13: TRadioButton;
    SpeedButton6: TSpeedButton;
    SpeedButton7: TSpeedButton;
    SpeedButton8: TSpeedButton;
    SpeedButton9: TSpeedButton;
    SpeedButton10: TSpeedButton;
    SpeedButton11: TSpeedButton;
    Label13: TLabel;
    Bevel11: TBevel;
    Bevel7: TBevel;
    Bevel12: TBevel;
    Panel7: TPanel;
    Image3: TImage;
    Image4: TImage;
    Label6: TLabel;
    Panel4: TPanel;
    Image5: TImage;
    Panel5: TPanel;
    Image6: TImage;
    Panel6: TPanel;
    Image7: TImage;
    Panel8: TPanel;
    Image8: TImage;
    Label10: TLabel;
    RadioButton14: TRadioButton;
    RadioButton15: TRadioButton;
    RadioButton16: TRadioButton;
    RadioButton17: TRadioButton;
    RadioButton18: TRadioButton;
    Bevel13: TBevel;
    Bevel14: TBevel;
    Shape1: TShape;
    SpeedButton17: TSpeedButton;
    SpeedButton18: TSpeedButton;
    SpeedButton19: TSpeedButton;
    SpeedButton20: TSpeedButton;
    SpeedButton21: TSpeedButton;
    SpeedButton22: TSpeedButton;
    Panel15: TPanel;
    Panel16: TPanel;
    OpenPictureDialog1: TOpenPictureDialog;
    ListBox1: TListBox;
    Panel19: TPanel;
    Panel20: TPanel;
    SavePictureDialog1: TSavePictureDialog;
    SpeedButton15: TSpeedButton;
    Image11: TImage;
    SpeedButton23: TSpeedButton;
    Bevel10: TBevel;

    procedure RadioButton11Click(Sender: TObject);
    procedure RadioButton10Click(Sender: TObject);
    procedure RadioButton12Click(Sender: TObject);
    procedure RadioButton13Click(Sender: TObject);
    procedure RadioButton4Click(Sender: TObject);
    procedure RadioButton3Click(Sender: TObject);
    procedure RadioButton1Click(Sender: TObject);
    procedure Panel14Click(Sender: TObject);
    procedure Panel15Click(Sender: TObject);
    procedure Panel16Click(Sender: TObject);
    procedure SpeedButton1Click(Sender: TObject);
    procedure Panel20Click(Sender: TObject);
    procedure SpeedButton12Click(Sender: TObject);
    procedure SpeedButton2Click(Sender: TObject);
    procedure SpeedButton101Click(Sender: TObject);
    procedure SpeedButton15Click(Sender: TObject);
    procedure SpeedButton23Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure Edit100KeyPress(Sender: TObject; var Key: Char);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form2: TForm2;
  x: string;
  gen: integer;
  c: TColor;
  Chel, Comp, chel1, comp1 :TBitmap;

implementation

uses UnitTochy;

{$R *.dfm}


procedure TForm2.FormCreate(Sender: TObject);
var p : TIgrok;
begin
Chel := TBitmap.Create; Comp := TBitmap.Create;
Chel.LoadFromFile('Разное\Игрок - человек(small).bmp');
Comp.LoadFromFile('Разное\Игрок - компьютер(small).bmp');
chel1 := TBitmap.Create; comp1 := TBitmap.Create;
chel1.LoadFromFile('Разное\Игрок - человек.bmp');
comp1.LoadFromFile('Разное\Игрок - компьютер.bmp');
Image11.Picture.LoadFromFile('Разное\Игрок - человек.bmp');
end;

procedure TForm2.RadioButton11Click(Sender: TObject);
begin

SpeedButton6.Enabled := false;
SpeedButton7.Enabled := false;
SpeedButton8.Enabled := false;
SpeedButton9.Enabled := false;
SpeedButton10.Enabled := false;
SpeedButton11.Enabled := false;
Panel16.Enabled := true;
Panel15.Enabled := false;
end;


procedure TForm2.RadioButton10Click(Sender: TObject);
begin

SpeedButton6.Enabled := false;
SpeedButton7.Enabled := false;
SpeedButton8.Enabled := false;
SpeedButton9.Enabled := false;
SpeedButton10.Enabled := false;
SpeedButton11.Enabled := false;
Panel16.Enabled := false;
Panel15.Enabled := false;
end;

procedure TForm2.RadioButton12Click(Sender: TObject);
begin
SpeedButton6.Enabled := false;
SpeedButton7.Enabled := false;
SpeedButton8.Enabled := false;
SpeedButton9.Enabled := false;
SpeedButton10.Enabled := false;
SpeedButton11.Enabled := false;
Panel16.Enabled := false;
Panel15.Enabled := false;
end;

procedure TForm2.RadioButton13Click(Sender: TObject);
begin
SpeedButton6.Enabled := true;
SpeedButton7.Enabled := true;
SpeedButton8.Enabled := true;
SpeedButton9.Enabled := true;
SpeedButton10.Enabled := true;
SpeedButton11.Enabled := true;
Panel16.Enabled := false;
Panel15.Enabled := true;
end;

procedure TForm2.RadioButton4Click(Sender: TObject);
begin
Panel20.Enabled := true;
end;

procedure TForm2.RadioButton3Click(Sender: TObject);
var rez: TModalResult;
begin
If RadioButton1.Checked = true then begin
rez := MessageDlg('Точка не может быть бесцветной'#10,
mtError,[mbOK], 0);
if rez = mrOK then begin
RadioButton2.Checked := true;
end;
RadioButton2.Checked := true;
end;
Panel20.Enabled := false;
Panel20.Color := Panel14.Color;
end;

procedure TForm2.RadioButton1Click(Sender: TObject);
var rez: TModalResult;
begin
If RadioButton3.Checked = true then begin
rez := MessageDlg('Точка не может быть бесцветной'#10,
mtError,[mbOK], 0);
if rez = mrOK then begin
RadioButton2.Checked := true;
end;
RadioButton2.Checked := true;
end;
Panel19.Enabled := false;
end;

procedure TForm2.Panel14Click(Sender: TObject);
begin
If ColorDialog1.Execute then begin
Panel14.Color := ColorDialog1.Color;
end;
Panel19.Color := Panel14.Color;
if RadioButton3.Checked then begin
Panel20.Color := Panel14.Color;
end;
end;

procedure TForm2.Panel15Click(Sender: TObject);
begin
If ColorDialog1.Execute then begin
Panel15.Color := ColorDialog1.Color;
end;
end;

procedure TForm2.Panel16Click(Sender: TObject);
begin
If ColorDialog1.Execute then begin
Panel16.Color := ColorDialog1.Color;
end;
end;

procedure TForm2.SpeedButton1Click(Sender: TObject);
begin
If OpenPictureDialog1.Execute then begin

Image11.Visible := false;

end;
end;

procedure TForm2.Panel20Click(Sender: TObject);
begin
If ColorDialog1.Execute then begin
Panel20.Color := ColorDialog1.Color;
end;
end;

procedure TForm2.SpeedButton12Click(Sender: TObject);
begin
If OpenPictureDialog1.Execute then begin

end;
end;

procedure TForm2.SpeedButton2Click(Sender: TObject);
begin
with image11.Canvas do begin
pen.Color := panel5.Color;
Brush.Color := pen.Color;
rectangle(0, 0, image11.ClientWidth, Image11.ClientHeight);
end;
end;

procedure TForm2.SpeedButton101Click(Sender: TObject);
begin
Form2.Close;
end;

procedure TForm2.SpeedButton15Click(Sender: TObject);

begin
if Form1.ListBox2.Items.IndexOf(Edit100.Text) = -1 then begin
ListBox1.Clear;
If SpeedButton13.Down then begin
ListBox1.Items.Add('игрок');
end;
If SpeedButton14.Down then begin
ListBox1.Items.Add('компьютер');
end;
x := Edit100.Text;
ListBox1.Items.Add(x);
x := intToStr(Panel14.Color);
ListBox1.Items.Add(x);

If RadioButton1.Checked = true then begin
ListBox1.Items.Add('0');
end;

If RadioButton2.Checked = true then begin
x := intToStr(Panel14.Color);
ListBox1.Items.Add(x);
end;

If RadioButton3.Checked = true then begin
ListBox1.Items.Add('0');
end;

If RadioButton4.Checked = true then begin
x := intToStr(Panel20.Color);
ListBox1.Items.Add(x);
end;





If RadioButton5.Checked = true then begin
ListBox1.Items.Add('Карандаш');
end;

If RadioButton6.Checked = true then begin
ListBox1.Items.Add('Ручка');
end;

If RadioButton7.Checked = true then begin
ListBox1.Items.Add('Кисть');
end;

If RadioButton8.Checked = true then begin
ListBox1.Items.Add('Перо');
end;

If RadioButton9.Checked = true then begin
ListBox1.Items.Add('Фломастер');
end;

  If RadioButton10.Checked = true then begin
  ListBox1.Items.Add('Нет заливки');
  ListBox1.Items.Add('---');
  ListBox1.Items.Add('---');
  end;

  If RadioButton11.Checked = true then begin
  ListBox1.Items.Add('Сплошной цвет');
  x := IntToStr(Panel16.Color);
  ListBox1.Items.Add(x);
  ListBox1.Items.Add('---');
  end;

  If RadioButton13.Checked = true then begin
  ListBox1.Items.Add('Заливка из линий');
  x := IntToStr(Panel16.Color);
  ListBox1.Items.Add(x);
  If SpeedButton6.Down = true then begin
  ListBox1.Items.Add('Вертикальные линии');
  end;
  If SpeedButton7.Down = true then begin
  ListBox1.Items.Add('Горизонтальные линии');
  end;
  If SpeedButton8.Down = true then begin
  ListBox1.Items.Add('Диаг. вверх');
  end;
  If SpeedButton9.Down = true then begin
  ListBox1.Items.Add('Диаг. вниз');
  end;
  If SpeedButton10.Down = true then begin
  ListBox1.Items.Add('Решётка');
  end;
  If SpeedButton11.Down = true then begin
  ListBox1.Items.Add('Косая решётка');
  end;
  end;
  If RadioButton14.Checked = true then begin
  ListBox1.Items.Add('Голос Вани');
  end;
  If RadioButton15.Checked = true then begin
  ListBox1.Items.Add('Голос Арсения');
  end;
  If RadioButton16.Checked = true then begin
  ListBox1.Items.Add('Голос Паши');
  end;
  If RadioButton17.Checked = true then begin
  ListBox1.Items.Add('Голос Ильи');
  end;
  If RadioButton18.Checked = true then begin
  ListBox1.Items.Add('Голос Маши');
  end;
  x := Edit100.Text;
  ListBox1.Items.SaveToFile('Игроки\' + x + '.igr');
  form1.ListBox2.Items.Add(Edit100.Text);
  form1.ListBox2.Items.SaveToFile('Игроки\Список.igr');
  end else begin
  ShowMessage('Введите другое имя игрока');
  Edit100.SetFocus;
  end;

end;

procedure TForm2.SpeedButton23Click(Sender: TObject);
begin
Form2.Close;
end;


procedure TForm2.Edit100KeyPress(Sender: TObject; var Key: Char);
begin
If (Key in ['\', '/', '*', '?', '''', '>', '<', '|', '"']) then Key := #0;
end;

end.
