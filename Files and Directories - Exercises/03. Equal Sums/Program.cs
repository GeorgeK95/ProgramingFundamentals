using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _03.Equal_Sums
{
    class Program
    {
        static string INPUT_PATH = "C:\\Users\\Georgi\\Downloads\\SU\\FDEExercises\\ex3\\input.txt";
        static string OUTPUT_PATH = "C:\\Users\\Georgi\\Downloads\\SU\\FDEExercises\\ex3\\output.txt";

        static void Main(string[] args)
        {
            int[] array = File.ReadAllText(INPUT_PATH).Split(' ').Select(int.Parse).ToArray();
            bool found = false;

            for (int index = 0; index < array.Length; index++)
            {
                bool checkCurrentNumber = CheckNumber(index, array);

                if (checkCurrentNumber)
                {
                    found = true;
                    File.WriteAllText(OUTPUT_PATH, index.ToString());
                }
            }

            if (!found)
            {
                File.WriteAllText(OUTPUT_PATH, "no");
            }

        }

        private static bool CheckNumber(int index, int[] array)
        {
            int sumBeforeIndex = 0;

            for (int i = 0; i < index; i++)
            {
                sumBeforeIndex += array[i];
            }

            int sumAfterIndex = 0;

            for (int i = index + 1; i < array.Length; i++)
            {
                sumAfterIndex += array[i];
            }

            return (sumBeforeIndex == sumAfterIndex) ? true : false;
        }
    }
}
