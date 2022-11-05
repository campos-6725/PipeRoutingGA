using Definitions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Genes
{
    public class DistributionHeight : Gene
    {
        private static GeneType _geneType = GeneType.Height;
        public double Height { get; set; }
        public DistributionHeight(double height, Face sourceFace) : base(_geneType, sourceFace)
        {
            Height = height;
        }
    }
}
