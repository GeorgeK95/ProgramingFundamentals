using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Sum_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string line1 = Console.ReadLine();
            string line2 = Console.ReadLine();

            int[] numbers_1 = line1.Split(' ').Select(int.Parse).ToArray();
            int[] numbers_2 = line2.Split(' ').Select(int.Parse).ToArray();

            if (numbers_1.Length > numbers_2.Length)
            {
                numbers_2 = MakeSizesEqual(new int[numbers_1.Length], numbers_2);

            }
            else
            {
                numbers_1 = MakeSizesEqual(new int[numbers_2.Length], numbers_1);
            }

            Console.WriteLine(string.Join(" ", GetResult(numbers_1, numbers_2)));

        }

        private static int[] GetResult(int[] numbers_1, int[] numbers_2)
        {
            int[] sumOfArrays = new int[Math.Max(numbers_1.Length, numbers_2.Length)];

            for (int i = 0; i < numbers_1.Length; i++)
            {
                sumOfArrays[i] = numbers_1[i] + numbers_2[i];
            }

            return sumOfArrays;
        }

        private static int[] MakeSizesEqual(int[] newArr, int[] smallerArr)
        {
            int p = 0;

            for (int i = 0; i < newArr.Length; i++)
            {
                newArr[i] = smallerArr[p];
                p++;

                if (p == smallerArr.Length)
                {
                    p = 0;
                }
            }

            return newArr;
        }
    }
}
