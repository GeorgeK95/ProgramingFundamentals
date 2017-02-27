using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Equal_Sums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            bool found = false;

            for (int index = 0; index < array.Length; index++)
            {
                bool checkCurrentNumber = CheckNumber(index, array);

                if (checkCurrentNumber)
                {
                    found = true;
                    Console.WriteLine(index);
                }
            }

            if (!found)
            {
                Console.WriteLine("no");
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
