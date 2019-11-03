unit tocki;

interface

uses SysUtils, Windows, Classes, Keyboard, GR32, GR32_Image, GR32_Polygons, GR32_RotLayer;

type

TMouseButton = (mbLeft, mbRight, mbMiddle);

PBitmap = ^TBitmap32;

TSize = record
x , y : word;
end;

TPoints = array of TPoint;

P2dpos = ^T2dpos;
T2dpos = record
x, y : smallint;
end;

T2dposf = record
x, y : single;
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
constructor Create(); overload;
constructor Create(Name : string; Color, ConturColor : TColor32; Alpha, ConturAlpha : byte;
FillColor : TColor32; FillAlpha : byte); overload;
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
FTocki: TTocki1d;
FGamePole : ^TGamePole;
TockiInBase : T2dar;
Polygon : TPolygon32;
procedure UpdateBasa;
function MinVInTockaAr(const n : word; const OnX : boolean = true) : word;
function MaxVInTockaAr(const n : word; const OnX : boolean = true) : word;

public
property Number : word read FNumber;
property Tocki : TTocki1d read Ftocki write FTocki;
constructor Create(); overload;
constructor Create(GamePole : TGamePole; Player : byte; Number : word; Tocki : TTocki1d); overload;
destructor Destroy(); override;
procedure FindAndDisableTockiInBase;
procedure FindLTandBPPos;
procedure DrawBasa();
//procedure SaveBasa(name : string);
end;

TGamePole = class
protected
FTocki : TTocki2d;
FTimeTocki : TTocki1d;
FPos : T2dposf;
FPlayers : TPlayers;
FFocusePlayer : byte;
FPole : TPole;
FBases : array of PBasa;
FCursor, FOldCur : TPoint;
FSnap : boolean;
{Auto Swith Players}
Fasp : boolean;
{Задержка клавиатуры}
FZadKey : byte;
FWindow : TSize;
FLeft, FTop : smallint;
FCanvas : TBitmap32;
procedure CheckCursor;
public
function GetTocka(x, y : word) : TTocka;
procedure AddTocka(x, y : word; tocka: Ttocka);  overload;
property Tocki : TTocki2d read FTocki write FTocki;
property Players : TPlayers read FPlayers write FPlayers;
property FocusePlayer : byte read FFocusePlayer write FFocusePlayer;
property Pole : TPole read FPole write FPole;
property Cursor : TPoint read FCursor write FCursor;
property Pos : T2dposf read Fpos write fpos;
property ZadKey : byte read FZadKey write FZadKey;
property Left : smallint read FLeft write FTop;
property Top : smallint read FTop write FTop;
property Canvas : TBitmap32 read FCanvas write FCanvas;
property Tocka[x, y : word]: TTocka read GetTocka write AddTocka;

property Snap : boolean read FSnap write FSnap default true;
property Asp : boolean read Fasp write Fasp default true;

property Window : TSize read FWindow write FWindow;

constructor Create(); overload;
constructor Create(Canvas : TBitmap32; Size : TSize; Pole : TPole; Tocki : TTocki2d; Players : TPlayers;
FocusePlayer : byte); overload;
destructor Destroy(); override;

procedure SaveGamePole(Name : string);
procedure LoadGamePole(canvas : TBitmap32; Name : string);

procedure DrawCursor(canvas : TBitmap32);
procedure NextPlayer;
function CheckPlace(pos : T2dpos): boolean;

procedure AddTocka(pos : t2dpos; Player : byte); overload;
function CheckTaroundT(pos : t2dpos; Player : byte; n : byte = 0; OnRight : boolean = true) : t2dpos;
function CheckTocka(xpos, ypos : smallint; Player : byte) : boolean;
procedure CheckTocki(bpos : t2dpos);
procedure CreateBasa(tocki : TTocki1d; Player : byte);

procedure UpdatePole();
end;

TGameTocki = class
private
Fmouse : boolean;
FScrollUp, FScrollDown, FScrollLeft, FScrollRight, FZoomIn, FZoomOut : word;
FCancel : word;
FGamePole : TGamePole;
FImage : ^TImgView32;
public

property GamePole : TGamePole read FGamePole write FGamePole;
property ZoomIn : word read FZoomIn write FZoomIn;
property ZoomOut : word read FZoomOut write FZoomOut;
property ScrollUp : word read FScrollUp write FScrollUp;
property ScrollDown : word read FScrollDown write FScrollDown;
property ScrollLeft : word read FScrollLeft write FScrollLeft;
property ScrollRight : word read FScrollRight write FScrollRight;

constructor Create(Image : TImgView32; GamePole : TGamePole); overload;
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
function Make2dposf(x, y : real) : T2dposf;

function Min2dpos(const t : array of TTocka) : t2dpos;
function Max2dpos(const t : array of TTocka) : t2dpos;
function TockaToPoint(t : TTocka):TPoint;

function Distance(const p1, p2 : TTocka) : single;


function GetFileName(name : string) : string;

const
PosNone : t2dpos = (x:-1; y:-1);
PosEmpty : t2dpos = (x:0; y:0);

var q: string;
MaxBaseSize : word;

implementation

var
RM : boolean;
TimeTocki : TTocki1d;
zad : word;
bp : ttocka;
bases : smallint;
c : TRotLayer;
TimePolygon : TPolygon32;

function GetFileName(name : string) : string;
begin
SetLength(name, Pos('.', name) -1);
result := name;
end;

procedure GRhorizLine(canvas : TBitmap32; x1, y1, x2, y2, w : integer; color : TColor32; alpha : byte);
var i : word;
begin
canvas.ResetAlpha(alpha);
for i := 0 to w div 2 do
canvas.LineTS(x1-i,y1,x2-i,y2, color);
for i := 0 to w div 2 do
canvas.LineTS(x1+i,y1,x2+i,y2, color);
end;

procedure GRVertLine(canvas : TBitmap32; x1, y1, x2, y2, w : integer; color : TColor32; alpha : byte);
var i : word;
begin
canvas.ResetAlpha(alpha);
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

function Make2dposf(x, y : real) : T2dposf;
begin
result.x := x;
result.y := y;
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
function CheckBS(t : TTocki1d) : boolean;
var i, m : word;
begin
result := true;
m := high(t);
if m mod 2 <> 0 then begin
for i := 0 to m do begin
if (t[i].xpos = t[m - i].xpos) and (t[i].ypos = t[m - i].ypos) then continue
else begin result := false; exit; end;
end;
end else begin
for i := 0 to m - 1 do begin
if (t[i].xpos = t[m - 1 - i].xpos) and (t[i].ypos = t[m - 1 - i].ypos) then continue
else begin result := false; exit; end;
end;
end;
end;

procedure SumVInT(var t : TTocka; const value : smallint);
begin
t.fxpos := t.fxpos + value;
t.fypos := t.fypos + value;
end;

function Distance(const p1, p2 : TTocka) : single;
begin
result := sqrt(sqr(p2.x - p1.x) + sqr(p2.y - p1.y));
end;

function TockaToPoint(t : TTocka):TPoint;
begin
result.X := t.x;
result.y := t.y;
end;

function Min2dpos(const t : array of TTocka) : t2dpos;
var
   i : Integer;
begin
   if Length(t)>0 then begin
      Result:= Make2dpos(t[0].xpos, t[0].ypos);
      for i:=1 to High(t) do begin
         if t[i].xpos < Result.x then Result.x := t[i].xpos;
         if t[i].ypos < Result.y then Result.y := t[i].ypos;
        end;
   end else Result:= PosNone;
end;


function Max2dpos(const t : array of TTocka) : t2dpos;
var
   i : Integer;
begin
   if Length(t)>0 then begin
      Result:= Make2dpos(t[0].xpos, t[0].ypos);
      for i:=1 to High(t) do begin
         if t[i].xpos > Result.x then Result.x := t[i].xpos;
         if t[i].ypos > Result.y then Result.y := t[i].ypos;
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
FillColor : TColor32; FillAlpha : byte);
begin
inherited Create;
FName := name;
FColor := Color;
FConturColor := ConturColor;
SetAlpha(FColor, alpha);
SetAlpha(FConturColor, ConturAlpha);
FFillColor := FillColor;
SetAlpha(FFillColor, FillAlpha);
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
WriteLn(f, Color, ' ', ConturColor, ' ',
' ' , FillColor);
CloseFile(f);
end;

procedure TPlayer.LoadPlayer(Path, Name: string);
var f : TextFile;
begin
Assign(f, Path + Name + '.player');
Reset(f);
ReadLn(f, FColor, FConturColor, FFillColor);
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
if player <> 127 then
end;

constructor TTocka.Create(tocka : TTocka);
begin
inherited Create;
Fxpos := tocka.xpos;
Fypos := tocka.ypos;
Fx := tocka.x;
Fy := tocka.y;
FBasa := tocka.Basa;
FEnable := tocka.Enable;
FPlayer := tocka.Player;
new(FGamePole);
FGamePole := tocka.FGamePole;
circle := TPolygon32.Create;
GetXY;
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
FAlpha := Alpha;
FLineWidth := LineWidth;
FKletkaSize := KletkaSize;
Fsize := size;
FWidth := KletkaSize*(FSize.x + 2);
FHeight := KletkaSize*(FSize.y + 2);
New(FGamePole);
fgamepole^ := GamePole;
GetWidthAndHeight;
end;

constructor TPole.Create(name : string; Color, LineColor : TColor32; Alpha : byte;
LineWidth, KletkaSize : byte; size : TSize);
begin
inherited Create;
FName := name;
FColor := Color;
FLineColor := LineColor;
FAlpha := Alpha;
FLineWidth := LineWidth;
FKletkaSize := KletkaSize;
Fsize := size;
FWidth := KletkaSize*(FSize.x + 2);
FHeight := KletkaSize*(FSize.y + 2);
New(FGamePole);

GetWidthAndHeight;
end;

procedure TPole.GetWidthAndHeight;
begin
FWidth := (size.x + 1) * KletkaSize;
FHeight := (size.y + 1) * KletkaSize;
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
FCanvas := TBitmap32.Create;
end;

constructor TGamePole.Create(Canvas : TBitmap32; Size : TSize; Pole : TPole; Tocki : TTocki2d; Players : TPlayers;
FocusePlayer : byte);
begin
inherited Create;
FPole := Pole;
FTocki := Tocki;
FPlayers := Players;
FFocusePlayer := FocusePlayer;
SetLength(FTocki, pole.size.x + 1, pole.size.y + 1);
SetLength(FBases, MaxBaseSize);
FWindow.x := Size.x;
FWindow.y := Size.y;
FCanvas := TBitmap32.Create;
FCanvas := Canvas;
end;

destructor TGamePole.Destroy();
begin
FPole := nil;
FTocki := nil;
FPlayers := nil;
FFocusePlayer := 0;
//canvas.Free;
inherited;
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
if (CheckPlace(Make2dpos(x, y)) = true) and (RM = false) then begin
result :=  FTocki[x, y];
end else result := nil;
end;


procedure TGamePole.AddTocka(x, y : word; tocka : TTocka);
begin
if (CheckPlace(Make2dpos(x, y)) = true) and (RM = false) then begin
FTocki[x, y] := TTocka.Create(x, y, FocusePlayer, true, -1, self);
FTocki[x, y].DrawTocka;
if Asp = true then
NextPlayer;
end;
end;

procedure TGamePole.AddTocka(pos : t2dpos; Player : byte);
begin
if (CheckPlace(pos) = true) and (RM = false) then begin
FTocki[pos.x, pos.y] := TTocka.Create(pos.x, pos.y, Player, true, -1, self);
FTocki[pos.x, pos.y].DrawTocka;
if Asp = true then
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
var p : t2dpos;
    a : array[0..100] of t2dpos;
    i, player  : word;
begin
i := 0;
player := Tocki[bpos.x, bpos.y].Player;
p := bpos;
while (p.x <> -1) and (p.x <> bpos.x) and (p.x <> bpos.x) do begin
p := CheckTaroundT(bpos, player);
a[i] := p;
i := i + 1;
end;

if (p.x = bpos.x) and (p.y = bpos.y) then begin

end;

end;

procedure TGamePole.CheckCursor;
begin
end;

procedure TGamePole.DrawCursor(canvas : TBitmap32);
//var d : byte;
begin
{d := pole.KletkaSize div 3;
with canvas do begin
PenColor := Players[focuseplayer].Color;
PenAlpha := 200;
PenWidth := pole.LineWidth;
Circle(Cursor.X , Cursor.Y, d);
end;  }
end;

procedure TGamePole.CreateBasa(tocki : TTocki1d; Player : byte);
var i : word; 
begin
bases := bases + 1;
New(FBases[bases]);
for i := 0 to High(TimeTocki) do
FTocki[TimeTocki[i].xpos, TimeTocki[i].ypos].FBasa := bases;
FBases[bases]^ := TBasa.Create(self, Player, bases, tocki);
RM := false;
end;

procedure TGamePole.UpdatePole();
var i, i1 : word;
begin
pole.DrawPole;
{with canvas do begin
if RM  = true then begin
PenColor := Players[FocusePlayer].color;
PenAlpha := Players[FocusePlayer].Alpha;
PenWidth := pole.LineWidth;
for i := 0 to timer do begin
if i <> timer then
line(canvas, pos.x + TimeTocki[i].x, pos.y + TimeTocki[i].y,pos.x +  TimeTocki[i + 1].x,pos.y +  TimeTocki[i + 1].y,
pole.LineWidth, Players[FocusePlayer].color, Players[FocusePlayer].Alpha)
else
line(pos.x + TimeTocki[i].x, TimeTocki[i].y, Cursor.x, Cursor.y);
end;
end;   }
if bases <> -1 then
for i := 0 to bases do begin
FBases[i].DrawBasa;
end;
for i := 0 to pole.size.x do begin
 for i1 := 0 to pole.size.y do begin
  if (Tocki[i, i1] <> nil) and (Tocki[i, i1].Player <> 127) then
   Tocki[i, i1].DrawTocka;
 end;
end;
end;

procedure TTocka.DrawTocka();
var  i : word;
p : t2dar;
begin
p := PrepareCircleVertexes(fx, fy, fgamepole^.Pole.KletkaSize div 4);
with fgamepole^.canvas do begin
BeginUpdate;
for i := 0 to High(p) do
circle.Add(FixedPoint(p[i].x, p[i].y));
circle.DrawFill(fgamepole^.canvas, SetAlpha(fgamepole^.Players[FPlayer].Color, fgamepole^.Players[FPlayer].Alpha));
circle.Outline.Grow(fixed(fgamepole^.Pole.LineWidth), 0.5);
circle.DrawEdge(fgamepole^.canvas, SetAlpha(fgamepole^.Players[FPlayer].ConturColor, fgamepole^.Players[FPlayer].ConturAlpha));
endUpdate;
Changed;
end;
end;

procedure TTocka.DrawTocka(x, y : smallint);
var  i : word;
p : t2dar;
begin
p := PrepareCircleVertexes(x, y, fgamepole^.Pole.KletkaSize div 4);
with fgamepole^.canvas do begin
BeginUpdate;
for i := 0 to High(p) do
circle.Add(FixedPoint(p[i].x, p[i].y));
circle.DrawFill(fgamepole^.canvas, SetAlpha(fgamepole^.Players[FPlayer].Color, fgamepole^.Players[FPlayer].Alpha));
circle.Outline.Grow(fixed(fgamepole^.Pole.LineWidth), 0.5);
circle.DrawEdge(fgamepole^.canvas, SetAlpha(fgamepole^.Players[FPlayer].ConturColor, fgamepole^.Players[FPlayer].ConturAlpha));
endUpdate;
Changed;
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
AssignFile(f, Name);
Rewrite(f);
s := -1;
for i := 0 to Pole.size.x do begin
 for i1 := 0 to Pole.size.y do
 if Tocki[i, i1] <> nil then
 s := s + 1;
end;
WriteLn(f, s,' ', pole.size.x,' ', pole.size.y,' ', High(players),' ', bases,' ',
FocusePlayer,' ', BoolToByte(Snap),' ',BoolToByte(Asp));
for i := 0 to High(Players) do
WriteLn(f, Players[i].name);
WriteLn(f, pole.name);
for i := 0 to Pole.size.x do begin
 for i1 := 0 to Pole.size.y do begin
 if Tocki[i, i1] <> nil then
 WriteLn(f, i, ' ', i1, ' ', Tocki[i, i1].Player,' ',
 BoolToByte(Tocki[i, i1].enable),' ', Tocki[i, i1].basa);
end;
end;
for i := 0 to bases do begin
WriteLn(f, FBases[i]^.Number,' ', FBases[i]^.FPlayer, ' ', High(FBases[i]^.FTocki));
for i1 := 0 to High(FBases[bases]^.FTocki) do
 WriteLn(f, FBases[i]^.FTocki[i1].xpos, ' ', FBases[i]^.FTocki[i1].ypos);
end;
CloseFile(f);
end;

procedure TGamePole.LoadGamePole(canvas : TBitmap32; Name : string);
var f : TextFile;
    s, a, b, c, i, i1, fp, fb, px, py : smallint;

    b1, b2 : byte;
begin
self.Destroy;
self := TGamePole.Create();
fcanvas := canvas;
canvas.Clear;
Assign(f, Name);
Reset(f);
ReadLn(f, s, px, py, a, c, FFocusePlayer, b1, b2);
bases := c;
FSnap := ByteToBool(b1);
FAsp := ByteToBool(b2);
SetLength(FTocki, px + 1, py + 1);
SetLength(Fplayers, a + 1);
SetLength(FBases, MaxBaseSize);
for i := 0 to a do  begin
Players[i] := TPlayer.Create();
ReadLn(f, Players[i].Fname);
Players[i].LoadPlayer('Игроки\', Players[i].name);
end;
pole := TPole.Create();
ReadLn(f, pole.fname);
pole.LoadPole('Поля\', pole.name);
pole.FGamePole^ := self;
pole.DrawPole;
for i := 0 to s do begin
ReadLn(f, a,  b,  fp, b1, fb);
Tocki[a, b] := TTocka.Create(a,b,fp,ByteToBool(b1), fb,self);
Tocki[a, b].DrawTocka;
end;
if c <> -1 then begin
for i := 0 to c do begin
ReadLn(f, s, fp, fb);
New(FBases[i]);
FBases[i]^ := TBasa.Create;
New(FBases[i]^.FGamePole);
FBases[i]^.FGamePole^ := self;
FBases[i]^.FNumber := s;
FBases[i]^.FPlayer := fp;
SetLength(FBases[i]^.FTocki, fb+1);
for i1 := 0 to fb do begin
ReadLn(f, px, py);
FBases[i]^.FTocki[i1] := TTocka.Create(px, py, fp, true, s, self);
end;
FBases[i].UpdateBasa;
FBases[i].DrawBasa;
end;
end;
CloseFile(f);
end;

procedure TPole.SavePole(path : string);
var f : TextFile;
begin
AssignFile(f, path + Name + '.pole');
Rewrite(f);
WriteLn(f, Color,' ', LineColor,' ', Alpha,' ',
LineWidth,' ', KletkaSize,' ', size.x,' ', size.y);
CloseFile(f);
end;

procedure TPole.LoadPole(Path, Name : string);
var f : TextFile;
begin
Assign(f, path + name + '.pole');
Reset(f);
FName := Name;
ReadLn(f, FColor, FLineColor, FAlpha, FLineWidth, FKletkaSize, Fsize.x, Fsize.y);
CloseFile(f);
end;

procedure TPole.DrawPole;
var i : integer;
begin
with fgamepole^.canvas do begin
BeginUpdate;
FillRectTS(fgamepole^.Left, fgamepole^.Top, fgamepole^.Left + KletkaSize*(size.x + 1), fgamepole^.Top + KletkaSize*(size.y + 1), color);
for i := 1 to size.x do
GRHorizline(fgamepole^.canvas, fgamepole^.Left + KletkaSize * i, fgamepole^.Top + KletkaSize, fgamepole^.Left + KletkaSize * i, fgamepole^.Top + KletkaSize*size.y, LineWidth, SetAlpha(LineColor, alpha), alpha);
for i := 1 to size.y do
GRVertline(fgamepole^.canvas, fgamepole^.Left + KletkaSize, fgamepole^.Top + KletkaSize * i, fgamepole^.Left + KletkaSize*size.x, fgamepole^.Top + KletkaSize * i, LineWidth, SetAlpha(LineColor, alpha), alpha);
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

constructor TBasa.Create(GamePole : TGamePole; Player : byte; Number : word; Tocki : TTocki1d);
var i : word;
begin
FPlayer := Player;
FNumber := Number;
New(FGamePole);
FGamePole^ := GamePole;
SetLength(FTocki, High(TimeTocki)+1);
Polygon := TPolygon32.Create;
for i := 0 to High(TimeTocki) do begin
FTocki[i] := Tocki[i];
polygon.Add(FixedPoint(FTocki[i].x, FTocki[i].y));
end;
FindLTandBPPos;
FindAndDisableTockiInBase;
DrawBasa;
end;

destructor TBasa.Destroy();
begin
Dispose(FGamePole);
inherited;
end;

procedure TBasa.FindAndDisableTockiInBase;
var i, i1, l, min, max : word;
    posit, posit1 : T2dar;
begin
l := 0;
SetLength(posit, MaxBaseSize);
SetLength(posit1, MaxBaseSize);
FindLTandBPPos;
if (FMaxPos.x - FMinPos.x = 1) or  (FMaxPos.x - FMinPos.x = 0) then exit;
for i := FMinPos.x + 1 to FMaxPos.x - 1 do begin
min := MinVInTockaAr(i);
max := MaxVInTockaAr(i);
for i1 := min + 1 to max - 1 do begin
if (Max - Min = 1) or (Max - Min = 0) then continue;
if (FGamePole^.Tocki[i, i1] = nil) then
FGamePole^.Tocki[i, i1] := TTocka.Create(i, i1, 127,false,-1, FGamePole^);
If FGamePole^.Tocki[i, i1].Basa <> Number then
FGamePole^.Tocki[i, i1].FEnable := false;
l := l + 1;
posit[l] := Make2dpos(i, i1);
end;
end;

{l := 0;
for i := FMinPos.y + 1 to FMaxPos.y - 1 do begin
min := MinVInTockaAr(i, false);
max := MaxVInTockaAr(i, false);
for i1 := min + 1 to max - 1 do begin
if (Max - Min = 1) or (Max - Min = 0) then continue;
if (FGamePole^.Tocki[i, i1] = nil) then
FGamePole^.Tocki[i, i1] := TTocka.Create(i, i1, 127,false,-1, FGamePole^);
If FGamePole^.Tocki[i, i1].Basa <> Number then
FGamePole^.Tocki[i, i1].FEnable := false;
l := l + 1;
posit1[l] := Make2dpos(i, i1);
end;
end;

l := 0;
SetLength(TockiInBase, MaxBaseSize);
for i := 0 to High(posit) do begin
 for i1 := 0 to High(posit1) do begin
 if (posit[i].x = posit1[i1].x) and (posit[i].y = posit1[i1].y) then begin
 l := l + 1;
 TockiInBase[l] := Make2dpos(posit[i].x, posit[i].y);
 end;
end;
end;

for i := 0 to l do
FGamePole^.Tocki[TockiInBase[i].x, TockiInBase[i].y].fenable := false;
}
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
if tocki[i].xpos = n then begin
result := tocki[i].ypos;
break;
end;
end;
for i:=1 to High(tocki) do begin
   if tocki[i].xpos = n then
   if tocki[i].ypos < Result then Result := tocki[i].ypos;
end;

end else begin
for i:=0 to High(tocki) do begin
if tocki[i].ypos = n then begin
result := tocki[i].xpos;
break;
end;
end;
for i:=1 to High(tocki) do begin
   if tocki[i].ypos = n then
   if tocki[i].xpos < Result then Result := tocki[i].xpos;
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
if tocki[i].xpos = n then begin
result := tocki[i].ypos;
break;
end;
end;
for i:=1 to High(tocki) do begin
   if tocki[i].xpos = n then
   if tocki[i].ypos > Result then Result := tocki[i].ypos;
end;

end else begin
for i:=0 to High(tocki) do begin
if tocki[i].ypos = n then begin
result := tocki[i].xpos;
break;
end;
end;
for i:=1 to High(tocki) do begin
   if tocki[i].ypos = n then
   if tocki[i].xpos > Result then Result := tocki[i].xpos;
end;
end;
end else result := 0;
end;

procedure TBasa.DrawBasa();
var i : integer;
begin
FGamePole^.Canvas.BeginUpdate;
polygon.DrawFill(FGamePole^.Canvas, SetAlpha(FGamePole.Players[FPlayer].FFillColor, FGamePole.Players[FPlayer].FFillAlpha));
FGamePole^.Canvas.EndUpdate;
FGamePole^.Canvas.Changed;
end;

procedure TBasa.UpdateBasa;
begin
FindLTandBPPos;
FindAndDisableTockiInBase;
end;

constructor TGameTocki.Create(Image : TImgView32; GamePole : TGamePole);
begin
inherited Create();
FGamePole := GamePole;
New(FImage);
FImage^ := Image;
end;

constructor TGameTocki.Create();
begin
end;

destructor TGameTocki.Destroy();
begin
end;

procedure TGameTocki.Obvodka(x, y : word);
begin
 if bp <> nil then bp.Destroy();
 bp := TTocka.Create(round(x/GamePole.Pole.KletkaSize) - 1, round(y/GamePole.Pole.KletkaSize) - 1,
 GamePole.FocusePlayer, true, bases, gamepole);
  if (GamePole.CheckTocka(bp.xpos, bp.ypos, GamePole.FocusePlayer) = true) then begin
   if RM = true then begin
    If Distance(bp, TimeTocki[High(TimeTocki)]) <= 1.5*GamePole.pole.KletkaSize then begin
     if (bp.xpos = TimeTocki[0].xpos) and (bp.ypos = TimeTocki[0].ypos) then begin
      GamePole.CreateBasa(TimeTocki, GamePole.FocusePlayer);
      TimePolygon.Destroy;
      exit;
     end;
     SetLength(TimeTocki, length(TimeTocki) + 1);
     TimeTocki[High(TimeTocki)] := TTocka.Create(bp);
     TimePolygon.Add(FixedPoint(bp.x, bp.y));
     gamepole.Canvas.Clear;
     gamepole.UpdatePole;
     TimePolygon.DrawFill(gamepole.Canvas, SetAlpha(gamepole.players[gamepole.FocusePlayer].Color, 100));
    end;
   end else begin
    RM := true;
    SetLength(TimeTocki, 1);
    TimePolygon := TPolygon32.Create;
    TimeTocki[0] := TTocka.Create(bp);
    gamepole.Canvas.Clear;
    gamepole.UpdatePole;
    TimePolygon.Add(FixedPoint(bp.x, bp.y));
    TimePolygon.DrawFill(gamepole.Canvas, SetAlpha(gamepole.players[gamepole.FocusePlayer].Color, 100));
   end;
  end;
end;

procedure TGameTocki.OnMouseDown(x, y: smallint; button : TMouseButton);
var xpos, ypos : word; p : TPoint;
begin
 //GetCursorPos(p);
 if button = mbleft then begin
   if RM = true then Obvodka(X, y) else begin
  xpos := round(x / GamePole.Pole.KletkaSize);
  ypos := round(y / GamePole.Pole.KletkaSize);
  //gamepole.Tocka[xpos - 1, ypos - 1] := TTocka.Create(xpos-1, ypos-1, gamepole.focuseplayer, true, -1, gamepole);
  gamepole.AddTocka(Make2dpos(xpos - 1, ypos - 1), gamepole.focusePlayer);
   end;
 end;
 if button = mbright then
  if RM = false then Obvodka(x, y);
end;

procedure TGameTocki.OnMouseMove(x, y : smallint);
var p : TPoint;
begin
GetCursorPos(p);
if gamepole.Snap = true then begin
x := round(x/ gamepole.Pole.KletkaSize);
y := round(y/ gamepole.Pole.KletkaSize);
end;
if (x = 0) then x := 1;
if (y = 0) then y := 1;
if (x > gamepole.pole.size.x) then x := gamepole.pole.size.x;
if (y > gamepole.pole.size.y) then y := gamepole.pole.size.y;
{if (x <= gamepole.pole.Size.x) and (y <= gamepole.pole.Size.y) then begin
if gamepole.tocki[x - 1, y - 1] <> nil then
if gamepole.tocki[x - 1, y - 1].Enable = false then gamepole.FCursor := gamepole.FOldCur;
end;  }
if gamepole.Snap = true then begin
GamePole.FOldCur := GamePole.FCursor;
GamePole.FCursor := Point(x * gamepole.Pole.KletkaSize, y * gamepole.Pole.KletkaSize) end else
GamePole.FCursor := Point(x , y);
{If RM = true then begin
if gamepole.FCursor.X >  TimeTocki[timer].X + gamepole.pole.KletkaSize then gamepole.FCursor.X := TimeTocki[timer].X + gamepole.pole.KletkaSize;
if gamepole.FCursor.Y >  TimeTocki[timer].Y + gamepole.pole.KletkaSize then gamepole.FCursor.Y := TimeTocki[timer].Y + gamepole.pole.KletkaSize;
if gamepole.FCursor.X <  TimeTocki[timer].X - gamepole.pole.KletkaSize then gamepole.FCursor.X := TimeTocki[timer].X - gamepole.pole.KletkaSize;
if gamepole.FCursor.Y <  TimeTocki[timer].Y - gamepole.pole.KletkaSize then gamepole.FCursor.Y := TimeTocki[timer].Y - gamepole.pole.KletkaSize;
end; }
end;

procedure TGameTocki.OnKeyDown(time : double);
var x, y, i, i1, ks : word;
MiddlePos : t2dpos;
begin
if zad = gamepole.zadkey + 1 then zad := 1;
zad := zad + 1;
if gamepole.zadkey <> 0 then
if zad mod gamepole.zadkey = 0 then begin

if (IsKeyDown(ZoomIn)) and (GamePole.Pole.KletkaSize <= 100) then begin
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
end;

gamepole.Pole.GetWidthAndHeight;
if (IsKeyDown(ScrollUp)) and (GamePole.Pos.y < 0) then
GamePole.fpos.y := GamePole.fpos.y + 5;

if (IsKeyDown(ScrollDown)) and (GamePole.Pos.y > -(gamepole.Pole.Height - gamepole.Window.y)) then
GamePole.fpos.y := GamePole.fpos.y - 5;

if (IsKeyDown(ScrollLeft)) and (GamePole.Pos.x < 0) then
GamePole.fpos.x := GamePole.fpos.x + 5;

if (IsKeyDown(ScrollRight)) and (GamePole.Pos.x > -(gamepole.Pole.Width - gamepole.Window.x)) then
GamePole.fpos.x := GamePole.fpos.x - 5;

ks := GamePole.Pole.KletkaSize;
x := GamePole.FCursor.x div ks;
y := GamePole.FCursor.Y div ks;
if IsKeyDown(gamepole.Players[gamepole.focuseplayer].MoveUp) and (GamePole.cursor.y < ks*GamePole.pole.Size.y)
then
GamePole.FCursor.Y := y * ks + ks;
if IsKeyDown(gamepole.Players[gamepole.focuseplayer].MoveDown)  and (GamePole.cursor.y > ks)
then
GamePole.FCursor.Y := y * ks - ks;
if IsKeyDown(gamepole.Players[gamepole.focuseplayer].MoveLeft) and (GamePole.cursor.X > ks)
then
GamePole.FCursor.x := x * ks - ks;
if IsKeyDown(gamepole.Players[gamepole.focuseplayer].MoveRight)  and (GamePole.cursor.x < ks*GamePole.pole.Size.x)
then
GamePole.FCursor.x := x * ks + ks;

if IsKeyDown(gamepole.Players[gamepole.focuseplayer].Enter) then begin
GamePole.AddTocka(Make2dpos(x - 1, y - 1), GamePole.FocusePlayer);
if RM = true then Obvodka(x, y);
end;
if IsKeyDown(VK_Control) then
if RM <> true then
Obvodka(x, y)
else  RM := false;
end;

end;

initialization
zad := 0;
MaxBaseSize := 50;
bases := -1;
RM := false;

end.
