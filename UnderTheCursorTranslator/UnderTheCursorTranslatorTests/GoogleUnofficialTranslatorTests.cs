using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using UnderTheCursorTranslatorLibrary;

namespace UnderTheCursorTranslatorTests
{
	[TestFixture]
	public class GoogleUnofficialTranslatorTests
	{
		const string WordToTranslate = "translator";

		Dictionary<enmLanguage, string> TranslatorTranslations = new Dictionary<enmLanguage, string>()
		{
			{ enmLanguage.Afrikaans, "vertaler"},
			{ enmLanguage.Albanian, "përkthyes"},
			{ enmLanguage.Armenian, "թարգմանիչ"},
			{ enmLanguage.Azerbaijani, "tərcüməçi"},
			{ enmLanguage.Arabic, "مترجم"},
			{ enmLanguage.Basque, "translator"},
			{ enmLanguage.Belarusian, "перакладчык"},
			{ enmLanguage.Bulgarian, "преводач"},
			{ enmLanguage.Catalan, "traductor"},
			{ enmLanguage.ChineseSimplified, "翻译"},
			{ enmLanguage.ChineseTraditional, "翻譯"},
			{ enmLanguage.Croatian, "prevoditelj"},
			{ enmLanguage.Czech, "překladatel"},
			{ enmLanguage.Danish, "oversætter"},
			{ enmLanguage.Dutch, "vertaler"},
			{ enmLanguage.English, "translator"},
			{ enmLanguage.Estonian, "tõlkija"},
			{ enmLanguage.Filipino, "tagasalin"},
			{ enmLanguage.Finnish, "kääntäjä"},
			{ enmLanguage.French, "traducteur"},
			{ enmLanguage.Galician, "tradutor"},
			{ enmLanguage.Georgian, "თარჯიმანი"},
			{ enmLanguage.German, "Übersetzer"},
			{ enmLanguage.Greek, "μεταφραστής"},
			{ enmLanguage.HaitianCreole, "tradiktè"},
			{ enmLanguage.Hebrew, "מתרגם"},
			{ enmLanguage.Hindi, "अनुवादक"},
			{ enmLanguage.Hungarian, "fordító"},
			{ enmLanguage.Icelandic, "þýðandi"},
			{ enmLanguage.Indonesian, "penterjemah"},
			{ enmLanguage.Italian, "traduttore"},
			{ enmLanguage.Irish, "aistritheoir"},
			{ enmLanguage.Japanese, "翻訳者"},
			{ enmLanguage.Korean, "번역기"},
			{ enmLanguage.Latvian, "tulkotājs"},
			{ enmLanguage.Lithuanian, "vertėjas"},
			{ enmLanguage.Macedonian, "преведувач"},
			{ enmLanguage.Malay, "penterjemah"},
			{ enmLanguage.Maltese, "traduttur"},
			{ enmLanguage.Norwegian, "oversetter"},
			{ enmLanguage.Persian, "مترجم"},
			{ enmLanguage.Polish, "tłumacz"},
			{ enmLanguage.Portuguese, "tradutor"},
			{ enmLanguage.Romanian, "traducător"},
			{ enmLanguage.Russian, "переводчик"},
			{ enmLanguage.Serbian, "преводилац"},
			{ enmLanguage.Slovak, "prekladateľ"},
			{ enmLanguage.Slovenian, "prevajalec"},
			{ enmLanguage.Spanish, "traductor"},
			{ enmLanguage.Swahili, "translator"},
			{ enmLanguage.Swedish, "Översättaren"},
			{ enmLanguage.Thai, "นักแปล"},
			{ enmLanguage.Turkish, "çevirmen"},
			{ enmLanguage.Ukrainian, "перекладач"},
			{ enmLanguage.Urdu, "مترجم"},
			{ enmLanguage.Vietnamese, "dịch"},
			{ enmLanguage.Welsh, "cyfieithydd"},
			{ enmLanguage.Yiddish, "יבערזעצער"}
		};
		
		[Test]
		public void TranslateToAllLanguagesTest()
		{
			var translator = new TextTranslatorGoogleUnofficial(enmLanguage.English);
			foreach (var translatorTranslation in TranslatorTranslations)
			{
				translator.SetLanguageTo(translatorTranslation.Key);
				var translatedWord = translator.Translate(WordToTranslate).Translation;
				if (translatedWord != translatorTranslation.Value)
					Assert.Inconclusive("Translation to language '{0}' failed. Expected '{1}' but actual is '{2}'",
						translatorTranslation.Key, translatorTranslation.Value, translatedWord);
			}
		}

		[Test]
		public void DetectAllLanguagesTest()
		{
			TextTranslatorGoogleUnofficial translator = new TextTranslatorGoogleUnofficial(enmLanguage.English);
			foreach (var translatorTranslation in TranslatorTranslations)
			{
				translator.SetLanguageFrom(null);
				var translatedWord = translator.Translate(translatorTranslation.Value).Translation;
				if (translatedWord != WordToTranslate)
					Assert.Inconclusive("Wrong translation ('{0}') of language '{1}'",
							translatedWord, translatorTranslation.Key);

				if (translator.LanguageFrom != translatorTranslation.Key)
					Assert.Inconclusive("Language '{0}' has not been deteced. Actual language is '{1}'",
						translatorTranslation.Key, translator.LanguageFrom);
			}
		}

		[Test]
		public void TranslateEmptyTest()
		{
			var translator = new TextTranslatorGoogleUnofficial(enmLanguage.English, enmLanguage.Russian);
			var translation = translator.Translate("");
			Assert.AreEqual(null, translation.Translation);
		}
	}
}
