unit Unit2;

interface

uses
   Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  DXInput, DXClass, DXSprite, DXSounds, DXDraws, ExtCtrls, MPlayer,
  ComCtrls, StdCtrls, Buttons;

type
  TForm2 = class(TForm)
    DXImageList1: TDXImageList;
    DXDraw1: TDXDraw;
    DXTimer1: TDXTimer;
    DXInput1: TDXInput;
    DXSpriteEngine1: TDXSpriteEngine;
    Panel1: TPanel;
    SpeedButton1: TSpeedButton;
    procedure DXTimer1Timer(Sender: TObject; LagCount: Integer);
    procedure FormCreate(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

  Type TBackground = class(TBackGroundSprite)
  end;

    TCampany = class(TImageSprite)
  protected
  procedure DoMove(MoveCount : integer);
  public
    constructor Create(AParent: TSprite); override;
  end;

  TDummy = class(TImageSprite)
    protected
    procedure DoMove(MoveCount: Integer); override;
  public
    constructor Create(AParent: TSprite); override;
  end;

var
  Form2: TForm2;
  i : integer;

implementation

{$R *.dfm}

procedure TCampany.DoMove(MoveCount : integer);
begin
inherited DoMove(MoveCount);

end;


constructor TCampany.Create(AParent: TSprite);
begin
  inherited Create(AParent);
  Image := form2.DXImageList1.Items.Find('Кампания');
  Width := Image.Width;
  Height := Image.Height;
  AnimCount := 2;
  Animpos:= 0;
end;

constructor TDummy.Create(AParent: TSprite);
begin
  inherited Create(AParent);
  Width := 0;
  Height := 0;


end;

procedure TDummy.DoMove(MoveCount: Integer);
begin
If isUp in form2.DXInput1.States then begin
i := i - 1;
If i < 0 then i := 5;
end;
If isDown in form2.DXInput1.States then begin
i := i + 1;
If i > 5 then i := 0;
end;
end;

procedure TForm2.DXTimer1Timer(Sender: TObject; LagCount: Integer);
begin
DXDraw1.Surface.Fill(0); // Закрашиваем все черным
DXSpriteEngine1.Move(0); // Делаем все процедуры DOMove
DXSpriteEngine1.Dead;  // Убиваем все спрайты
DXSpriteEngine1.Draw;
DXInput1.Update;

with Form2.DXDraw1.Surface.Canvas do  //Так выводится текст \/
 begin
  Brush.Style:= bsClear;
  Font.Color:=clWhite;
  Font.Size:=10;
  Font.Name:='Arial';
  Textout(2,0,'Управление: стрелки-движение, пробел-стрельба. Для победы нужно набрать 150 очков.');
  Textout(2,12,'FPS:'+inttostr(Form2.DXTimer1.FrameRate));
  Font.Color:=clAqua;
  Textout(20, 20, IntToStr(i));
   Textout(2,36,'Автор - DRON, Van, ARS');
   Release; // Писать обязательно после вывода текста!!!
  end;
DXDraw1.Flip;
end;

procedure TForm2.FormCreate(Sender: TObject);
begin

i := 0;
TDummy.Create(DXSpriteEngine1.Engine);
with TBackground.Create(DXSpriteEngine1.Engine) do begin

SetMapSize(800, 600);
    Image := form2.DXImageList1.Items.Find('Фон');
    x := 0;
    Y := 0;
    Z := -2;
    Tile := false;
end;

with TCampany.Create(DXSpriteEngine1.engine) do begin
x := (dxdraw1.Display.Width div 2) - (image.Width div 2);
y := (dxdraw1.Display.Height div 2) - (image.Height div 2);

end;
DXDraw1.cursor:=crnone;
end;

 end.

