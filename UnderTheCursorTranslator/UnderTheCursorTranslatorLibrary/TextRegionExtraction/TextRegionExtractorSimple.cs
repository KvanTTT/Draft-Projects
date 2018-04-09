using System.Drawing;

namespace UnderTheCursorTranslatorLibrary
{
    public class TextRegionExtractorSimple : ITextRegionExtractor
	{
		const int AreaWidth = 512;
		const int AreaHeight = 64;

		public Bitmap ExtractTextRegion(Bitmap bitmap, ref Point position)
		{
			int left = position.X - AreaWidth / 2;
			if (left < 0)
				left = 0;
			int width = left + AreaWidth > bitmap.Width ? bitmap.Width - left : AreaWidth;

			int top = position.Y - AreaHeight / 2;
			if (top < 0)
				top = 0;
			int height = top + AreaHeight > bitmap.Height ? bitmap.Height - top : AreaHeight;

			var rect = new Rectangle(left, top, width, height);
			position.X -= left;
			position.Y -= top;

            var result = new Bitmap(rect.Width, rect.Height);
            Graphics g;
            using (g = Graphics.FromImage(bitmap))
            {
                g.DrawImageUnscaledAndClipped(result, rect);
            }
            return result;
		}
	}
}
