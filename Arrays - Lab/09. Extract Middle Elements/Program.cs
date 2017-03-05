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
            string line1 = Console.ReadLine();
            int[] numbers_1 = line1.Split(' ').Select(int.Parse).ToArray();
            int l = numbers_1.Length;

            if (l == 1)
            {
                Print(numbers_1);
            }
            else if (IsOdd(l))
            {
                numbers_1 = ExtractMiddleOdd(numbers_1, l);
                Print(numbers_1);
            }
            else
            {
                numbers_1 = ExtractMiddleEven(numbers_1, l);
                Print(numbers_1);
            }
        }

        private static int[] ExtractMiddleEven(int[] numbers_1, int l)
        {
            int[] newArr = new int[2];
            int index = 0;

            for (int i = l / 2 - 1; i <= l / 2 - 1 + 1; i++)
            {
                newArr[index] = numbers_1[i];
                index++;
            }

            return newArr;
        }

        private static int[] ExtractMiddleOdd(int[] numbers_1, int l)
        {
            int[] newArr = new int[3];
            int index = 0;

            for (int i = l / 2 - 1; i <= l / 2 - 1 + 2; i++)
            {
                newArr[index] = numbers_1[i];
                index++;
            }

            return newArr;
        }

        private static bool IsOdd(int l)
        {
            if (l % 2 == 0)
            {
                return false;
            }

            return true;
        }

        private static void Print(int[] numbers_1)
        {
            Console.Write("{ ");
            Console.Write(string.Join(", ", numbers_1));
            Console.Write(" }");
        }
    }
}
