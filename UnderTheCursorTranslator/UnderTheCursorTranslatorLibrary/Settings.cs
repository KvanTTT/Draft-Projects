using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnderTheCursorTranslatorLibrary
{
	public class Settings
	{
		public InputCombination InputCombination
		{
			get;
			set;
		}

		public string AffixDictionaryFileName
		{
			get;
			set;
		}

		public DictionariesFileNames DictionariesFileNames
		{
			get;
			set;
		}
	}
}
