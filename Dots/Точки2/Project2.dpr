program Project2;

uses
  Forms,
  Unit1 in 'Unit1.pas' {Form1},
  Keyboard in 'Keyboard.pas';

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.
