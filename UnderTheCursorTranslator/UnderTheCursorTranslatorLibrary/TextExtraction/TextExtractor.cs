using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace UnderTheCursorTranslatorLibrary
{
	public abstract class TextExtractor
	{
		public Bitmap Bitmap
		{
			get;
			set;
		}

		public int CurrentVariantNumber
		{
			get;
			protected set;
		}

		public Point Position
		{
			get;
			protected set;
		}

		public virtual void SetPosition(Point position)
		{
			Position = position;
			CurrentVariantNumber = -1;
		}

		public abstract string NextVariant();
	}
}
