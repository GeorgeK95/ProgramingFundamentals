using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _04.Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static string INPUT_PATH = "C:\\Users\\Georgi\\Downloads\\SU\\FDEExercises\\ex4\\input.txt";
        static string OUTPUT_PATH = "C:\\Users\\Georgi\\Downloads\\SU\\FDEExercises\\ex4\\output.txt";

        static void Main(string[] args)
        {
            int[] array = File.ReadAllText(INPUT_PATH).Split(' ').Select(int.Parse).ToArray();

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
                StringBuilder outputBuilder = new StringBuilder();

                for (int i = 0; i < count; i++)
                {
                    outputBuilder.Append(value + " ");
                }

                File.WriteAllText(OUTPUT_PATH, outputBuilder.ToString());
            }
            else
            {
                File.WriteAllText(OUTPUT_PATH, "no");
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
