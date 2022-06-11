//PL5
//João Carlos Borges Silva nº2019216753 
//Alexandre da Silva van Velze nº2019216618
//Sofia Botelho Vieira Alves nº2019227240

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Mutations;
using GeneticSharp.Domain.Randomizations;

public class SinglePointMutation : IMutation
{
    public bool IsOrdered { get; private set; } // indicating whether the operator is ordered (if can keep the chromosome order).

    public SinglePointMutation()
    {
        IsOrdered = true;
    }


    public void Mutate(IChromosome chromosome, float probability)
    {

		// Mutation operator of bit-flip
        for(int i = 0; i < chromosome.Length; i++){ // iterate through chromosome
			// if number generated is under the given probability, flip the gene
            if(RandomizationProvider.Current.GetDouble() <= probability){
                int geneValue = (int)chromosome.GetGene(i).Value;
                if(geneValue == 1){
                    chromosome.ReplaceGene(i, new Gene(0));
                }
                else{
                    chromosome.ReplaceGene(i, new Gene(1));
                }
            }
        }


    }

}