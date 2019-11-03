object Form1: TForm1
  Left = 249
  Top = 208
  Width = 573
  Height = 586
  Caption = 'Form1'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  OnKeyDown = FormKeyDown
  PixelsPerInch = 96
  TextHeight = 13
  object ImgView: TImgView32
    Left = 0
    Top = 0
    Width = 497
    Height = 514
    Align = alCustom
    Bitmap.ResamplerClassName = 'TNearestResampler'
    Scale = 1.000000000000000000
    ScrollBars.ShowHandleGrip = True
    ScrollBars.Style = rbsDefault
    ScrollBars.Visibility = svAuto
    OverSize = 0
    TabOrder = 0
    OnMouseDown = ImgViewMouseDown
    OnMouseMove = ImgViewMouseMove
  end
end
