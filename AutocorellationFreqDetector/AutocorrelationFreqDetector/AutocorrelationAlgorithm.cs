using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutocorrelationFreqDetector
{
	class AutocorrelationAlgorithm
	{
		public static double GetCorrelation(double[] x, double[] y)
		{
			double avgX = 0;
			for (int i = 0; i < x.Length; i++)
				avgX += x[i];
			avgX /= x.Length;

			double stdevX = 0;
			for (int i = 0; i < x.Length; i++)
				stdevX += (x[i] - avgX) * (x[i] - avgX);
			stdevX = Math.Sqrt(stdevX);

			double avgY = 0;
			for (int i = 0; i < y.Length; i++)
				avgY += y[i];
			avgY /= y.Length;

			double stdevY = 0;
			for (int i = 0; i < y.Length; i++)
				stdevY += (y[i] - avgY) * (y[i] - avgY);
			stdevY = Math.Sqrt(stdevY);

			double covXY = 0;
			double pearson = 0;
			for (int i = 0; i < x.Length; i++)
				covXY += (x[i] - avgX) * (y[i] - avgY);
			covXY /= x.Length;
			pearson = covXY / (stdevX * stdevY);

			return pearson;
		}

		public static double[] GetAutocorrelation(double[] x)
		{
			int half = (int)x.Length / 2;
			double[] result = new double[x.Length];
			double[] a = new double[half];
			double[] b = new double[half];

			for (int i = 0; i < half; i++)
			{
				a[i] = x[i];
				b[i] = x[i + i];

				result[i] = GetCorrelation(a, b);
				result[x.Length - 1 - i] = result[i];
			}

			return result;
		}

		public static List<int> IndiciesOfMax(double[] x)
		{
			var result = new List<int>();

			if (x[0] >= x[1])
				result.Add(0);
			for (int i = 1; i < x.Length - 1; i++)
				if (x[i] > x[i - 1] && x[i] >= x[i + 1])
					result.Add(i);
			if (x[x.Length - 1] > x[x.Length - 2])
				result.Add(x.Length - 1);

			return result;
		}

		public static void Normalize(double[] x)
		{
			double oneDivMax = 1.0 / x.Max(a => Math.Abs(a));
			for (int i = 0; i < x.Length; i++)
				x[i] *= oneDivMax;
		}

		public static double[] GetAutocorrelation2(double[] x)
		{
			double[] result = new double[(x.Length + 1) / 2];

			/*Parallel.For(0, result.Length, i =>
			{
				double sum = 0;
				for (int j = 0; j < x.Length; j++)
					sum += x[j] * x[(j + i) % x.Length];
				result[i] = sum;
			});*/

			Parallel.For(0, result.Length, i =>
			{
				double sum = 0;
				for (int j = 0; j < x.Length - i; j++)
					sum += x[j] * x[j + i];
				result[i] = sum;
			});

			return result;
		}
		
		const int leftOffset = 1;

		public static int[] GetFundFreqInd(double[] x)
		{
			int result = 0;

			double[] temp = new double[x.Length + leftOffset + (x.Length + 2) / 3 * 3 + 1];
			bool[] calculatedValues = new bool[temp.Length];

			Array.Copy(x, 0, temp, leftOffset, x.Length);

			temp[0] = double.MaxValue;
			calculatedValues[0] = true;

			temp[temp.Length - 1] = double.MinValue;
			calculatedValues[temp.Length - 1] = true;
			if (x.Length % 3 == 2)
			{
				temp[temp.Length - 2] = double.MinValue + 1;
				calculatedValues[temp.Length - 2] = true;
			}
			else if (x.Length % 3 == 1)
			{
				temp[temp.Length - 2] = double.MinValue + 1;
				calculatedValues[temp.Length - 2] = true;
				temp[temp.Length - 3] = double.MinValue + 2;
				calculatedValues[temp.Length - 3] = true;
			}

			List<int> indexes = new List<int>();

			Parallel.For(0, (x.Length + 2) / 3, (ind, state) =>
			{
				int sourceInd = ind * 3 + 1;

				CalculateIteration(sourceInd, x, temp, calculatedValues);

				CalculateIteration(sourceInd - 1, x, temp, calculatedValues);

				if (calculatedValues[sourceInd - 2 + leftOffset] &&
					temp[sourceInd - 1 + leftOffset] > temp[sourceInd - 2 + leftOffset] &&
					temp[sourceInd - 1 + leftOffset] >= temp[sourceInd + leftOffset])
				{
					result = sourceInd - 1;
					indexes.Add(sourceInd - 1);
					//state.Stop();
				}

				CalculateIteration(sourceInd + 1, x, temp, calculatedValues);

				if (temp[sourceInd + leftOffset] > temp[sourceInd - 1 + leftOffset] &&
					temp[sourceInd + leftOffset] >= temp[sourceInd + 1 + leftOffset])
				{
					result = sourceInd;
					indexes.Add(sourceInd);
					//state.Stop();
				}

				if (calculatedValues[sourceInd + 2 + leftOffset] &&
					temp[sourceInd + 1 + leftOffset] > temp[sourceInd + leftOffset] &&
					temp[sourceInd + 1 + leftOffset] >= temp[sourceInd + 2 + leftOffset])
				{
					result = sourceInd + 1;
					indexes.Add(sourceInd + 1);
					//state.Stop();
				}
			});

			return indexes.ToArray();
		}

		private static void CalculateIteration(int sourceInd, double[] source, double[] autocorrelation, bool[] calculatedValues)
		{
			double sum = 0;
			for (int j = 0; j < source.Length - sourceInd; j++)
				sum += source[j] * source[j + sourceInd];
			autocorrelation[sourceInd + leftOffset] = sum;
			calculatedValues[sourceInd + leftOffset] = true;
		}
	}
}
