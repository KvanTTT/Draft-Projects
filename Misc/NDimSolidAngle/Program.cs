using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathNet.Numerics.LinearAlgebra.Generic;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra.Double;

namespace NDimSolidAngle
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("2-dim solid angle (formula): {0}", NSpaces.NSphereSurfaceAreaOrtVectors(2));
			var vectors = new List<Vector<double>>()
			{
				new DenseVector(new[] { 1.0, 0.0 }),
				new DenseVector(new[] { 0.0, 1.0 }),
			};
			Console.WriteLine("2-dim solid angle (vectors): {0}", NSpaces.SolidAngle(vectors));
			Console.WriteLine();

			Console.WriteLine("2-dim solid angle (formula): {0}", NSpaces.NSphereSurfaceAreaOrtVectors(2) / 2);
			vectors = new List<Vector<double>>()
			{
				new DenseVector(new[] { 1.0, 0.0 }),
				new DenseVector(new[] { 1.0, 1.0 }),
			};
			Console.WriteLine("2-dim solid angle (vectors): {0}", NSpaces.SolidAngle(vectors));
			Console.WriteLine();

			Console.WriteLine("3-dim solid angle (formula): {0}", NSpaces.NSphereSurfaceAreaOrtVectors(3));
			vectors = new List<Vector<double>>()
			{
				new DenseVector(new[] { 1.0, 0.0, 0.0 }),
				new DenseVector(new[] { 0.0, 1.0, 0.0 }),
				new DenseVector(new[] { 0.0, 0.0, 1.0 }),
			};
			Console.WriteLine("3-dim solid angle (vectors): {0}", NSpaces.SolidAngle(vectors));

			Console.ReadLine();
		}
	}
}
