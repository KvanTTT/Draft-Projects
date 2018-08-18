using System;
using System.Xml.Serialization;
using System.Xml;

namespace Utilities
{
    public class FloatRect : FloatShape
    {
        [XmlAttribute]
        public float Left
        {
            get;
            set;
        }
        
        [XmlAttribute]
        public float Top
        {
            get;
            set;
        }
        
        [XmlAttribute]
        public float Width
        {
            get;
            set;
        }
        
        [XmlAttribute]
        public float Height
        {
            get;
            set;
        }

        public FloatRect()
        {
        }

        public FloatRect(string Name, float Left, float Top, float Width, float Height)
        {
            this.Name = Name;
            this.Left = Left;
            this.Top = Top;
            this.Width = Width;
            this.Height = Height;
        }

        public FloatRect(string Name, double Left, double Top, double Width, double Height)
        {
            this.Name = Name;
            this.Left = (float)Left;
            this.Top = (float)Top;
            this.Width = (float)Width;
            this.Height = (float)Height;
        }

        public override void Normalize(float CoefX, float CoefY)
        {
            Left *= CoefX;
            Top *= CoefY;
            Width *= CoefX;
            Height *= CoefY;
        }
    }
}
