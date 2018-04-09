using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.IO;
using System.Xml.Linq;
using NLog;

namespace UnderTheCursorTranslatorLibrary
{
	public class WordRecognizerTesseractHocr : TextExtractor
	{
		const string HelperFileName = "temp";
		Logger Logger;

		#region Constructors

		public WordRecognizerTesseractHocr()
		{
			Logger = LogManager.GetCurrentClassLogger();
		}

		#endregion

		#region Implementation

		public override string NextVariant()
		{
			if (CurrentVariantNumber == -1)
			{
				Bitmap.Save(HelperFileName + ".png", ImageFormat.Png);
				var startInfo = new ProcessStartInfo("tesseract.exe", HelperFileName + ".png temp hocr");
				startInfo.WindowStyle = ProcessWindowStyle.Hidden;
				var process = Process.Start(startInfo);
				process.WaitForExit();

				var result = GetNearestWord(File.ReadAllText(HelperFileName + ".html"), Position);

				return result;
			}
			else if (CurrentVariantNumber == 0)
				CurrentVariantNumber++;
			return null;
		}

		#endregion

		public string GetNearestWord(string tesseractHtml, Point position)
		{
			var xml = XDocument.Parse(tesseractHtml);

			RectsWords = new Dictionary<Rectangle, string>();

			var ocr_words = xml.Descendants("span").Where(element => element.Attribute("class").Value == "ocr_word").ToList();
			foreach (var ocr_word in ocr_words)
			{
				var strs = ocr_word.Attribute("title").Value.Split(' ');
				int left = int.Parse(strs[1]);
				int top = int.Parse(strs[2]);
				int width = int.Parse(strs[3]) - left + 1;
				int height = int.Parse(strs[4]) - top + 1;
				RectsWords.Add(new Rectangle(left, top, width, height), ocr_word.Value);
			}

			var nearestWords = RectsWords.OrderBy(rectWord => Distance(position, rectWord.Key));
			Logger.Trace("Count of recognized words: " + nearestWords.Count());

			return nearestWords.Count() != 0 ? nearestWords.First().Value : string.Empty;
		}

		public static double Distance(Point pos, Rectangle rect)
		{
			if (pos.X < rect.Left)
			{
				if (pos.Y < rect.Top)
					return Math.Sqrt((rect.X - pos.X) * (rect.X - pos.X) + (rect.Top - pos.Y) * (rect.Top - pos.Y));
				else if (pos.Y < rect.Top + rect.Height)
					return rect.Left - pos.X;
				else
					return Math.Sqrt((rect.X - pos.X) * (rect.X - pos.X) + 
						(rect.Top + rect.Height - 1 - pos.Y) * (rect.Top + rect.Height - 1 - pos.Y));
			}
			else if (pos.X < rect.Left + rect.Width)
			{
				if (pos.Y < rect.Top)
					return rect.Top - pos.Y;
				else if (pos.Y < rect.Top + rect.Height)
					return 0;
				else
					return pos.Y - (rect.Top + rect.Height - 1);
			}
			else
			{
				if (pos.Y < rect.Top)
					return Math.Sqrt((rect.X + rect.Width - 1 - pos.X) * (rect.X + rect.Width - 1 - pos.X) + 
						(rect.Top - pos.Y) * (rect.Top - pos.Y));
				else if (pos.Y < rect.Top + rect.Height)
					return pos.X - (rect.Left + rect.Width - 1);
				else
					return Math.Sqrt((rect.X + rect.Width - 1 - pos.X) * (rect.X + rect.Width - 1 - pos.X) +
						(rect.Top + rect.Height - 1 - pos.Y) * (rect.Top + rect.Height - 1 - pos.Y));
			}
		}

		public IDictionary<Rectangle, string> RectsWords
		{
			get;
			protected set;
		}
	}
}
