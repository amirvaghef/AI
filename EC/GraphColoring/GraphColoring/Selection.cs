using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphColoring
{
    public class Selection
    {
        public void Roulette(ref List<Array> medianPopulation, List<Array> population, int[] fitness)
        {
            medianPopulation.Clear();
            float[] rouletteFitness = MakeRoulette(fitness);

            Random rand = new Random();
            int randNo;
            for (int i = 0; i < fitness.Length; i++)
            {
                randNo = rand.Next(0, 101);
                for (int j = 0; j < fitness.Length; j++)
                {
                    if (randNo <= rouletteFitness[j])
                    {
                        medianPopulation.Add(population[j]);
                        break;
                    }
                }
            }
        }

        public void Ranking(ref List<Array> medianPopulation, List<Array> population, int[] fitness)
        {
            int minimum = 0;
            int maximum = 0;
            int[] rankedFitness = new int[fitness.Length];

            #region Set number for any fitness & Find min and max of fitnesses
            int min = int.MaxValue;
            int index = -1;
            int rx = 0;
            bool equal = false;
            for (int temp = 0; temp < fitness.Length; temp++)
            {
                for (int i = 0; i < fitness.Length; i++)
                {
                    if (fitness[i] < min && fitness[i] != -1)
                    {
                        min = fitness[i];
                        index = i;
                        equal = false;
                    }
                    else
                        if (fitness[i] == min && fitness[i] != -1)
                        {
                            index = i;
                            equal = true;
                        }
                }
                if (temp > 0 && temp < fitness.Length - 1)
                {
                    if (equal)
                    {
                        rankedFitness[index] = rx;
                        fitness[index] = -1;
                    }
                    else
                    {
                        rankedFitness[index] = ++rx;
                        fitness[index] = -1;
                    }
                }
                else
                {
                    if (temp == 0)
                    {
                        minimum = min;
                        if (equal)
                        {
                            rankedFitness[index] = ++rx;
                            fitness[index] = -1;
                        }
                        else
                        {
                            rankedFitness[index] = ++rx;
                            fitness[index] = -1;
                        }
                    }
                    else
                    {
                        if (temp == fitness.Length - 1)
                        {
                            maximum = min;
                            if (equal)
                            {
                                rankedFitness[index] = rx;
                                fitness[index] = -1;
                            }
                            else
                            {
                                rankedFitness[index] = ++rx;
                                fitness[index] = -1;
                            }
                        }
                    }
                }
            }
            #endregion

            for (int i = 0; i < fitness.Length; i++)
                rankedFitness[i] = int.Parse(Math.Round((decimal)(minimum + (maximum - minimum) * ((rankedFitness[i] - 1) / (fitness.Length - 1))) * 100).ToString());

            Roulette(ref medianPopulation, population, rankedFitness);
        }

        public void Tournament(ref List<Array> medianPopulation, List<Array> population, int[] fitness)
        {
            medianPopulation.Clear();

            Random rand = new Random();
            int tournamentSize = rand.Next(1, fitness.Length + 1);

            for (int i = 0; i < fitness.Length; i++)
            {
                int bestFitness = int.MaxValue;
                int bestIndex = -1;

                for (int j = 0; j < tournamentSize; j++)
                {
                    int index = rand.Next(0, fitness.Length);
                    if (fitness[index] < bestFitness)
                    {
                        bestFitness = fitness[index];
                        bestIndex = index;
                    }
                }

                medianPopulation.Add(population[bestIndex]);
            }
        }

        public void SUS(ref List<Array> medianPopulation, List<Array> population, int[] fitness)
        {
            medianPopulation.Clear();
            
            float[] rouletteFitness = MakeRoulette(fitness);

            Random rand = new Random();
            float point = rand.Next(0, 101);
            for (int i = 0; i < fitness.Length; i++)
            {
                for (int j = 0; j < fitness.Length; j++)
                {
                    if (point <= rouletteFitness[j])
                    {
                        medianPopulation.Add(population[j]);
                        break;
                    }
                }
                point = point + 100 / fitness.Length;
                if (point > 100)
                    point = point - 100;
            }
        }

        private float[] MakeRoulette(int[] fitness)
        {
            int sumOfFitness = 0;
            for (int i = 0; i < fitness.Length; i++)
                sumOfFitness += fitness[i];

            float[] rouletteFitness = new float[fitness.Length];
            rouletteFitness[0] = ((float)(sumOfFitness - fitness[0]) / (float)(sumOfFitness * fitness.Length - sumOfFitness)) * 100;
            for (int i = 1; i < fitness.Length; i++)
                rouletteFitness[i] = ((float)(sumOfFitness - fitness[i]) / (float)(sumOfFitness * fitness.Length - sumOfFitness)) * 100 + rouletteFitness[i - 1];

            return rouletteFitness;
        }
    }
}