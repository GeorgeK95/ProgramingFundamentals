using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Min__Max__Sum__Average
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var numbers = GetSetWithNumbers(n);

            PrintResult(numbers);
        }

        private static void PrintResult(SortedSet<double> numbers)
        {
            double sum = GetSumOfSet(numbers);
            double min = numbers.First();
            double max = numbers.Last();
            double average = sum / numbers.Count;

            Console.WriteLine($"Sum = {sum}\nMin = {min}\nMax = {max}\nAverage = {average}");
        }

        private static double GetSumOfSet(SortedSet<double> numbers)
        {
            double res = 0;

            foreach (double item in numbers)
            {
                res += item;
            }

            return res;
        }

        private static SortedSet<double> GetSetWithNumbers(int n)
        {
            SortedSet<double> numbers = new SortedSet<double>();

            for (int i = 0; i < n; i++)
            {
                double currNum = double.Parse(Console.ReadLine());
                numbers.Add(currNum);
            }

            return numbers;
        }
    }
}
