using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Max_Sequence_of_Increasing_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int count = int.MinValue;
            int startIndex = 0;
            int endIndex = 0;
            bool found = false;

            for (int i = 0; i < array.Length - 1; i++)
            {
                int currCount = GetMatchCount(i, array);

                if (currCount > count)
                {
                    found = true;
                    count = currCount;
                    startIndex = i;
                    endIndex = i + currCount;
                }
            }

            if (found)
            {
                PrintResult(startIndex, endIndex, array);
            }
            else
            {
                Console.WriteLine("No");
            }
        }

        private static void PrintResult(int start, int end, int[] array)
        {
            for (int i = start; i <= end; i++)
            {
                Console.Write(array[i] + " ");
            }
        }

        private static int GetMatchCount(int startIndex, int[] array)
        {
            int count = 0;
            int a = 0;

            for (int currIndex = startIndex; startIndex + a + 1 != array.Length; currIndex++)
            {
                if (array[startIndex + a] < array[startIndex + a + 1])
                {
                    count++;
                }
                else
                {
                    break;
                }

                a++;
            }

            return count;
        }
    }
}

