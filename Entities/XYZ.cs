using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class XYZ : IEquatable<XYZ>
    {
        public static XYZ BasisX => new XYZ(1, 0, 0);
        public static XYZ BasisY => new XYZ(0, 1, 0);
        public static XYZ BasisZ => new XYZ(0, 0, 1);
        public static XYZ Origin => new XYZ(0, 0, 0);

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

        public bool Equals(XYZ other)
        {
            return X == other.X && Y == other.Y && Z == other.Z;                    
        }
        public static bool operator ==(XYZ a, XYZ b)
        {
            if (a.X == b.X && a.Y == b.Y && a.Z == b.Z)
                return true;
            return false;
        }

        public static bool operator !=(XYZ a, XYZ b)
        {
            if (a.X != b.X || a.Y != b.Y || a.Z != b.Z)
                return true;
            return false;
        }




        public static XYZ operator -(XYZ a, XYZ b) => new XYZ(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        public static XYZ operator +(XYZ a, XYZ b) => new XYZ(a.X + b.X, a.Y + b.Y, a.Z + b.Z);

        public static XYZ operator -(XYZ a) => new XYZ(-a.X, -a.Y, -a.Z);
        public static XYZ operator +(XYZ a) => a;

        public static XYZ operator *(XYZ a, double num) => new XYZ(num * a.X, num * a.Y, num * a.Z);

        public static XYZ operator /(XYZ a, double num) => new XYZ(a.X / num, a.Y / num, a.Z / num);

    }
}
