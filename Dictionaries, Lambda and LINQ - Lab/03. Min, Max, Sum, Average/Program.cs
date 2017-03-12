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
            List<int> numbers = new List<int>();
            GetNumbers(numbers, n);
            Console.WriteLine($"Sum = {numbers.Sum()}\nMin = {numbers.Min()}\nMax = {numbers.Max()}\nAverage = {numbers.Average()}");
        }

        private static void GetNumbers(List<int> numbers, int n)
        {
            for (int i = 0; i < n; i++)
            {
                numbers.Add(int.Parse(Console.ReadLine()));
            }
        }
    }
}
