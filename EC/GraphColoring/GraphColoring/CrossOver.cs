using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphColoring
{
    public class CrossOver
    {
        public void PointByPoint(ref List<Array> medianPopulation, int pc, int pointNO)
        {
            List<Array> tempPopulation = new List<Array>(medianPopulation);
            medianPopulation.Clear();

            while (tempPopulation.Count != 0)
            {
                if (tempPopulation.Count >= 2)
                {
                    int[] firstChrom = (int[])tempPopulation[0].Clone();
                    int[] secondChrom = (int[])tempPopulation[1].Clone();
                    tempPopulation.RemoveRange(0, 2);

                    Random rand = new Random();
                    if (rand.Next(0, 101) <= pc)
                    {
                        swap(ref firstChrom, ref secondChrom, pointNO);
                    }

                    medianPopulation.Add(firstChrom);
                    medianPopulation.Add(secondChrom);
                }
                else
                {
                    medianPopulation.Add((int[])tempPopulation[0].Clone());
                    tempPopulation.RemoveAt(0);
                }
            }
        }

        public void Uniform(ref List<Array> medianPopulation, int pc)
        {
            List<Array> tempPopulation = new List<Array>(medianPopulation);
            medianPopulation.Clear();

            Random rand = new Random();
            while (tempPopulation.Count != 0)
            {
                if (tempPopulation.Count >= 2)
                {
                    int[] firstChrom = (int[])tempPopulation[0].Clone();
                    int[] secondChrom = (int[])tempPopulation[1].Clone();
                    tempPopulation.RemoveRange(0, 2);

                    //int[] firstChromNew = new int[firstChrom.Length];
                    //int[] secondChromNew = new int[secondChrom.Length];
                    //Random rand = new Random();
                    if (rand.Next(0, 101) <= pc)
                    {
                        for (int i = 0; i < firstChrom.Length; i++)
                        {
                            firstChrom[i] = rand.Next(1, 3) == 1 ? firstChrom[i] : secondChrom[i];
                            secondChrom[i] = rand.Next(1, 3) == 1 ? firstChrom[i] : secondChrom[i];
                        }
                    }
                    medianPopulation.Add(firstChrom);
                    medianPopulation.Add(secondChrom);
                }
                else
                {
                    medianPopulation.Add((int[])tempPopulation[0].Clone());
                    tempPopulation.RemoveAt(0);
                }
            }
        }

        private void swap(ref int[] firstChrom, ref int[] secondChrom, int pointNO)
        {
            Random rand = new Random();
            int nodeNumber = firstChrom.Length;
            switch (pointNO)
            {
                case 1:
                    int firstPoint = rand.Next(1, nodeNumber);
                    for (int i = firstPoint; i < nodeNumber; i++)
                    {
                        int temp = firstChrom[i];
                        firstChrom[i] = secondChrom[i];
                        secondChrom[i] = temp;
                    }
                    break;
                case 2:
                    firstPoint = rand.Next(1, nodeNumber - 1);
                    int secondPoint = rand.Next(firstPoint + 1, nodeNumber);
                    for (int i = firstPoint; i < secondPoint; i++)
                    {
                        int temp = firstChrom[i];
                        firstChrom[i] = secondChrom[i];
                        secondChrom[i] = temp;
                    }
                    break;
                case 3:
                    firstPoint = rand.Next(1, nodeNumber - 2);
                    secondPoint = rand.Next(firstPoint + 1, nodeNumber - 1);
                    int thirdPoint = rand.Next(secondPoint + 1, nodeNumber);
                    for (int i = firstPoint; i < secondPoint; i++)
                    {
                        int temp = firstChrom[i];
                        firstChrom[i] = secondChrom[i];
                        secondChrom[i] = temp;
                    }
                    for (int i = thirdPoint; i < nodeNumber; i++)
                    {
                        int temp = firstChrom[i];
                        firstChrom[i] = secondChrom[i];
                        secondChrom[i] = temp;
                    }
                    break;
            }
        }
    }
}
