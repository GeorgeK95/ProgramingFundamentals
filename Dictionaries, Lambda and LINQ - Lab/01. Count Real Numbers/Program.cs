using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Count_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();
            SortedDictionary<double, int> occurrences = new SortedDictionary<double, int>();
            GetOccurrences(numbers, occurrences);
            PrintOccurrences(occurrences);

        }

        private static void PrintOccurrences(SortedDictionary<double, int> occurrences)
        {
            foreach (var pair in occurrences)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }

        private static void GetOccurrences(double[] numbers, SortedDictionary<double, int> occurrences)
        {
            foreach (var number in numbers)
            {
                if (occurrences.ContainsKey(number))
                {
                    occurrences[number]++;
                }
                else
                {
                    occurrences.Add(number, 1);
                }
            }
        }
    }
}
