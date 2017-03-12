using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().ToUpper().Split();
            Dictionary<string, int> occurrences = new Dictionary<string, int>();
            GetOccurrences(numbers, occurrences);
            PrintOccurrences(occurrences);
        }

        private static void GetOccurrences(string[] numbers, Dictionary<string, int> occurrences)
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

        private static void PrintOccurrences(Dictionary<string, int> occurrences)
        {
            List<string> result = new List<string>();

            foreach (var pair in occurrences)
            {
                if (pair.Value % 2 != 0)
                {
                    result.Add(pair.Key.ToLower());
                }
            }

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
