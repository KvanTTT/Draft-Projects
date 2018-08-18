using System;
using System.Xml.Serialization;

namespace Utilities
{
    public class FloatSize
    {
        [XmlAttribute]
        public float X;

        [XmlAttribute]
        public float Y;

        public FloatSize()
        {

        }

        public FloatSize(float X, float Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public FloatSize(double X, double Y)
        {
            this.X = (float)X;
            this.Y = (float)Y;
        }
    }
}
