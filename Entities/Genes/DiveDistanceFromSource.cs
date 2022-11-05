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
    }
}
