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
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            bool found = false;
            int best = int.MinValue;
            int value = 0;

            for (int i = 0; i < array.Length; i++)
            {
                int count = GetFrequentCount(array, i);

                if (count > best)
                {
                    found = true;
                    best = count;
                    value = array[i];
                }

            }

            if (found)
            {
                Console.WriteLine(value);
            }
            else
            {
                Console.WriteLine("No");
            }
        }

        private static int GetFrequentCount(int[] array, int startIndex)
        {
            int counter = 0;

            for (int i = startIndex; i < array.Length; i++)
            {
                if (array[startIndex] == array[i])
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
