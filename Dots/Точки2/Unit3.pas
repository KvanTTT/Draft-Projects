unit Unit3;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, tocki2, Keyboard,  GR32, GR32_RotLayer, StdCtrls, GR32_Image,
  GR32_Layers,  GR32_Transforms, GR32_Polygons, GR32_Resamplers;

type
  TForm1 = class(TForm)
    ImgView: TImgView32;
    procedure FormCreate(Sender: TObject);

    procedure FormKeyDown(Sender: TObject; var Key: Word;
      Shift: TShiftState);
    procedure ImgViewMouseMove(Sender: TObject; Shift: TShiftState; X,
      Y: Integer; Layer: TCustomLayer);
    procedure ImgViewMouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer; Layer: TCustomLayer);
  private
    { Private declarations }
  public

  end;

var
  Form1: TForm1;
  pole : TPole;
  GamePole1 : TGamePole;
  GameTocki : TGameTocki;
  Players : TPlayers;
  basa : TBasa;
  t : TTocka;
  mx, my : smallint;
  b : boolean;
  c : TRotLayer;
implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
c := TRotLayer.Create(ImgView.Layers);
c.Bitmap := TBitmap32.Create;
ImgView.SetupBitmap();

SetLength(Players, 2);
Players[0] := TPlayer.Create();
Players[0].Name := 'Van';
Players[0].Color := clGreen32;
Players[0].ConturColor := clBlack32;
Players[0].FillColor := clGreen32;
Players[0].MoveUp := VK_up;
Players[0].MoveDown := VK_Down;
Players[0].MoveLeft := VK_Left;
Players[0].MoveRight := VK_Right;
Players[0].Enter := VK_return;
Players[0].FillColor := SetAlpha(players[0].FillColor, 200);


Players[1] := TPlayer.Create();
Players[1].Color := clRed32;
Players[1].ConturColor := clBlack32;
Players[1].FillColor := clRed32;
Players[1].Name := 'Ars';


Pole := TPole.Create('proba', clWhite32, clBlack32, 255, 1, 15, MakeSize(30, 40));
GamePole1 := TGamePole.Create(ImgView.Bitmap, c.Bitmap, MakeSize(form1.width, form1.Height), Pole, nil, Players, 0);
GamePole1.asp := true;
GamePole1.Pos := Make2dposf(0, 0);
GamePole1.ZadKey := 10;
GameTocki := TGameTocki.Create(ImgView, GamePole1);
GameTocki.ZoomIn := VK_Tab;
GameTocki.zoomout := VK_LShift;
GameTocki.ScrollUp := VK_Space;
GameTocki.ScrollDown := VK_Control;

ImgView.Cursor := crNone;

GameTocki.GamePole.Players[0].MoveUp := VK_Up;
GameTocki.GamePole.Players[0].MoveDown := VK_Down;
GameTocki.GamePole.Players[0].MoveLeft := VK_Left;
GameTocki.GamePole.Players[0].MoveRight := VK_Right;

GamePole1.Window := MakeSize(pole.Width, pole.height);
ImgView.ClientWidth := pole.Width;
ImgView.ClientHeight := pole.Height;

gamepole1.UpdatePole;
Form1.Caption := IntToStr(gamepole1.players[1].Color);
GameTocki.GamePole.DrawCursor;

end;


procedure TForm1.FormKeyDown(Sender: TObject; var Key: Word;
  Shift: TShiftState);
begin
if key = VK_Escape then close;
if key = VK_F5 then gamepole1.SaveGamePole('Игры\1');
if key = VK_F4 then gamepole1.UpdatePole;
if key = VK_F9 then begin
gamepole1.LoadGamePole(ImgView.Bitmap, 'Игры\1');
//Form1.Caption :=  '   ' +IntToStr(gamepole1.players[1].color);
end;
end;

procedure TForm1.ImgViewMouseMove(Sender: TObject; Shift: TShiftState; X,
  Y: Integer; Layer: TCustomLayer);
begin
c.Position := FloatPoint(x-pole.KletkaSize, y-pole.KletkaSize);
//GameTocki.OnMouseMove(x, y);
end;

procedure TForm1.ImgViewMouseDown(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer; Layer: TCustomLayer);
begin

GameTocki.OnMouseDown(x, y, Button);
GameTocki.GamePole.DrawCursor;
end;

end.
