using System;
using System.Drawing;

namespace BinarySundial
{
    public class ColorHelper
	{
		public static Color[] DivideSpectrum(int colorCount, double offset, double luminosity)
		{
			var result = new Color[colorCount];

			/*if (colorCount == 4)
			{
				var rgb = (new Lab { L = luminosity * 100, A = -128, B = -128 }).ToRgb();
				result[0] = Color.FromArgb((int)Math.Round(rgb.R), (int)Math.Round(rgb.G), (int)Math.Round(rgb.B));
				rgb = (new Lab { L = luminosity * 100, A = -128, B = 128}).ToRgb();
				result[1] = Color.FromArgb((int)Math.Round(rgb.R), (int)Math.Round(rgb.G), (int)Math.Round(rgb.B));
				rgb = (new Lab { L = luminosity * 100, A = 128, B = 128 }).ToRgb();
				result[2] = Color.FromArgb((int)Math.Round(rgb.R), (int)Math.Round(rgb.G), (int)Math.Round(rgb.B));
				rgb = (new Lab { L = luminosity * 100, A = 128, B = -128 }).ToRgb();
				result[3] = Color.FromArgb((int)Math.Round(rgb.R), (int)Math.Round(rgb.G), (int)Math.Round(rgb.B));
			}
			else*/
			{
				for (int i = 0; i < colorCount; i++)
					result[i] = HsvToRgb((double)(i + offset) / colorCount, 1, luminosity);
			}
			

			return result;
		}

		public static Color[] GetBlendingColors(Color[] colors, CodingFormat format)
		{
			var result = new Color[1 << colors.Length];

			for (int i = 0; i < result.Length; i++)
			{
				int r = 0, g = 0, b = 0;
				int n = i;
				if (format == CodingFormat.Gray)
					n = i ^ (i >> 1);
				for (int j = 0; j < colors.Length; j++)
				{
					if (((n >> j) & 1) == 1)
					{
						r = Clamp(r + colors[j].R);
						g = Clamp(g + colors[j].G);
						b = Clamp(b + colors[j].B);
					}
					result[i] = Color.FromArgb(r, g, b);
				}
			}

			return result;
		}

		public static Color HslToRgb(double h, double s, double l)
		{
			double r, g, b;

			if (s == 0)
			{
				r = g = b = l;
			}
			else
			{
				var q = l < 0.5 ? l * (1 + s) : l + s - l * s;
				var p = 2 * l - q;
				r = Hue2Rgb(p, q, h + 1 / 3);
				g = Hue2Rgb(p, q, h);
				b = Hue2Rgb(p, q, h - 1 / 3);
			}

			return Color.FromArgb(255, (int)Math.Round(r * 255), (int)Math.Round(g * 255), (int)Math.Round(b * 255));
		}

		private static double Hue2Rgb(double p, double q, double t)
		{
			if (t < 0)
				t += 1;
			if (t > 1)
				t -= 1;
			if (t < 1 / 6)
				return p + (q - p) * 6 * t;
			if (t < 1 / 2)
				return q;
			if (t < 2 / 3)
				return p + (q - p) * (2 / 3 - t) * 6;
			return p;
		}

		public static HSL RgbToHsl(Color color)
		{
			double r = color.R / 255.0;
			double g = color.G / 255.0;
			double b = color.B / 255.0;
			var max = Math.Max(r, g);
			max = Math.Max(max, b);
			var min = Math.Min(r, g);
			min = Math.Min(min, b);
			double h, s, l = (max + min) / 2;

			if (max == min)
			{
				h = s = 0;
			}
			else
			{
				var d = max - min;
				s = l > 0.5 ? d / (2 - max - min) : d / (max + min);
				if (max == r)
					h = (g - b) / d + (g < b ? 6 : 0);
				else if (max == g)
					h = (b - r) / d + 2;
				else
					h = (r - g) / d + 4;
				h /= 6;
			}

			return new HSL { H = h, S = s, L = l };
		}

		public static Color HsvToRgb(double h, double s, double v)
		{
			while (h < 0)
			{
				h += 1;
			}
			while (h >= 1)
			{
				h -= 1;
			}
			double r, g, b;
			if (v <= 0)
			{
				r = g = b = 0;
			}
			else if (s <= 0)
			{
				r = g = b = v;
			}
			else
			{
				double hf = h * 6.0;
				int i = (int)Math.Floor(hf);
				double f = hf - i;
				double pv = v * (1 - s);
				double qv = v * (1 - s * f);
				double tv = v * (1 - s * (1 - f));
				switch (i)
				{
					case 0:
						r = v;
						g = tv;
						b = pv;
						break;
					case 1:
						r = qv;
						g = v;
						b = pv;
						break;
					case 2:
						r = pv;
						g = v;
						b = tv;
						break;
					case 3:
						r = pv;
						g = qv;
						b = v;
						break;
					case 4:
						r = tv;
						g = pv;
						b = v;
						break;
					case 5:
						r = v;
						g = pv;
						b = qv;
						break;
					case 6:
						r = v;
						g = tv;
						b = pv;
						break;
					case -1:
						r = v;
						g = pv;
						b = qv;
						break;
					default:
						r = g = b = v;
						break;
				}
			}

			return Color.FromArgb(Clamp((int)Math.Round(r * 255.0)), Clamp((int)Math.Round(g * 255.0)), Clamp((int)Math.Round(b * 255.0)));
		}

		private static int Clamp(int i)
		{
			if (i < 0)
				return 0;
			if (i > 255)
				return 255;
			return i;
		}
	}
}
