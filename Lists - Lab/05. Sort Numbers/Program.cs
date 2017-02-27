using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Sort_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine().Split(' ').Select(double.Parse).ToList();

            numbers.Sort();

            PrintResult(numbers);
        }

        private static void PrintResult(List<double> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (i == numbers.Count - 1)
                {
                    Console.Write(numbers[i]);
                }
                else
                {
                    Console.Write(numbers[i] + " <= ");
                }

            }
        }
    }
}
