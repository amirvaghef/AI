using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Int64 count = 0;
            Int64 readNode = 0;
            int[] index = new int[8];
            Queue<Array> un = new Queue<Array>();
            int unMaxSize = 1;

            DateTime startTime = DateTime.Now;

            Console.WriteLine("Start time is:  " + startTime.ToString());
            Console.WriteLine("Please wait for find answer");
            Console.WriteLine("__________ Alghoritm Is Begining __________");
            //Make first Node
            for (int i1 = 0; i1 < 8; i1++)
                index[i1] = 0;
            //....
            un.Enqueue(index);

            int i = 0;
            bool check = true;
            
            while(un.Count != 0)
            {
                index = (int[])un.Dequeue();
                readNode++;

                check = index.Contains(0);

                if (check)
                    i = index.ToList().IndexOf(0);
                else
                    if (CheckOK(index))
                        break;

                if (check)
                {
                    for (int j = 1; j <= 8; j++)
                    {
                        index[i] = j;
                        un.Enqueue(index.Clone() as Array);
                        //for (int o = 0; o < 7; o++)
                        //    Console.Write(index[o]);
                        //Console.WriteLine(index[7]);
                        unMaxSize = unMaxSize >= un.Count ? unMaxSize : un.Count;
                        count++;
                    }
                }
                else
                {
                    //for (int o = 0; o < 7; o++)
                    //    Console.Write(index[o]);
                    //Console.WriteLine(index[7]);
                }
            }
            Console.WriteLine("__________ Alghoritm Find Answer __________");
            Console.WriteLine("Please enter return key for obvious statics");
            Console.ReadLine();
            DateTime endTime = DateTime.Now;
            Console.WriteLine("End time is: " + endTime.ToString());
            Console.WriteLine("Elapsed time for execution is: " + endTime.Subtract(startTime));
            Console.WriteLine("Number of made node: " + ++count);
            Console.WriteLine("Number of read node: " + readNode);
            Console.WriteLine("Max number of nodes in Un: " + unMaxSize);
            Console.Write("Answer node is: ");
            for (int o = 0; o < 7; o++)
                Console.Write(index[o]);
            Console.WriteLine(index[7]);
            Console.ReadLine();
            Console.ReadLine();
        }

        private static bool CheckOK(int[] ar)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = i + 1; j < 8; j++)
                {
                    if (ar[i] == ar[j])
                        return false;

                    if (Math.Abs(i - j) == Math.Abs(ar[i] - ar[j]))
                        return false;
                }
            }
            return true;
        }
    }
}
