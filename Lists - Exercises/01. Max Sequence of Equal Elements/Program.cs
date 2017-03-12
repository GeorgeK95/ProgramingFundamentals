using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int[] numbers = input.Split(' ').Select(int.Parse).ToArray();
            FindMaxSequenceAndPrintIt(numbers);
        }

        private static void FindMaxSequenceAndPrintIt(int[] numbers)
        {
            int element = numbers[0];
            int bestCount = 0;
            int currCount = 0;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    currCount++;
                    if (currCount > bestCount)
                    {
                        bestCount = currCount;
                        element = numbers[i];
                    }
                }
                else
                {
                    currCount = 0;
                }
            }

            PrintResult(bestCount, element);
        }

        private static void PrintResult(int bestCount, int element)
        {
            for (int i = 0; i <= bestCount; i++)
            {
                if (i == bestCount)
                {
                    Console.Write(element);
                }
                else
                {
                    Console.Write(element + " ");
                }
            }
        }
    }
}
