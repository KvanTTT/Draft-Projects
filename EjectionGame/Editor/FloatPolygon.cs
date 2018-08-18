using System;
using System.Xml.Linq;

namespace Utilities
{
    public class FloatPolygon : FloatShape
    {
        public FloatPoint[] Vertexes;

        public FloatPolygon()
        {
        }

        public FloatPolygon(string Name, FloatPoint[] Vertexes)
            : base(Name)
        {
            this.Vertexes = Vertexes;
        }

        public override void Normalize(float CoefX, float CoefY)
        {
            //Vertexes = Array.ConvertAll(Vertexes, P => new FloatPoint(P.X, P.Y));
        }
    }
}
