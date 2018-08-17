using System;
using System.Collections.Generic;

namespace BinarySundial
{
    public class PolygonalModel
	{
		public List<Point3D> Verticies { get; set; }
		//public List<>

		public static PolygonalModel GenerateCube(double size)
		{
			return null;
		}

		public static PolygonalModel GenerateSphere(double radius)
		{
			return null;
		}

		public static PolygonalModel GenerateCylinder(double radius, double height, int baseVerticiesCount)
		{
			Point3D[] verticies = new Point3D[baseVerticiesCount * 2];
			double angleDelta = Math.PI * 2 / baseVerticiesCount;
			for (int i = 0; i < baseVerticiesCount; i++)
			{
				double angle = angleDelta * i;
				double x = Math.Cos(angle) * radius;
				double y = Math.Cos(angle) * radius;
				verticies[i] = new Point3D(x, y, 0);
				verticies[i + baseVerticiesCount] = new Point3D(x, y, height);
			}

			return null;
		}
	}
}
