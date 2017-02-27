using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _14.Factorial_Trailing_Zeroes
{
    class Program
    {
        static void Main(string[] args)
        {
            int factorial = int.Parse(Console.ReadLine());
            BigInteger factorialResult = CalculateFactorial(factorial);
            Console.WriteLine(GetNumberOfZeroes(factorialResult));
        }

        private static int GetNumberOfZeroes(BigInteger factorialResult)
        {
            string factorialResultStr = factorialResult.ToString();
            return CountTraillingZeroes(factorialResultStr, 0); 
        }

        private static int CountTraillingZeroes(string factorialResultStr, int v)
        {
            int numberOfZeroes = 0;

            for (int i = 0; i < factorialResultStr.Length - 1; i++)
            {
                if (factorialResultStr[i].Equals('0'))
                {
                    int currentZeroes = 1;

                    for (int j = i + 1; j < factorialResultStr.Length; j++)
                    {
                        if (!factorialResultStr[j].Equals('0'))
                        {
                            break;
                        }
                        if (factorialResultStr[j].Equals('0'))
                        {
                            currentZeroes++;
                        }
                    }

                    numberOfZeroes = GetBiggerNumber(numberOfZeroes, currentZeroes);
                }
            }

            return numberOfZeroes;
        }

        private static int GetBiggerNumber(int numberOfZeroes, int currentZeroes)
        {
            if (currentZeroes > numberOfZeroes)
            {
                return currentZeroes;
            }

            return numberOfZeroes;
        }

        private static BigInteger CalculateFactorial(int factorial)
        {
            if (factorial == 1)
            {
                return 1;
            }

            return factorial * CalculateFactorial(factorial - 1);
        }
    }
}
