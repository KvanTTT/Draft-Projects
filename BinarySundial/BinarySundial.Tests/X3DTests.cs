using NUnit.Framework;
using System.IO;
using System.Xml.Serialization;
using X3d.Core;

namespace BinarySundial.Tests
{
    [TestFixture]
	public class X3DTests
    {
		[Test]
		public void ReadX3D()
		{
			var path = @"..\..\..\test.x3d";
			var serializer = new XmlSerializer(typeof(Head));

			using (var reader = new StreamReader(path))
			{
				var model = (Head)serializer.Deserialize(reader);
			}
		}
    }
}
