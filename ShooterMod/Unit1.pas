unit Unit1;
// ����, ������� ���� DELPHI X
interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  DXInput, DXClass, DXSprite, DXSounds, DXDraws, ExtCtrls, MPlayer,
  ComCtrls;
 
type
  TForm1 = class(TDXForm)
    DXDraw: TDXDraw;
    DXImageList1: TDXImageList;
    DXSound1: TDXSound;
    DXWaveList: TDXWaveList;
    DXSpriteEngine: TDXSpriteEngine;
    DXTimer1: TDXTimer;
    DXInput1: TDXInput;
    Timer1: TTimer;
    Timer2: TTimer;
    MediaPlayer1: TMediaPlayer;
    Timer3: TTimer;
    procedure DXTimer1Timer(Sender: TObject; LagCount: Integer);
    procedure FormCreate(Sender: TObject);
    procedure Timer1Timer(Sender: TObject);
    procedure Timer2Timer(Sender: TObject);
    procedure MediaPlayer1Notify(Sender: TObject);
    procedure FormKeyUp(Sender: TObject; var Key: Word;
      Shift: TShiftState);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

// ������ � ���������� ��� ���, � ������ ���� �������� �������������� � ����
// ��� ��� ����������� �� ����� ����� ���� ���� ���
    type
 Tship = class(TImageSprite) // ���� ��� ����� ��� Ship, �������, ��� �� ������ ������� ���� ���, ��� ������ =)
  private // � ������� ������������� ���������� ����������� ������ � ����� �������. ������, ���� � ���� 10 ��������, �� lives(�����) � ��� � ������� ����
  animspeed,shoot, health :integer;
  protected
    procedure DoMove(MoveCount: Integer); override;  // ��� ����� ������ ��������� ��� �������, ��� ����������� ������ ��� ������ � ����������� DXTimer'� ������ ��� � ���� ������ � ���������� DXTimer'�
    procedure DoCollision(Sprite: TSprite; var Done: Boolean); override; // �������� ������� ���� �� ����, ��� ��������� �������� �� ��, ��� ���������� �� �������� ��� ���������(������������) � ������ ��������
  public
    constructor Create(AParent: TSprite); override; // � ���� �������� �� ��������� ��������� ��������� �������, ��������, ���������� ������, ��������� ����� � ��.
  end;


    Tship1 = class(TImageSprite) // ���� ��� ����� ��� Ship, �������, ��� �� ������ ������� ���� ���, ��� ������ =)
     private // � ������� ������������� ���������� ����������� ������ � ����� �������. ������, ���� � ���� 10 ��������, �� lives(�����) � ��� � ������� ����
  animspeed,shoot, health :integer;
  protected
    procedure DoMove(MoveCount: Integer); override;  // ��� ����� ������ ��������� ��� �������, ��� ����������� ������ ��� ������ � ����������� DXTimer'� ������ ��� � ���� ������ � ���������� DXTimer'�
    procedure DoCollision(Sprite: TSprite; var Done: Boolean); override; // �������� ������� ���� �� ����, ��� ��������� �������� �� ��, ��� ���������� �� �������� ��� ���������(������������) � ������ ��������
  public
    constructor Create(AParent: TSprite); override; // � ���� �������� �� ��������� ��������� ��������� �������, ��������, ���������� ������, ��������� ����� � ��.
  end;







//  ��� ���� �� ���� ���������� \/
      type
 TBoom = class(TImageSprite) // �����
  private
  animspeed:integer;
  protected
    procedure DoMove(MoveCount: Integer); override;
  public
    constructor Create(AParent: TSprite); override;
  end;

   TBoom1 = class(TImageSprite) // �����
  private
  animspeed:integer;
  protected
    procedure DoMove(MoveCount: Integer); override;
  public
    constructor Create(AParent: TSprite); override;
  end;


      type
 TPlayer1 = class(TImageSprite)  // ����� 1
  private
  animspeed:integer;
  protected
    procedure DoMove(MoveCount: Integer); override;
    procedure DoCollision(Sprite: TSprite; var Done: Boolean); override;
  public
    constructor Create(AParent: TSprite); override;
  end;

  THealth = class(TImageSprite)
  private

  protected
    procedure DoMove(MoveCount : integer);override;
  public
    constructor Create(AParent: TSprite); override;
  end;

   TScrollBackground = class(TBackgroundSprite)  // ��������� ��� ������ ��� ������� ������������ �� ��������� ���, ��� ��� �������� "��������" ���� ����� � ������� ������ � ��� ��������� ������ (�� ���� ����)
  private
    FSpeed: Double;
  protected
    procedure DoMove(MoveCount: Integer); override;
  end;



   TScrollBackground1 = class(TBackgroundSprite)  // ��������� ��� ������ ��� ������� ������������ �� ��������� ���, ��� ��� �������� "��������" ���� ����� � ������� ������ � ��� ��������� ������ (�� ���� ����)
  private
  protected

  end;

  TBackgroundPanel = class(TBackgroundSprite)
  end;



 Trocket = class(TImageSprite)   // ������
  private
    animspeed:integer;
  protected
    procedure DoMove(MoveCount: Integer); override;
  public
    constructor Create(AParent: TSprite); override;
  end;

          type
 TBullet = class(TImageSprite) // ������
  protected
    procedure DoMove(MoveCount: Integer); override;
  public
    constructor Create(AParent: TSprite); override;
  end;


   TB1 = class(TImageSprite) //�����1
  protected
    procedure DoMove(MoveCount: Integer); override;
  public
    constructor Create(AParent: TSprite); override;
  end;

   TB2 = class(TImageSprite) //�����2
  protected
    procedure DoMove(MoveCount: Integer); override;
  public
    constructor Create(AParent: TSprite); override;
  end;


     TBonus = class(TImageSprite) //�����
  protected
    procedure DoMove(MoveCount: Integer); override;
  public
    constructor Create(AParent: TSprite); override;
  end;

  TBonus1 = class(TImageSprite) //�����
  protected
    procedure DoMove(MoveCount: Integer); override;
  public
    constructor Create(AParent: TSprite); override;
  end;

   TB3 = class(TImageSprite)   //�����3
  protected
    procedure DoMove(MoveCount: Integer); override;
  public
    constructor Create(AParent: TSprite); override;
  end;

     TB4 = class(TImageSprite)    //�����4
  protected
    procedure DoMove(MoveCount: Integer); override;
  public
    constructor Create(AParent: TSprite); override;
  end;

     TBS = class(TImageSprite)
  protected
    procedure DoMove(MoveCount: Integer); override;
  public
    constructor Create(AParent: TSprite); override;
  end;

  TBP = class(TImageSprite)
   protected
    procedure DoMove(MoveCount: Integer); override;
  public
    constructor Create(AParent: TSprite); override;
  end;

   TBc = class(TImageSprite)
   protected
    procedure DoMove(MoveCount: Integer); override;
  public
    constructor Create(AParent: TSprite); override;
  end;
  
var
  Form1: TForm1;
 i, a, polet,sx,sy, score, shitpoints, immortal,weapon, hitpoints,  leave : integer;  // ������ ������ ����������
 bdead,alldead : boolean;

implementation

{$R *.DFM}



Procedure TShip.DoMove(MoveCount: Integer); // ���� ��������� �������� ������� (������, ���� �������)
var
bx,by : integer; // �������� ���������� ������ ��������� ������ ���
begin
inherited DoMove(MoveCount);
y:=y + 3; // �������� ����� ����, ������ ���������� Y
if x < sx then x := x + 1;
if x > sx then x := x - 1;
if alldead then  dead; // ���� ��� �������, �� � ���� ������ ���� ������������� (alldead �������� � true ����� �� ������ ����� ����� ��. ����)
 bx:=trunc(x); // ����� � - ���������� �������, � ������� trunc ����� ��� ���� ��� �� � �� doubl ��������� � integer
 by:=trunc(y);
  if animspeed=7 then begin // ����� ����� ������� ��� ���������� ������, ��� �� ��� �� ��������� �������� ��������� ������ ��. ������ ����������� ����� ������ animspeed ��� ������� integer
  // ������ ����� �����, ��� �� ������ ���� ����� 7 ���������� �������, ������� ����� =)
  animspeed:=0;
  Animpos:=animpos+1; // ������� �������� �� ���� ������ "-" ������ �����
  if animpos=5 then animpos:=0; // ��� ��� � ��� 3 ����� (������� � 0) �� ���� ������ ������ (4 �����) � ��������� ���� ���������� �� ��������� ���� 0
  end;
  {����� ���� ��� �� ������� ���� ����������� � ���, ��� ���� ����� ���� ���������� ������� ������
  �� �� �������� sx - ���������� ������ �� � }
  if ((x>sx) and (x<sx+61)) or ((x<sx+61) and (x>sx)) then  begin
  shoot:=shoot+1;
  if shoot=20 then begin
  shoot:=0;
  Form1.DXWaveList.Items.Find('Shoot1').Play(False); // ��� ���� ������ ���� �� DXWavlist
with TBullet.Create(form1.DXSpriteEngine.engine) do   // ������� ������ � ������� ��� ������������
begin
x:=bx + 25;
y:=by + 75;
end;
end;
end;
animspeed:=animspeed+1;
if  y> Form1.DXDraw.Display.Height - 20  then dead; // ���� ��������� �������� �� ������� ������ �� �� ������
Collision;   // ���� ������ �����������, ��� �� ��������� ������������ � ���� ��������
end;

procedure Tship1.DoMove(MoveCount: Integer);
var
bx,by : integer; // �������� ���������� ������ ��������� ������ ���
begin
inherited DoMove(MoveCount);
y:=y + 3; // �������� ����� ����, ������ ���������� Y
if alldead then  dead; // ���� ��� �������, �� � ���� ������ ���� ������������� (alldead �������� � true ����� �� ������ ����� ����� ��. ����)
 bx:=trunc(x); // ����� � - ���������� �������, � ������� trunc ����� ��� ���� ��� �� � �� doubl ��������� � integer
 by:=trunc(y);
  if animspeed=7 then begin // ����� ����� ������� ��� ���������� ������, ��� �� ��� �� ��������� �������� ��������� ������ ��. ������ ����������� ����� ������ animspeed ��� ������� integer
  // ������ ����� �����, ��� �� ������ ���� ����� 7 ���������� �������, ������� ����� =)
  animspeed:=0;
  Animpos:=animpos+1; // ������� �������� �� ���� ������ "-" ������ �����
  if animpos=2 then animpos:=0; // ��� ��� � ��� 3 ����� (������� � 0) �� ���� ������ ������ (4 �����) � ��������� ���� ���������� �� ��������� ���� 0
  end;
  {����� ���� ��� �� ������� ���� ����������� � ���, ��� ���� ����� ���� ���������� ������� ������
  �� �� �������� sx - ���������� ������ �� � }
  if ((x>sx) and (x<sx+61)) or ((x<sx+61) and (x>sx)) then  begin
  shoot:=shoot+1;
  if shoot=20 then begin
  shoot:=0;
  Form1.DXWaveList.Items.Find('Shoot1').Play(False); // ��� ���� ������ ���� �� DXWavlist
with TBullet.Create(form1.DXSpriteEngine.engine) do   // ������� ������ � ������� ��� ������������
begin
x:=bx + 25;
y:=by + 75;
end;
end;
end;
animspeed:=animspeed+1;
if  y> Form1.DXDraw.Display.Height - 20  then dead; // ���� ��������� �������� �� ������� ������ �� �� ������
Collision;   // ���� ������ �����������, ��� �� ��������� ������������ � ���� ��������
end;

procedure THealth.DoMove(MoveCount : integer);
begin
inherited DoMove(MoveCount);
If hitpoints > 75 then begin
Animpos:= 0; // ������� �������� �� ���� ������ "-" ������ �����
end;
If (hitpoints <= 75) and (hitpoints > 60) then begin
Animpos:= 1;
end;
If (hitpoints <= 60) and (hitpoints > 35) then begin
Animpos:= 2;
end;
If (hitpoints <= 35) and (hitpoints > 0) then begin
Animpos:= 3;
end;
If hitpoints <= 0then begin
Animpos:= 4;
end;
end;

// ��� ����������� domove'� ����� �� �����������
procedure TScrollBackground.DoMove(MoveCount: Integer);
begin
  inherited DoMove(MoveCount);
  y := y + 1*FSpeed;  //��������� ����� �������, ��� � ������� ������
end;



Procedure TRocket.DoMove(MoveCount: Integer);
begin
inherited DoMove(MoveCount);
y := y - 3;
if  (y<0) or (x<0) or (x > Form1.DXDraw.Display.Width)  then dead;
if animspeed=4 then begin // ����� ����� ������� ��� ���������� ������, ��� �� ��� �� ��������� �������� ��������� ������ ��. ������ ����������� ����� ������ animspeed ��� ������� integer
  // ������ ����� �����, ��� �� ������ ���� ����� 7 ���������� �������, ������� ����� =)
  animspeed:=0;
  Animpos:=animpos+1; // ������� �������� �� ���� ������ "-" ������ �����
  if animpos=2 then animpos:=0; // ��� ��� � ��� 3 ����� (������� � 0) �� ���� ������ ������ (4 �����) � ��������� ���� ���������� �� ��������� ���� 0
  end;
end;


  Procedure TBullet.DoMove(MoveCount: Integer);
begin
inherited DoMove(MoveCount);
y:=y+4;

  if  y> Form1.DXDraw.Display.Height - 20 then dead;

  end;



procedure tbs.DoMove(MoveCount: Integer);
begin
inherited DoMove(MoveCount);
y:=y+4;
if  y> Form1.DXDraw.Display.Height - 20  then dead;
end;

    Procedure TB1.DoMove(MoveCount: Integer);
begin
inherited DoMove(MoveCount);

y:=y+4;
  if  y> Form1.DXDraw.Display.Height - 20  then dead;

  end;


    Procedure TB2.DoMove(MoveCount: Integer);
begin
inherited DoMove(MoveCount);

y:=y+4;
  if  y> Form1.DXDraw.Display.Height - 20  then dead;

  end;


    Procedure TB3.DoMove(MoveCount: Integer);
begin
inherited DoMove(MoveCount);

y:=y+4;
  if  y> Form1.DXDraw.Display.Height - 20  then dead;

  end;


    Procedure TBonus.DoMove(MoveCount: Integer);
begin
inherited DoMove(MoveCount);
if bdead then begin dead; bdead:=false; end;
x:=sx-38;
y := sy + 20;
  end;

  procedure TBonus1.DoMove(moveCount : integer);
  begin
 inherited DoMove(MoveCount);
if bdead then begin dead; bdead:=false; end;
x:=sx - 10;
y := sy + 10;
end;

Procedure TB4.DoMove(MoveCount: Integer);
begin
inherited DoMove(MoveCount);
y:=y+4;
if  y>form1.DXDraw.Display.Height  then dead;
end;

Procedure TBp.DoMove(MoveCount: Integer);
begin
inherited DoMove(MoveCount);
y:=y+4;
if  y>form1.DXDraw.Display.Height  then dead;
end;

Procedure TBc.DoMove(MoveCount: Integer);
begin
inherited DoMove(MoveCount);
y:=y+2;
if  y>form1.DXDraw.Display.Height  then dead;
end;

Procedure TBoom.DoMove(MoveCount: Integer);
begin
inherited DoMove(MoveCount);
  if animpos=5 then dead;
  if animspeed=7 then begin
  animspeed:=0;
  Animpos:=animpos+1;
  end;
  animspeed:=animspeed+1;
end;

Procedure TBoom1.DoMove(MoveCount: Integer);
begin
inherited DoMove(MoveCount);
  if animpos=7 then dead;
  if animspeed=7 then begin
  animspeed:=0;
  Animpos:=animpos+1;
  end;
  animspeed:=animspeed+1;
end;



Procedure TPlayer1.DoMove(MoveCount: Integer);
var
bx,by : integer;
begin
inherited DoMove(MoveCount);

bx:=trunc(x)+25;
by:=trunc(y)-10;
sy := trunc(y);
  if animspeed=7 then begin
  animspeed:=0;
  Animpos:=animpos+1;
  if animpos=3 then animpos:=0;
  end;
  animspeed:=animspeed+1;

  if isleft in form1.dxinput1.States then begin
  x:=x-5;  // ����������
  end;
  if isright in form1.dxinput1.States then begin
  x:=x+5;
  end;
  if isdown in form1.dxinput1.States then begin
  y:=y+3;
  end;
  if isup in form1.dxinput1.States then begin
  y:=y-3;
  end;
  if x < 0 then x := 0; If x > Form1.DXDraw.Display.Width - 150 then  x := Form1.DXDraw.Display.Width - 150;
  If y > Form1.DXDraw.Display.Height - 70  then y := Form1.DXDraw.Display.Height - 70 ;
  If y < form1.DXDraw.Display.Height div 3 then y := form1.DXDraw.Display.Height div 3;
  sx:=trunc(x);


  // �������� � ����������� �� ������
  if (isButton1 in form1.dxinput1.States) and (weapon=1) then begin
if polet>20 then begin   //���������� ���������
Form1.DXWaveList.Items.Find('Shoot').Play(False);

  polet:=0;
with TRocket.Create(form1.DXSpriteEngine.engine) do
begin
x:=bx;
y:=by;
end;
end;

  end;


    if (isButton1 in form1.dxinput1.States) and (weapon=3) then begin
if polet>60 then begin
Form1.DXWaveList.Items.Find('Shoot').Play(False);

polet:=0;
with TRocket.Create(form1.DXSpriteEngine.engine) do
begin
x:=bx;
y:=by;
Image := form1.DXImageList1.Items.Find('Ball');
Width :=18 ;
Height :=30 ;
end;
end;
end;

 if (isButton1 in form1.dxinput1.States) and (weapon=10) then begin
if polet>7 then begin
Form1.DXWaveList.Items.Find('Shoot').Play(False);
polet:=0;
with TRocket.Create(form1.DXSpriteEngine.engine) do
begin
x:=bx;
y:=by;
Image := form1.DXImageList1.Items.Find('����');
Width :=image.Width ;
Height :=image.Height ;
end;
end;
end;

if (isButton1 in form1.dxinput1.States) and (weapon=2) then begin
if polet>20 then begin
Form1.DXWaveList.Items.Find('Shoot').Play(False);
polet:=0;
with TRocket.Create(form1.DXSpriteEngine.engine) do
begin
x:=bx;
y:=by;
end;
with TRocket.Create(form1.DXSpriteEngine.engine) do
begin
x:=bx+15;
y:=by;
end;
with TRocket.Create(form1.DXSpriteEngine.engine) do
begin
x:=bx-15;
y:=by;
end;
end;
end;

if (isButton1 in form1.dxinput1.States) and (weapon=5) then begin
if polet>20 then begin
Form1.DXWaveList.Items.Find('Shoot').Play(False);
 polet:=0;
with TRocket.Create(form1.DXSpriteEngine.engine) do
begin
x:=bx;
y:=by;
end;
with TRocket.Create(form1.DXSpriteEngine.engine) do
begin
x:=bx+53;
y:=by;
end;
with TRocket.Create(form1.DXSpriteEngine.engine) do
begin
x:=bx-53;
y:=by;
end;
end;
end;

immortal:=immortal+1;

if immortal>100 then Collision;
  if x+image.Width>= form1.DXDraw.Display.Width then x:=x-3;
  if x<=0 then x:=x+3;
  end;


procedure TShip.DoCollision(Sprite: TSprite; var Done: Boolean); // ��������� ������������
var
bx,by : integer;
begin
bx:=trunc(x);
by:=trunc(y);
if sprite is Trocket then begin  // ���� ������ ������ �� ������� =(
If weapon = 1 then begin health := health - 25; with TBoom.Create(form1.DXSpriteEngine.engine) do // ������� ��������
begin
x:=bx;
y:=by;
end;sprite.dead; end;
If weapon = 5 then begin health := health - 15; with TBoom.Create(form1.DXSpriteEngine.engine) do // ������� ��������
begin
x:=bx;
y:=by;
end;sprite.dead; end;
If weapon = 10 then begin health := health - 15; with TBoom.Create(form1.DXSpriteEngine.engine) do // ������� ��������
begin
x:=bx;
y:=by;
end;sprite.dead; end;
If weapon = 2 then begin health := health - 25;with TBoom.Create(form1.DXSpriteEngine.engine) do // ������� ��������
begin
x:=bx;
y:=by;
end; sprite.dead; end;
If weapon = 4 then begin health := health - 25; with TBoom.Create(form1.DXSpriteEngine.engine) do // ������� ��������
begin
x:=bx;
y:=by;
end;sprite.dead; end;
If weapon = 6 then begin health := health - 25;with TBoom.Create(form1.DXSpriteEngine.engine) do // ������� ��������
begin
x:=bx;
y:=by;
end; sprite.dead; end;
If weapon = 3 then begin health := health - 50;with TBoom.Create(form1.DXSpriteEngine.engine) do // ������� ��������
begin
x:=bx;
y:=by;
end;  end;
if weapon<>3 then sprite.dead;
If health <= 0 then begin
dead;
Form1.DXWaveList.Items.Find('Boom').Play(False);
 score:=score+1;
with TBoom1.Create(form1.DXSpriteEngine.engine) do // ������� ��������
begin
x:=bx;
y:=by;
end;
end;
end;
end;

procedure TShip1.DoCollision(Sprite: TSprite; var Done: Boolean);
var
bx,by : integer;
begin
bx:=trunc(x);
by:=trunc(y);
if sprite is Trocket then begin  // ���� ������ ������ �� ������� =(
If weapon = 1 then begin health := health - 25; with TBoom.Create(form1.DXSpriteEngine.engine) do // ������� ��������
begin
x:=bx;
y:=by;
end;sprite.dead; end;
If weapon = 5 then begin health := health - 15; with TBoom.Create(form1.DXSpriteEngine.engine) do // ������� ��������
begin
x:=bx;
y:=by;
end;sprite.dead; end;
If weapon = 10 then begin health := health - 15; with TBoom.Create(form1.DXSpriteEngine.engine) do // ������� ��������
begin
x:=bx;
y:=by;
end;sprite.dead; end;
If weapon = 2 then begin health := health - 25;with TBoom.Create(form1.DXSpriteEngine.engine) do // ������� ��������
begin
x:=bx;
y:=by;
end; sprite.dead; end;
If weapon = 4 then begin health := health - 25; with TBoom.Create(form1.DXSpriteEngine.engine) do // ������� ��������
begin
x:=bx;
y:=by;
end;sprite.dead; end;
If weapon = 6 then begin health := health - 25;with TBoom.Create(form1.DXSpriteEngine.engine) do // ������� ��������
begin
x:=bx;
y:=by;
end; sprite.dead; end;
If weapon = 3 then begin health := health - 50;with TBoom.Create(form1.DXSpriteEngine.engine) do // ������� ��������
begin
x:=bx;
y:=by;
end;  end;
if weapon<>3 then sprite.dead;

If health <= 0 then begin
dead;
Form1.DXWaveList.Items.Find('Boom').Play(False);
 score:=score+1;
with TBoom1.Create(form1.DXSpriteEngine.engine) do // ������� ��������
begin
x:=bx;
y:=by;
end;
end;
end;
end;

procedure TPlayer1.DoCollision(Sprite: TSprite; var Done: Boolean);
var
bx,by,i : integer;
begin
bx:=trunc(x);
by:=trunc(y);

if sprite is Tb1 then begin  // ���� ������ �����1 ��...
polet:=0;
sprite.dead;
bdead:=true;
weapon:=2;
end;

if sprite is Tb2 then begin // ���� ������ �����2 ��...
polet:=0;
sprite.dead;
bdead:=true;
weapon:=3;
end;

if sprite is Tb3 then begin  // ���� ������ �����3 ��...
polet:=0;
bdead:=true;
sprite.dead;
weapon:=1;
alldead:=true;
Form1.DXWaveList.Items.Find('Boom').Play(False);
Form1.DXWaveList.Items.Find('Boom').Play(False);
Form1.DXWaveList.Items.Find('Boom').Play(False);
Form1.DXWaveList.Items.Find('Boom').Play(False);
Form1.DXWaveList.Items.Find('Boom').Play(False);
for i:=1 to 50 do
with TBoom.Create(form1.DXSpriteEngine.engine) do
begin
x:=random(Form1.DXDraw.Display.Width );
y:=random(Form1.DXDraw.Display.Height);
end;
end;

if sprite is Tb4 then begin
polet:=0;
sprite.dead;
if weapon<>5 then begin
bdead:=false;
with Tbonus.create(form1.DXSpriteEngine.engine) do
begin
x:=bx-38;
y := by + 20;
end;
weapon:=5;
end;
end;


if sprite is Tbs then begin
polet:=0;
sprite.dead;
shitpoints := 100;
if weapon=5 then begin
bdead:=false;
end;
weapon := 1;
with Tbonus1.Create(form1.DXSpriteEngine.Engine) do begin
x := bx + 15;
y := sy + 5;
end;

end;

If  sprite is Tbc then begin
sprite.dead;
hitpoints := hitpoints - 40;
with TBoom.Create(form1.DXSpriteEngine.engine) do
begin
x:=bx;
y:=by;
end;
end;

if sprite is Tbullet then begin  // ���� ������ ����
 sprite.dead;

 If hitpoints > 0 then begin
  with TBoom.Create(form1.DXSpriteEngine.engine) do begin
   x:=bx;
   y:=by;
  end;
 end;

If hitpoints <= 0 then begin
 dead;
 bdead:=true;
 shitpoints := 0;
 score:=score-10;
 form1.timer2.enabled:=true;
 Form1.DXWaveList.Items.Find('Boom').Play(False);
 with TBoom.Create(form1.DXSpriteEngine.engine) do begin
  x:=bx;
  y:=by;
 end;
end;
end;




if sprite is TShip then begin
 sprite.dead;
 hitpoints := hitpoints - 35;
 If hitpoints > 0 then begin
  with TBoom.Create(form1.DXSpriteEngine.engine) do begin
  x:=bx;
  y:=by;
 end;
end;

If hitpoints <= 0 then begin
dead;

bdead:=true;
score:=score-10;
form1.timer2.enabled:=true;
Form1.DXWaveList.Items.Find('Boom').Play(False);
with TBoom.Create(form1.DXSpriteEngine.engine) do
begin
x:=bx;
y:=by;
end;
end;
end;

if sprite is TShip1 then begin
 sprite.dead;
 hitpoints := hitpoints - 35;
 If hitpoints > 0 then begin
  with TBoom.Create(form1.DXSpriteEngine.engine) do begin
  x:=bx;
  y:=by;
 end;
end;

If hitpoints <= 0 then begin
dead;
shitpoints := 0;
bdead:=true;
score:=score-10;
form1.timer2.enabled:=true;
Form1.DXWaveList.Items.Find('Boom').Play(False);
with TBoom.Create(form1.DXSpriteEngine.engine) do
begin
x:=bx;
y:=by;
end;
end;
end;




if sprite is Tbp then begin // ���� ������ �����2 ��...
polet:=0;

 sprite.dead;
 bdead:=true;

 weapon:=10;
 end;
end;




constructor TShip.Create(AParent: TSprite); // ��������� �������� �������
begin
  inherited Create(AParent);
Image := form1.DXImageList1.Items.Find('Ship'); // �������� ��������
  Width := Image.Width;  // ������������� ����� � ������ (����� ������ ��������� �������� � ��������� ���� �������� � DXImageList), ��������� ����� ���� � �����
  Height := Image.Height;
  AnimCount := Image.PatternCount; // ���-�� ������
  Animpos:=0; // ��� �� ��� ������ =)
  health := 30;

end;

constructor TShip1.Create(AParent: TSprite);
begin
  inherited Create(AParent);
Image := form1.DXImageList1.Items.Find('Ship1'); // �������� ��������
  Width := Image.Width;  // ������������� ����� � ������ (����� ������ ��������� �������� � ��������� ���� �������� � DXImageList), ��������� ����� ���� � �����
  Height := Image.Height;
  AnimCount := Image.PatternCount; // ���-�� ������
  Animpos:=0; // ��� �� ��� ������ =)
  health := 30;

end;

constructor TRocket.Create(AParent: TSprite);
begin
  inherited Create(AParent);
Image := form1.DXImageList1.Items.Find('Rocket');
  Width := Image.Width ;
  Height := Image.Height ;
  AnimCount := Image.PatternCount; // ���-�� ������
  Animpos:=0
end;


constructor TBullet.Create(AParent: TSprite);
begin
  inherited Create(AParent);
Image := form1.DXImageList1.Items.Find('Bullet');
  Width :=10 ;
  Height :=10 ;
end;


constructor TB1.Create(AParent: TSprite);
begin
  inherited Create(AParent);
Image := form1.DXImageList1.Items.Find('B1');
  Width :=32 ;
  Height :=24 ;
end;


constructor TB2.Create(AParent: TSprite);
begin
  inherited Create(AParent);
Image := form1.DXImageList1.Items.Find('B2');
  Width :=32 ;
  Height :=24 ;
end;


constructor TB3.Create(AParent: TSprite);
begin
  inherited Create(AParent);
Image := form1.DXImageList1.Items.Find('B3');
  Width :=32 ;
  Height :=24 ;
end;

constructor TB4.Create(AParent: TSprite);
begin
  inherited Create(AParent);
Image := form1.DXImageList1.Items.Find('B4');
  Width :=32 ;
  Height :=24 ;
end;

constructor TBS.Create(AParent: TSprite);
begin
  inherited Create(AParent);
Image := form1.DXImageList1.Items.Find('���');
  Width :=32 ;
  Height :=24 ;
end;

constructor TBp.Create(AParent: TSprite);
begin
  inherited Create(AParent);
Image := form1.DXImageList1.Items.Find('������');
  Width :=32 ;
  Height :=24 ;
end;

constructor TBc.Create(AParent: TSprite);
begin
  inherited Create(AParent);
Image := form1.DXImageList1.Items.Find('����');
  Width :=image.Width ;
  Height := image.Height ;
end;

constructor TBonus.Create(AParent: TSprite);
begin
  inherited Create(AParent);
Image := form1.DXImageList1.Items.Find('B');
  Width :=Image.Width ;
  Height :=Image.Height ;

end;

constructor TBonus1.Create(AParent: TSprite);
begin
  inherited Create(AParent);
Image := form1.DXImageList1.Items.Find('������������');
  Width :=Image.Width ;
  Height :=Image.Height ;

end;

constructor TBoom.Create(AParent: TSprite);
begin
  inherited Create(AParent);
Image := form1.DXImageList1.Items.Find('Boom');
  Width := Image.Width;
  Height := Image.Height;
  AnimCount := Image.PatternCount;
  Animpos:=0;
end;

constructor TBoom1.Create(AParent: TSprite);
begin
  inherited Create(AParent);
Image := form1.DXImageList1.Items.Find('�����1');
  Width := Image.Width;
  Height := Image.Height;
  AnimCount := Image.PatternCount;
  Animpos:=0;
end;

constructor TPlayer1.Create(AParent: TSprite);
begin
  inherited Create(AParent);
Image := form1.DXImageList1.Items.Find('Ship2');
  Width := Image.Width;
  Height := Image.Height;
  AnimCount := Image.PatternCount;
  Animpos:=0;

end;

constructor Thealth.Create(AParent: TSprite);
begin
  inherited Create(AParent);
  Image := form1.DXImageList1.Items.Find('�����������');
  Width := Image.Width;
  Height := Image.Height;
  AnimCount := 5;
  Animpos:=0;
end;

procedure TForm1.DXTimer1Timer(Sender: TObject; LagCount: Integer); // !!!!��� ��� ������ �����!!!!
begin

polet:=polet+1;
If shitpoints > 0 then begin

end;

//��� ���� ���� ����������� �� ����������� �� �� �������� �������� � ������ ��� ��������� ������� �����
DXDraw.Surface.Fill(0); // ����������� ��� ������
DXSpriteEngine.Move(0); // ������ ��� ��������� DOMove
DXSpriteEngine.Dead;  // ������� ��� �������
DXSpriteEngine.Draw;  // ������ ����� �������
DXInput1.Update;   // ��������� ����������
/////////////////////////////////////////////////////////

with Form1.DXDraw.Surface.Canvas do  //��� ��������� ����� \/
 begin
  Brush.Style:= bsClear;
  Font.Color:=clWhite;
  Font.Size:=10;
  Font.Name:='Arial';
  Textout(2,0,'����������: �������-��������, ������-��������. ��� ������ ����� ������� 150 �����.');
  Textout(2,12,'FPS:'+inttostr(Form1.DXTimer1.FrameRate));
  Font.Color:=clAqua;
  Textout(2,24,'����:'+inttostr(score));
   Textout(2,36,'����� - DRON, Van, ARS');
   // ��� � ������� ������, �� ������� �������� � �������� ������ =]

      if (score< - 20) and (score> - 30)then begin
   Font.Size:=20;
     Font.Color:=clRed;
   Textout(200,200,'�� �� ������ ����������');
end;

   if (score< - 50) and (score> - 70) then begin
   Font.Size:=20;
     Font.Color:=clRed;
   Textout(200,200,'����������?)');
end;

   if score>110then begin
   Font.Size:=20;
     Font.Color:=clRed;
   Textout(200,200,'�� �� ������ ���� ');
end;

if (score>10) and (score<15) then begin
   Font.Size:=20;
     Font.Color:=clGreen;
   Textout(200,200,'����� ������ �����!');
end;

if (score>20) and (score<25) then begin
   Font.Size:=20;
     Font.Color:=clYellow;
   Textout(200,200,'�� �� �� ���� ');
end;

if (score>50) and (score<55) then begin
   Font.Size:=20;
     Font.Color:= RGB(123, 34, 38);
   Textout(200,200,'�� ������ ��� ����!');
end;

if (score>70) and (score<75) then begin
   Font.Size:=20;
     Font.Color:=clBlue;
   Textout(200,200,'�� ��� ����-����!');
end;

if (score>85) and (score<90) then begin
   Font.Size:=20;
     Font.Color:=clWhite;
   Textout(200,200,'�� ������ � ������!');
end;

if (score>100) and (score<110) then begin
   Font.Size:=20;
     Font.Color:=clRed;
   Textout(200,200,'������ ����� �����!');
end;

if (score>120) and (score<130) then begin
   Font.Size:=20;
     Font.Color:=clRed;
   Textout(200,200,'��� �� ������!');
end;

if (score>145) and (score<150) then begin
   Font.Size:=20;
     Font.Color:=clRed;
   Textout(200,200,'�� ������ ���� ���� � ������!');
end;

  Release; // ������ ����������� ����� ������ ������!!!
  end;

DXDraw.Flip;  // ������� ��� ��� ������������ �� ����� =) !!!!������ ����������� �� ����� 1 ���� � �����!!!
end;


// ���� ���� ����� ����� �� ��������� � ����� �

{PS. � ��������� DXSpriteEngine � DXImageList � �������� DXDraw ����� ������� �� DXDraw �� ������ ����� ����������
�������. � �������� DXWavList DXSound ����� ������� ��� DXSound ������� � ����� ������ �����. ��� � ���
������� ���� �� ����� � ������� � ������� ��� �� ���� ����! ���! BYE! }

procedure TForm1.FormCreate(Sender: TObject);
begin

left:=0;
top:=0;
DXDraw.cursor:=crnone;
 weapon:=1;
mediaplayer1.FileName:=ExtractFilepath(Application.exename)+'music.mid';
mediaplayer1.Open;
mediaplayer1.Play;
hitpoints := 100;
shitpoints := 0;



i := 0;
end;

procedure TForm1.Timer1Timer(Sender: TObject);
var
i : integer;
begin
alldead:=false;
if score<=0 then timer1.Interval:=800;
if score>20 then timer1.Interval:=800;
if score>40 then timer1.Interval:=600;
if score>60 then timer1.Interval:=400;
if score>80 then timer1.Interval:=300;
if score>100 then timer1.Interval:=150;

if score>=150 then begin
score:=149;
dxtimer1.Enabled:=false;
showmessage('�� ������� �����-����� ������ ���� ���� ������ � �������! =-)');
close;
end;


i:=random(45);

if i=5 then
with TB1.create(form1.DXSpriteEngine.engine) do
 begin
      x:=random (dxdraw.Display.Width - 128);
      y:=0;
end;

if i=10 then
with TB2.create(form1.DXSpriteEngine.engine) do
 begin
      x:=random (dxdraw.Display.Width - 128);
      y:=0;
end;

if i=15 then
with TB3.create(form1.DXSpriteEngine.engine) do
 begin
      x:=random (dxdraw.Display.Width - 128);
      y:=0;
end;

if i=19 then
with TB4.create(form1.DXSpriteEngine.engine) do
 begin
      x:=random (dxdraw.Display.Width - 128);
      y:=0;
end;

if i=25 then
with TBp.create(form1.DXSpriteEngine.engine) do
 begin
      x:=random (dxdraw.Display.Width - 128);
      y:=0;
end;

If i = 35 then
with TBs.create(form1.DXSpriteEngine.engine) do
 begin
      x:=random (dxdraw.Display.Width - 128);
      y:=0;
end;

If i = 30 then
with TBc.create(form1.DXSpriteEngine.engine) do
 begin
      x:=random (dxdraw.Display.Width - 128);
      y:=0;
end;

with TShip.create(form1.DXSpriteEngine.engine) do
 begin
      x:=random (dxdraw.Display.Width - 128);
      y:=0;
end;

with TShip1.create(form1.DXSpriteEngine.engine) do
 begin
      x:=random (dxdraw.Display.Width - 128);
      y:=0;
end;

end;

procedure TForm1.Timer2Timer(Sender: TObject);
begin
immortal:=0;
polet:=0;
weapon:=1;
hitpoints := 100;
with TPlayer1.create(form1.DXSpriteEngine.engine) do
 begin
      x:=320;
      y:=dxdraw.Display.Height - 40;

end;
timer2.Enabled:=false;
end;


procedure TForm1.MediaPlayer1Notify(Sender: TObject);
begin
with MediaPlayer1 do
if NotifyValue = nvSuccessful then
begin
Notify := True;
Play;
end;

end;

procedure TForm1.FormKeyUp(Sender: TObject; var Key: Word;
  Shift: TShiftState);
begin
if key=Vk_escape then close;
end;

procedure TForm1.FormClose(Sender: TObject; var Action: TCloseAction);
begin
dxtimer1.Enabled:=false;
Showmessage ('������ � ������� ����� � � ����� �������� ���������� ����� ������� ��� ����! PS. �� �������� ����� �� http://dronprogs.narod.ru');
end;


end.
