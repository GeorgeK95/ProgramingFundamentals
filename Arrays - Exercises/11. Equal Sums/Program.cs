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
            string line1 = Console.ReadLine();
            int[] array = line1.Split(' ').Select(int.Parse).ToArray();
            GetIndexOfEqualSumsElement(array);
        }

        private static void GetIndexOfEqualSumsElement(int[] array)
        {
            bool isPrinted = false;

            for (int i = 0; i < array.Length; i++)
            {
                int sumLeft = GetSumForCurrentElement(array, i, "left");
                int sumRight = GetSumForCurrentElement(array, i, "right");

                if (sumLeft == sumRight)
                {
                    Console.WriteLine(i);
                    isPrinted = true;
                    break;
                }
            }

            if (!isPrinted)
            {
                Console.WriteLine("no");
            }
        }

        private static int GetSumForCurrentElement(int[] array, int index, string v)
        {
            int sum = 0;

            switch (v)
            {
                case "left":
                    for (int i = 0; i < index; i++)
                    {
                        sum += array[i];
                    }
                    break;

                case "right":
                    for (int i = index + 1; i < array.Length; i++)
                    {
                        sum += array[i];
                    }
                    break;
            }

            return sum;
        }
    }
}
