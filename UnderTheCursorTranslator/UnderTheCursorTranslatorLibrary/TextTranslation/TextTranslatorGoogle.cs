using Google.Apis.Services;
using Google.Apis.Translate.v2;
using Google.Apis.Util;
using System;

namespace UnderTheCursorTranslatorLibrary
{
	public class TextTranslatorGoogle : TextTranslator
	{
		TranslateService Client;

		public TextTranslatorGoogle(enmLanguage languageFrom, enmLanguage languageTo)
		{
			throw new NotImplementedException();

			/*LanguageFrom = languageFrom;
			LanguageTo = languageTo;
			Client = new TranslateService(new BaseClientService.Initializer()
			{
				ApiKey = "My API Key",
				ApplicationName = "Under The Cursor Translator"
			});*/
		}

		public override TranscriptionTranslation Translate(string text)
		{
			throw new NotImplementedException();

			/*TranscriptionTranslation result;
			if (LanguageFrom == null)
			{
				string languageFrom;
				var request = Client.Translations.List(new Repeatable<string>(new[] { text }),
					TextTranslator.LanguagesEncodings[LanguageTo].Id);
				//LanguageFrom = TextTranslator.GetLanguageFromId(languageFrom);
				var response = request.Execute();
			}
			else
				result = new TranscriptionTranslation(text, string.Empty, Client.Translate(text,
					TextTranslator.LanguagesEncodings[(enmLanguage)LanguageFrom].Id, 
					TextTranslator.LanguagesEncodings[LanguageTo].Id));
			return result;*/
		}
	}
}
