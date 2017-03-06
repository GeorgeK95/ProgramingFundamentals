using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Most_Frequent_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string line1 = Console.ReadLine();
            int[] array = line1.Split(' ').Select(int.Parse).ToArray();
            int mostCommonNumber = GetMostCommonElement(array);
            Console.WriteLine(mostCommonNumber);
        }

        private static int GetMostCommonElement(int[] array)
        {
            int number = 0;
            int bestCount = 0;

            for (int i = 0; i < array.Length; i++)
            {
                int currCount = 0;

                for (int j = 0; j < array.Length; j++)
                {
                    if (array[i] == array[j])
                    {
                        currCount++;

                        if (currCount > bestCount)
                        {
                            bestCount = currCount;
                            number = array[i];
                        }
                    }
                }
            }

            return number;
        }
    }
}
