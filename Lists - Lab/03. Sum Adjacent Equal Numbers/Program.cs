using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Sum_Adjacent_Equal_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<double> numbers = input.Split(' ').Select(double.Parse).ToList();
            CalculateAdjacentEqualNumbers(numbers);
            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void CalculateAdjacentEqualNumbers(List<double> numbers)
        {
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    double sum = numbers[i] + numbers[i + 1];
                    numbers.RemoveAt(i);
                    numbers.RemoveAt(i);
                    numbers.Insert(i, sum);
                    i = -1;
                }
            }
        }
    }
}
