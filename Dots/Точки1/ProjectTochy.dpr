program ProjectTochy;

uses
  Forms,
  UnitTochy in 'UnitTochy.pas' {Form1},
  Unit2Tochy in 'Unit2Tochy.pas' {Form2},
  Unit3Tochy in 'Unit3Tochy.pas' {Form3};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.CreateForm(TForm2, Form2);
  Application.CreateForm(TForm3, Form3);
  Application.Run;
end.
