using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int k = inputArray.Length / 4;
            int[] sumArray = new int[k * 2];

            sumArray = GetParts(k, inputArray);

            SumAndPrint(inputArray, sumArray, k);
        }

        private static void SumAndPrint(int[] inputArray, int[] sumArray, int k)
        {
            for (int i = 0; i < inputArray.Length / 2; i++)
            {
                Console.Write(inputArray[i + k] + sumArray[i] + " ");
            }

            Console.WriteLine();
        }

        private static int[] GetParts(int k, int[] inputArray)
        {
            int[] sumArray = new int[k * 2];
            int[] sumArray1 = new int[k];
            int[] sumArray2 = new int[k];

            for (int i = 0; i < k; i++)
            {
                sumArray2[i] = inputArray[i];
            }

            Array.Reverse(sumArray2);
            sumArray = ReverseFirst(sumArray, sumArray2);

            for (int j = 0; j < k; j++)
            {
                int last = GetLast(inputArray, j);
                sumArray1[j] = last;
            }

            sumArray = ReverseSecond(sumArray, sumArray1);

            return sumArray;
        }

        private static int[] ReverseSecond(int[] sumArray, int[] sumArray1)
        {
            int p = 0;
            for (int i = sumArray1.Length; i < sumArray.Length; i++)
            {
                sumArray[i] = sumArray1[p];

                p++;
            }

            return sumArray;
        }

        private static int[] ReverseFirst(int[] sumArray, int[] sumArray2)
        {
            for (int i = 0; i < sumArray2.Length; i++)
            {
                sumArray[i] = sumArray2[i];
            }

            return sumArray;
        }

        private static int GetLast(int[] inputArray, int j)
        {
            int returnValue = 0;

            for (int i = inputArray.Length - j; i >= 0; i--)
            {
                returnValue = inputArray[i - 1];
                break;
            }

            return returnValue;
        }
    }
}
