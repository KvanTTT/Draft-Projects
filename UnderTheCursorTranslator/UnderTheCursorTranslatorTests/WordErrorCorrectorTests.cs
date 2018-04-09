using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using UnderTheCursorTranslatorTests.Properties;
using UnderTheCursorTranslatorLibrary;

namespace UnderTheCursorTranslatorTests
{
	[TestFixture]
	public class WordErrorCorrectorTests
	{
		WordErrorCorrectorHunspell WordErrorCorrector;

		[SetUp]
		public void SetupWordErrorCorrector()
		{
			WordErrorCorrector = new WordErrorCorrectorHunspell(
				Resources.en_US_aff, 
				Encoding.Default.GetBytes(Resources.en_US_dic));
		}

		[Test]
		public void RemoveUselessCharsTest()
		{
			WordErrorCorrector.SetText(" MethOd,!\"~");
			var correctedWord = WordErrorCorrector.NextVariant();

			Assert.AreEqual("method", correctedWord);
		}

		[Test]
		public void CorrectErrorsTest()
		{
			WordErrorCorrector.SetText("methot");
			
			Assert.AreEqual(WordErrorCorrector.NextVariant(), "method");
			Assert.AreEqual(WordErrorCorrector.CurrentVariantNumber, 0);
			Assert.AreEqual(WordErrorCorrector.NextVariant(), "met hot");
			Assert.AreEqual(WordErrorCorrector.NextVariant(), "met-hot");
			Assert.AreEqual(WordErrorCorrector.NextVariant(), "methought");
			Assert.AreEqual(WordErrorCorrector.NextVariant(), "meths");
			Assert.AreEqual(WordErrorCorrector.NextVariant(), "menthol");
			Assert.AreEqual(WordErrorCorrector.NextVariant(), "mahomet");
			Assert.AreEqual(WordErrorCorrector.NextVariant(), "methodist");
			Assert.AreEqual(WordErrorCorrector.NextVariant(), "methodism");
			Assert.AreEqual(WordErrorCorrector.CurrentVariantNumber, 8);
			Assert.IsNull(WordErrorCorrector.NextVariant());
			Assert.AreEqual(WordErrorCorrector.CurrentVariantNumber, 9);
			Assert.IsNull(WordErrorCorrector.NextVariant());
			Assert.AreEqual(WordErrorCorrector.CurrentVariantNumber, 9);
		}
	}
}
