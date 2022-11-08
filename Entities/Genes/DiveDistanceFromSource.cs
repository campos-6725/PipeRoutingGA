using Definitions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Genes
{
    public class DiveDistanceFromSource : Gene
    {
        private static GeneType _geneType = GeneType.DistanceToDive;
        public double PointDistanceFromStartPointInMainWall { get; set; }
        public DiveDistanceFromSource(double pointDistanceFromStartPointInMainWall, Face sourceFace) : base(_geneType, sourceFace)
        {
            PointDistanceFromStartPointInMainWall = pointDistanceFromStartPointInMainWall;
        }

        public XYZ GetDivePointOnFloor()
        {
            var min = base.SourceFace.Min.setZ(0);
            var max = base.SourceFace.Max.setZ(0);

            var direction = (max - min).Normalize();

            return min + direction * PointDistanceFromStartPointInMainWall;
        }


    }
}
