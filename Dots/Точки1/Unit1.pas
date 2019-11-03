unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs;

type
  TForm1 = class(TForm)
    procedure FormCreate(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;
   TPole = class(TImage)
 private
  FStandartMode : boolean;
  FPoleLenght : smallint;
  FPoleHeight : smallint;
  FPoleColor : TColor;
  FPoleBorders : boolean;
  FKletkaSize : smallint;
  FPoleLineWidth : Byte;
  FPoleLineColor : TColor;
 public
  property StandartMode : boolean read FStandartMode write FStandartMode;
  property PoleLenght : smallint read FPoleLenght write FPoleLenght;
  property PoleHeight : smallint read FPoleHeight write FPoleHeight;
  property PoleColor : TColor read FPoleColor write FPoleColor;
  property PoleBorders: boolean read FPoleBorders write FPoleBorders;
  property PKletkaSize : smallint read FKletkaSize write FKletkaSize;
  property PoleLineWidth : byte read FPoleLineWidth write FPoleLineWidth;
  property PoleLineColor : TColor read FPoleLineColor write FPoleLineColor;
  constructor Create(AOwner : TComponent); override;

  procedure BuiltPole(Sender: TObject; StandartMode : boolean; PoleHeight : smallint;
                      PoleLenght  : smallint;  PoleBackground : TColor;
                      PoleBorders : boolean; KletkaSize : smallint;
                      PoleLineWidth : Byte; PoleLineColor : TColor);

 end;

 constructor TPole.Create(AOwner : TComponent);
  begin
  FStandartMode := true;
  FPoleLenght := 10;
  FPoleHeight := 10;
  FPoleColor := clWhite;
  FPoleBorders := true;
  FKletkaSize := 10;
  FPoleLineWidth := 5;
  FPoleLineColor := clBlack;
 end;

 procedure TPole.BuiltPole(Sender: TObject; StandartMode : boolean; PoleHeight : smallint;
                      PoleLenght  : smallint;  PoleBackground : TColor;
                      PoleBorders : boolean; KletkaSize : smallint;
                      PoleLineWidth : Byte; PoleLineColor : TColor);

 var i, i1 : integer;
 begin
 with  TPole(Sender).Canvas do begin
 Pen.Width := 0;
 Pen.Color := 0;
 Brush.Color := PoleBackground;
 Rectangle(0, 0, ClientWidth, ClientHeight);

 Pen.Width := PoleLineWidth;
 Pen.Color := PoleLineColor;
 If StandartMode = true then begin
   for i := 1 to PoleLenght do begin
    if PoleBorders = true then begin
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
    If PoleBorders = true then begin
     If (i1 = 1) or (i1 = PoleHeight) then begin
       Pen.Color := PoleBackground;
       pen.Width := 0;
       MoveTo(0, 0); LineTo(0, 0);
       end
     else begin
       Pen.Width := PoleLineWidth;
       Pen.Color := PoleLineColor;
       MoveTo(KletkaSize, KletkaSize * i1);
       LineTo(KletkaSize, KletkaSize * PoleLenght);
     end;
    end;
    If PoleBorders = true then begin
       Pen.Width := PoleLineWidth;
       Pen.Color := PoleLineColor;
       MoveTo(KletkaSize, KletkaSize * i1);
       LineTo(KletkaSize, KletkaSize * PoleLenght);
      end;
    end;
   end;
  end;
 end;
end;
var
  Form1: TForm1;

implementation

{$R *.dfm}

type


procedure TForm1.FormCreate(Sender: TObject);
var p : TPole;
begin
p.BuiltPole(sender : TObject, true, 80, 80, clWhite, true, 10, 5, clBlack);

end;

end.
