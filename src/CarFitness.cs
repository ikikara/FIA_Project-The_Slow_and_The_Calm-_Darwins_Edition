//PL5
//João Carlos Borges Silva nº2019216753 
//Alexandre da Silva van Velze nº2019216618
//Sofia Botelho Vieira Alves nº2019227240

using GeneticSharp.Domain.Fitnesses;
using GeneticSharp.Domain.Chromosomes;
using System.Threading;
using UnityEngine;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System;
using System.Linq;

namespace GeneticSharp.Runner.UnityApp.Car
{
    public class CarFitness : IFitness
    {
        public CarFitness()
        {
            ChromosomesToBeginEvaluation = new BlockingCollection<CarChromosome>();
            ChromosomesToEndEvaluation = new BlockingCollection<CarChromosome>();
        }

        public BlockingCollection<CarChromosome> ChromosomesToBeginEvaluation { get; private set; }
        public BlockingCollection<CarChromosome> ChromosomesToEndEvaluation { get; private set; }
        public double Evaluate(IChromosome chromosome)
        {
            var c = chromosome as CarChromosome;
            ChromosomesToBeginEvaluation.Add(c);

            float fitness = 0; 
            do
            {
                Thread.Sleep(1000);

                /*YOUR CODE HERE: You should define de fitness function here!!
                 * 
                 * 
                 * You have access to the following information regarding how the car performed in the scenario:
                 * MaxDistance: Maximum distance reached by the car;
                 * MaxDistanceTime: Time taken to reach the MaxDistance;
                 * MaxVelocity: Maximum Velocity reached by the car;
                 * NumberOfWheels: Number of wheels that the cars has;
                 * CarMass: Weight of the car;
                 * IsRoadComplete: This variable has the value 1 if the car reaches the end of the road, 0 otherwise.
                 * 
                */
                float MaxDistance = c.MaxDistance;
                float MaxDistanceTime = c.MaxDistanceTime;
                float MaxVelocity = c.MaxVelocity;
                float NumberOfWheels = c.NumberOfWheels;
                float CarMass = c.CarMass;
                int IsRoadComplete = c.IsRoadComplete ? 1 : 0;

                //fitness = IsRoadComplete;
                //*(GRUPO - GAPROAD)*/ fitness = (float)(MaxDistance * 0.3 + IsRoadComplete * 100 + MaxDistance/(MaxDistanceTime + 1) * 0.2);
                //*(GRUPO - HILLROAD)*/ fitness = (float)(IsRoadComplete * 10000 + MaxDistance * 40 + CarMass * (-50) + NumberOfWheels * (-100) + MaxVelocity * 200);
                /*(GRUPO - HILLROAD)*/ fitness = (float)(MaxDistance/(MaxDistanceTime - 1)*150 + MaxDistance * 40 + (1/CarMass) * 5 + (1/NumberOfWheels) * 15 + MaxVelocity * 200 + IsRoadComplete * 10000);

                //CarMass € [150, 160]

                c.Fitness = fitness;

            } while (!c.Evaluated);

            ChromosomesToEndEvaluation.Add(c);

            do
            {
                Thread.Sleep(1000);
            } while (!c.Evaluated);


            return fitness;
        }

    }
}