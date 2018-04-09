using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using UnderTheCursorTranslatorLibrary;

namespace UnderTheCursorTranslatorTests
{
	[TestFixture]
	public class DictionariesFileNamesTests
	{
		[Test]
		public void SaveLoadTest()
		{
			var dictionariesFileNames = new DictionariesFileNames();
			dictionariesFileNames.Add(enmTextTranslatorType.Xdxf, Environment.CurrentDirectory + "\\xdxf.bin");
			dictionariesFileNames.Add(enmTextTranslatorType.GoogleUnofficial, Environment.CurrentDirectory + 
				"\\googleUnofficial.bin");
			var str = dictionariesFileNames.ToString();

			var dictionariesFileNames2 = new DictionariesFileNames(str);
			foreach (var dict in dictionariesFileNames)
				Assert.IsTrue(dictionariesFileNames2.Contains(dict));
		}
	}
}
