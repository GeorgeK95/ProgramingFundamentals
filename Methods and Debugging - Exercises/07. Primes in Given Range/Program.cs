using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Primes_in_Given_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            List<int> primesList = FindPrimesInRange(start, end);

            PrintResult(primesList);
        }

        private static void PrintResult(List<int> primesList)
        {
            for (int currElement = 0; currElement < primesList.Count; currElement++)
            {
                if (currElement == primesList.Count - 1)
                {
                    Console.Write($"{primesList[currElement]} ");
                }
                else
                {
                    Console.Write($"{primesList[currElement]}, ");
                }
            }
        }

        private static List<int> FindPrimesInRange(int start, int end)
        {
            List<int> primesList = new List<int>();

            for (int currentNumber = start; currentNumber <= end; currentNumber++)
            {
                if (IsPrime(currentNumber))
                {
                    primesList.Add(currentNumber);
                }
            }

            return primesList;
        }

        private static bool IsPrime(long number)
        {
            if (number == 1 || number == 0) return false;
            if (number == 2) return true;

            for (int i = 2; i <= Math.Ceiling(Math.Sqrt(number)); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
