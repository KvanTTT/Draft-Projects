using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace UnderTheCursorTranslatorLibrary
{
	public class ScreenCapturerWin : ScreenCapturer
	{
		[DllImport("user32.dll")]
		private static extern IntPtr GetForegroundWindow();

		[DllImport("user32.dll")]
		private static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);

		[StructLayout(LayoutKind.Sequential)]
		private struct Rect
		{
			public int Left;
			public int Top;
			public int Right;
			public int Bottom;
		}

		#region Implementation

		public override Bitmap Capture(enmScreenCaptureMode screenCaptureMode = enmScreenCaptureMode.Window)
		{
			Rectangle bounds;

			if (screenCaptureMode == enmScreenCaptureMode.Screen)
			{
				bounds = Screen.GetBounds(Point.Empty);
				CursorPosition = Cursor.Position;
			}
			else
			{
				var foregroundWindowsHandle = GetForegroundWindow();
				var rect = new Rect();
				GetWindowRect(foregroundWindowsHandle, ref rect);
				bounds = new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
				CursorPosition = new Point(Cursor.Position.X - rect.Left, Cursor.Position.Y - rect.Top);
			}

			var result = new Bitmap(bounds.Width, bounds.Height);

			using (var g = Graphics.FromImage(result))
				g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);

			return result;
		}

		#endregion
	}
}