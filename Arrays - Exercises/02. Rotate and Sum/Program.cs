using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Rotate_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int k = int.Parse(Console.ReadLine());
            long[] copyInputArray = new long[inputArray.Length * k];

            for (int i = 0; i < k; i++)
            {
                inputArray = RotateRightArray(inputArray);
                copyInputArray = FillCopyInputArrayWithRotatedValues(copyInputArray, i * inputArray.Length, inputArray);
            }

            PrintArr(inputArray, k, copyInputArray);
        }

        private static void PrintArr(int[] inputArray, int k, long[] copyInputArray)
        {
            for (int i = 0; i < inputArray.Length; i++)
            {
                long sum = 0;
                for (int j = i; j < copyInputArray.Length; j += inputArray.Length)
                {
                    sum += copyInputArray[j];
                }

                Console.Write(sum + " ");
            }
        }

        private static long[] FillCopyInputArrayWithRotatedValues(long[] copyInputArray, int i, int[] inputArray)
        {
            int b = 0;

            while (b < inputArray.Length)
            {
                copyInputArray[i] = inputArray[b];
                b++; i++;
            }

            return copyInputArray;
        }

        private static int[] RotateRightArray(int[] array)
        {
            int lastElement = array[array.Length - 1];

            for (int i = array.Length - 1; i >= 1; i--)
            {
                array[i] = array[i - 1];
            }

            array[0] = lastElement;

            return array;
        }

        private static long[] FillCopyInputArray(long[] copyInputArray, int[] inputArray)
        {
            for (int i = 0; i < inputArray.Length; i++)
            {
                copyInputArray[i] = inputArray[i];
            }

            return copyInputArray;
        }
    }
}
