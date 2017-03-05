using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Tripple_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            bool isPrinted = false;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    int currSum = numbers[i] + numbers[j];

                    if (IsNumbersContainsCurrSum(numbers, currSum))
                    {
                        Console.WriteLine($"{numbers[i]} + {numbers[j]} == {currSum}");
                        isPrinted = true;
                    }
                }
            }

            if (!isPrinted)
            {
                Console.WriteLine("No");
            }
        }

        private static bool IsNumbersContainsCurrSum(int[] numbers, long currSum)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == currSum)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
