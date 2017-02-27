using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Square_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> squareNumber = new List<int>();

            for (int i = 0; i < input.Count; i++)
            {
                if (IsSquare(input[i]))
                {
                    squareNumber.Add(input[i]);
                }
            }

            PrintFinalResult(squareNumber);
        }

        private static void PrintFinalResult(List<int> squareNumber)
        {
            squareNumber.Sort();
            squareNumber.Reverse();

            for (int i = 0; i < squareNumber.Count; i++)
            {
                Console.Write(squareNumber[i] + " ");
            }
        }

        private static bool IsSquare(int num)
        {
            if (Math.Sqrt(num) == (int)Math.Sqrt(num))
            {
                return true;
            }

            return false;
        }
    }
}
