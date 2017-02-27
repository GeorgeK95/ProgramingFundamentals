using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Reverse_Array_of_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = fillArrayWithValues(n);

            PrintReversedNumbers(numbers);
        }

        private static int[] fillArrayWithValues(int lenght)
        {
            int[] values = new int[lenght];

            for (int i = 0; i < lenght; i++)
            {
                values[i] = int.Parse(Console.ReadLine());
            }

            return values;
        }

        private static void PrintReversedNumbers(int[] numbers)
        {
            Array.Reverse(numbers);

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }
        }
    }
}
