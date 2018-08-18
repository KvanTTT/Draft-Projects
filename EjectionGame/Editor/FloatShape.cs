using System;
using System.Xml.Serialization;

namespace Utilities
{
    public class FloatShape
    {
        [XmlAttribute]
        public string Name
        {
            get;
            set;
        }

        public FloatShape()
        {

        }

        public FloatShape(string Name)
        {
            this.Name = Name;
        }

        virtual public void Normalize(float CoefX, float CoefY)
        {
        
        }
    }
}
