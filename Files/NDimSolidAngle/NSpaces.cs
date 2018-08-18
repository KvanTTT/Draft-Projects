using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra.Generic;

namespace NDimSolidAngle
{
	public class NSpaces
	{
		public static double NSphereVolume(double dimension, double radius)
		{
			return Math.Pow(Math.PI, dimension / 2) / SpecialFunctions.Gamma(dimension / 2 + 1) *
				Math.Pow(radius, dimension);
		}

		public static double NSphereSurfaceArea(double dimension, double radius)
		{
			return dimension * Math.Pow(Math.PI, dimension / 2) / SpecialFunctions.Gamma(dimension / 2 + 1) *
				Math.Pow(radius, dimension - 1);
		}

		public static double NSphereSurfaceAreaOrtVectors(double dimension)
		{
			return dimension * Math.Pow(Math.PI, dimension / 2) / SpecialFunctions.Gamma(dimension / 2 + 1) /
				Math.Pow(2, dimension);
		}

		public static double SolidAngle(IList<Vector<double>> vectors)
		{
			if (vectors.Count == 2)
			{
				Matrix<double> m = Matrix<double>.CreateFromRows(vectors);
				double v0 = vectors[0].Norm(2);
				double v1 = vectors[1].Norm(2);
				return 2 * Math.Atan2(m.Determinant(), v0 * v1 + vectors[0] * vectors[1]);
			}
			else
			if (vectors.Count == 3)
			{
				Matrix<double> m = Matrix<double>.CreateFromRows(vectors);
				double v0 = vectors[0].Norm(2);
				double v1 = vectors[1].Norm(2);
				double v2 = vectors[2].Norm(2);
				return 2 * Math.Atan2(m.Determinant(), v0 * v1 * v2 +
					vectors[0] * vectors[1] * v2 + vectors[0] * vectors[2] * v1 + vectors[1] * vectors[2] * v0);
			}
			else
			{
				Matrix<double> m = Matrix<double>.CreateFromRows(vectors);
				double v0 = vectors[0].Norm(2);
				double v1 = vectors[1].Norm(2);
				double v2 = vectors[2].Norm(2);
				double v3 = vectors[3].Norm(2);

				/*return 2 * Math.Atan2(m.Determinant(), 
					v0 * v1 * v2 * v3 +
					vectors[0] * vectors[1] * v2 * v3 + vectors[0] * vectors[2] * v1 * v3 + vectors[0] * vectors[3] * v1 * v2 +
					vectors[1] * vectors[2] * v0 * v3 + vectors[1] * vectors[3] * v0 * v2 +
					vectors[2] * vectors[3] * v0 * v2);*/
				/*return 2 * Math.Atan2(m.Determinant(),
					v0 * v1 * v2 * v3 +
					(vectors[0][0] * vectors[1][0] * vectors[2][0] + vectors[0][1] * vectors[1][1] * vectors[2][1] + vectors[0][2] * vectors[1][2] * vectors[2][2]) * v3 +
					(vectors[0][0] * vectors[1][0] * vectors[3][0] + vectors[0][1] * vectors[1][1] * vectors[3][1] + vectors[0][2] * vectors[1][2] * vectors[3][2]) * v2 +
					(vectors[1][0] * vectors[2][0] * vectors[3][0] + vectors[1][1] * vectors[2][1] * vectors[3][1] + vectors[1][2] * vectors[2][2] * vectors[3][2]) * v0);*/
				/*return 2 * Math.Atan2(m.Determinant(),
						v0 * v1 * v2 +
						vectors[0] * vectors[1] * v2 + vectors[0] * vectors[2] * v1 + vectors[1] * vectors[2] * v0) *
					Math.Atan2(m.Determinant(),
						v0 * v1 * v3 +
						vectors[0] * vectors[1] * v3 + vectors[0] * vectors[3] * v1 + vectors[1] * vectors[3] * v0);*/
				/*return 2 * Math.Atan2(m.Determinant(),
						v0 * v1 * v2 * v3 +
						vectors[0] * vectors[1] + vectors[0] * vectors[2] + vectors[0] * vectors[3] +
						vectors[1] * vectors[2] + vectors[1] * vectors[3] + 
						vectors[2] * vectors[3]) *
					Math.Atan2(m.Determinant(),
						v0 * v1 * v2 * v3 +
						v0 * v1 + v0 * v2 + v0 * v3 +
						v1 * v2 + v1 * v3 +
						v2 * v3);*/
			}
			return 0;
		}
	}
}
