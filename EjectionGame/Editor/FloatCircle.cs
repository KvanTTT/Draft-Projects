using System;
using System.Xml.Serialization;

namespace Utilities
{
    public class FloatCircle : FloatShape
    {
        [XmlAttribute]
        public float X 
        {
            get;
            set;
        }

        [XmlAttribute]
        public float Y 
        {
            get;
            set;
        }

        [XmlAttribute]
        public float Radius 
        {
            get;
            set;
        }               

        public FloatCircle()
        {
        }

        public FloatCircle(string Name, float X, float Y, float Radius) : base(Name)
        {
            this.X = X;
            this.Y = Y;
            this.Radius = Radius;
        }

        public FloatCircle(string Name, double X, double Y, double Radius) : base(Name)
        {
            this.X = (float)X;
            this.Y = (float)Y;
            this.Radius = (float)Radius;
        }

        public override void Normalize(float CoefX, float CoefY)
        {
            X *= CoefX;
            Y *= CoefY;
            Radius *= CoefX;
        }
    }
}
