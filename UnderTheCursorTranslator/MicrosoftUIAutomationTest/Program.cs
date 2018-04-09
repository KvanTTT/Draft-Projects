using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Automation;
using System.Threading;
using System.Runtime.InteropServices;

namespace MicrosoftUIAutomationTest
{
	class WordCapturer
	{
		[DllImport("user32")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetCursorPos(out System.Drawing.Point lpPoint);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll")]
		static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, [MarshalAs(UnmanagedType.LPStr)] out string lParam);

		[DllImport("user32")]
		public static extern IntPtr WindowFromPoint(int xPoint, int yPoint);

		const uint WM_GETTEXT = 13;
		const uint WM_GETTEXTLENGTH = 14;

		public static string GetCharFromPosition(System.Drawing.Point p)
		{
			IntPtr hHandle;
			string aText = "";
			int lTextlen;
			hHandle = WindowFromPoint(p.X, p.Y);
			lTextlen = (int)SendMessage(hHandle, WM_GETTEXTLENGTH, IntPtr.Zero, IntPtr.Zero);
			if (lTextlen != 0)
			{
				if (lTextlen > 1024)
					lTextlen = 1024;
				lTextlen += 1;


				//SendMessage(hHandle, WM_GETTEXT, (IntPtr)lTextlen, out aText);
			}

			return aText;
		}

		public static string GetWindowProcess(System.Drawing.Point p)
		{
			var hHandle = WindowFromPoint(p.X, p.Y);

			return "";
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			do
			{
				System.Drawing.Point mouse = Cursor.Position; // use Windows forms mouse code instead of WPF

				var s = WordCapturer.GetCharFromPosition(mouse);
				Console.WriteLine(s);
				
				Thread.Sleep(1000);

				AutomationElement element = AutomationElement.FromPoint(new Point(mouse.X, mouse.Y));
				if (element == null)
				{
					// no element under mouse
					return;
				}

				try
				{
					Console.WriteLine("Element at position " + mouse + " is '" + element.Current.Name + "'");
				}
				catch
				{

				}

				object pattern = null;
				// the "Value" pattern is supported by many application (including IE & FF)
				if (element.TryGetCurrentPattern(ValuePattern.Pattern, out pattern))
				{
					ValuePattern valuePattern = (ValuePattern)pattern;
					Console.WriteLine(" Value=" + valuePattern.Current.Value);
				}

				// the "Text" pattern is supported by some applications (including Notepad)and returns the current selection for example
				if (element.TryGetCurrentPattern(TextPattern.Pattern, out pattern))
				{
					TextPattern textPattern = (TextPattern)pattern;
					foreach (var range in textPattern.GetSelection())
					{
						Console.WriteLine(" SelectionRange=" + range.GetText(-1));
					}
				}  
				Thread.Sleep(1000);
				Console.WriteLine();
			}
			while (true);
		}
	}
}
