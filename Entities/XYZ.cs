using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class XYZ
    {

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public XYZ(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        

        public XYZ setX(double x)
        {
            X = x;
            return this;
        }

        public XYZ setY(double y)
        {
            Y = y;
            return this;
        }

        public XYZ setZ(double z)
        {
            Z = z;
            return this;
        }

        public override string ToString()
        {
            string str = "(" + X + "," + Y + "," + Z + ")";
            return str;
        }

        public static XYZ operator -(XYZ a, XYZ b) => new XYZ(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        public static XYZ operator +(XYZ a, XYZ b) => new XYZ(a.X + b.X, a.Y + b.Y, a.Z + b.Z);

    }
}
