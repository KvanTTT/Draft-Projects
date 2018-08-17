namespace BinarySundial
{
    public struct AltitudeAzimuth
	{
		public double Altitude { get; set; }

		public double Azimuth { get; set; }

		public AltitudeAzimuth(double altitude, double azimuth)
			: this()
		{
			Altitude = altitude;
			Azimuth = azimuth;
		}

		public override bool Equals(object obj)
		{
			if (obj is AltitudeAzimuth)
			{
				var altAz = (AltitudeAzimuth)obj;
				return Altitude == altAz.Altitude && Azimuth == altAz.Azimuth;
			}
			else
				return false;
		}

		public override int GetHashCode()
		{
			return (int)((Altitude * 360) + Azimuth);
		}

		public static bool operator ==(AltitudeAzimuth x, AltitudeAzimuth y)
		{
			return x.Altitude == y.Altitude && x.Azimuth == y.Azimuth;
		}

		public static bool operator !=(AltitudeAzimuth x, AltitudeAzimuth y)
		{
			return x.Altitude != y.Altitude || x.Azimuth != y.Azimuth;
		}

		public override string ToString()
		{
			return "Altitude: " + Altitude + "; Azimuth: " + Azimuth;
		}
	}
}
