using Entities.Genes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.GA
{
    public class PathChromossome
    {
        public List<Gene> Genes { get; set; }

        public PathChromossome(List<Gene> facesGenes)
        {
            Genes = facesGenes; 
        }
    }
}
