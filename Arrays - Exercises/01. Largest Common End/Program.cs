using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Largest_Common_End
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrayOfWords1 = Console.ReadLine().Split(' ').ToArray();
            string[] arrayOfWords2 = Console.ReadLine().Split(' ').ToArray();

            int counterLeft = GetLeftCommonEnd(arrayOfWords1, arrayOfWords2, Math.Min(arrayOfWords1.Length, arrayOfWords2.Length));
            int counterRight = GetRightCommonEnd(arrayOfWords1, arrayOfWords2, Math.Min(arrayOfWords1.Length, arrayOfWords2.Length));

            Console.WriteLine(Math.Max(counterLeft, counterRight));

        }

        private static int GetRightCommonEnd(string[] arrayOfWords1, string[] arrayOfWords2, int size)
        {
            int counter = 0;

            for (int i = 1; i <= size; i++)
            {
                if (arrayOfWords1[arrayOfWords1.Length - i] == arrayOfWords2[arrayOfWords2.Length - i])
                {
                    counter++;
                }
            }

            return counter;
        }

        private static int GetLeftCommonEnd(string[] arrayOfWords1, string[] arrayOfWords2, int size)
        {
            int counter = 0;

            for (int i = 0; i < size; i++)
            {
                if (arrayOfWords1[i] == arrayOfWords2[i])
                {
                    counter++;
                }
            }

            return counter;
        }

    }
}
