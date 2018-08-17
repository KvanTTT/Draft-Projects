﻿namespace BinarySundial
{
    public struct Point3D
	{
		public double X { get; set; }
		public double Y { get; set; }
		public double Z { get; set; }

		public Point3D(double x, double y, double z) : this()
		{
			X = x;
			Y = y;
			Z = z;
		}
	}
}
