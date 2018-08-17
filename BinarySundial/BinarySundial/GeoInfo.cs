using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace BinarySundial
{
	[XmlRoot("Response")]
	public class GeoInfo
	{
		public string Ip { get; set; }

		public CoutryCode CountryCode { get; set; }

		public string CountryName { get; set; }

		/*[XmlElement(IsNullable = true)]
		public int? RegionCode { get; set; }

		[XmlElement(IsNullable = true)]
		public string RegionName { get; set; }*/

		public string City { get; set; }

		public double Latitude { get; set; }

		public double Longitude { get; set; }
	}
}
