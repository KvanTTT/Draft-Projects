program Project1;

uses
  Forms,
  Unit1 in 'Unit1.pas',
  Unit2 in 'Unit2.pas' {Form2};


{$R *.RES}
 begin
  Application.Initialize;
  Application.Title := 'SHOOTER by DRON';
    Application.CreateForm(TForm2, Form2);

  Application.Run;
end.
