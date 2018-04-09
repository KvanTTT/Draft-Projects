using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnderTheCursorTranslatorLibrary
{
	[Serializable]
	public class TranscriptionTranslation
	{
		public string Word;

		public string Transcription;

		public string Translation;

		public TranscriptionTranslation()
		{
		}

		public TranscriptionTranslation(string word, TranscriptionTranslation transcriptionTranslation)
		{
			Word = word;
			Transcription = transcriptionTranslation.Transcription;
			Translation = transcriptionTranslation.Translation;
		}

		public TranscriptionTranslation(string word, string transcription, string translation)
		{
			Word = word;
			Transcription = transcription;
			Translation = translation;
		}
	}

}
