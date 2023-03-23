using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace GraphColoring
{
    public class Replacement
    {
        public void GenerationalWithElitism(ref List<Array> population, List<Array> medianPopulation, int[] medianFitness, int[] fitness)
        {
            int min = int.MaxValue;
            int minIndex = -1;
            for (int i = 0; i < fitness.Length; i++)
            {
                if (fitness[i] < min)
                {
                    min = fitness[i];
                    minIndex = i;
                }
            }

            for (int i = 0; i < fitness.Length; i++)
            {
                if (i != minIndex)
                    medianPopulation[i].CopyTo(population[i], 0);
                else
                    if (fitness[minIndex] > medianFitness[minIndex])
                        medianPopulation[i].CopyTo(population[i], 0);
            }
        }

        public void Generational(ref List<Array> population, List<Array> medianPopulation)
        {
            population.Clear();
            population.AddRange(medianPopulation);
        }

        public void SteadyState(ref List<Array> population, List<Array> medianPopulation, int[] medianFitness, int[] fitness)
        {
            for (int i = 0; i < fitness.Length; i++)
            {
                if (medianFitness[i] <= fitness[i])
                    medianPopulation[i].CopyTo(population[i],0);
            }
        }
    }
}
