
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Tripple_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] numbers = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            int n = numbers.Length;
            bool found = false;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (IfArrayContainsSum(i, j, n, numbers))
                    {
                        found = true;
                    }
                }
            }

            if (!found)
            {
                Console.WriteLine("No");
            }
        }

        private static bool IfArrayContainsSum(int i, int j, int n, long[] numbers)
        {
            for (int q = 0; q < n; q++)
            {
                if (numbers[i] + numbers[j] == numbers[q])
                {
                    Console.WriteLine("{0} + {1} == {2}", numbers[i], numbers[j], numbers[q]);
                    return true;
                }
            }

            return false;
        }
    }
}
