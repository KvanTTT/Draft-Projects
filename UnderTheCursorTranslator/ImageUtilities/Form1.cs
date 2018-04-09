using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace ImageUtilities
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void btnLoad_Click(object sender, EventArgs e)
		{
			if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				pbImage.Image = new Bitmap(openFileDialog1.FileName);
			}
		}

		private void btnCalculate_Click(object sender, EventArgs e)
		{
			var horizHisogramm = CalculateHistogram(true);
			var vertHisogramm = CalculateHistogram(false);

			var horizontalBitmap = new Bitmap(horizontal.Width, horizontal.Height);
			var g = Graphics.FromImage(horizontalBitmap);
			g.Clear(Color.White);
			var oldPoint = new PointF(0.0f, (float)(horizHisogramm[0] * horizontal.Height));
			var redPen = Pens.Red;
			for (int i = 1; i < horizHisogramm.Length; i++)
			{
				var newPoint = new PointF(i, (float)(horizHisogramm[i] * horizontal.Height));
				g.DrawLine(redPen, oldPoint, newPoint);
				oldPoint = newPoint;
			}
			horizontal.Image = horizontalBitmap;

			var verticalBitmap = new Bitmap(vertical.Width, vertical.Height);
			g = Graphics.FromImage(verticalBitmap);
			g.Clear(Color.White);
			oldPoint = new PointF((float)(vertHisogramm[0] * vertical.Width), 0);
			for (int i = 1; i < vertHisogramm.Length; i++)
			{
				var newPoint = new PointF((float)(vertHisogramm[i] * vertical.Width), i);
				g.DrawLine(redPen, oldPoint, newPoint);
				oldPoint = newPoint;
			}
			vertical.Image = verticalBitmap;

			var bitmap = (Bitmap)pbImage.Image;
			/*var horizHisogramm2 = CalculateDifferenceHistogram(bitmap, true, 0, bitmap.Width - 1);
			var vertHisogramm2 = CalculateDifferenceHistogram(bitmap, false, 0, bitmap.Height - 1);*/
			var horizHisogramm2 = CalculateHistogram(true);
			var vertHisogramm2 = CalculateHistogram(false);

			horizontalBitmap = new Bitmap(horizontal2.Width, horizontal2.Height);
			g = Graphics.FromImage(horizontalBitmap);
			g.Clear(Color.White);
			oldPoint = new PointF(0.0f, (float)(horizHisogramm2[0] * horizontal2.Height));
			for (int i = 1; i < horizHisogramm2.Length; i++)
			{
				var newPoint = new PointF(i, (float)(horizHisogramm2[i] * horizontal2.Height));
				g.DrawLine(redPen, oldPoint, newPoint);
				oldPoint = newPoint;
			}
			horizontal2.Image = horizontalBitmap;

			verticalBitmap = new Bitmap(vertical2.Width, vertical2.Height);
			g = Graphics.FromImage(verticalBitmap);
			g.Clear(Color.White);
			oldPoint = new PointF((float)(vertHisogramm2[0] * vertical2.Width), 0);
			for (int i = 1; i < vertHisogramm2.Length; i++)
			{
				var newPoint = new PointF((float)(vertHisogramm2[i] * vertical2.Width), i);
				g.DrawLine(redPen, oldPoint, newPoint);
				oldPoint = newPoint;
			}
			vertical2.Image = verticalBitmap;
		}

		private double[] CalculateHistogram(bool horizontal)
		{
			var bitmap = (Bitmap)pbImage.Image;
			int[] intResult;

			if (horizontal)
			{
				intResult = new int[bitmap.Width];

				for (int i = 0; i < bitmap.Width; i++)
					for (int j = 0; j < bitmap.Height; j++)
					{
						var pixel = bitmap.GetPixel(i, j);
						intResult[i] += pixel.R + pixel.G + pixel.B;
					}
			}
			else
			{
				intResult = new int[bitmap.Height];

				for (int i = 0; i < bitmap.Height; i++)
					for (int j = 0; j < bitmap.Width; j++)
					{
						var pixel = bitmap.GetPixel(j, i);
						intResult[i] += pixel.R + pixel.G + pixel.B;
					}
			}

			var max = intResult.Max();
			var result = new double[intResult.Length];
			for (int i = 0; i < intResult.Length; i++)
				result[i] = (double)intResult[i] / (double)max;

			return result;
		}

		private double[] CalculateDifference(bool horizontal)
		{
			var bitmap = (Bitmap)pbImage.Image;
			int[] intResult;
			Color color, oldColor, newColor;

			if (horizontal)
			{
				intResult = new int[bitmap.Width];


				for (int i = 0; i < bitmap.Width; i++)
				{
					oldColor = bitmap.GetPixel(i, 0);
					color = bitmap.GetPixel(i, 1);
					for (int j = 1; j < bitmap.Height - 1; j++)
					{
						newColor = bitmap.GetPixel(i, j + 1);

						intResult[i] +=
							Math.Abs(newColor.R - color.R) + //Math.Abs(oldColor.R - color.R) +
							Math.Abs(newColor.G - color.G) + //Math.Abs(oldColor.G - color.G) +
							Math.Abs(newColor.B - color.B);//Math.Abs(oldColor.B - color.B);

						oldColor = color;
						color = newColor;
					}
				}
			}
			else
			{
				intResult = new int[bitmap.Height];

				for (int i = 0; i < bitmap.Height; i++)
				{
					oldColor = bitmap.GetPixel(0, i);
					color = bitmap.GetPixel(1, i);
					for (int j = 1; j < bitmap.Width - 1; j++)
					{
						newColor = bitmap.GetPixel(j + 1, i);

						intResult[i] +=
							Math.Abs(newColor.R - color.R) + //Math.Abs(oldColor.R - color.R) +
							Math.Abs(newColor.G - color.G) + //Math.Abs(oldColor.G - color.G) +
							Math.Abs(newColor.B - color.B);//Math.Abs(oldColor.B - color.B);

						oldColor = color;
						color = newColor;
					}
				}
			}

			var max = intResult.Max();
			var result = new double[intResult.Length];
			for (int i = 0; i < intResult.Length; i++)
				result[i] = (double)intResult[i] / (double)max;

			return result;
		}


		private double[] CalculateDifferenceHistogram(Bitmap bitmap, bool horizontal, int firstCoord, int lastCoord)
		{
			var rect = horizontal ? new Rectangle(firstCoord, 0, lastCoord - firstCoord + 1, bitmap.Height) :
				new Rectangle(0, firstCoord, bitmap.Width, lastCoord - firstCoord + 1);
			var bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, bitmap.PixelFormat);
			int bufferSize = bitmapData.Height * bitmapData.Stride;
			
			byte[] bytesData = new byte[bufferSize];
			Marshal.Copy(bitmapData.Scan0, bytesData, 0, bytesData.Length);

			bitmap.UnlockBits(bitmapData);

			var increment = bitmap.PixelFormat == PixelFormat.Format24bppRgb ? 3 : 
				bitmap.PixelFormat == PixelFormat.Format8bppIndexed ? 1 : 4;

			int[] intResult;
			if (!horizontal)
			{
				intResult = new int[bitmapData.Height];
				for (int i = 0; i < bitmapData.Height; i += 1)
				{
					int firstPixelPos = i * bitmapData.Stride;
					intResult[i] = bytesData[firstPixelPos] + bytesData[firstPixelPos + 1] + bytesData[firstPixelPos + 2];
					for (int j = firstPixelPos + increment; j < (i + 1) * bitmapData.Stride - increment; j += increment)
					{
						intResult[i] +=
							Math.Abs(bytesData[j] - bytesData[j - increment]) +
							Math.Abs(bytesData[j + 1] - bytesData[j + 1 - increment]) +
							Math.Abs(bytesData[j + 2] - bytesData[j + 2 - increment]);
					}
				}
			}
			else
			{
				intResult = new int[bitmapData.Width];
				for (int i = 0; i < bitmapData.Stride; i += increment)
					try
					{
						intResult[i / increment] = bytesData[i] + bytesData[i + 1] + bytesData[i + 2];
					}catch
					{}
				for (int i = 1; i < bitmapData.Height; i += 1)
				{
					int t = i * bitmapData.Stride;
					for (int j = 0; j < bitmapData.Width; j++)
					{
						int firstIndex = t + j * increment;
						int secondIndex = firstIndex - bitmapData.Stride;
						intResult[j] +=
							Math.Abs(bytesData[firstIndex] - bytesData[secondIndex]) +
							Math.Abs(bytesData[firstIndex + 1] - bytesData[secondIndex + 1]) +
							Math.Abs(bytesData[firstIndex + 2] - bytesData[secondIndex + 2]);
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

		/*
		private double[] CalculateDifferenceHistogram2(Bitmap bitmap, bool horizontal, int firstCoord, int lastCoord)
		{
			var rect = horizontal ? new Rectangle(firstCoord, 0, lastCoord - firstCoord + 1, bitmap.Height) :
				new Rectangle(0, firstCoord, bitmap.Width, lastCoord - firstCoord + 1);
			var bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, bitmap.PixelFormat);
			int bufferSize = bitmapData.Height * bitmapData.Width;

			int[] intData = new int[bufferSize];
			Marshal.Copy(bitmapData.Scan0, intData, 0, intData.Length);

			int[] intResult;
			if (!horizontal)
			{
				intResult = new int[bitmapData.Height];
				for (int i = 0; i < bitmapData.Height; i += 1)
				{
					int firstPixelPos = i * bitmapData.Width;
					intResult[i] = intData[firstPixelPos] + (intData[firstPixelPos] >> 8) + (intData[firstPixelPos] >> 16);
					for (int j = firstPixelPos + 1; j < (i + 1) * bitmapData.Width - increment; j++)
					{
						intResult[i] +=
							(intData[j] - intData[j - 1]) & 0x000000FF +
							(intData[j] - intData[j - 1]) & 0x000000FF +
							(intData[j] - intData[j - 1]) & 0x000000FF +
					}
				}
			}
			else
			{
				intResult = new int[bitmapData.Width];
				for (int i = 0; i < bitmapData.Stride; i += increment)
					intResult[i / increment] = intData[i] + intData[i + 1] + intData[i + 2];
				for (int i = 1; i < bitmapData.Height; i += 1)
				{
					int t = i * bitmapData.Stride;
					for (int j = 0; j < bitmapData.Width; j++)
					{
						int firstIndex = t + j * increment;
						int secondIndex = firstIndex - bitmapData.Stride;
						intResult[j] +=
							Math.Abs(intData[firstIndex] - intData[secondIndex]) +
							Math.Abs(intData[firstIndex + 1] - intData[secondIndex + 1]) +
							Math.Abs(intData[firstIndex + 2] - intData[secondIndex + 2]);
					}
				}
			}

			bitmap.UnlockBits(bitmapData);

			var max = intResult.Max();
			var result = new double[intResult.Length];
			if (max != 0)
				for (int i = 0; i < intResult.Length; i++)
					result[i] = (double)intResult[i] / (double)max;

			return result;
		}*/
	}
}
