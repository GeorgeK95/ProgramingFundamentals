using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Pairs_by_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            string line1 = Console.ReadLine();
            int difference = int.Parse(Console.ReadLine());
            int[] array = line1.Split(' ').Select(int.Parse).ToArray();

            int pairs = GetPairs(array, difference);
            Console.WriteLine(pairs);
        }

        private static int GetPairs(int[] array, int difference)
        {
            int pairs = 0;
            
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (Math.Abs(array[i] - array[j]) == difference)
                    {
                        pairs++;
                    }
                }
            }

            return pairs;
        }
    }
}
