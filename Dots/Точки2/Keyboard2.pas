unit Keyboard2;

interface

{$i GLScene.inc}
{$IFDEF LINUX}{$Message Error 'Unit not supported'}{$ENDIF LINUX}

uses
  Windows;

type

   TVirtualKeyCode = Integer;

const
   // pseudo wheel keys (we squat F23/F24), see KeyboardNotifyWheelMoved
   VK_MOUSEWHEELUP   = VK_F23;
   VK_MOUSEWHEELDOWN = VK_F24;

{: Check if the key corresponding to the given Char is down.<p>
   The character is mapped to the <i>main keyboard</i> only, and not to the
   numeric keypad.<br>
   The Shift/Ctrl/Alt state combinations that may be required to type the
   character are ignored (ie. 'a' is equivalent to 'A', and on my french
   keyboard, '5' = '(' = '[' since they all share the same physical key). }
function IsKeyDown(c : Char) : Boolean; overload;
{: Check if the given virtual key is down.<p>
   This function is just a wrapper for GetAsyncKeyState. }
function IsKeyDown(vk : TVirtualKeyCode) : Boolean; overload;
{: Returns the first pressed key whose virtual key code is >= to minVkCode.<p>
   If no key is pressed, the return value is -1, this function does NOT
   wait for user input.<br>
   If you don't care about multiple key presses, just don't use the parameter. }
function KeyPressed(minVkCode : TVirtualKeyCode = 0) : TVirtualKeyCode;

{: Converts a virtual key code to its name.<p>
   The name is expressed using the locale windows options. }
function VirtualKeyCodeToKeyName(vk : TVirtualKeyCode) : String;
{: Converts a key name to its virtual key code.<p>
   The comparison is case-sensitive, if no match is found, returns -1.<p>
   The name is expressed using the locale windows options, except for mouse
   buttons which are translated to 'LBUTTON', 'MBUTTON' and 'RBUTTON'. }
function KeyNameToVirtualKeyCode(const keyName : String) : TVirtualKeyCode;
{: Returns the virtual keycode corresponding to the given char.<p>
   The returned code is untranslated, f.i. 'a' and 'A' will give the same
   result. A return value of -1 means that the characted cannot be entered
   using the keyboard. }
function CharToVirtualKeyCode(c : Char) : TVirtualKeyCode;

{: Use this procedure to notify a wheel movement and have it resurfaced as key stroke.<p>
   Honoured by IsKeyDown and KeyPressed }
procedure KeyboardNotifyWheelMoved(wheelDelta : Integer);

var
   vLastWheelDelta : Integer;

// ---------------------------------------------------------------------
// ---------------------------------------------------------------------
// ---------------------------------------------------------------------
implementation
// ---------------------------------------------------------------------
// ---------------------------------------------------------------------
// ---------------------------------------------------------------------

uses SysUtils;

const
   cLBUTTON = 'LBUTTON';
   cMBUTTON = 'MBUTTON';
   cRBUTTON = 'RBUTTON';
   cUP = 'UP';
   cDOWN = 'DOWN';
   cRIGHT = 'RIGHT';
   cLEFT = 'LEFT';
   cPAGEUP = 'PAGE UP';
   cPAGEDOWN = 'PAGE DOWN';
   cHOME = 'HOME';
   cEND = 'END';
   cMOUSEWHEELUP = 'MWHEEL UP';
   cMOUSEWHEELDOWN = 'MWHEEL DOWN';

// IsKeyDown
//
function IsKeyDown(c : Char) : Boolean;
var
   vk : Integer;
begin
   // '$FF' filters out translators like Shift, Ctrl, Alt
   vk:=VkKeyScan(c) and $FF;
   if vk<>$FF then
      Result:=(GetAsyncKeyState(vk)<0)
   else Result:=False;
end;

// IsKeyDown
//
function IsKeyDown(vk : TVirtualKeyCode) : Boolean;
begin
   case vk of
      VK_MOUSEWHEELUP : begin
         Result:=(vLastWheelDelta>0);
         if Result then vLastWheelDelta:=0;
      end;
      VK_MOUSEWHEELDOWN : begin
         Result:=(vLastWheelDelta<0);
         if Result then vLastWheelDelta:=0;
      end;
   else
      Result:=(GetAsyncKeyState(vk)<0);
   end;
end;

// KeyPressed
//
function KeyPressed(minVkCode : TVirtualKeyCode = 0) : TVirtualKeyCode;
var
   i : Integer;
   buf : TKeyboardState;
begin
   Assert(minVkCode>=0);
   Result:=-1;
      if GetKeyboardState(buf) then begin
      for i:=minVkCode to High(buf) do begin
         if (buf[i] and $80)<>0 then begin
            Result:=i;
            Exit;
         end;
      end;
   end;
   if vLastWheelDelta<>0 then begin
      if vLastWheelDelta>0 then
         Result:=VK_MOUSEWHEELUP
      else Result:=VK_MOUSEWHEELDOWN;
      vLastWheelDelta:=0;
   end;
end;

// VirtualKeyCodeToKeyName
//
function VirtualKeyCodeToKeyName(vk : TVirtualKeyCode) : String;
var
   nSize : Integer;
begin
   // Win32 API can't translate mouse button virtual keys to string
   case vk of
      VK_LBUTTON : Result:=cLBUTTON;
      VK_MBUTTON : Result:=cMBUTTON;
      VK_RBUTTON : Result:=cRBUTTON;
      VK_UP : Result:=cUP;
      VK_DOWN : Result:=cDOWN;
      VK_LEFT : Result:=cLEFT;
      VK_RIGHT : Result:=cRIGHT;
      VK_PRIOR : Result:=cPAGEUP;
      VK_NEXT : Result:=cPAGEDOWN;
      VK_HOME : Result:=cHOME;
      VK_END : Result:=cEND;
      VK_MOUSEWHEELUP : Result:=cMOUSEWHEELUP;
      VK_MOUSEWHEELDOWN : Result:=cMOUSEWHEELDOWN;
   else
      nSize:=32; // should be enough
      SetLength(Result, nSize);
      vk:=MapVirtualKey(vk, 0);
      nSize:=GetKeyNameText((vk and $FF) shl 16, PChar(Result), nSize);
      SetLength(Result, nSize);
   end;
end;

// KeyNameToVirtualKeyCode
//
function KeyNameToVirtualKeyCode(const keyName : String) : TVirtualKeyCode;
var
   i : Integer;
begin
   if keyName=cLBUTTON then
      Result:=VK_LBUTTON
   else if keyName=cMBUTTON then
      Result:=VK_MBUTTON
   else if keyName=cRBUTTON then
      Result:=VK_RBUTTON
   else if keyName=cMOUSEWHEELUP then
      Result:=VK_MOUSEWHEELUP
   else if keyName=cMOUSEWHEELDOWN then
      Result:=VK_MOUSEWHEELDOWN
   else begin
      // ok, I admit this is plain ugly. 8)
      Result:=-1;
      for i:=0 to 255 do begin
         if CompareText(VirtualKeyCodeToKeyName(i), keyName)=0 then begin
            Result:=i;
            Break;
         end;
      end;
   end;
end;

// CharToVirtualKeyCode
//
function CharToVirtualKeyCode(c : Char) : TVirtualKeyCode;
begin
   Result:=VkKeyScan(c) and $FF;
   if Result=$FF then Result:=-1;
end;

// KeyboardNotifyWheelMoved
//
procedure KeyboardNotifyWheelMoved(wheelDelta : Integer);
begin
   vLastWheelDelta:=wheelDelta;
end;

end.

{unit Keyboard2;

interface

uses Windows;

const
    Key_LBUTTON = 1;
    Key_RBUTTON = 2;
    Key_CANCEL = 3;
    Key_MBUTTON = 4;
    Key_Escape = 27;
    Key_Tab = 9;
    Key_Backspace = 8;
    Key_Space = 32;
    Key_Enter = 13;
    Key_Shift = 16;
    Key_Control = 17;
    Key_insert = 45;
    Key_DELETE = 46;
    Key_LSHIFT = 160;
    Key_RSHIFT = 161;
    Key_LCONTROL = 162;
    Key_RCONTROL = 163;
    Key_LAlt= 164;
    Key_RAlt = 165;
    Key_Alt = 18;
    Key_F1 =  112;
    Key_F2 =  113;
    Key_F3 =  114;
    Key_F4 =  115;
    Key_F5 =  116;
    Key_F6 =  117;
    Key_F7 =  118;
    Key_F8 =  119;
    Key_F9 =  120;
    Key_F10 = 121;
    Key_F11 = 122;
    Key_F12 = 123;
    Key_Left = 37;
    Key_Up = 38;
    Key_Right = 39;
    Key_Down = 40;
    Key_0 = 48;
    Key_1 = 49;
    Key_2 = 50;
    Key_3 = 51;
    Key_4 = 52;
    Key_5 = 53;
    Key_6 = 54;
    Key_7 = 55;
    Key_8 = 56;
    Key_9 = 57;
    Key_A = 65;
    Key_B = 66;
    Key_C = 67;
    Key_D = 68;
    Key_E = 69;
    Key_F = 70;
    Key_G = 71;
    Key_H = 72;
    Key_I = 73;
    Key_J = 74;
    Key_K = 75;
    Key_L = 76;
    Key_M = 77;
    Key_N = 78;
    Key_O = 79;
    Key_P = 80;
    Key_Q = 81;
    Key_R = 82;
    Key_S = 83;
    Key_T = 84;
    Key_U = 85;
    Key_V = 86;
    Key_W = 87;
    Key_X = 88;
    Key_Y = 89;
    Key_Z = 90;
    Key_NUMPAD0 = 96;
    Key_NUMPAD1 = 97;
    Key_NUMPAD2 = 98;
    Key_NUMPAD3 = 99;
    Key_NUMPAD4 = 100;
    Key_NUMPAD5 = 101;
    Key_NUMPAD6 = 102;
    Key_NUMPAD7 = 103;
    Key_NUMPAD8 = 104;
    Key_NUMPAD9 = 105;
    Key_MULTIPLY = 106;
    Key_ADD = 107;
    Key_SEPARATOR = 108;
    Key_SUBTRACT = 109;
    Key_DECIMAL = 110;
    Key_DIVIDE = 111;


implementation

function GetKeyCode(s : string): byte;
begin

end;

end.      }
