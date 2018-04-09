using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace UnderTheCursorTranslatorLibrary
{
	public class TextRegionExtractor : ITextRegionExtractor
	{
		const int MaxTextAreaWidth = 512; //64;
		const int MaxTextAreaHeight = 64; // 20;

		private byte[] ByteData_;
		private BitmapData BitmapData_;

		protected class Segment
		{
			public int FirstCoord;
			public int LastCoord;

			public Segment()
			{
			}

			public Segment(int firstCoord, int lastCoord)
			{
				FirstCoord = firstCoord;
				LastCoord = lastCoord;
			}
		}

		public Bitmap InputBitmap
		{
			get;
			protected set;
		}

		public TextRegionExtractor()
		{
		}

		protected Rectangle EnlargeRect(Rectangle rectangle, int incWidth, int incHeight)
		{
			int left = rectangle.Left - incWidth;
			int top = rectangle.Top - incHeight;
			int width = rectangle.Width + 2 * incWidth;
			int height = rectangle.Height + 2 * incHeight;

			if (left < 0)
				left = 0;
			if (top < 0)
				top = 0;
			if (left + rectangle.Width > BitmapData_.Width)
				width = BitmapData_.Width - left;
			if (top + rectangle.Height > BitmapData_.Height)
				height = BitmapData_.Height - top;

			return new Rectangle(left, top, width, height);
		}

		public void GetWordRegionTest(Bitmap bitmap, ref Point position)
		{
			InputBitmap = bitmap;

			PrepareByteData();

			double firstThreshold = 0.05;
			double secondThreshold = 0.99;
			double thirdThreshold = 0.05;

			int firstSemiWidth = 4;
			int firstSemiHeight = 4;
			int firstSemiWidthInc = 2;
			int firstSemiHeightInc = 2;
			int firstRectMaxCount = 8;

			int thirdSemiWidthInc = 0;
			int thirdSemiHeightInc = 2;
			int thirdRectMaxCount = 8;

			Rectangle firstVertRect = new Rectangle(position.X - firstSemiWidth, position.Y - firstSemiHeight, firstSemiWidth, firstSemiHeight);
			Rectangle secondHorizRect;
			Rectangle thirdVertRect;

			for (int i = 0; i < firstRectMaxCount; i++)
			{
				var firstVertHistogram = CalculateDifferenceHistogram(false, firstVertRect);
				var firstSegments = GetSegments(firstVertHistogram, firstThreshold, firstThreshold);
				var firstInvertSegments = InvertSegments(firstSegments, firstVertHistogram.Length);

				SaveDifferenceHistogram(firstVertHistogram, false, "first_step_hist_" + i + ".png");
				
				if (firstInvertSegments.Count >= 2)
				{
					var firstNearestSegment = GetNearestSegment(firstSegments, position.Y - firstVertRect.Top);

					var secondHorizHistogram = CalculateDifferenceHistogram(true, new Rectangle(0, firstNearestSegment.FirstCoord + firstVertRect.Top,
						BitmapData_.Width, firstNearestSegment.LastCoord - firstNearestSegment.FirstCoord + 1), true);

					var secondSegments = GetSegments(secondHorizHistogram, secondThreshold, secondThreshold);
					var secondInvertSegments = InvertSegments(secondSegments, firstVertRect.Width);
					var secondNearestSegment = GetNearestSegment(secondInvertSegments, position.X);

					secondHorizRect = new Rectangle(
						secondNearestSegment.FirstCoord,
						firstNearestSegment.FirstCoord + firstVertRect.Top,
						secondNearestSegment.LastCoord - secondNearestSegment.FirstCoord + 1,
						firstNearestSegment.LastCoord - firstNearestSegment.FirstCoord + 1);

					SaveDifferenceHistogram(secondHorizHistogram, true, "second_step_hist.png");
					/*InputBitmap.Clone(new Rectangle(0, firstNearestSegment.FirstCoord + firstVertRect.Top,
						BitmapData_.Width, firstNearestSegment.LastCoord - firstNearestSegment.FirstCoord + 1), PixelFormat.Format32bppRgb).Save(
						SaveDir + "first_step.png", ImageFormat.Png);*/
					//InputBitmap.Clone(secondHorizRect, PixelFormat.Format32bppRgb).Save(SaveDir + "second_step.png", ImageFormat.Png);

					thirdVertRect = secondHorizRect;
					for (int j = 0; j < thirdRectMaxCount; j++)
					{
						var thirdVertHistogram = CalculateDifferenceHistogram(false, thirdVertRect);
						var thirdSegments = GetSegments(thirdVertHistogram, thirdThreshold, thirdThreshold);
						var thirdInvertSegments = InvertSegments(thirdSegments, thirdVertHistogram.Length);

						if (thirdInvertSegments.Count >= 2)
						{
							var thirdNearestSegment = GetNearestSegment(thirdSegments, position.Y - thirdVertRect.Top);

							var finalRect = new Rectangle(
								thirdVertRect.Left, thirdNearestSegment.FirstCoord + thirdVertRect.Top,
								thirdVertRect.Width, thirdNearestSegment.LastCoord - thirdNearestSegment.FirstCoord + 1);
							//InputBitmap.Clone(finalRect, PixelFormat.Format32bppRgb).Save(SaveDir + "third_step.png", ImageFormat.Png);
						}

						thirdVertRect = EnlargeRect(thirdVertRect, thirdSemiWidthInc, thirdSemiHeightInc);
					}
				}

				firstVertRect = EnlargeRect(firstVertRect, firstSemiWidthInc, firstSemiHeightInc);
			}
		}

		

		protected void PrepareByteData()
		{
			var rect = new Rectangle(0, 0, InputBitmap.Width, InputBitmap.Height);
			BitmapData_ = InputBitmap.LockBits(rect, ImageLockMode.ReadOnly, InputBitmap.PixelFormat);
			int bufferSize = BitmapData_.Height * BitmapData_.Stride;

			ByteData_ = new byte[bufferSize];
			Marshal.Copy(BitmapData_.Scan0, ByteData_, 0, bufferSize);

			InputBitmap.UnlockBits(BitmapData_);
		}
		
		protected double[] CalculateDifferenceHistogram(bool horizontal)
		{
			return CalculateDifferenceHistogram(horizontal, new Rectangle(0, 0, BitmapData_.Width, BitmapData_.Height));
		}

		protected double[] CalculateDifferenceHistogram(bool horizontal, Rectangle rect, bool absolute = false)
		{
			const int increment = 4;
			int t;

			int[] intResult;
			if (!horizontal)
			{
				intResult = new int[rect.Height];
				for (int i = rect.Top; i < rect.Top + rect.Height; i++)
				{
					t = i * BitmapData_.Stride;
					if (absolute)
						intResult[i - rect.Top] = ByteData_[t] + ByteData_[t + 1] + ByteData_[t + 2];
					for (int j = rect.Left + 1; j < rect.Left + rect.Width; j++)
					{
						int firstIndex = t + j * increment;
						int secondIndex = firstIndex - increment;
						if (!absolute)
							intResult[i - rect.Top] +=
								Math.Abs(ByteData_[firstIndex] - ByteData_[secondIndex]) +
								Math.Abs(ByteData_[firstIndex + 1] - ByteData_[secondIndex + 1]) +
								Math.Abs(ByteData_[firstIndex + 2] - ByteData_[secondIndex + 2]);
						else
							intResult[i - rect.Top] +=
								ByteData_[firstIndex] + ByteData_[firstIndex + 1] + ByteData_[firstIndex + 2];
					}
				}
			}
			else
			{
				intResult = new int[rect.Width];
				if (absolute)
					for (int i = rect.Left; i < rect.Left + rect.Width; i++)
					{
						t = i * increment + rect.Top * BitmapData_.Stride;
						intResult[i - rect.Left] = ByteData_[t] + ByteData_[t + 1] + ByteData_[t + 2];
					}
				for (int i = rect.Top + 1; i < rect.Top + rect.Height; i++)
				{
					t = i * BitmapData_.Stride;
					for (int j = rect.Left + 1; j < rect.Left + rect.Width; j++)
					{
						int firstIndex = t + j * increment;
						int secondIndex = firstIndex - BitmapData_.Stride;
						int thirdIndex = firstIndex - increment;
						if (!absolute)
							intResult[j - rect.Left] +=
								Math.Abs(Math.Abs(ByteData_[firstIndex] - ByteData_[secondIndex]) - ByteData_[thirdIndex]) +
								Math.Abs(Math.Abs(ByteData_[firstIndex + 1] - ByteData_[secondIndex + 1]) - ByteData_[thirdIndex + 1]) +
								Math.Abs(Math.Abs(ByteData_[firstIndex + 2] - ByteData_[secondIndex + 2]) - ByteData_[thirdIndex + 2]);
							/*intResult[j - rect.Left] +=
								Math.Abs(ByteData_[firstIndex] - ByteData_[secondIndex]) - Math.Abs(ByteData_[firstIndex] - ByteData_[thirdIndex]) +
								Math.Abs(ByteData_[firstIndex + 1] - ByteData_[secondIndex + 1]) - Math.Abs(ByteData_[firstIndex + 1] - ByteData_[thirdIndex + 1]) +
								Math.Abs(ByteData_[firstIndex + 2] - ByteData_[secondIndex + 2]) - Math.Abs(ByteData_[firstIndex + 2] - ByteData_[thirdIndex + 2]);*/
						else
							intResult[j - rect.Left] +=
								ByteData_[firstIndex] + ByteData_[firstIndex + 1] + ByteData_[firstIndex + 2];
					}
				}
			}

			var max = intResult.Max();
			var result = new double[intResult.Length];
			if (max != 0)
				for (int i = 0; i < intResult.Length; i++)
					result[i] = (double)intResult[i] / (double)max;

			return result;
		}

		protected List<Segment> GetSegments(double[] differenceHistogram, double inTheshold, double outTheshhold, int minWidth = 0)
		{
			List<Segment> result = new List<Segment>();

			Segment segment = null;
			for (int i = 0; i < differenceHistogram.Length; i++)
			{
				//if (i != 0)
				//	runningTotal -= differenceHistogram[i - 1];
				//runningTotal += differenceHistogram[i];
				//average = runningTotal / (i + 1);

				if (differenceHistogram[i] >= inTheshold)
				{
					if (segment == null)
						segment = new Segment { FirstCoord = i };
				}
				else if (differenceHistogram[i] < outTheshhold)
				{
					if (segment != null)
					{
						segment.LastCoord = i - 1;
						if (segment.LastCoord - segment.FirstCoord >= minWidth)
							result.Add(segment);
						segment = null;
					}
				}
			}
			if (segment != null)
			{
				segment.LastCoord = differenceHistogram.Length - 1;
				if (segment.LastCoord - segment.FirstCoord >= minWidth)
					result.Add(segment);
			}

			return result;
		}

		protected List<Segment> InvertSegments(List<Segment> segments, int width)
		{
			var result = new List<Segment>();
			int oldCoord = 0;

			foreach (var segment in segments)
			{
				if (segment.FirstCoord - oldCoord > 0)
					result.Add(new Segment(oldCoord, segment.FirstCoord - 1));
				oldCoord = segment.LastCoord + 1;
			}
			if (width - oldCoord > 0)
				result.Add(new Segment(oldCoord, width - 1));

			return result;
		}

		protected Segment GetNearestSegment(List<Segment> segments, int coord)
		{
			Segment result = segments[0];
			int minDistance = Math.Abs(coord - segments[0].FirstCoord);

			foreach (var segment in segments)
				if (coord >= segment.FirstCoord && coord <= segment.LastCoord)
				{
					minDistance = 0;
					result = segment;
				}
				else if (Math.Abs(coord - segment.FirstCoord) < minDistance)
				{
					minDistance = Math.Abs(coord - segment.FirstCoord);
					result = segment;
				}
				else if (Math.Abs(coord - segment.LastCoord) < minDistance)
				{
					minDistance = Math.Abs(coord - segment.LastCoord);
					result = segment;
				}

			return result;
		}

		protected void SaveDifferenceHistogram(double[] histogram, bool horizontal, string name)
		{
			int histogramHeight = 100;//horizontal ? BitmapData_.Height : BitmapData_.Width;
			
			var result = new Bitmap(horizontal ? histogram.Length : histogramHeight, horizontal ? histogramHeight : histogram.Length);

			var g = Graphics.FromImage(result);
			g.Clear(Color.White);

			PointF oldPoint;
			var redPen = Pens.Red;

			if (horizontal)
			{
				oldPoint = new PointF(0.0f, (float)(histogram[0] * histogramHeight));
				for (int i = 1; i < histogram.Length; i++)
				{
					var newPoint = new PointF(i, (float)Math.Round(histogram[i] * histogramHeight));
					g.DrawLine(redPen, oldPoint, newPoint);
					oldPoint = newPoint;
				}
			}
			else
			{
				oldPoint = new PointF((float)(histogram[0] * histogramHeight), 0);
				for (int i = 1; i < histogram.Length; i++)
				{
					var newPoint = new PointF((float)Math.Round(histogram[i] * histogramHeight), i);
					g.DrawLine(redPen, oldPoint, newPoint);
					oldPoint = newPoint;
				}
			}

			//result.Save(SaveDir + name, ImageFormat.Png);
		}

		public Bitmap ExtractTextRegion(Bitmap bitmap, ref Point position)
		{
			InputBitmap = bitmap;

			PrepareByteData();

			double firstThreshold = 0.05;
			double secondThreshold = 0.99;
			double thirdThreshold = 0.05;

			int firstSemiWidth = 4;
			int firstSemiHeight = 4;
			int firstSemiWidthInc = 2;
			int firstSemiHeightInc = 2;
			int firstRectMaxCount = 8;

			int thirdSemiWidthInc = 0;
			int thirdSemiHeightInc = 2;
			int thirdRectMaxCount = 8;

			Rectangle firstVertRect = new Rectangle(position.X - firstSemiWidth, position.Y - firstSemiHeight, firstSemiWidth, firstSemiHeight);
			Rectangle secondHorizRect;
			Rectangle thirdVertRect;
			Rectangle? finalRect = null;

			for (int i = 0; i < firstRectMaxCount; i++)
			{
				var firstVertHistogram = CalculateDifferenceHistogram(false, firstVertRect);
				var firstSegments = GetSegments(firstVertHistogram, firstThreshold, firstThreshold);
				var firstInvertSegments = InvertSegments(firstSegments, firstVertHistogram.Length);

				//SaveDifferenceHistogram(firstVertHistogram, false, "first_step_hist_" + i + ".png");

				if (firstInvertSegments.Count >= 2)
				{
					var firstNearestSegment = GetNearestSegment(firstSegments, position.Y - firstVertRect.Top);

					var secondHorizHistogram = CalculateDifferenceHistogram(true, new Rectangle(0, firstNearestSegment.FirstCoord + firstVertRect.Top,
						BitmapData_.Width, firstNearestSegment.LastCoord - firstNearestSegment.FirstCoord + 1), true);

					var secondSegments = GetSegments(secondHorizHistogram, secondThreshold, secondThreshold);
					var secondInvertSegments = InvertSegments(secondSegments, firstVertRect.Width);
					var secondNearestSegment = GetNearestSegment(secondInvertSegments, position.X);

					secondHorizRect = new Rectangle(
						secondNearestSegment.FirstCoord,
						firstNearestSegment.FirstCoord + firstVertRect.Top,
						secondNearestSegment.LastCoord - secondNearestSegment.FirstCoord + 1,
						firstNearestSegment.LastCoord - firstNearestSegment.FirstCoord + 1);
					/*
					SaveDifferenceHistogram(secondHorizHistogram, true, "second_step_hist.png");
					InputBitmap.Clone(new Rectangle(0, firstNearestSegment.FirstCoord + firstVertRect.Top,
						BitmapData_.Width, firstNearestSegment.LastCoord - firstNearestSegment.FirstCoord + 1), PixelFormat.Format32bppRgb).Save(
						SaveDir + "first_step.png", ImageFormat.Png);
					InputBitmap.Clone(secondHorizRect, PixelFormat.Format32bppRgb).Save(SaveDir + "second_step.png", ImageFormat.Png);
					*/
					thirdVertRect = secondHorizRect;
					for (int j = 0; j < thirdRectMaxCount; j++)
					{
						var thirdVertHistogram = CalculateDifferenceHistogram(false, thirdVertRect);
						var thirdSegments = GetSegments(thirdVertHistogram, thirdThreshold, thirdThreshold);
						var thirdInvertSegments = InvertSegments(thirdSegments, thirdVertHistogram.Length);

						if (thirdInvertSegments.Count >= 2)
						{
							var thirdNearestSegment = GetNearestSegment(thirdSegments, position.Y - thirdVertRect.Top);

							finalRect = new Rectangle(
								thirdVertRect.Left, thirdNearestSegment.FirstCoord + thirdVertRect.Top,
								thirdVertRect.Width, thirdNearestSegment.LastCoord - thirdNearestSegment.FirstCoord + 1);
							goto exit;
							//InputBitmap.Clone(finalRect, PixelFormat.Format32bppRgb).Save(SaveDir + "third_step.png", ImageFormat.Png);
						}

						thirdVertRect = EnlargeRect(thirdVertRect, thirdSemiWidthInc, thirdSemiHeightInc);
					}
				}

				firstVertRect = EnlargeRect(firstVertRect, firstSemiWidthInc, firstSemiHeightInc);
			}

		exit:

			Bitmap result = null;
			if (finalRect.HasValue)
			{
				position.X -= finalRect.Value.Left;
				position.Y -= finalRect.Value.Top;
				result = InputBitmap.Clone(finalRect.Value, PixelFormat.Format32bppRgb);
			}

			return result;
		}
	}
}
