unit tocki2;

interface

uses SysUtils, Windows, Classes, Controls, Keyboard2, GR32, GR32_Image, GR32_Polygons, GR32_RotLayer;

type

PBitmap = ^TBitmap32;

TSize = record
x , y : word;
end;

TPoints = array of TPoint;

P2dpos = ^T2dpos;
T2dpos = record
x, y : integer;
end;

T2dar = array of T2dpos;

TPole = class;
TGamePole = class;

TPlayer = class
protected
FName : string;
FColor, FConturColor : TColor32;
Fradius : byte;
FFillColor : TColor32;
Fmouse : boolean;
FEnter, FMoveUp, FMoveDown, FMoveLeft, FMoveRight : word;
FTocka, FObvodka : word;
public

property Name  : string read FName  write FName ;
property Color : TColor32 read FColor write FColor;
property ConturColor : TColor32 read FConturColor write FConturColor;
property radius : byte read Fradius;
property FillColor : TColor32 read FFillColor write FFillColor;
property Mouse : boolean read FMouse write FMouse;
property MoveUp : word read FMoveUp write FMoveUp;
property MoveDown : word read FMoveDown write FMoveDown;
property MoveLeft : word read FMoveLeft write FMoveLeft;
property MoveRight : word read FMoveRight write FMoveRight;
property Enter : word read FEnter write FEnter;
property Obvodka : word read fobvodka write fobvodka;

constructor Create(); overload;
constructor Create(Name : string; Color, ConturColor : TColor32; Alpha, ConturAlpha : byte;
FillColor : TColor32; FillAlpha : byte; mouse : boolean;
MoveUp, moveDown, MoveLeft, MoveRight, enter, obvodka: integer); overload;
destructor Destroy(); override;
procedure SavePlayer(path : string);
procedure LoadPlayer(path, Name : string);
end;

TPlayers = array of TPlayer;

PTocka = ^TTocka;
TTocka = class
private
Fx, Fy, Fxpos, Fypos : smallint;
FEnable, Fbt, FUsed : boolean;
FPlayer : shortint;
FBasa : smallint;
FGamePole : ^TGamePole;
circle : TPolygon32;
procedure GetXY;
public
property x : smallint read Fx write Fx;
property y : smallint read Fy write Fy;
property xpos : smallint read Fxpos;
property ypos : smallint read Fypos;
property Enable : boolean read FEnable;
property Player : shortint read FPlayer write FPlayer;
property Basa : smallint read FBasa;

constructor Create(); overload;
constructor Create(xpos, ypos : word; Player : byte; Enable : boolean;
Basa : smallint; GamePole : TGamePole); overload;
constructor Create(tocka : TTocka); overload;
procedure Clear;
destructor Destroy(); override;
procedure DrawTocka(); overload;
procedure DrawTocka(x, y : smallint); overload;
end;

TTocki2d = array of array of TTocka;
TTocki1d = array of TTocka;

TPole = class
private
FName : string;
FWidth, FHeight : word;
FColor, FLineColor : TColor32;
FLineWidth : byte;
FKletkaSize : byte;
Fsize : TSize;
protected

public
FGamePole : ^TGamePole;
property Name : string read FName write FName;
property Width : word read FWidth;
property Height : word read FHeight;
property Color : TColor32 read FColor write FColor;
property LineColor : TColor32 read FLineColor write FLineColor;
property LineWidth : byte read FLineWidth write FLineWidth;
property KletkaSize : byte read FKletkaSize write FKletkaSize;
property Size : TSize read Fsize write Fsize;
constructor Create(); overload;
constructor Create(GamePole : TGamePole; Color, LineColor : TColor32; Alpha : byte;
LineWidth, KletkaSize : byte; size : TSize); overload;
constructor Create(name : string; Color, LineColor : TColor32; Alpha : byte;
LineWidth, KletkaSize : byte; size : TSize); overload;
destructor Destroy(); override;
procedure GetWidthAndHeight;
procedure SavePole(path : string);
procedure LoadPole(Path, Name: string);
procedure DrawPole;
end;

PBasa = ^Tbasa;
TBasa = class
private
FMinPos, FMaxPos : t2dpos;
FPlayer : byte;
FNumber : word;
FMax : word;
FTocki: t2dar;
FGamePole : ^TGamePole;
TockiInBase : T2dar;
Polygon : TPolygon32;

protected
procedure UpdateBasa;
function MinVInTockaAr(const n : word; const OnX : boolean = true) : word;
function MaxVInTockaAr(const n : word; const OnX : boolean = true) : word;
procedure FindAndDisableTockiInBase;
procedure FindLTandBPPos;
function IsItNilOrDisable : boolean;
procedure OptimizeBaseAr();

public
property Number : word read FNumber;
property Tocki : t2dar read Ftocki write FTocki;
constructor Create(); overload;
constructor Create(GamePole : TGamePole; Player : byte; Number : word; Tocki : t2dar); overload;
destructor Destroy(); override;

procedure DrawBasa();
//procedure SaveBasa(name : string);
end;

TGamePole = class
protected
FTocki : TTocki2d;
FTimeTocki : TTocki1d;
FPos : T2dpos;
FPlayers : TPlayers;
FFocusePlayer : byte;
FPole : TPole;
FBases : array of PBasa;
FOldCur : TPoint;
FWindow : TSize;
FLeft, FTop : smallint;
FCanvas : TBitmap32;
FCursor : TRotLayer;
FSnap : boolean;
{Auto Swith Players}
Faob : boolean;
{Задержка клавиатуры}
FZadKey : byte;
procedure CheckCursor;
public
function GetTocka(x, y : word) : TTocka;
procedure AddTocka(x, y : word; tocka: Ttocka);  overload;
property Tocki : TTocki2d read FTocki write FTocki;
property Players : TPlayers read FPlayers write FPlayers;
property FocusePlayer : byte read FFocusePlayer write FFocusePlayer;
property Pole : TPole read FPole write FPole;
property Cursor : TRotLayer read FCursor write FCursor;
property Pos : T2dpos read Fpos write fpos;
property Left : smallint read FLeft write FTop;
property Top : smallint read FTop write FTop;
property Canvas : TBitmap32 read FCanvas write FCanvas;
property Tocka[x, y : word]: TTocka read GetTocka write AddTocka;

property Snap : boolean read FSnap write FSnap default true;
property aob : boolean read Faob write Faob default true;
property ZadKey : byte read FZadKey write FZadKey;
property Window : TSize read FWindow write FWindow;

constructor Create(); overload;
constructor Create(Canvas : TImgView32; Size : TSize; Pole : TPole; Tocki : TTocki2d; Players : TPlayers;
FocusePlayer : byte; Snap, AutoSwichPlayers : boolean); overload;
destructor Destroy(); override;

procedure SaveGamePole(Name : string);
procedure LoadGamePole(Canvas : TImgView32; Name : string);

procedure DrawCursor();
procedure NextPlayer;
function CheckPlace(pos : T2dpos): boolean;

procedure AddTocka(pos : t2dpos; Player : byte); overload;
function GetTaroundT(pos : t2dpos; n : byte = 0; OnRight : boolean = true) : t2dpos;
function CheckTocka(xpos, ypos : smallint; Player : byte) : boolean;
function CheckTocka2(xpos, ypos : smallint; Player : byte) : boolean;
function CheckPos(xpos, ypos : integer) : boolean;
procedure CheckOnBase(bpos : t2dpos);
procedure CreateBasa(timetocki  : T2dar; Player : byte);

procedure UpdatePole();
end;

TGameTocki = class
private
Fmouse : boolean;
FScrollUp, FScrollDown, FScrollLeft, FScrollRight, FZoomIn, FZoomOut, FNextPlayer : word;
FCancel : word;
FGamePole : TGamePole;
FImage : ^TImgView32;
FSnap : boolean;
Faob : boolean;
FZadKey : byte;
procedure SetSnap(snap : boolean);
public

property GamePole : TGamePole read FGamePole write FGamePole;
property ZoomIn : word read FZoomIn write FZoomIn;
property ZoomOut : word read FZoomOut write FZoomOut;
property ScrollUp : word read FScrollUp write FScrollUp;
property ScrollDown : word read FScrollDown write FScrollDown;
property ScrollLeft : word read FScrollLeft write FScrollLeft;
property ScrollRight : word read FScrollRight write FScrollRight;
property NextPlayer : word read FNextPlayer write FNextPlayer;
procedure Image(image : TImgView32);
procedure SaveToFile(name : string);
procedure LoadFromFile(name : string);
property mouse : boolean read fmouse write fmouse;
property aob : boolean read faob write faob;
property snap : boolean read fsnap write SetSnap;

constructor Create(GamePole : TGamePole; image : TImgView32); overload;
constructor Create(); overload;
destructor Destroy(); override;

procedure Obvodka(x, y : word);
procedure OnMouseDown(x, y: smallint; button : TMouseButton);
procedure OnMouseMove(x, y: smallint);
procedure OnKeyDown(time : double);
end;

function MakeSize(x, y: word) : TSize;
function Make2dpos(x, y : smallint) : T2dpos; overload;
function Make2dpos(x, y : real) : T2dpos; overload;

function TockaToPoint(t : TTocka):TPoint;

function Distance(const p1, p2 : T2dpos) : single;

function GetFileName(name : string) : string;

const
PosNone : t2dpos = (x:-1; y:-1);
PosEmpty : t2dpos = (x:0; y:0);

var q: string;
MaxBaseSize : word;

implementation

var
RM : boolean;
TimeTocki : T2dar;
zad : word;
bp : ttocka;
TimePolygon : TPolygon32;

function GetPos(pos : t2dpos; x : smallint): t2dpos;
begin
case x of
-1: begin
result := pos;
end;
0: begin
result := Make2dpos(pos.x, pos.y - 1);
end;
1: begin
result := Make2dpos(pos.x + 1, pos.y - 1);
end;
2: begin
result := Make2dpos(pos.x + 1, pos.y);
end;
3: begin
result := Make2dpos(pos.x + 1, pos.y + 1);
end;
4: begin
result := Make2dpos(pos.x, pos.y + 1);
end;
5: begin
result := Make2dpos(pos.x - 1, pos.y + 1);
end;
6: begin
result := Make2dpos(pos.x - 1, pos.y);
end;
7: begin
result := Make2dpos(pos.x - 1, pos.y - 1);
end;
end;
end;

function pp(ot, t : t2dpos): smallint;
begin
result := -1;
if (t.x = ot.x) and (t.y = ot.y - 1) then begin
result := 0; exit;
end;
if (t.x = ot.x + 1) and (t.y = ot.y - 1) then begin
result := 1; exit;
end;
if (t.x = ot.x + 1) and (t.y = ot.y) then begin
result := 2; exit;
end;
if (t.x = ot.x + 1) and (t.y = ot.y + 1) then begin
result := 3; exit;
end;
if (t.x = ot.x) and (t.y = ot.y + 1) then begin
result := 4; exit;
end;
if (t.x = ot.x - 1) and (t.y = ot.y + 1) then begin
result := 5; exit;
end;
if (t.x = ot.x - 1) and (t.y = ot.y) then begin
result := 6; exit;
end;
if (t.x = ot.x - 1) and (t.y = ot.y - 1) then begin
result := 7; exit;
end;
end;

function GetFileName(name : string) : string;
begin
SetLength(name, Pos('.', name) -1);
result := name;
end;

procedure GRhorizLine(canvas : TBitmap32; x1, y1, x2, y2, w : integer; color : TColor32);
var i : word;
begin
for i := 0 to w div 2 do
canvas.LineTS(x1-i,y1,x2-i,y2, color);
for i := 0 to w div 2 do
canvas.LineTS(x1+i,y1,x2+i,y2, color);
end;

procedure GRVertLine(canvas : TBitmap32; x1, y1, x2, y2, w : integer; color : TColor32);
var i : word;
begin
for i := 0 to w div 2 do
canvas.LineTS(x1,y1-i,x2,y2-i, color);
for i := 0 to w div 2 do
canvas.LineTS(x1,y1+i,x2,y2+i, color);
end;

function PrepareCircleVertexes(xc, yc, radius : word) : t2dar;
var i : word;
a : real;
begin
a := radius*8;
SetLength(result, trunc(a));
a := 360/a;
for i := 0 to High(result) do begin
result[i].x := xc + round(radius*cos(a*i*pi/180));
result[i].y := yc + round(radius*sin(a*i*pi/180));
end;
end;

function DeleteFile(const FileName: string): Boolean;
begin
{$IFDEF MSWINDOWS}
  Result := Windows.DeleteFile(PChar(FileName));
{$ENDIF}
{$IFDEF LINUX}
  Result := unlink(PChar(FileName)) <> -1;
{$ENDIF}
end;

function BoolToByte(b : boolean) : byte;
begin
if b = true then result := 0 else result := 1;
end;

function ByteToBool(b : byte) : boolean;
begin
if b = 0 then result := true else result := false;
end;

{Check Base Sqvare}
function CheckBS(t : t2dar) : boolean;
var i, m : word;
begin
result := true;
m := high(t);
if m mod 2 <> 0 then begin
for i := 0 to m do begin
if (t[i].x = t[m - i].x) and (t[i].y = t[m - i].y) then continue
else begin result := false; exit; end;
end;
end else begin
for i := 0 to m - 1 do begin
if (t[i].x = t[m - 1 - i].x) and (t[i].y = t[m - 1 - i].y) then continue
else begin result := false; exit; end;
end;
end;
end;

procedure SumVInT(var t : TTocka; const value : smallint);
begin
t.fxpos := t.fxpos + value;
t.fypos := t.fypos + value;
end;

function Distance(const p1, p2 : T2dpos) : single;
begin
result := sqrt(sqr(p2.x - p1.x) + sqr(p2.y - p1.y));
end;

function TockaToPoint(t : TTocka):TPoint;
begin
result.X := t.x;
result.y := t.y;
end;

function Min2dpos(const t : t2dar) : t2dpos;
var
   i : Integer;
begin
   if Length(t)>0 then begin
      Result:= Make2dpos(t[0].x, t[0].y);
      for i:=1 to High(t) do begin
         if t[i].x < Result.x then Result.x := t[i].x;
         if t[i].y < Result.y then Result.y := t[i].y;
        end;
   end else Result:= PosNone;
end;


function Max2dpos(const t : t2dar) : t2dpos;
var
   i : Integer;
begin
   if Length(t)>0 then begin
      Result:= Make2dpos(t[0].x, t[0].y);
      for i:=1 to High(t) do begin
         if t[i].x > Result.x then Result.x := t[i].x;
         if t[i].y > Result.y then Result.y := t[i].y;
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

function Make2dpos(x, y :real) : T2dpos;
begin
result.x := round(x);
result.y := round(y);
end;

constructor TPlayer.Create();
begin
inherited;
end;

constructor TPlayer.Create(Name : string; Color, ConturColor : TColor32; Alpha, ConturAlpha : byte;
FillColor : TColor32; FillAlpha : byte; mouse : boolean; MoveUp, moveDown, MoveLeft, MoveRight, enter, obvodka: integer);
begin
inherited Create;
FName := name;
FColor := Color;
FConturColor := ConturColor;
FColor := SetAlpha(FColor, alpha);
FConturColor := SetAlpha(FConturColor, ConturAlpha);
FFillColor := FillColor;
FFillColor := SetAlpha(FFillColor, FillAlpha);
FMouse := mouse;
FMoveUp := MoveUp;
FMoveDown := MoveDown;
FMoveLeft := MoveLeft;
FMoveRight := MoveRight;
FEnter := Enter;
FObvodka := obvodka;
end;

destructor TPlayer.Destroy();
begin
inherited;
end;

procedure TPlayer.SavePlayer(path : string);
var f : TextFile;
begin
AssignFile(f, path + FName + '.player');
Rewrite(f);
Write(f, Color, ' ', ConturColor, ' ',
' ' , FillColor,' ', BoolToByte(mouse),' ', movedown,' ', moveup,' ',moveleft,' ', moveright,' ',enter,' ',obvodka);
CloseFile(f);
end;

procedure TPlayer.LoadPlayer(Path, Name: string);
var f : TextFile;
b : integer;
begin
Assign(f, Path + Name + '.player');
Reset(f);
ReadLn(f, FColor, FConturColor, FFillColor, b, fmovedown, fmoveup, fmoveleft, fmoveright, fenter, FObvodka);
mouse := ByteToBool(b);
FName := name;
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
circle := TPolygon32.Create;
end;

constructor TTocka.Create(xpos, ypos : word; Player : byte;
Enable : boolean; Basa : smallint; GamePole : TGamePole);
var p : t2dar;   i : word;
begin
inherited Create;
Fbasa := Basa;
fxpos := xpos;
fypos := ypos;
fPlayer := Player;
fenable := enable;
New(FGamePole);
FGamePole^ := GamePole;
GetXY;
circle := TPolygon32.Create;
p := PrepareCircleVertexes(fx, fy, fgamepole^.Pole.KletkaSize div 4);
for i := 0 to High(p) do
circle.Add(FixedPoint(p[i].x, p[i].y));
end;

constructor TTocka.Create(tocka : TTocka);
begin
inherited Create;
self := tocka;
end;

procedure TTocka.Clear;
begin
circle.Clear;
circle := TPolygon32.Create;
end;

destructor TTocka.Destroy();
begin
Dispose(FGamePole);
FBasa := -1;
FEnable := false;
fx := 0;
fy := 0;
fxpos := 0;
fypos := 0;
FPlayer := -1;
inherited;
end;

constructor TPole.Create();
begin
inherited;
New(FGamePole);
end;

constructor TPole.Create(GamePole : TGamePole; Color, LineColor : TColor32; Alpha : byte;
LineWidth, KletkaSize : byte; size : TSize);
begin
inherited Create;
FColor := Color;
FLineColor := LineColor;
SetAlpha(FColor, alpha);
SetAlpha(FLineColor, alpha);
FLineWidth := LineWidth;
FKletkaSize := KletkaSize;
Fsize := size;
FWidth := KletkaSize*(FSize.x + 2);
FHeight := KletkaSize*(FSize.y + 2);
New(FGamePole);
fgamepole^ := GamePole;
FWidth := (size.x + 1) * KletkaSize;
FHeight := (size.y + 1) * KletkaSize;
end;

constructor TPole.Create(name : string; Color, LineColor : TColor32; Alpha : byte;
LineWidth, KletkaSize : byte; size : TSize);
begin
inherited Create;
FName := name;
FColor := Color;
FLineColor := LineColor;
FColor := SetAlpha(FColor, alpha);
FLineColor := SetAlpha(FLineColor, alpha);
FLineWidth := LineWidth;
FKletkaSize := KletkaSize;
Fsize := size;
Dispose(FGamePole);
New(FGamePole);
FGamePole^ := TGamePole.create;
FWidth := (size.x + 1) * KletkaSize;
FHeight := (size.y + 1) * KletkaSize;
end;

procedure TPole.GetWidthAndHeight;
begin
FWidth := (size.x + 1) * KletkaSize;
FHeight := (size.y + 1) * KletkaSize;
if FGamePole^.Canvas <> nil then
FGamePole^.Canvas.SetSize(FWidth, FHeight);
end;

destructor TPole.Destroy();
begin
inherited;
end;

constructor TGamePole.Create();
begin
inherited;
FPole := TPole.Create;
FTocki := nil;
FPlayers := nil;
FBases := nil;
FFocusePlayer := 0;
fcanvas.Free;
fcursor.Free;
end;

constructor TGamePole.Create(Canvas : TImgView32; Size : TSize; Pole : TPole; Tocki : TTocki2d; Players : TPlayers;
FocusePlayer : byte; Snap, AutoSwichPlayers : boolean);
begin
inherited Create;
FPole := Pole;
pole.FGamePole^ := self;
FTocki := Tocki;
FPlayers := Players;
FFocusePlayer := FocusePlayer;
SetLength(FTocki, pole.size.x + 1, pole.size.y + 1);
FWindow.x := Size.x;
FWindow.y := Size.y;
fsnap := snap;
faob := AutoSwichPlayers;

Canvas.Layers.Clear;
FCanvas := TBitmap32.Create;
FCanvas := Canvas.Bitmap;
FCanvas.SetSize(pole.Width, pole.Height);
FCursor := TRotLayer.create(canvas.Layers);
cursor.Bitmap.SetSize(pole.KletkaSize, pole.KletkaSize);
cursor.Bitmap.DrawMode := dmBlend;
drawCursor;
SetLength(FBases, 0);
end;

destructor TGamePole.Destroy();
begin
if self <> nil then begin
FPole := nil;
FTocki := nil;
FPlayers := nil;
FBases := nil;
//FCursor.Free;
FFocusePlayer := 0;
//fcanvas.Free;
inherited;
end;
end;

procedure TGamePole.NextPlayer;
begin
If FocusePlayer <> high(players) then
FocusePlayer := FocusePlayer + 1 else FocusePlayer := 0;
end;

function TGamePole.CheckPlace(pos : T2dpos): boolean;
begin
if (pos.x > Pole.size.x - 1) or (pos.x < 0) or
(pos.y > Pole.size.y - 1) or (pos.y < 0) then result := false
else if Tocki[pos.x, pos.y] = nil then result := true else result := false;
end;

function TGamePole.GetTocka(x, y : word) : TTocka;
begin
if (CheckPos(x, y) = true) and (RM = false) then begin
result :=  FTocki[x, y];
end else result := nil;
end;


procedure TGamePole.AddTocka(x, y : word; tocka : TTocka);
begin
if (CheckPlace(Make2dpos(x, y)) = true) and (RM = false) then begin
FTocki[x, y] := TTocka.Create(x, y, FocusePlayer, true, -1, self);
FTocki[x, y].DrawTocka;
CheckOnBase(pos);
NextPlayer;
end;
end;

procedure TGameTocki.SetSnap(snap : boolean);
begin
fsnap := snap;
if gamepole <> nil then fgamepole.snap := snap;
end;

procedure TGamePole.AddTocka(pos : t2dpos; Player : byte);
begin
if (CheckPlace(pos) = true) and (RM = false) then begin
FTocki[pos.x, pos.y] := TTocka.Create(pos.x, pos.y, Player, true, -1, self);
FTocki[pos.x, pos.y].DrawTocka;
CheckOnBase(pos);
NextPlayer;
end;
end;

function TGamePole.CheckTocka(xpos, ypos : smallint; Player : byte) : boolean;
begin
result := false;
if (xpos <= pole.Size.x) and (ypos <= pole.Size.y) and (xpos >=0) and (ypos >=0) then begin
If Tocki[xpos, ypos] <> nil then begin
If (Tocki[xpos, ypos].Enable = true) and (Tocki[xpos, ypos].Player = Player) then
result := true;
end;
end;
end;

function TGamePole.CheckTocka2(xpos, ypos : smallint; Player : byte) : boolean;
begin
result := false;
if (xpos <= pole.Size.x) and (ypos <= pole.Size.y) and (xpos >=0) and (ypos >=0) then begin
If Tocki[xpos, ypos] <> nil then begin
If (Tocki[xpos, ypos].Enable = true) and (Tocki[xpos, ypos].Player = Player)
and (Tocki[xpos, ypos].fused = false) then
result := true;
end;
end;
end;

function TGamePole.CheckPos(xpos, ypos : integer) : boolean;
begin
result := true;
if (pos.x > Pole.size.x - 1) or (pos.x < 0) or
(pos.y > Pole.size.y - 1) or (pos.y < 0) then result := false;
end;

function TGamePole.GetTaroundT(pos : t2dpos; n : byte = 0; OnRight : boolean = true) : t2dpos;
var p : t2dpos;
    n1 : byte;
begin
result := pos;
if onright = true then n1 := n + 1 else n1 := n - 1;
if n1 = 8 then n1 := 0;
if n1 = -1 then n1 := 7;

while n1 <>  n do begin
p := GetPos(pos, n1);
if CheckTocka(p.x, p.y, Tocki[pos.x, pos.y].player) = true then begin
result := p;
exit;
end else begin
if onright = true then n1 := n1 + 1 else n1 := n1 - 1;
if n1 = 8 then n1 := 0;
if n1 = -1 then n1 := 7;
end;
end;

if n1 = n then begin
p := GetPos(pos, n1);
if CheckTocka(p.x, p.y, Tocki[pos.x, pos.y].player) = true then
result := p;
end;

end;

procedure TGamePole.CheckOnBase(bpos : t2dpos);
function sravn(p, p1 : t2dpos) : boolean;
begin
if (p.x = p1.x) and (p.y = p1.y) then result := true else result := false;
end;

var p, p1 : t2dpos;
    a : t2dar;
    b : smallint;
begin
p := bpos;
p1 := GetTAroundT(p);
SetLength(a, 1);
a[0] := bpos;
while sravn(p1, bpos) = false do begin
b := pp(p1, p);
b := b + 1;
if b = 8 then b := 0;
SetLength(a, length(a) + 1);
a[High(a)] := p1;
p := p1;
p1 := GetTaroundT(p, b);
end;

if (p1.x = bpos.x) and (p1.y = bpos.y) then begin
CreateBasa(a, Tocki[bpos.x, bpos.y].Player);
end;
end;

procedure TGamePole.CheckCursor;
begin
end;

procedure TGamePole.DrawCursor();
var a : t2dar;
i : word;
p : TPolygon32;
begin
p := TPolygon32.Create;
cursor.BeginUpdate;
cursor.Bitmap.Clear(SetAlpha($ffffff, 0));
cursor.Bitmap.EndUpdate;
cursor.Bitmap.Changed;
a := PrepareCircleVertexes(round(cursor.Bitmap.Width/2), round(cursor.Bitmap.Height/2), trunc(1/3 * pole.KletkaSize));
for i := 0 to High(a) do
p.Add(FixedPoint(a[i].x, a[i].y));
p.Draw(cursor.Bitmap, players[focuseplayer].Color, SetAlpha($000000, 0));
end;

procedure TGamePole.CreateBasa(timetocki : T2dar; Player : byte);
var i : word;
basa1 : TBasa;
begin
basa1 := TBasa.Create(self, Player, 0, timetocki);
basa1.OptimizeBaseAr;
if basa1.IsItNilOrDisable = false then begin
SetLength(FBases, Length(FBases) + 1);
New(FBases[high(FBases)]);
for i := 0 to High(basa1.FTocki) do
FTocki[basa1.FTocki[i].x, basa1.FTocki[i].y].FBasa := high(FBases);
FBases[high(FBases)]^ := TBasa.Create(self, Player, high(FBases), basa1.FTocki);
FBases[high(FBases)]^.UpdateBasa;
UpdatePole;
end;
end;

procedure TGamePole.UpdatePole();
var i, i1 : word;
begin
Fcanvas.Clear(SetAlpha($ffffff, 0));
pole.DrawPole;
if Length(FBases) <> 0 then begin
for i := high(Fbases) downto 0  do
FBases[i].DrawBasa;
end;
for i := 0 to pole.size.x do begin
 for i1 := 0 to pole.size.y do begin
  if Tocki[i, i1] <> nil then
   Tocki[i, i1].DrawTocka;
 end;
end;
end;

procedure TTocka.DrawTocka();
var i : word; p : t2dar;
begin
if (player <> 127)  then begin
p := PrepareCircleVertexes(x, y, fgamepole^.Pole.KletkaSize div 4);
circle.Clear;
for i := 0 to High(p) do
circle.Add(FixedPoint(p[i].x, p[i].y));
circle.Outline.Grow(fgamepole.Pole.LineWidth);
circle.Draw(fgamepole^.Canvas, fgamepole^.Players[Player].ConturColor,
fgamepole^.Players[Player].Color);
end;
end;

procedure TTocka.DrawTocka(x, y : smallint);
var  i : word;
p : t2dar;
begin
if (player <> 127) then begin
p := PrepareCircleVertexes(x, y, fgamepole^.Pole.KletkaSize div 4);
for i := 0 to High(p) do
circle.Add(FixedPoint(p[i].x, p[i].y));
circle.Outline.Grow(fgamepole.Pole.LineWidth);
circle.Draw(fgamepole^.Canvas, fgamepole^.Players[Player].ConturColor,
fgamepole^.Players[Player].Color);
end;
end;

procedure TTocka.GetXY;
begin
x := (xpos + 1) * fgamepole.pole.KletkaSize;
y := (ypos + 1) * fgamepole.pole.KletkaSize;   
end;

procedure TGamePole.SaveGamePole(Name : string);
var f : TextFile;
    i, i1, s : smallint;
begin
AssignFile(f, Name + '.tocki');
Rewrite(f);
s := -1;
for i := 0 to Pole.size.x do begin
 for i1 := 0 to Pole.size.y do
 if Tocki[i, i1] <> nil then
 s := s + 1;
end;
WriteLn(f, s,' ', pole.size.x,' ', pole.size.y,' ', High(players),' ', length(FBases)-1,' ',
FocusePlayer);
for i := 0 to High(Players) do begin
WriteLn(f, Players[i].name);
Players[i].SavePlayer('Игроки\');
end;
WriteLn(f, pole.name);
pole.SavePole('Поля\');
for i := 0 to Pole.size.x do begin
 for i1 := 0 to Pole.size.y do begin
 if Tocki[i, i1] <> nil then
 WriteLn(f, i, ' ', i1, ' ', Tocki[i, i1].Player,' ',
 BoolToByte(Tocki[i, i1].enable),' ', Tocki[i, i1].basa);
end;
end;
for i := 0 to high(Fbases) do begin
WriteLn(f, FBases[i]^.Number,' ', FBases[i]^.FPlayer, ' ', High(FBases[i]^.FTocki));
for i1 := 0 to High(FBases[i]^.FTocki) do
 WriteLn(f, FBases[i]^.FTocki[i1].x, ' ', FBases[i]^.FTocki[i1].y);
end;
CloseFile(f);
end;

procedure TGamePole.LoadGamePole(Canvas : TImgView32; Name : string);
var f : TextFile;
    s, a, b, c, i, i1, fp, fb, px, py : smallint;
    art : t2dar;
    b1, b2 : byte;
begin
if self <> nil then
self.Destroy;
self := TGamePole.Create();
fcanvas := canvas.Bitmap;
if canvas.Layers.Count > 0 then
Canvas.Layers.Delete(0);
FCursor := TRotLayer.create(canvas.Layers);

Assign(f, Name + '.tocki');
Reset(f);
ReadLn(f, s, px, py, a, c, FFocusePlayer);
setLength(FBases, c+1);
SetLength(FTocki, px + 1, py + 1);
SetLength(Fplayers, a + 1);

for i := 0 to a do  begin
Players[i] := TPlayer.Create();
ReadLn(f, Players[i].Fname);
Players[i].LoadPlayer('Игроки\', Players[i].name);
end;

pole := TPole.Create();
ReadLn(f, pole.fname);
pole.LoadPole('Поля\', pole.name);
pole.FGamePole^ := self;

FCanvas.SetSize(pole.Width, pole.Height);
cursor.Bitmap.SetSize(pole.KletkaSize, pole.KletkaSize);
cursor.Bitmap.DrawMode := dmBlend;

for i := 0 to s do begin
ReadLn(f, a,  b,  fp, b1, fb);
Tocki[a, b] := TTocka.Create(a,b,fp,ByteToBool(b1), fb,self);
end;
if c <> -1 then begin
for i := 0 to c do begin
ReadLn(f, s, fp, fb);
New(FBases[i]);
SetLength(art, fb+1);
for i1 := 0 to fb do begin
ReadLn(f, px, py);
art[i1] := Make2dpos(px, py);
end;
FBases[i]^ := TBasa.Create(self, fp, s, art);
New(FBases[i]^.FGamePole);
FBases[i]^.FGamePole^ := self;
FBases[i]^.FNumber := s;
FBases[i]^.FPlayer := fp;
FBases[i].UpdateBasa;
end;
end;
CloseFile(f);
end;

procedure TPole.SavePole(path : string);
var f : TextFile;
begin
AssignFile(f, path + Name + '.pole');
Rewrite(f);
WriteLn(f, Color,' ', LineColor,' ',
LineWidth,' ', KletkaSize,' ', size.x,' ', size.y);
CloseFile(f);
end;

procedure TPole.LoadPole(Path, Name : string);
var f : TextFile;
begin
Assign(f, path + name + '.pole');
Reset(f);
FName := Name;
ReadLn(f, FColor, FLineColor, FLineWidth, FKletkaSize, Fsize.x, Fsize.y);
FWidth := (size.x + 1) * KletkaSize;
FHeight := (size.y + 1) * KletkaSize;
CloseFile(f);
end;

procedure TPole.DrawPole;
var i : integer;
begin
with fgamepole^.canvas do begin
BeginUpdate;
FillRectTS(fgamepole^.Left, fgamepole^.Top, fgamepole^.Left + KletkaSize*(size.x + 1), fgamepole^.Top + KletkaSize*(size.y + 1), color);
for i := 1 to size.x do
GRHorizline(fgamepole^.canvas, fgamepole^.Left + KletkaSize * i, fgamepole^.Top + KletkaSize, fgamepole^.Left + KletkaSize * i, fgamepole^.Top + KletkaSize*size.y, LineWidth, LineColor);
for i := 1 to size.y do
GRVertline(fgamepole^.canvas, fgamepole^.Left + KletkaSize, fgamepole^.Top + KletkaSize * i, fgamepole^.Left + KletkaSize*size.x, fgamepole^.Top + KletkaSize * i, LineWidth, LineColor);
EndUpdate;
Changed;
end;
end;

{procedure TBasa.SaveBasa(name : string);
begin

end;}

constructor TBasa.Create();
begin
FMaxPos := posEmpty;
FMinPos := posEmpty;
FPlayer := 0;
Polygon := TPolygon32.Create;
end;

constructor TBasa.Create(GamePole : TGamePole; Player : byte; Number : word; Tocki : t2dar);
var i : word;
begin
FPlayer := Player;
FNumber := Number;
New(FGamePole);
FGamePole^ := GamePole;
SetLength(FTocki, High(Tocki)+1);
Polygon := TPolygon32.Create;
for i := 0 to High(Tocki) do begin
FTocki[i] := Tocki[i];
polygon.Add(FixedPoint(FTocki[i].x * GamePole.Pole.KletkaSize + GamePole.Pole.KletkaSize, FTocki[i].y * GamePole.Pole.KletkaSize + GamePole.Pole.KletkaSize));
end;
//DrawBasa;
end;

destructor TBasa.Destroy();
begin
Polygon.Free;
FGamePole.UpdatePole;
Dispose(FGamePole);
inherited;
end;

procedure TBasa.FindAndDisableTockiInBase;
var i, i1, min, max : word;
    posit, posit1 : T2dar;
begin
FindLTandBPPos;
if (FMaxPos.x - FMinPos.x = 1) or  (FMaxPos.x - FMinPos.x = 0) then exit;
for i := FMinPos.x + 1 to FMaxPos.x - 1 do begin
min := MinVInTockaAr(i);
max := MaxVInTockaAr(i);
for i1 := min + 1 to max - 1 do begin
if (Max - Min = 1) or (Max - Min = 0) then continue;
{if (FGamePole^.Tocki[i, i1] = nil) then
FGamePole^.Tocki[i, i1] := TTocka.Create(i, i1, 127,false,-1, FGamePole^);
If FGamePole^.Tocki[i1, i].Basa <> Number then
FGamePole^.Tocki[i, i1].FEnable := false;  }
SetLength(posit, length(posit) + 1);
posit[high(posit)] := Make2dpos(i, i1);
end;
end;

if (FMaxPos.x - FMinPos.x = 1) or  (FMaxPos.x - FMinPos.x = 0) then exit;
for i := FMinPos.y + 1 to FMaxPos.y - 1 do begin
min := MinVInTockaAr(i, false);
max := MaxVInTockaAr(i, false);
for i1 := min + 1 to max - 1 do begin
if (Max - Min = 1) or (Max - Min = 0) then continue;
{if (FGamePole^.Tocki[i1, i] = nil) then
FGamePole^.Tocki[i1, i] := TTocka.Create(i1, i, 127,false,-1, FGamePole^);
If FGamePole^.Tocki[i1, i].Basa <> Number then
FGamePole^.Tocki[i1, i].FEnable := false;       }
SetLength(posit1, length(posit1) + 1);
posit1[high(posit1)] := Make2dpos(i1, i);
end;
end;

for i := 0 to High(posit) do begin
 for i1 := 0 to High(posit1) do begin
 if (posit[i].x = posit1[i1].x) and (posit[i].y = posit1[i1].y) then begin
 SetLength(TockiInBase, length(TockiInBase) + 1);
 TockiInBase[high(TockiInBase)] := Make2dpos(posit[i].x, posit[i].y);
 end;
end;
end;

for i := 0 to high(TockiInBase) do begin
if FGamePole^.Tocki[TockiInBase[i].x, TockiInBase[i].y] = nil then
FGamePole^.Tocki[TockiInBase[i].x, TockiInBase[i].y] :=
TTocka.Create(TockiInBase[i].x, TockiInBase[i].y, 127,false,-1, FGamePole^);
if FGamePole^.Tocki[TockiInBase[i].x, TockiInBase[i].y].Basa <> number then
FGamePole^.Tocki[TockiInBase[i].x, TockiInBase[i].y].fenable := false;
end;
end;

function TBasa.IsItNilOrDisable : boolean;
var i, i1, min, max : word;
    posit, posit1 : T2dar;
begin
result := true;
FindLTandBPPos;
SetLength(TockiInBase, 0);
if (FMaxPos.x - FMinPos.x = 1) or  (FMaxPos.x - FMinPos.x = 0) then exit;
for i := FMinPos.x + 1 to FMaxPos.x - 1 do begin
min := MinVInTockaAr(i);
max := MaxVInTockaAr(i);
for i1 := min + 1 to max - 1 do begin
if (Max - Min = 1) or (Max - Min = 0) then continue;
SetLength(posit, length(posit) + 1);
posit[high(posit)] := Make2dpos(i, i1);
end;
end;

if (FMaxPos.x - FMinPos.x = 1) or  (FMaxPos.x - FMinPos.x = 0) then exit;
for i := FMinPos.y + 1 to FMaxPos.y - 1 do begin
min := MinVInTockaAr(i, false);
max := MaxVInTockaAr(i, false);
for i1 := min + 1 to max - 1 do begin
if (Max - Min = 1) or (Max - Min = 0) then continue;
SetLength(posit1, length(posit1) + 1);
posit1[high(posit1)] := Make2dpos(i1, i);
end;
end;

if (length(posit) <> 0) and (Length(posit1) <> 0) then begin
for i := 0 to High(posit) do begin
 for i1 := 0 to High(posit1) do begin
 if (posit[i].x = posit1[i1].x) and (posit[i].y = posit1[i1].y) then begin
 SetLength(TockiInBase, length(TockiInBase) + 1);
 TockiInBase[high(TockiInBase)] := Make2dpos(posit[i].x, posit[i].y);
 end;
end;
end;
end else exit;

if length(TockiInBase) <> 0 then begin
for i := 0 to high(TockiInBase) do begin
if (FGamePole^.Tocki[TockiInBase[i].x, TockiInBase[i].y] = nil) or
(FGamePole^.Tocki[TockiInBase[i].x, TockiInBase[i].y].Player = FPlayer) then continue
else begin
if (FGamePole^.Tocki[TockiInBase[i].x, TockiInBase[i].y]).Enable = true
then begin
result := false; exit;
end;
end;
end;
end;

end;

procedure AddTo2dAr(var ar : t2dar; p : t2dpos);
var a : word;
begin
a := length(ar);
SetLength(ar, a + 1);
ar[a] := p;
end;

procedure TBasa.OptimizeBaseAr();
label 1;
var ar1 : t2dar;
x, y : smallint;
i, i1 : word;
p : t2dpos;
begin
if length(ftocki) > 1 then begin
 x := 0;
 1:
 ar1 := ftocki;
 x := x + 1;
 if x >= high(ar1) - 1 then exit;
 p := ar1[x];
 for i := x+1 to high(ar1) do begin
  if (p.x = ar1[i].x) and (p.y = ar1[i].y) then begin
   y := i;
    SetLength(ftocki, x + 1);
    for i1 := 0 to x do
    ftocki[i1] := ar1[i1];
  for i1 := y + 1 to high(ar1) do begin
    SetLength(ftocki, length(ftocki) + 1);
    ftocki[high(ftocki)] := ar1[i1];
   end;
   goto 1;
  end;
 end;
end;
ar1 := nil;
for i := 0 to high(ftocki) do begin
if (fgamepole^.Tocki[ftocki[i].x, ftocki[i].y].Basa <> - 1) and
(fgamepole^.Tocki[ftocki[i].x, ftocki[i].y].Player = fplayer) and
(fgamepole^.Tocki[ftocki[i-1].x, ftocki[i-1].y].Basa = - 1)
then begin
ftocki[i] := posnone;
end;
end;
for i := 0 to high(ftocki) do begin
if ftocki[i].x <> -1 then
AddTo2dAr(ar1, ftocki[i]);
end;
ftocki := ar1;
end;

procedure TBasa.FindLTandBPpos;
begin
FMinPos := Make2dpos(Min2dpos(FTocki).x, Min2dpos(FTocki).y);
FMaxPos := Make2dpos(Max2dpos(FTocki).x, Max2dpos(FTocki).y);
end;

function TBasa.MinVInTockaAr(const n : word; const OnX : boolean = true) : word;
var i : word;
begin
if Length(tocki)>0 then begin
if onx = true then begin
for i:=0 to High(tocki) do begin
if tocki[i].x = n then begin
result := tocki[i].y;
break;
end;
end;
for i:=1 to High(tocki) do begin
   if tocki[i].x = n then
   if tocki[i].y < Result then Result := tocki[i].y;
end;

end else begin
for i:=0 to High(tocki) do begin
if tocki[i].y = n then begin
result := tocki[i].x;
break;
end;
end;
for i:=1 to High(tocki) do begin
   if tocki[i].y = n then
   if tocki[i].x < Result then Result := tocki[i].x;
end;
end;
end else result := 0;
end;

function TBasa.MaxVInTockaAr(const n : word; const OnX : boolean = true) : word;
var i : word;
begin
if Length(tocki)>0 then begin
if onx = true then begin
for i:=0 to High(tocki) do begin
if tocki[i].x = n then begin
result := tocki[i].y;
break;
end;
end;
for i:=1 to High(tocki) do begin
   if tocki[i].x = n then
   if tocki[i].y > Result then Result := tocki[i].y;
end;

end else begin
for i:=0 to High(tocki) do begin
if tocki[i].y = n then begin
result := tocki[i].x;
break;
end;
end;
for i:=1 to High(tocki) do begin
   if tocki[i].y = n then
   if tocki[i].x > Result then Result := tocki[i].x;
end;
end;
end else result := 0;
end;

procedure TBasa.DrawBasa();
begin
polygon.Draw(FGamePole^.Canvas, FGamePole.Players[FPlayer].ConturColor, FGamePole.Players[FPlayer].FFillColor);
end;

procedure TBasa.UpdateBasa;
begin
FindLTandBPPos;
FindAndDisableTockiInBase;
end;

constructor TGameTocki.Create(GamePole : TGamePole; image : TImgView32);
begin
inherited Create();
FGamePole := GamePole;
New(FImage);
FImage^ := TImgView32.Create(nil);
FImage^ := image;
end;

constructor TGameTocki.Create();
begin
FGAmePole := TGamePole.Create;
end;

destructor TGameTocki.Destroy();
begin
end;

procedure TGameTocki.Obvodka(x, y : word);
begin
 if bp <> nil then bp.Destroy();
 bp := TTocka.Create(round(x/GamePole.Pole.KletkaSize-0.5), round(y/GamePole.Pole.KletkaSize-0.5),
 GamePole.FocusePlayer, true, -1, gamepole);
  if (GamePole.CheckTocka(bp.xpos, bp.ypos, GamePole.FocusePlayer) = true) then begin
   if RM = true then begin
    If Distance(Make2dpos(bp.xpos,  bp.ypos), TimeTocki[High(TimeTocki)]) <= 1.5*GamePole.pole.KletkaSize then begin
     if (bp.xpos = TimeTocki[0].x) and (bp.ypos = TimeTocki[0].y) then begin
      GamePole.CreateBasa(TimeTocki, GamePole.FocusePlayer);
      RM := false;
      TimePolygon.Clear;
      gamepole.UpdatePole;
      exit;
     end;
     SetLength(TimeTocki, length(TimeTocki)+1);
     TimeTocki[High(TimeTocki)] := Make2dpos(bp.xpos, bp.ypos);
     TimePolygon.Add(FixedPoint(bp.x, bp.y));
     gamepole.UpdatePole;
     TimePolygon.Draw(gamepole.Canvas, gamepole.players[gamepole.FocusePlayer].ConturColor, SetAlpha(gamepole.players[gamepole.FocusePlayer].Color, 100));
    end else begin SetLength(TimeTocki,0); RM := false; TimePolygon.Clear; gamepole.UpdatePole; end;
   end else begin
    RM := true;
    SetLength(TimeTocki, 1);
    TimePolygon := TPolygon32.Create;
    TimeTocki[0] := Make2dpos(bp.xpos, bp.ypos);
    TimePolygon.Add(FixedPoint(bp.x, bp.y));
   end;
  end else begin SetLength(TimeTocki,0); RM := false; end;
end;

procedure TGameTocki.OnMouseDown(x, y: smallint; button : TMouseButton);
var  p : TPoint;
x1, y1 : smallint;
begin
x1 := X - gamepole.Pos.x;
y1 := y - gamepole.Pos.y;
 if button = mbleft then begin
   if RM = true then Obvodka(x1, y1) else
  gamepole.AddTocka(Make2dpos(round(x1/GamePole.Pole.KletkaSize-0.5), round(y1/GamePole.Pole.KletkaSize-0.5)), gamepole.focusePlayer);
//  gamepole.CheckOnBase(Make2dpos(round(x1/GamePole.Pole.KletkaSize-0.5), round(y1/GamePole.Pole.KletkaSize-0.5)));
 end;
 if button = mbright then
  Obvodka(x1, y1);
  gamepole.DrawCursor;
end;

procedure TGameTocki.Image(image : TImgView32);
begin
New(FImage);
FImage^ := TImgView32.Create(nil);
FImage^ := image;
end;

procedure TGameTocki.OnMouseMove(x, y : smallint);
var x1, y1 : smallint;
begin
if gamepole.Snap = true then begin
x1 := round(x / gamepole.Pole.KletkaSize);
y1 := round(y  / gamepole.Pole.KletkaSize);
{if (x1 <= 0) then x1 := 1;
if (y1 <= 0) then y1 := 1;
if (x1 > gamepole.pole.size.x) then x1 := gamepole.pole.size.x;
if (y1 > gamepole.pole.size.y) then y1 := gamepole.pole.size.y;  }
gamepole.Cursor.Position := floatpoint(x1*gamepole.Pole.KletkaSize + gamepole.Pole.KletkaSize, y1*gamepole.Pole.KletkaSize + gamepole.Pole.KletkaSize);
end else
gamepole.Cursor.Position := floatPoint(x, y);

{if (x <= gamepole.pole.Size.x) and (y <= gamepole.pole.Size.y) then begin
if gamepole.tocki[x - 1, y - 1] <> nil then
if gamepole.tocki[x - 1, y - 1].Enable = false then gamepole.FCursor := gamepole.FOldCur;
end;  }
{if gamepole.Snap = true then begin
GamePole.FCursor := Point(x * gamepole.Pole.KletkaSize, y * gamepole.Pole.KletkaSize) end else
GamePole.FCursor := Point(x , y);   }
{If RM = true then begin
if gamepole.FCursor.X >  TimeTocki[timer].X + gamepole.pole.KletkaSize then gamepole.FCursor.X := TimeTocki[timer].X + gamepole.pole.KletkaSize;
if gamepole.FCursor.Y >  TimeTocki[timer].Y + gamepole.pole.KletkaSize then gamepole.FCursor.Y := TimeTocki[timer].Y + gamepole.pole.KletkaSize;
if gamepole.FCursor.X <  TimeTocki[timer].X - gamepole.pole.KletkaSize then gamepole.FCursor.X := TimeTocki[timer].X - gamepole.pole.KletkaSize;
if gamepole.FCursor.Y <  TimeTocki[timer].Y - gamepole.pole.KletkaSize then gamepole.FCursor.Y := TimeTocki[timer].Y - gamepole.pole.KletkaSize;
end; }
end;

procedure TGameTocki.OnKeyDown(time : double);
var  x, y, i, i1 : word;
MiddlePos : t2dpos;
begin
{if zad = gamepole.zadkey + 1 then zad := 1;
zad := zad + 1;
if gamepole.zadkey <> 0 then
if zad mod gamepole.zadkey = 0 then begin  }

{if (IsKeyDown(ZoomIn)) and (GamePole.Pole.KletkaSize <= 100) then begin
MiddlePos := Make2dpos(-gamepole.Pos.x+gamepole.Window.x/2,
-gamepole.Pos.y + gamepole.Window.y/2);
q := FloatToStr(MiddlePos.x) + '  ' + FloatToStr(MiddlePos.y);
gamepole.Pole.KletkaSize := gamepole.Pole.KletkaSize+1;
gamepole.Pos := Make2dposf(MiddlePos.x/gamepole.Pole.KletkaSize*(gamepole.Pole.KletkaSize+1),
MiddlePos.y/gamepole.Pole.KletkaSize*(gamepole.Pole.KletkaSize+1)) ;

for i := 0 to gamepole.Pole.Size.x do begin
for i1 := 0 to gamepole.Pole.Size.y do begin
if gamepole.Tocki[i, i1] <> nil then
gamepole.Tocki[i, i1].GetXY;
end;
end;
end;
if (IsKeyDown(ZoomOut)) and (GamePole.Pole.KletkaSize >= 10) then  begin
gamepole.Pole.GetWidthAndHeight;
if gamepole.Pole.Width > gamepole.Window.x then
GamePole.Pole.KletkaSize := GamePole.Pole.KletkaSize - 1;
if gamepole.Pole.Height > gamepole.Window.y then
GamePole.Pole.KletkaSize := GamePole.Pole.KletkaSize - 1;
for i := 0 to gamepole.Pole.Size.x do begin
for i1 := 0 to gamepole.Pole.Size.y do begin
if gamepole.Tocki[i, i1] <> nil then
gamepole.Tocki[i, i1].GetXY;
end;
end;
end;              }

gamepole.Pole.GetWidthAndHeight;
if (IsKeyDown(ScrollUp)) and (GamePole.Pos.y < 0) then
GamePole.fpos.y := GamePole.fpos.y + 5;

if (IsKeyDown(ScrollDown)) and (GamePole.Pos.y > -(gamepole.Pole.Height - gamepole.Window.y)) then
GamePole.fpos.y := GamePole.fpos.y - 5;

if (IsKeyDown(ScrollLeft)) and (GamePole.Pos.x < 0) then
GamePole.fpos.x := GamePole.fpos.x + 5;

if (IsKeyDown(ScrollRight)) and (GamePole.Pos.x > -(gamepole.Pole.Width - gamepole.Window.x)) then
GamePole.fpos.x := GamePole.fpos.x - 5;

x := round(GamePole.cursor.Position.x / gamepole.Pole.KletkaSize-0.5);
y := round(GamePole.cursor.Position.y / gamepole.Pole.KletkaSize-0.5);
if IsKeyDown(gamepole.Players[gamepole.focuseplayer].MoveUp) and (GamePole.cursor.Position.y < gamepole.Pole.KletkaSize*GamePole.pole.Size.y)
then
GamePole.FCursor.Position := FloatPoint(x*gamepole.Pole.KletkaSize,y * gamepole.Pole.KletkaSize - gamepole.Pole.KletkaSize);
if IsKeyDown(gamepole.Players[gamepole.focuseplayer].MoveDown)  and (GamePole.cursor.Position.y > gamepole.Pole.KletkaSize)
then
GamePole.FCursor.Position := FloatPoint(x*gamepole.Pole.KletkaSize,y * gamepole.Pole.KletkaSize + gamepole.Pole.KletkaSize);
if IsKeyDown(gamepole.Players[gamepole.focuseplayer].MoveLeft) and (GamePole.cursor.Position.X > gamepole.Pole.KletkaSize)
then
GamePole.FCursor.Position := FloatPoint(x * gamepole.Pole.KletkaSize - gamepole.Pole.KletkaSize,y*gamepole.Pole.KletkaSize);
if IsKeyDown(gamepole.Players[gamepole.focuseplayer].MoveRight)  and (GamePole.cursor.Position.x < gamepole.Pole.KletkaSize*GamePole.pole.Size.x)
then
GamePole.FCursor.Position := FloatPoint(x * gamepole.Pole.KletkaSize + gamepole.Pole.KletkaSize,y*gamepole.Pole.KletkaSize);

{if IsKeyDown(gamepole.Players[gamepole.focuseplayer].Enter) then begin
GamePole.AddTocka(Make2dpos(x - 1, y - 1), GamePole.FocusePlayer);
if RM = true then Obvodka(x, y);
end;
if IsKeyDown(VK_Control) then
if RM <> true then
Obvodka(x, y)
else  RM := false;
end;       }

end;

procedure TGameTocki.SaveToFile(name : string);
var f : TextFile;
begin
assign(f, name);
rewrite(f);
Write(f,' ', ScrollUp,' ', ScrollDown,' ', ScrollLeft,' ', ScrollRight,' ', ZoomIn,' ', ZoomOut,' ',
NextPlayer,' ', BoolToByte(mouse),' ', BoolToByte(gamepole.fsnap),' ', BoolToByte(gamepole.faob));
closefile(f);
end;

procedure TGameTocki.LoadFromFile(name : string);
var f : TextFile;
b,b1,b2 : integer;
begin
assign(f, name);
reset(f);
Read(f, fScrollUp, fScrollDown, fScrollLeft, fScrollRight, fZoomIn, fZoomOut, fNextPlayer, b, b1, b2);
mouse := ByteToBool(b);
gamepole.fsnap := ByteToBool(b1);
gamepole.faob := ByteToBool(b2);
closefile(f);
end;

initialization
zad := 0;
MaxBaseSize := 50;
RM := false;

end.
