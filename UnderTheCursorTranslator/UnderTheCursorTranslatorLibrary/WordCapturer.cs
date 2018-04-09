using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;

namespace UnderTheCursorTranslatorLibrary
{
	class WordCapturer
	{
		[DllImport("user32")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetCursorPos(out Point lpPoint);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll", EntryPoint = "SendMessageW")]
		static extern IntPtr SendMessageW(IntPtr hWnd, UInt32 Msg, IntPtr wParam, [MarshalAs(UnmanagedType.LPWStr)] out string lParam);

		[DllImport("user32")]
		public static extern IntPtr WindowFromPoint(int xPoint, int yPoint);
		
		const uint WM_GETTEXT = 13;
		const uint WM_GETTEXTLENGTH = 14;

		public string GetCharFromPosition(Point p)
		{
			Point P;
			bool lRet;
			IntPtr hHandle;
			string aText = string.Empty;
			int lTextlen;
			lRet = GetCursorPos(out P);
			hHandle = WindowFromPoint(P.X, P.Y);
			lTextlen = (int)SendMessage(hHandle, WM_GETTEXTLENGTH, IntPtr.Zero, IntPtr.Zero);
			if (lTextlen != 0)
			{
				if (lTextlen > 1024)
					lTextlen = 1024;
				lTextlen += 1;
				//aText = Space(lTextlen);
				SendMessageW(hHandle, WM_GETTEXT, (IntPtr)lTextlen, out aText);
			}

			return aText;
		}
	}
}
