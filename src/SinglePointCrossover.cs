//PL5
//João Carlos Borges Silva nº2019216753 
//Alexandre da Silva van Velze nº2019216618
//Sofia Botelho Vieira Alves nº2019227240

using GeneticSharp.Domain.Chromosomes;
using System;
using System.Linq;
using UnityEngine;
using GeneticSharp.Domain.Randomizations;
using System.Collections.Generic;
using GeneticSharp.Domain.Crossovers;

namespace GeneticSharp.Runner.UnityApp.Commons
{
    public class SinglePointCrossover : ICrossover
    {
  
        public int ParentsNumber { get; private set; }

        public int ChildrenNumber { get; private set; }

        public int MinChromosomeLength { get; private set; }

        public bool IsOrdered { get; private set; } // indicating whether the operator is ordered (if can keep the chromosome order).

        protected float crossoverProbability;


        public SinglePointCrossover(float crossoverProbability) : this(2, 2, 2, true)
        {
            this.crossoverProbability = crossoverProbability;
        }

        public SinglePointCrossover(int parentsNumber, int offSpringNumber, int minChromosomeLength, bool isOrdered)
        {
            ParentsNumber = parentsNumber;
            ChildrenNumber = offSpringNumber;
            MinChromosomeLength = minChromosomeLength;
            IsOrdered = isOrdered;
        }

        public IList<IChromosome> Cross(IList<IChromosome> parents)
        {
			// Parent selection
            IChromosome parent1 = parents[0]; // parent 1
            IChromosome parent2 = parents[1]; // parent 2
			
			// New offsprings
            IChromosome offspring1 = parent1.CreateNew();
            IChromosome offspring2 = parent2.CreateNew();


			// If number generated is under the given probability, then do crossover (Probability of crossing over)
            if(RandomizationProvider.Current.GetDouble() <= crossoverProbability){
                int cutPoint = RandomizationProvider.Current.GetInt(1,parent1.Length); // Point until crossover happens
                for(int i = 0; i < cutPoint; i++){
                    offspring1.ReplaceGene(i, parent2.GetGene(i));
                    offspring2.ReplaceGene(i, parent1.GetGene(i));
                }
            }

            return new List<IChromosome> { offspring1, offspring2 };
        }
    }
}