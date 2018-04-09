using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnderTheCursorTranslatorLibrary
{
	public abstract class TextErrorCorrector
	{
		public int CurrentVariantNumber
		{
			get;
			protected set;
		}

		public string Text
		{
			get;
			protected set;
		}

		public virtual void SetText(string text)
		{
			Text = text;
		}

		public abstract string NextVariant();
	}
}
