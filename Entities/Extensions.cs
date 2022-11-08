using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Entities
{
    public static class Extensions
    {
        public static XYZ Normalize(this XYZ xyz)
        {
            double distance = Math.Sqrt(xyz.X * xyz.X + xyz.Y * xyz.Y + xyz.Z * xyz.Z);
            return new XYZ(xyz.X / distance, xyz.Y / distance, xyz.Z / distance);
        }

        public static double DistanceTo(this XYZ source, XYZ target)
        => Math.Sqrt(
            (source.X - target.X) * (source.X - target.X) +
            (source.Y - target.Y) * (source.Y - target.Y) +
            (source.Z - target.Z) * (source.Z - target.Z));

        public static XYZ CrossProduct(this XYZ a, XYZ b)
        {
            new XYZ(a.Y * b.Z - a.Z * b.Y, a.Z * b.X - a.X * b.Z, a.X * b.Y - a.Y * b.X);

            throw new NotImplementedException();
        }

        public static double DotProduct (this XYZ a, XYZ b)
        {
            return a.X * b.X + a.Y * b.Y + a.Z *b.Z;
        }

        public static XYZ GetProjectedPointOnLine(this XYZ point, Line line)
        {
            XYZ p0 = line.StartPoint;
            XYZ p1 = line.EndPoint;

            if (point.X == p1.X && p0.Y == p1.Y && p0.Z == p1.Z) p0.X -= 0.00001;

            double Unumer =
                ((point.X - p0.X) * (p1.X - p0.X)) +
                ((point.Y - p0.Y) * (p1.Y - p0.Y)) +
                ((point.Z - p0.Z) * (p1.Z - p0.Z));

            double Udenom =
                Math.Pow(p1.X - p0.X, 2) +
                Math.Pow(p1.Y - p0.Y, 2) +
                Math.Pow(p1.Z - p0.Z, 2);

            double U = Unumer / Udenom;

            XYZ r = new XYZ(
                p0.X + (U * (p1.X - p0.X)),
                p0.Y + (U * (p1.Y - p0.Y)),
                p0.Z + (U * (p1.Z - p0.Z)));

            double minx = Math.Min(p0.X, p1.X);
            double maxx = Math.Max(p0.X, p1.X);
            double miny = Math.Min(p0.Y, p1.Y);
            double maxy = Math.Max(p0.Y, p1.Y);
            double minz = Math.Min(p0.Z, p1.Z);
            double maxz = Math.Max(p0.Z, p1.Z);

            bool isValid = (r.X >= minx && r.X <= maxx) && (r.Y >= miny && r.Y <= maxy) && (r.Z >= minz && r.Z <= maxz);

            return isValid ? r : null;

        }

        public static bool IsSameDirection(this XYZ a, XYZ b)
        {
            if (a.Normalize().Equals(b.Normalize()) || a.Normalize().Equals(-b.Normalize()))
                return true;
            return false;
        }

        public static Face ToNewFace(this Face face)
        {
            return new Face(face.Min, face.Max, face.Normal, face.TerminalPoints);
        }
    }
}
