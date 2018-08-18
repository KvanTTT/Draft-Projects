using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Utilities
{
    public class FloatLine : FloatShape
    {
        [XmlAttribute]
        public float X1;

        [XmlAttribute]
        public float Y1;

        [XmlAttribute]
        public float X2;

        [XmlAttribute]
        public float Y2;

        public FloatLine() { }

        public FloatLine(string Name, float X1, float Y1, float X2, float Y2) : base(Name)
        {
            this.X1 = X1;
            this.Y1 = Y1;
            this.X2 = X2;
            this.Y2 = Y2;
        }

        public FloatLine(string Name, double X1, double Y1, double X2, double Y2)
            : base(Name)
        {
            this.X1 = (float)X1;
            this.Y1 = (float)Y1;
            this.X2 = (float)X2;
            this.Y2 = (float)Y2;
        }

        public override void Normalize(float CoefX, float CoefY)
        {
            X1 *= CoefX;
            X2 *= CoefX;
            Y1 *= CoefY;
            Y2 *= CoefY;
        }
    }
}
