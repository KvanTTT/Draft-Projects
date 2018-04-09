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
using NLog;

namespace UnderTheCursorTranslatorLibrary
{
	public delegate void ProcessTranslationDelegate(IList<TranscriptionTranslation> translation);

	public class GeneralProcessor
	{
		public InputHook InputHooker
		{
			get;
			protected set;
		}

		public ScreenCapturer ScreenCapturer
		{
			get;
			protected set;
		}

		public ITextRegionExtractor WordRegionSelector
		{
			get;
			protected set;
		}

		public TextExtractor WordsRecognizer
		{
			get;
			protected set;
		}

		public TextErrorCorrector WordErrorCorrector
		{
			get;
			protected set;
		}

		public IList<TextTranslator> TextTranslators
		{
			get;
			protected set;
		}

		public event ProcessTranslationDelegate ProcessTranslation;

		void OnProcessTranslation(IList<TranscriptionTranslation> translation)
		{
			if (ProcessTranslation != null)
			{
				var func = new ProcessTranslationDelegate(ProcessTranslation);
				func.BeginInvoke(translation, null, null);
			}
		}

		Logger Logger;

		public GeneralProcessor(Settings settings)
		{
			Logger = LogManager.GetCurrentClassLogger();

			InputHooker = new InputHookWin(settings.InputCombination, ProcessInput);
			ScreenCapturer = new ScreenCapturerWin();
			WordRegionSelector = new TextRegionExtractorSimple();
			WordsRecognizer = new WordRecognizerTesseractHocr();
			WordErrorCorrector = new WordErrorCorrectorHunspell(settings.AffixDictionaryFileName);
			TextTranslators = new List<TextTranslator>();
			foreach (var dictionaryTypeFileName in settings.DictionariesFileNames)
				TextTranslators.Add(
					TextTranslatorFactory.CreateTextTranslator(
					dictionaryTypeFileName.Key,
					dictionaryTypeFileName.Value));
		}

		protected void ProcessInput()
		{
			var bitmap = ScreenCapturer.Capture();
			var position = ScreenCapturer.CursorPosition;
			Logger.Info("Bitmap with size {0},{1} and cursor pos {2},{3} has been captured",
				bitmap.Width, bitmap.Height, position.X, position.Y);

			var wordRegion = WordRegionSelector.ExtractTextRegion(bitmap, ref position);
			Logger.Info("Bitmap has been cropped to size {0},{1} and cursor pos {2},{3}",
				wordRegion.Width, wordRegion.Height, position.X, position.Y);

			WordsRecognizer.Bitmap = wordRegion;
			WordsRecognizer.SetPosition(position);
			var word = WordsRecognizer.NextVariant();
			Logger.Info("Recognized word under the cursor: " + word);

			WordErrorCorrector.SetText(word);
			string correctedWord;
			TranscriptionTranslation tempTranslation;
			var translations = new List<TranscriptionTranslation>();

			foreach (var translator in TextTranslators)
			{
				tempTranslation = null;
				while (tempTranslation == null && (correctedWord = WordErrorCorrector.NextVariant()) != null)
				{
					Logger.Info("Word after triming and error correction: " + correctedWord);
					tempTranslation = translator.Translate(correctedWord);
					if (tempTranslation == null)
						Logger.Error("Translation failed. Check next variant from Corrector");
				}
				if (tempTranslation != null)
					translations.Add(tempTranslation);
			}

			if (translations.Count != 0)
			{
				OnProcessTranslation(translations);
				Logger.Info("Process Translation function has been invoked");
			}
			else
				Logger.Info("Translation has not been found");
		}
	}
}
