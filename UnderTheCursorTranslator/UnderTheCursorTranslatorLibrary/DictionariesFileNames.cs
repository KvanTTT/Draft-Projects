using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnderTheCursorTranslatorLibrary
{
	public class DictionariesFileNames : Dictionary<enmTextTranslatorType, string>
	{
		public DictionariesFileNames()
		{
		}

		public DictionariesFileNames(string str)
		{
			FromString(str);
		}

		public override string ToString()
		{
			var builder = new StringBuilder();
			foreach (var keyValue in this)
				builder.AppendFormat("{0} {1}{2}", keyValue.Key, keyValue.Value, Environment.NewLine);
			return builder.ToString();
		}

		public void FromString(string str)
		{
			Clear();
			var strs = str.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
			foreach (var s in strs)
			{
				var strs2 = s.Split();
				Add((enmTextTranslatorType)Enum.Parse(typeof(enmTextTranslatorType), strs2[0]), strs2[1]);
			}
		}
	}
}
