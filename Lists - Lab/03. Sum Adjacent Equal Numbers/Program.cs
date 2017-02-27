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
            string values = Console.ReadLine();
            List<double> numbers = values.Split(' ').Select(double.Parse).ToList();

            for (int i = 0; i < numbers.Count - 1; i++)
             {
                if (numbers[i] == numbers[i + 1])
                {
                    double sum = numbers[i] + numbers[i + 1];
                    numbers = TreatList(numbers, sum, i);
                    i = -1;
                }
            }

            PrintResult(numbers);
        }

        private static void PrintResult(List<double> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                Console.Write(numbers[i] + " ");
            }
        }

        private static List<double> TreatList(List<double> numbers, double sum, int i)
        {
            numbers.RemoveAt(i);
            numbers.RemoveAt(i);

            numbers.Insert(i, sum);

            return numbers;
        }
    }
}
