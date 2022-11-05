using Definitions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Genes
{
    public class DirectionToFollow : Gene
    {
        private static GeneType _geneType = GeneType.DirectionToFollow;
        public PathDirection PathDirection { get; set; }
        public DirectionToFollow(PathDirection pathDirection, Face sourceFace) : base(_geneType, sourceFace)
        {
            PathDirection = pathDirection;
        }
    }
}
