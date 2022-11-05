using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Line : IEquatable<Line>
    {

        public XYZ StartPoint { get; set; }
        public XYZ EndPoint { get; set; }
        public XYZ Direction { get; set; }

        public Line(XYZ startPoint, XYZ endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            Direction = (EndPoint - StartPoint).Normalize();
        }

        public bool Equals(Line other)
        {
            if (this.StartPoint == other.StartPoint && this.EndPoint == other.EndPoint)
                return true;
            else if (this.StartPoint == other.EndPoint && this.EndPoint == other.StartPoint) 
                return true;
            return false;
        }
    }
}
