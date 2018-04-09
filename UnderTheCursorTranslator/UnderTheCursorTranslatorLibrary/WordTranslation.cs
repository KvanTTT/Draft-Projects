using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnderTheCursorTranslatorLibrary
{
	class WordTranslation : IComparable<WordTranslation>, IComparable
	{
		public WordTranslation(string word, string translation, string transcription)
		{
			Word = word;
			Translation = translation;
			Transcription = transcription;
		}

		public int Number
		{
			get;
			set;
		}

		public string Word
		{
			get;
			set;
		}

		public string Transcription
		{
			get;
			set;
		}

		public string Translation
		{
			get;
			set;
		}

		public int CompareTo(WordTranslation other)
		{
			return Word.CompareTo(other.Word);
		}

		public int CompareTo(object obj)
		{
			return Word.CompareTo((obj as WordTranslation).Word);
		}
	}
}
