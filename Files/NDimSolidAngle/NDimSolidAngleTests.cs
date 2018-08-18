using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra.Generic;
using NDimSolidAngle;
using NUnit.Framework;

namespace Tests
{
	[TestFixture]
	public class NDimSolidAngleTests
	{
		const double Epsilon = 0.00000000000001;

		[Test]
		public void Test()
		{
			var vertexes = new List<Vector<double>>()
			{
				new DenseVector(new[] { 1.0,0.0,0.0 }),
				new DenseVector(new[] { 0.0,1.0,0.0 }),
				new DenseVector(new[] { 0.0,0.0,1.0 }),
			};
		}

		[Test]
		public void RightAngleTest2d()
		{
			double actual = NSpaces.NSphereSurfaceAreaOrtVectors(2);

			var vectors = new List<Vector<double>>()
			{
				new DenseVector(new[] { 1.0, 0.0 }),
				new DenseVector(new[] { 0.0, 1.0 }),
			};
			double real = NSpaces.SolidAngle(vectors);

			Assert.IsTrue(Math.Abs(actual - real) <= Epsilon);
		}

		[Test]
		public void AnglesSumOfTriangle2d()
		{
			double actual = NSpaces.NSphereSurfaceArea(2, 1) / 2;

			var rand = new Random();

			var vertexes = new List<Vector<double>>()
			{
				new DenseVector(new[] { rand.NextDouble(), rand.NextDouble() }),
				new DenseVector(new[] { rand.NextDouble(), rand.NextDouble() }),
				new DenseVector(new[] { rand.NextDouble(), rand.NextDouble() }),
			};

			var angle1Vectors = new List<Vector<double>>()
			{
				vertexes[1] - vertexes[0],
				vertexes[2] - vertexes[0],
			};
			var angle2Vectors = new List<Vector<double>>()
			{
				vertexes[0] - vertexes[1],
				vertexes[2] - vertexes[1],
			};
			var angle3Vectors = new List<Vector<double>>()
			{
				vertexes[0] - vertexes[2],
				vertexes[1] - vertexes[2],
			};

			double real = Math.Abs(NSpaces.SolidAngle(angle1Vectors)) + Math.Abs(NSpaces.SolidAngle(angle2Vectors)) + Math.Abs(NSpaces.SolidAngle(angle3Vectors));

			Assert.IsTrue(Math.Abs(actual - real) <= Epsilon);
		}

		[Test]
		public void RightAngleDiv2Test2d()
		{
			double actual = NSpaces.NSphereSurfaceAreaOrtVectors(2) / 2;

			var vectors = new List<Vector<double>>()
			{
				new DenseVector(new[] { 1.0, 0.0 }),
				new DenseVector(new[] { 1.0, 1.0 }),
			};
			double real = NSpaces.SolidAngle(vectors);

			Assert.IsTrue(Math.Abs(actual - real) <= Epsilon);
		}

		[Test]
		public void RightAngleTest3d()
		{
			double actual = NSpaces.NSphereSurfaceAreaOrtVectors(3);

			var vectors = new List<Vector<double>>()
			{
				new DenseVector(new[] { 1.0, 0.0, 0.0 }),
				new DenseVector(new[] { 0.0, 1.0, 0.0 }),
				new DenseVector(new[] { 0.0, 0.0, 1.0 }),
			};
			double real = NSpaces.SolidAngle(vectors);

			Assert.IsTrue(Math.Abs(actual - real) <= Epsilon);
		}

		[Test]
		public void AnglesSumOfTriangle3d()
		{
			//double actual = NSpaces.NSphereSurfaceArea(3, 1) / 2;

			var rand = new Random();

			var vertexes = new List<Vector<double>>()
			{
				new DenseVector(new[] { rand.NextDouble(), rand.NextDouble(), rand.NextDouble() }),
				new DenseVector(new[] { rand.NextDouble(), rand.NextDouble(), rand.NextDouble() }),
				new DenseVector(new[] { rand.NextDouble(), rand.NextDouble(), rand.NextDouble() }),
				new DenseVector(new[] { rand.NextDouble(), rand.NextDouble(), rand.NextDouble() })
			};

			var angle1Vectors = new List<Vector<double>>()
			{
				vertexes[1] - vertexes[0],
				vertexes[2] - vertexes[0],
				vertexes[3] - vertexes[0],
			};
			var angle2Vectors = new List<Vector<double>>()
			{
				vertexes[0] - vertexes[1],
				vertexes[2] - vertexes[1],
				vertexes[3] - vertexes[1],
			};
			var angle3Vectors = new List<Vector<double>>()
			{
				vertexes[0] - vertexes[2],
				vertexes[1] - vertexes[2],
				vertexes[3] - vertexes[2],
			};
			var angle4Vectors = new List<Vector<double>>()
			{
				vertexes[0] - vertexes[3],
				vertexes[1] - vertexes[3],
				vertexes[2] - vertexes[3],
			};

			double real = Math.Abs(NSpaces.SolidAngle(angle1Vectors)) + Math.Abs(NSpaces.SolidAngle(angle2Vectors)) + 
				Math.Abs(NSpaces.SolidAngle(angle3Vectors)) + Math.Abs(NSpaces.SolidAngle(angle4Vectors));

			//Assert.IsTrue(Math.Abs(actual - real) <= Epsilon);
		}

		[Test]
		public void RightAngleDiv3Test3d()
		{
			double actual = NSpaces.NSphereSurfaceAreaOrtVectors(3) / 3;

			var vectors = new List<Vector<double>>()
			{
				new DenseVector(new[] { 1.0, 0.0, 0.0 }),
				new DenseVector(new[] { 0.0, 1.0, 0.0 }),
				new DenseVector(new[] { 1.0, 1.0, 1.0 }),
			};
			double real = NSpaces.SolidAngle(vectors);

			Assert.IsTrue(Math.Abs(actual - real) <= Epsilon);
		}

		[Test]
		public void RightAngleTest4d()
		{
			double actual = NSpaces.NSphereSurfaceAreaOrtVectors(4);

			var vectors = new List<Vector<double>>()
			{
				new DenseVector(new[] { 1.0, 0.0, 0.0, 0.0 }),
				new DenseVector(new[] { 0.0, 1.0, 0.0, 0.0 }),
				new DenseVector(new[] { 0.0, 0.0, 1.0, 0.0 }),
				new DenseVector(new[] { 0.0, 0.0, 0.0, 1.0 }),
			};
			double real = NSpaces.SolidAngle(vectors);

			Assert.IsTrue(Math.Abs(actual - real) <= Epsilon);
		}

		[Test]
		public void RightAngleDiv4Test4d()
		{
			double actual = NSpaces.NSphereSurfaceAreaOrtVectors(4) / 4;

			var vectors = new List<Vector<double>>()
			{
				new DenseVector(new[] { 1.0, 0.0, 0.0, 0.0 }),
				new DenseVector(new[] { 0.0, 1.0, 0.0, 0.0 }),
				new DenseVector(new[] { 0.0, 0.0, 1.0, 0.0 }),
				new DenseVector(new[] { 1.0, 1.0, 1.0, 1.0 }),
			};
			double real = NSpaces.SolidAngle(vectors);

			Assert.IsTrue(Math.Abs(actual - real) <= Epsilon);
		}
	}
}
