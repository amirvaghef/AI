using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphColoring
{
    public class Mutation
    {
        public void BitFliping(ref List<Array> medianPopulation, int pm, int colorNO)
        {
            Random rand = new Random();
            for (int i = 0; i < medianPopulation.Count; i++)
            {
                if (rand.Next(0,101) <= pm)
                {
                    ((int[])medianPopulation[i])[rand.Next(0, ((int[])medianPopulation[i]).Length)] = rand.Next(1, colorNO + 1);
                }
            }
        }

        public void Swap(ref List<Array> medianPopulation, int pm)
        {
            Random rand = new Random();
            int firstGen = -1;
            int secondGen = -1;
            for (int i = 0; i < medianPopulation.Count; i++)
            {
                if (rand.Next(0, 101) <= pm)
                {
                    firstGen = rand.Next(0, ((int[])medianPopulation[i]).Length);
                    secondGen = rand.Next(0, ((int[])medianPopulation[i]).Length);

                    int temp = ((int[])medianPopulation[i])[firstGen];
                    ((int[])medianPopulation[i])[firstGen] = ((int[])medianPopulation[i])[secondGen];
                    ((int[])medianPopulation[i])[secondGen] = temp;
                }
            }
        }
    }
}
