using System;
using System.Collections.Generic;
using System.Drawing;
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


        public static XYZ DotProduct()
        {

        }

        public static XYZ GetProjectedPointOnLine(this XYZ point,Line line)
        {

        }
    }
}
