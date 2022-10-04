using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Face
    {
        public XYZ Min { get; set; }
        public XYZ Max { get; set; }
        public List<Line> ContourLines { get; set; }
        public List<TerminalPoint> TerminalPoints { get; set; }


        public Face(XYZ min, XYZ max)
        {
            Min = min;
            Max = max;
            ContourLines = GetContourLinesFromExtremities(min,max);
        }

        private List<Line> GetContourLinesFromExtremities(XYZ min, XYZ max)
        {
            List<Line> contourLines = new List<Line>
            {
                //cria 4 linhas de contorno de uma face
                new Line(min, min.setZ(max.Z)),
                new Line(min.setZ(max.Z), max),
                new Line(min, max.setZ(min.Z)),
                new Line(max.setZ(min.Z), max)
            };

            return contourLines;
        }
    }
}
