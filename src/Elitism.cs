//PL5
//João Carlos Borges Silva nº2019216753 
//Alexandre da Silva van Velze nº2019216618
//Sofia Botelho Vieira Alves nº2019227240

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Populations;
using GeneticSharp.Domain.Reinsertions;


public class Elitism : ReinsertionBase{
    protected int eliteSize = 0;
    public Elitism(int eliteSize) : base(false, false){
        this.eliteSize = eliteSize;
    }
    
    protected override IList<IChromosome> PerformSelectChromosomes(IPopulation population, IList<IChromosome> offspring, IList<IChromosome> parents){

        var old_population = population.CurrentGeneration.Chromosomes.OrderByDescending(p => p.Fitness).ToList(); // previous population sorted by fitness

		// Selecting the "elites" based on given eliteSize. If zero, no "elites" carry over
        for(int i = 0; i < eliteSize; i++){
            offspring[i] = old_population[i];
        }
    
        return offspring;
    }
    
}