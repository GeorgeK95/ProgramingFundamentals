using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Printing_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            PrintTriangle(input);
        }

        private static void PrintTriangle(int input)
        {
            UpperPart(input);
            DownPart(input);
        }

        private static void DownPart(int input)
        {
            for (int index1 = input - 1; index1 >= 1; index1--)
            {
                for (int index2 = 1; index2 <= index1; index2++)
                {
                    Console.Write(index2 + " ");
                }
                Console.WriteLine();
            }
        }

        private static void UpperPart(int input)
        {
            for (int index1 = 1; index1 <= input; index1++)
            {
                for (int index2 = 1; index2 <= index1; index2++)
                {
                    Console.Write(index2 + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
