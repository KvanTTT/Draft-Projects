object Form3: TForm3
  Left = 293
  Top = 211
  BorderIcons = [biSystemMenu]
  BorderStyle = bsDialog
  ClientHeight = 91
  ClientWidth = 245
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 15
    Top = 10
    Width = 169
    Height = 13
    Caption = #1042#1074#1077#1076#1080#1090#1077' '#1080#1084#1103' '#1089#1086#1093#1088#1072#1085#1103#1077#1084#1086#1081' '#1082#1072#1088#1090#1099
  end
  object Edit1: TEdit
    Left = 15
    Top = 30
    Width = 216
    Height = 21
    TabOrder = 0
    Text = #1050#1072#1088#1090#1072' 1'
  end
  object BitBtn1: TBitBtn
    Left = 80
    Top = 60
    Width = 75
    Height = 25
    TabOrder = 1
    OnClick = BitBtn1Click
    Kind = bkOK
  end
  object BitBtn2: TBitBtn
    Left = 155
    Top = 60
    Width = 75
    Height = 25
    Caption = #1054#1090#1084#1077#1085#1072
    TabOrder = 2
    OnClick = BitBtn2Click
    Kind = bkCancel
  end
end
