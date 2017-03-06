using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Count_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<int> numbers = input.Split(' ').Select(int.Parse).ToList();
            int[] counts = new int[1000];

            for (int i = 0; i < numbers.Count; i++)
            {
                int currentNumber = numbers[i];
                counts[currentNumber]++;
            }

            for (int i = 0; i < counts.Length; i++)
            {
                if (counts[i] != 0)
                {
                    Console.WriteLine($"{i} -> {counts[i]}");
                }
                
            }
        }
    }
}
