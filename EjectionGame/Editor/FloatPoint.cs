using System;
using System.Xml.Serialization;

namespace Utilities
{
    public class FloatPoint : FloatShape
    {
        [XmlAttribute]
        public float X;

        [XmlAttribute]
        public float Y;

        public FloatPoint() { }

        public FloatPoint(float X, float Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public FloatPoint(double X, double Y)
        {
            this.X = (float)X;
            this.Y = (float)Y;
        }

        public override void Normalize(float CoefX, float CoefY)
        {
            this.X *= CoefX;
            this.Y *= CoefY;
        }
    }
}
