using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _01.Most_Frequent_Number
{
    class Program
    {
        static string INPUT_PATH = "C:\\Users\\Georgi\\Downloads\\SU\\FDEExercises\\ex1\\input.txt";
        static string OUTPUT_PATH = "C:\\Users\\Georgi\\Downloads\\SU\\FDEExercises\\ex1\\output.txt";

        static void Main(string[] args)
        {
            int[] numbers = File.ReadAllText(INPUT_PATH).Split(' ').Select(int.Parse).ToArray();

            int mostFrequentNumber = GetMostFrequentNumber(numbers);

            File.WriteAllText(OUTPUT_PATH, mostFrequentNumber.ToString());
        }

        private static int GetMostFrequentNumber(int[] numbers)
        {
            bool found = false;
            int best = int.MinValue;
            int value = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                int count = GetFrequentCount(numbers, i);

                if (count > best)
                {
                    found = true;
                    best = count;
                    value = numbers[i];
                }

            }

            /* if (found)
             {
                 Console.WriteLine(value);
             }
             else
             {
                 Console.WriteLine("No");
             }*/

            return value;
        }

        private static int GetFrequentCount(int[] array, int startIndex)
        {
            int counter = 0;

            for (int i = startIndex; i < array.Length; i++)
            {
                if (array[startIndex] == array[i])
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
