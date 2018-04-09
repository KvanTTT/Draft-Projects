using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnderTheCursorTranslatorLibrary
{
	public class WordErrorCorrectorUselessChars : TextErrorCorrector
	{
		protected string Word;

		static char[] IgnoringChars =
			   new char[]  {
				' ', '\t', '\n', '\r', ',', '.', ';', ':',  '\'', '/', '|', 
				'"', '-', '+', '!', '?', '`', '~', '@', '№', '*', '(', ')' };
		
		#region Implementation

		public override void SetText(string text)
		{
			Word = TrimUseless(text);
			CurrentVariantNumber = -1;
		}

		public override string NextVariant()
		{
			if (CurrentVariantNumber == -1)
			{
				CurrentVariantNumber++;
				return Word;
			}
			else
			{
				if (CurrentVariantNumber == 0)
					CurrentVariantNumber++;
				return null;
			}
		}

		#endregion

		protected static string TrimUseless(string word)
		{
			return word.Trim(IgnoringChars).ToLowerInvariant();
		}
	}
}
