using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace UnderTheCursorTranslatorLibrary
{
	public abstract class ScreenCapturer
	{
		public abstract Bitmap Capture(enmScreenCaptureMode screenCaptureMode = enmScreenCaptureMode.Window);

		public Point CursorPosition
		{
			get;
			protected set;
		}
	}
}
