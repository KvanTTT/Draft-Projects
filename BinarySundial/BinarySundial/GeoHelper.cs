using System.Xml.Serialization;

namespace BinarySundial
{
    public class GeoHelper
	{
		public static GeoInfo GetCurrentGetInfo()
		{
			GeoInfo result;
			using (var response = Helper.GetStreamFromRequest("http://freegeoip.net/xml/"))
			{
				var serializer = new XmlSerializer(typeof(GeoInfo));
				result = (GeoInfo)serializer.Deserialize(response);
			}
			return result;
		}
	}
}
