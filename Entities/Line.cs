using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Line
    {

        XYZ StartPoint { get; set; }
        XYZ EndPoint { get; set; }
        XYZ Direction { get; set; }

        public   Line(XYZ startPoint, XYZ endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            Direction = (EndPoint - StartPoint).Normalize();
        }

    }
}
