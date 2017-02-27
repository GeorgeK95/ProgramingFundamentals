using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int count = int.MinValue;
            int value = 0;
            bool found = false;

            for (int i = 0; i < array.Length - 1; i++)
            {
                int currCount = GetMatchCount(i, array);

                if (currCount > count)
                {
                    found = true;
                    count = currCount;
                    value = array[i];
                }
            }

            if (found)
            {
                PrintResult(true, value, count);
            }
            else
            {
                PrintResult(false, value, count);
            }
        }

        private static void PrintResult(bool v, int value, int count)
        {
            if (v)
            {
                for (int i = 0; i < count; i++)
                {
                    Console.Write(value + " ");
                }
            }
            else
            {
                Console.WriteLine("No");
            }
        }

        private static int GetMatchCount(int startIndex, int[] array)
        {
            int count = 0;

            for (int currIndex = startIndex; currIndex < array.Length; currIndex++)
            {
                if (array[startIndex] == array[currIndex])
                {
                    count++;
                }
                else
                {
                    break;
                }
            }

            return count;
        }
    }
}
