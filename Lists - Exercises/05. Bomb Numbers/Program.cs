using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Bomb_Numbers
{
    class Program
    {
        static List<int> numbers;
        static void Main(string[] args)
        {
            numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> numbers2 = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            int bomb = numbers2[0];
            int power = numbers2[1];

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == bomb)
                {
                    Explode(numbers, i, power);
                }
            }

            PrintSum(numbers);
        }

        private static void PrintSum(List<int> numbers)
        {
            long sum = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }

            Console.WriteLine(sum);
        }

        private static void Explode(List<int> numbers, int i, int power)
        {
            int startDestroing = i - power;
            int endDestroing = i + power;

            if (startDestroing < 0)
            {
                startDestroing = 0;
            }
            if (endDestroing > numbers.Count)
            {
                endDestroing = numbers.Count - 1;
            }

            for (int index = startDestroing; index <= endDestroing; index++)
            {
                numbers[index] = 0;
            }
        }
    }
}
