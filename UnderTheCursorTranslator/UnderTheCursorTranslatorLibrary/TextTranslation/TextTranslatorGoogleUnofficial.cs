using System;
using System.Text;
using System.Net;

namespace UnderTheCursorTranslatorLibrary
{
	public class TextTranslatorGoogleUnofficial : TextTranslator
	{
		#region Constructors
		
		public TextTranslatorGoogleUnofficial(string fileName) : base(fileName)
		{
		}

		public TextTranslatorGoogleUnofficial(enmLanguage? languageFrom, enmLanguage languageTo)
		{
			LanguageFrom = languageFrom;
			LanguageTo = languageTo;
		}

		public TextTranslatorGoogleUnofficial(enmLanguage languageTo)
		{
			LanguageTo = languageTo;
		}

		#endregion

		public override TranscriptionTranslation Translate(string text)
		{
			string htmlResponse = String.Empty;

			using (WebClient webClient = new WebClient())
			{
				webClient.Encoding = Encoding.GetEncoding(LanguagesEncodings[LanguageTo].Encoding);
				webClient.Headers[HttpRequestHeader.UserAgent] = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)";
				string link = GenerateLink(text);
				htmlResponse = webClient.DownloadString(link);
				var realEncoding = GetEncoding(htmlResponse);
				if (realEncoding != webClient.Encoding)
				{
					webClient.Encoding = realEncoding;
					htmlResponse = webClient.DownloadString(link);
				}
				LanguageFrom = DetectLanguage(htmlResponse);
			}

			var translation = GetTranslation(htmlResponse);

			return !string.IsNullOrEmpty(translation) ? new TranscriptionTranslation(text, null, translation) : null;
		}

		public void SetLanguageFrom(enmLanguage? language)
		{
			LanguageFrom = language;
		}

		public void SetLanguageTo(enmLanguage language)
		{
			LanguageTo = language;
		}

		public void ChangeLanguages()
		{
			var tempLang = LanguageFrom;
			LanguageFrom = LanguageTo;
			LanguageTo = (enmLanguage)tempLang;
		}

		protected string GenerateLink(string textToTranslate)
		{
			return String.Format("http://translate.google.com/?langpair={0}|{1}&text={2}",
						LanguageFrom == null ? "auto" : LanguagesEncodings[(enmLanguage)LanguageFrom].Id,
						LanguagesEncodings[LanguageTo].Id,
						WebUtility.HtmlEncode(textToTranslate));
		}

		protected Encoding GetEncoding(string html)
		{
			string l = "charset=";
			int indBegin = html.IndexOf(l) + l.Length;
			int indEnd = html.IndexOf('"', indBegin) - 1;
			string encodingString = html.Substring(indBegin, indEnd - indBegin + 1);
			return Encoding.GetEncoding(encodingString);
		}

		protected string GetTranslation(string html)
		{
			var ind1 = html.IndexOf("result_box");
			var indEnd = html.IndexOf("</span>", ind1) - 1;
			var indBegin = html.LastIndexOf('>', indEnd) + 1;
			return WebUtility.HtmlDecode(html.Substring(indBegin, indEnd - indBegin + 1));
		}

		protected enmLanguage DetectLanguage(string html)
		{
			var ind1 = html.IndexOf("id=src-translit");
			var divStr = "<div class=\"goog-inline-block goog-toolbar-button-inner-box\">";
			var indBegin = html.IndexOf(divStr, ind1) + divStr.Length;
			indBegin = html.IndexOf(divStr, indBegin) + divStr.Length;
			var indEnd = html.IndexOf("</div>", indBegin) - 1;
			var langStr = html.Substring(indBegin, indEnd - indBegin + 1);
			return TextTranslator.GetLanguageFromName(langStr);
		}
	}
}
