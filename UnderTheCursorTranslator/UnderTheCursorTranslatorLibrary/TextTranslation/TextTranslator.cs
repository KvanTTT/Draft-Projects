using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace UnderTheCursorTranslatorLibrary
{
	[Serializable]
	public abstract class TextTranslator
	{
		#region Languages & Encodings
		
		public static Dictionary<enmLanguage, LanguageIdEncoding> LanguagesEncodings = new Dictionary<enmLanguage, LanguageIdEncoding>()
		{
			{ enmLanguage.Afrikaans, new LanguageIdEncoding("Afrikaans", "af", "ISO-8859-1") },
			{ enmLanguage.Albanian, new LanguageIdEncoding("Albanian", "sq", "ISO-8859-1") },
			{ enmLanguage.Armenian, new LanguageIdEncoding("Armenian", "hy", "UTF-8") },
			{ enmLanguage.Azerbaijani, new LanguageIdEncoding("Azerbaijani", "az", "ISO-8859-9") },
			{ enmLanguage.Arabic, new LanguageIdEncoding("Arabic", "ar", "windows-1256") },
			{ enmLanguage.Basque, new LanguageIdEncoding("Basque", "eu", "ISO-8859-1") },
			{ enmLanguage.Belarusian, new LanguageIdEncoding("Belarusian", "be", "windows-1251") },
			{ enmLanguage.Bulgarian, new LanguageIdEncoding("Bulgarian", "bg", "windows-1251") },
			{ enmLanguage.Catalan, new LanguageIdEncoding("Catalan", "ca", "UTF-8") },
			{ enmLanguage.ChineseSimplified, new LanguageIdEncoding("Chinese (Simplified)", "zh-cn", "GB2312") },
			{ enmLanguage.ChineseTraditional, new LanguageIdEncoding("Chinese (Traditional)", "zh-tw", "Big5") },
			{ enmLanguage.Croatian, new LanguageIdEncoding("Croatian", "hr", "ISO-8859-2") },
			{ enmLanguage.Czech, new LanguageIdEncoding("Czech", "cs", "ISO-8859-2") },
			{ enmLanguage.Danish, new LanguageIdEncoding("Danish", "da", "ISO-8859-1") },
			{ enmLanguage.Dutch, new LanguageIdEncoding("Dutch", "nl", "ISO-8859-1") },
			{ enmLanguage.English, new LanguageIdEncoding("English", "en", "ISO-8859-1") },
			{ enmLanguage.Estonian, new LanguageIdEncoding("Estonian", "et", "windows-1257") },
			{ enmLanguage.Filipino, new LanguageIdEncoding("Filipino", "tl", "ISO-8859-1") },
			{ enmLanguage.Finnish, new LanguageIdEncoding("Finnish", "fi", "ISO-8859-1") },
			{ enmLanguage.French, new LanguageIdEncoding("French", "fr", "ISO-8859-1") },
			{ enmLanguage.Galician, new LanguageIdEncoding("Galician", "gl", "ISO-8859-1") },
			{ enmLanguage.Georgian, new LanguageIdEncoding("Georgian", "ka", "utf-8") },
			{ enmLanguage.German, new LanguageIdEncoding("German", "de", "ISO-8859-1") },
			{ enmLanguage.Greek, new LanguageIdEncoding("Greek", "el", "ISO-8859-7") },
			{ enmLanguage.HaitianCreole, new LanguageIdEncoding("Haitian Creole", "ht", "ISO-8859-1") },
			{ enmLanguage.Hebrew, new LanguageIdEncoding("Hebrew", "iw", "windows-1255") },
			{ enmLanguage.Hindi, new LanguageIdEncoding("Hindi", "hi", "ISO-8859-1") },
			{ enmLanguage.Hungarian, new LanguageIdEncoding("Hungarian", "hu", "ISO-8859-2") },
			{ enmLanguage.Icelandic, new LanguageIdEncoding("Icelandic", "is", "ISO-8859-1") },
			{ enmLanguage.Indonesian, new LanguageIdEncoding("Indonesian", "id", "ISO-8859-1") },
			{ enmLanguage.Italian, new LanguageIdEncoding("Italian", "it", "ISO-8859-1") },
			{ enmLanguage.Irish, new LanguageIdEncoding("Irish", "ga", "ISO-8859-1") },
			{ enmLanguage.Japanese, new LanguageIdEncoding("Japanese", "ja", "Shift_JIS") },
			{ enmLanguage.Korean, new LanguageIdEncoding("Korean", "ko", "EUC-KR") },
			{ enmLanguage.Latvian, new LanguageIdEncoding("Latvian", "lv", "windows-1257") },
			{ enmLanguage.Lithuanian, new LanguageIdEncoding("Lithuanian", "lt", "windows-1257") },
			{ enmLanguage.Macedonian, new LanguageIdEncoding("Macedonian", "mk", "windows-1251") },
			{ enmLanguage.Malay, new LanguageIdEncoding("Malay", "ms", "ISO-8859-1") },
			{ enmLanguage.Maltese, new LanguageIdEncoding("Maltese", "mt", "ISO-8859-1") },
			{ enmLanguage.Norwegian, new LanguageIdEncoding("Norwegian", "no", "ISO-8859-1") },
			{ enmLanguage.Persian, new LanguageIdEncoding("Persian", "fa", "windows-1256") },
			{ enmLanguage.Polish, new LanguageIdEncoding("Polish", "pl", "ISO-8859-2") },
			{ enmLanguage.Portuguese, new LanguageIdEncoding("Portuguese", "pt", "ISO-8859-1") },
			{ enmLanguage.Romanian, new LanguageIdEncoding("Romanian", "ro", "ISO-8859-2") },
			{ enmLanguage.Russian, new LanguageIdEncoding("Russian", "ru", "windows-1251") },
			{ enmLanguage.Serbian, new LanguageIdEncoding("Serbian", "sr", "ISO-8859-2") },
			{ enmLanguage.Slovak,  new LanguageIdEncoding("Slovak", "sk", "ISO-8859-2") },
			{ enmLanguage.Slovenian, new LanguageIdEncoding("Slovenian", "sl", "ISO-8859-2") },
			{ enmLanguage.Spanish, new LanguageIdEncoding("Spanish", "es", "ISO-8859-1") },
			{ enmLanguage.Swahili, new LanguageIdEncoding("Swahili", "sw", "ISO-8859-1") },
			{ enmLanguage.Swedish, new LanguageIdEncoding("Swedish", "sv", "ISO-8859-1") },
			{ enmLanguage.Thai, new LanguageIdEncoding("Thai", "th", "windows-874") },
			{ enmLanguage.Turkish, new LanguageIdEncoding("Turkish", "tr", "ISO-8859-9") },
			{ enmLanguage.Ukrainian, new LanguageIdEncoding("Ukrainian", "uk", "windows-1251") },
			{ enmLanguage.Urdu, new LanguageIdEncoding("Urdu", "ur", "windows-1256") },
			{ enmLanguage.Vietnamese, new LanguageIdEncoding("Vietnamese", "vi", "ISO-8859-1") },
			{ enmLanguage.Welsh, new LanguageIdEncoding("Welsh", "cy", "ISO-8859-1") },
			{ enmLanguage.Yiddish, new LanguageIdEncoding("Yiddish", "yi", "windows-1255") }
		};

		#endregion

		#region
		
		public static enmLanguage GetLanguageFromId(string languageId)
		{
			return LanguagesEncodings.Where(langEnc => languageId.ToLowerInvariant().Contains(langEnc.Value.Id)).First().Key;
		}

		public static enmLanguage GetLanguageFromName(string languageName)
		{
			return LanguagesEncodings.Where(langEnc => langEnc.Value.Name == languageName).First().Key;
		}

		#endregion

		#region Properties

		public enmLanguage? LanguageFrom
		{
			get;
			protected set;
		}

		public enmLanguage LanguageTo
		{
			get;
			protected set;
		}

		public string Format
		{
			get;
			protected set;
		}

		public string FullName
		{
			get;
			protected set;
		}

		public string Description
		{
			get;
			protected set;
		}

		#endregion

		#region Virtual & Abstract
		
		public TextTranslator(string fileName = null)
		{
			if (fileName != null)
				Load(fileName);
		}

		public abstract TranscriptionTranslation Translate(string text);

		public virtual void Save(string fileName)
		{
			using (var writer = new StreamWriter(fileName))
			{
				BinaryFormatter bf = new BinaryFormatter();
				bf.Serialize(writer.BaseStream, this);
			}
		}

		public virtual void Load(string fileName)
		{
			TextTranslator dictionary = null;
			using (var reader = new StreamReader(fileName))
			{
				BinaryFormatter bf = new BinaryFormatter();
				dictionary = (TextTranslator)bf.Deserialize(reader.BaseStream);
			}
			LanguageFrom = dictionary.LanguageFrom;
			LanguageTo = dictionary.LanguageTo;
			Format = dictionary.Format;
			FullName = dictionary.FullName;
			Description = dictionary.Description;
		}
		
		#endregion
	}
}
