using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnderTheCursorTranslatorLibrary
{
	public class TextTranslatorFactory
	{
		public static TextTranslator CreateTextTranslator(enmTextTranslatorType type, string fileName)
		{
			switch (type)
			{
				case enmTextTranslatorType.Xdxf:
					return new WordTranslatorXdxf(fileName);
				case enmTextTranslatorType.GoogleUnofficial:
					return new TextTranslatorGoogleUnofficial(fileName);
				default:
					return null;
			}
		}
	}
}
