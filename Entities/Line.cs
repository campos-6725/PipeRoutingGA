using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Line
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

    }
}
