using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit;
using NUnit.Framework;
using System.Drawing;
using UnderTheCursorTranslatorTests.Properties;
using UnderTheCursorTranslatorLibrary;

namespace UnderTheCursorTranslatorTests
{
	[TestFixture]
	public class TextHocrRecognizerTests
	{
		[Test]
		public void PointRectDistanceTest()
		{
			var rect = new Rectangle(10, 10, 11, 11);

			var diag = Math.Sqrt(5 * 5 + 5 * 5);
			Assert.AreEqual(diag, WordRecognizerTesseractHocr.Distance(new Point(5, 5), rect));
			Assert.AreEqual(5, WordRecognizerTesseractHocr.Distance(new Point(5, 15), rect));
			Assert.AreEqual(diag, WordRecognizerTesseractHocr.Distance(new Point(5, 25), rect));

			Assert.AreEqual(5, WordRecognizerTesseractHocr.Distance(new Point(15, 5), rect));
			Assert.AreEqual(0, WordRecognizerTesseractHocr.Distance(new Point(15, 15), rect));
			Assert.AreEqual(5, WordRecognizerTesseractHocr.Distance(new Point(15, 25), rect));

			Assert.AreEqual(diag, WordRecognizerTesseractHocr.Distance(new Point(25, 5), rect));
			Assert.AreEqual(5, WordRecognizerTesseractHocr.Distance(new Point(25, 15), rect));
			Assert.AreEqual(diag, WordRecognizerTesseractHocr.Distance(new Point(25, 25), rect));
		}

		[Test]
		public void ParseHocrTest()
		{
			var recognizer = new WordRecognizerTesseractHocr();
			var recognizedWord = recognizer.GetNearestWord(Resources.hocr_sample_output, new Point(235, 30));

			Assert.GreaterOrEqual(recognizer.RectsWords.Count, 25);
			Assert.AreEqual("method,", recognizedWord);
		}
	}
}
