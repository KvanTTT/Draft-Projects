unit Unit3Tochy;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Buttons;

type
  TForm3 = class(TForm)
    Edit1: TEdit;
    Label1: TLabel;
    BitBtn1: TBitBtn;
    BitBtn2: TBitBtn;
    procedure BitBtn1Click(Sender: TObject);
    procedure BitBtn2Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form3: TForm3;

implementation

uses UnitTochy;

{$R *.dfm}

procedure TForm3.BitBtn1Click(Sender: TObject);
begin
Form1.ListBox4.Items.Add(Edit1.Text);
Form3.Close;

end;

procedure TForm3.BitBtn2Click(Sender: TObject);
begin
Form3.Close;
end;

end.
