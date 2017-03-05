using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Condense_Array_to_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string line1 = Console.ReadLine();
            int[] numbers_1 = line1.Split(' ').Select(int.Parse).ToArray();
            int operationCount = numbers_1.Length - 1;

            for (int i = 0; i < operationCount; i++)
            {
                numbers_1 = PerformOperation(numbers_1);
            }

            Console.WriteLine(numbers_1[0]);
        }

        private static int[] PerformOperation(int[] numbers_1)
        {
            int[] temp = new int[numbers_1.Length - 1];

            for (int i = 0; i < numbers_1.Length - 1; i++)
            {
                temp[i] = numbers_1[i] + numbers_1[i + 1];
            }

            return temp;
        }
    }
}
