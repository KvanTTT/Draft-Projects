using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;
using NHunspell;

namespace UnderTheCursorTranslatorLibrary
{
	public class WordErrorCorrectorHunspell : WordErrorCorrectorUselessChars
	{
		protected List<string> Suggests;
		protected Hunspell Hunspell;
		protected bool IsCorrectWord;

		public WordErrorCorrectorHunspell(byte[] affixFileData = null, byte[] dictionaryFileData = null)
		{
			if (affixFileData != null && dictionaryFileData != null)
				Hunspell = new Hunspell(affixFileData, dictionaryFileData);
		}

		public WordErrorCorrectorHunspell(string fileNameWithoutExtension)
		{
			if (!string.IsNullOrEmpty(fileNameWithoutExtension))
				Hunspell = new Hunspell(fileNameWithoutExtension + ".aff", fileNameWithoutExtension + ".dic");
		}

		#region Implementation

		public override void SetText(string text)
		{
			base.SetText(text);
			Suggests = null;
			IsCorrectWord = false;
		}

		public override string NextVariant()
		{
			if (Hunspell != null)
			{
				if (CurrentVariantNumber == -1)
				{
					CurrentVariantNumber++;
					if (Hunspell.Spell(Word))
					{
						IsCorrectWord = true;
						return Word;
					}
					else
					{
						Suggests = Hunspell.Suggest(Word);
						if (Suggests.Count != 0)
							return TrimUseless(Suggests[CurrentVariantNumber]);
						else
							return null;
					}
				}
				else
				{
					if (Suggests == null)
					{
						CurrentVariantNumber = 1;
						Suggests = Hunspell.Suggest(Word);
						if (Suggests.Count != 0)
							return TrimUseless(Suggests[0]);
						else
							return null;
					}
					else if (Suggests.Count != 0)
					{
						if (IsCorrectWord)
						{
							if (CurrentVariantNumber + 1 - 1 <= Suggests.Count)
							{
								CurrentVariantNumber++;
								return TrimUseless(Suggests[CurrentVariantNumber - 1]);
							}
							else
							{
								if (CurrentVariantNumber + 1 - 1 == Suggests.Count - 1)
									CurrentVariantNumber++;
								return null;
							}
						}
						else
						{
							if (CurrentVariantNumber + 1 < Suggests.Count)
							{
								CurrentVariantNumber++;
								return TrimUseless(Suggests[CurrentVariantNumber]);
							}
							else
							{
								if (CurrentVariantNumber == Suggests.Count - 1)
									CurrentVariantNumber++;
								return null;
							}
						}
					}
					else
						return null;
				}
			}
			else
				return base.NextVariant();
		}

		#endregion
	}
}
