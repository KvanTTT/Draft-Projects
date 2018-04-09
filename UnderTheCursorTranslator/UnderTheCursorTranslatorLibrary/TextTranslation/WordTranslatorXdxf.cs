using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using MouseKeyboardLibrary;

namespace UnderTheCursorTranslatorLibrary
{
	[Serializable]
	public class WordTranslatorXdxf : TextTranslator
	{
		SerializableSortedList<string, TranscriptionTranslation> SortedList;
		
		#region Constructors

		public WordTranslatorXdxf(string fileName = null) : base(fileName)
		{
		}

		#endregion

		public void LoadFromXdxf(string xdxfFileName)
		{
			var document = XDocument.Load(xdxfFileName);
			var xdxfElement = document.Element("xdxf");

			LanguageFrom = TextTranslator.GetLanguageFromId(xdxfElement.Attribute("lang_from").Value);
			LanguageTo = TextTranslator.GetLanguageFromId(xdxfElement.Attribute("lang_to").Value);
			Format = xdxfElement.Attribute("format").Value;
			var fullNameElem = document.Element("full_name");
			//FullName = document.Element("full_name").Value;
			//Description = document.Element("description").Value;

			SortedList = new SerializableSortedList<string, TranscriptionTranslation>();
			var documentElements = xdxfElement.Elements("ar");
			foreach (var element in documentElements)
			{
				var transcriptionTranslate = new TranscriptionTranslation
				{
					Transcription = element.Element("tr") == null ? string.Empty : element.Element("tr").Value,
					Translation = element.Value
				};

				SortedList.Add(element.Element("k").Value, transcriptionTranslate);
			}
		}

		#region Implementation

		public override void Load(string fileName)
		{
			WordTranslatorXdxf dictionary = null;
			using (var reader = new StreamReader(fileName))
			{
				BinaryFormatter bf = new BinaryFormatter();
				dictionary = (WordTranslatorXdxf)bf.Deserialize(reader.BaseStream);
			}
			LanguageFrom = dictionary.LanguageFrom;
			LanguageTo = dictionary.LanguageTo;
			Format = dictionary.Format;
			FullName = dictionary.FullName;
			Description = dictionary.Description;
			SortedList = dictionary.SortedList;
		}

		public override TranscriptionTranslation Translate(string word)
		{
			if (SortedList.ContainsKey(word))
				return new TranscriptionTranslation(word, SortedList[word]);
			else
				return null;
		}

		#endregion
	}
}
