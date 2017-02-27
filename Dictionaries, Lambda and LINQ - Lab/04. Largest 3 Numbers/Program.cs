using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Largest_3_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            SortedSet<int> setOfNumbers = GetSetOfNumbers(inputNumbers);

            PrintLargestThree(setOfNumbers);
        }

        private static SortedSet<int> GetSetOfNumbers(List<int> inputNumbers)
        {
            SortedSet<int> setOfNumbers = new SortedSet<int>();

            for (int i = 0; i < inputNumbers.Count; i++)
            {
                setOfNumbers.Add(inputNumbers[i]);
            }

            return setOfNumbers;
        }

        private static void PrintLargestThree(SortedSet<int> setOfNumbers)
        {
            for (int i = 0; i < 3; i++)
            {
                if (setOfNumbers.Max == 0)
                {
                    break;
                }

                Console.WriteLine(setOfNumbers.Max);
                setOfNumbers.Remove(setOfNumbers.Max);
            }
        }
    }
}
