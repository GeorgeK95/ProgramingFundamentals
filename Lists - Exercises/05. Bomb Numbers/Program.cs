using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int[] numbers = input.Split(' ').Select(int.Parse).ToArray();
            string input2 = Console.ReadLine();
            int bomb = input2.Split(' ').Select(int.Parse).ToArray()[0];
            int power = input2.Split(' ').Select(int.Parse).ToArray()[1];

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == bomb)
                {
                    Detonate(numbers, i, power);
                    numbers[i] = 0;
                }
            }

            PrintSum(numbers);
        }

        private static void PrintSum(int[] numbers)
        {
            long sum = 0;

            foreach (var number in numbers)
            {
                if (number != 0)
                {
                    sum += number;
                }
            }

            Console.WriteLine(sum);
        }

        private static void Detonate(int[] numbers, int i, int power)
        {
            int start = i - power;
            int end = i + power;

            if (start < 0)
            {
                start = 0;
            }
            if (end > numbers.Length - 1)
            {
                end = numbers.Length - 1;
            }

            DetonateLeft(numbers, start, i);
            DetonateRight(numbers, end, i);
        }

        private static void DetonateRight(int[] numbers, int end, int i)
        {
            for (int j = i + 1; j <= end; j++)
            {
                numbers[j] = 0;
            }
        }

        private static void DetonateLeft(int[] numbers, int start, int i)
        {
            for (int j = start; j < i; j++)
            {
                numbers[j] = 0;
            }
        }
    }
}

