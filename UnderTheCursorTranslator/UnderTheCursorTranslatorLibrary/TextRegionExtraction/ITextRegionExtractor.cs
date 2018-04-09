using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace UnderTheCursorTranslatorLibrary
{
	public interface ITextRegionExtractor
	{
		Bitmap ExtractTextRegion(Bitmap bitmap, ref Point position);
	}
}
