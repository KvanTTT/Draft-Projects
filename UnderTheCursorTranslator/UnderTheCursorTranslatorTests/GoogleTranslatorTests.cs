using NUnit.Framework;
using UnderTheCursorTranslatorLibrary;

namespace UnderTheCursorTranslatorTests
{
	[TestFixture]
	public class GoogleTranslatorTests
	{
		[Test]
		public void TranslateTest()
		{
			var translator = new TextTranslatorGoogle(enmLanguage.English, enmLanguage.Russian);
			var translation = translator.Translate("method");
			Assert.AreEqual("метод", translation.Translation);
		}
	}
}
