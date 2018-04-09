using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.IO;

namespace UnderTheCursorTranslatorLibrary
{
	public class WordRecognizerTesseract : TextExtractor
	{
		const string HelperFileName = "temp";

		public override string NextVariant()
		{
			if (CurrentVariantNumber == -1)
			{
				CurrentVariantNumber++;
				Bitmap.Save(HelperFileName + ".png", ImageFormat.Png);
				var startInfo = new ProcessStartInfo("tesseract.exe",
					string.Format("{0}.png {0} -psm 8", HelperFileName));
				startInfo.WindowStyle = ProcessWindowStyle.Hidden;
				var process = Process.Start(startInfo);
				process.WaitForExit();
				var result = File.ReadAllText(HelperFileName + ".txt");
				return result;
			}
			else if (CurrentVariantNumber == 0)
				CurrentVariantNumber++;
			return null;
		}
	}
}
