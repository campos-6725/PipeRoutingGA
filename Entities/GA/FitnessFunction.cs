using System;
using System.Collections.Generic;
using System.Text;
using GeneticSharp;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Fitnesses;
using GeneticSharp.Infrastructure.Framework.Commons;

namespace Entities.GA
{
    internal class FitnessFunction : IFitness
    {
        private readonly Func<PathChromossome, double> m_func;

        FitnessFunction()
        {
            m_func = CalculateFitness;
        }

        public double Evaluate(IChromosome chromossome)
        {
            return m_func(chromossome as PathChromossome);
        }

        private double CalculateFitness(PathChromossome pathCrom)
        {
            double loadLossFromCurve = 1.5;
            // avaliar o caminho com os nos obtidos
            double distance = 1;


            // avaliar a quantidade de curvas no caminho
            int curves = 1;


            //compor a nota 
            double fitness = distance + curves * loadLossFromCurve;

            return fitness;
        }

    }
}
