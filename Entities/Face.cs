using Definitions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class Face : IEquatable<Face>
    {
        public XYZ Min { get; set; }
        public XYZ Max { get; set; }
        public XYZ Normal { get; set; }
        public List<Line> ContourLines { get; set; }
        public List<TerminalPoint> TerminalPoints { get; set; }
        public FaceType Type { get; set; }


        public Face(XYZ min, XYZ max, XYZ normal)
        {
            Min = min;
            Max = max;
            Normal = normal;
            ContourLines = GetContourLinesFromExtremities(min, max);
        }

        public Face(XYZ min, XYZ max, XYZ normal, List<TerminalPoint> terminalPoints)
        {
            Min = min;
            Max = max;
            Normal = normal;
            ContourLines = GetContourLinesFromExtremities(min, max);
            TerminalPoints = terminalPoints;
        }

        

        private List<Line> GetContourLinesFromExtremities(XYZ min, XYZ max)
        {
            List<Line> contourLines;
            if (Normal.Equals(XYZ.BasisZ))
            {
                contourLines = new List<Line>()
                 {
                //cria 4 linhas de contorno de uma face de piso
                new Line(min, min.setY(max.Y)),
                new Line(min.setY(max.Y), max),
                new Line(min, max.setY(min.Y)),
                new Line(max.setY(min.Y), max)
                 };
            }
            else
            {
                contourLines = new List<Line>()
                {
                //cria 4 linhas de contorno de uma face de parede
                new Line(min, min.setZ(max.Z)),
                new Line(min.setZ(max.Z), max),
                new Line(min, max.setZ(min.Z)),
                new Line(max.setZ(min.Z), max)
                };
            }
            return contourLines;
        }

        public bool Equals(Face other)
        {
            if (other == null)
                throw new NullReferenceException();
            if (this.Min == other.Min && this.Max == other.Max)
                return true;
            else if (this.Min == other.Max || this.Max == other.Min)
                return true;
            return false;
        }

        public bool ShareSideWhith(Face f)
        {
            double count = 0;

            foreach (var line in ContourLines)
            {
                List<Line> equalLines = f.ContourLines.Where(ln => ln.Equals(line)).ToList();
                if (equalLines.Count > 0)
                    count++;
            }
            if (count > 0)
                return true;
            return false;
        }

        private void SetFaceType(XYZ normal)
        {
            if(normal.)
        }
    }
}
