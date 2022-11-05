using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Crossovers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.GA
{
    internal class Crossover : ICrossover
    {
        public int ParentsNumber => throw new NotImplementedException();

        public int ChildrenNumber => throw new NotImplementedException();

        public int MinChromosomeLength => throw new NotImplementedException();

        public bool IsOrdered => throw new NotImplementedException();

        public IList<IChromosome> Cross(IList<IChromosome> parents)
        {
            throw new NotImplementedException();
        }
    }
}
