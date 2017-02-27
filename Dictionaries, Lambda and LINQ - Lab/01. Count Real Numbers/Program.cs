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
            string input = Console.ReadLine();
            double[] numbers = input.Split(' ').Select(double.Parse).ToArray();
            SortedDictionary<double, int> occurrences = new SortedDictionary<double, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                double key = numbers[i];

                if (occurrences.ContainsKey(key))
                {
                    occurrences[key] += 1;
                }
                else
                {
                    occurrences.Add(key, 1);
                }
            }

            PrintDict(occurrences);

        }

        private static void PrintDict(SortedDictionary<double, int> occurrences)
        {
            foreach (var item in occurrences)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
