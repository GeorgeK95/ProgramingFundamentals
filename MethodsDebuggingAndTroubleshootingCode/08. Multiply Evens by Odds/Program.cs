using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Multiply_Evens_by_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int sumEvenDigits = GetSumOfEvenDigits(number);
            int sumOddDigits = GetSumOfOddDigits(number);

            Console.WriteLine(sumEvenDigits * sumOddDigits);
        }

        private static int GetSumOfOddDigits(int number)
        {
            int sum = 0;

            while (number != 0)
            {
                int digit = number % 10;
                if (isOdd(digit))
                {
                    sum += digit;
                }
                number /= 10;
            }

            return sum;
        }

        private static bool isOdd(int digit)
        {
            return digit % 2 == 0 ? false : true;
        }

        private static int GetSumOfEvenDigits(int number)
        {
            int sum = 0;

            while (number != 0)
            {
                int digit = number % 10;
                if (isEven(digit))
                {
                    sum += digit;
                }
                number /= 10;
            }

            return sum;
        }

        private static bool isEven(int digit)
        {
            return digit % 2 == 0 ? true : false;
        }
    }
}
