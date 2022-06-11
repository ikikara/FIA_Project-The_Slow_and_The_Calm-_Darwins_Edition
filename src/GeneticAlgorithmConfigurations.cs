//PL5
//João Carlos Borges Silva nº2019216753 
//Alexandre da Silva van Velze nº2019216618
//Sofia Botelho Vieira Alves nº2019227240

using System.Collections;
using System.Collections.Generic;
using GeneticSharp.Runner.UnityApp.Car;
using GeneticSharp.Runner.UnityApp.Commons;
using UnityEngine;

public static class GeneticAlgorithmConfigurations
{

	// Experience algorithm configurations are set here
    public static float mutationProbability = 0.05f;
    public static int eliteSize = 2;
    public static int tournamentSize = 5;
    public static float crossoverProbability = 0.9f;
    public static int maximumNumberOfGenerations = 30; 

    public static SinglePointCrossover crossoverOperator = new SinglePointCrossover(crossoverProbability);
    public static SinglePointMutation mutationOperator = new SinglePointMutation();
    public static Tournament parentSelection = new Tournament(tournamentSize);
    public static Elitism survivorSelection = new Elitism(eliteSize);
    public static GenerationsTermination terminationCondition = new GenerationsTermination(maximumNumberOfGenerations);
}
