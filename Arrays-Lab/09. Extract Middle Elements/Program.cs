using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Extract_Middle_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbersArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int size = numbersArray.Length;

            if (size == 1)
            {
                Console.Write("{");
                Console.Write(" {0} ", numbersArray[0]);
                Console.Write("}");
            }
            else if (size % 2 == 0)
            {
                PrintEven(numbersArray);
            }
            else if (size % 2 != 0)
            {
                PrintOdd(numbersArray);
            }
        }

        private static void PrintOdd(int[] numbersArray)
        {
            Console.Write("{");
            Console.Write(" {0}, {1}, {2} ", numbersArray[(numbersArray.Length / 2) - 1], numbersArray[(numbersArray.Length / 2)], numbersArray[(numbersArray.Length / 2) + 1]);
            Console.Write("}");
        }

        private static void PrintEven(int[] numbersArray)
        {
            Console.Write("{");
            Console.Write( " {0}, {1} ", numbersArray[(numbersArray.Length / 2) - 1], numbersArray[(numbersArray.Length / 2)]);
            Console.Write("}");
        }
    }
}
