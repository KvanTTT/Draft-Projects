using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnderTheCursorTranslatorLibrary
{
	public struct LanguageIdEncoding
	{
		public string Name
		{
			get;
			set;
		}

		public string Id
		{
			get;
			set;
		}

		public string Encoding
		{
			get;
			set;
		}

		public LanguageIdEncoding(string name, string id, string encoding)
			: this()
		{
			Name = name;
			Id = id;
			Encoding = encoding;
		}

		public override string ToString()
		{
			return Name + " " + Id + " " + Encoding;
		}
	}
}
