using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Sum_Arrays
{
    class Program
    {
        static int[] numbersArray1;
        static int[] numbersArray2;
        static void Main(string[] args)
        {
            numbersArray1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            numbersArray2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            SummingArraysAndPrintingResult();
        }

        private static void SummingArraysAndPrintingResult()
        {
            int sizeArray1 = numbersArray1.Length;
            int sizeArray2 = numbersArray2.Length;
            int[] summedArray = new int[sizeArray2];

            if (sizeArray1 < sizeArray2)
            {
                numbersArray1 = DuplicateArray(sizeArray2, numbersArray1);
                summedArray = new int[sizeArray2];
            }
            else if (sizeArray1 > sizeArray2)
            {
                numbersArray2 = DuplicateArray(sizeArray1, numbersArray2);
                summedArray = new int[sizeArray1];
            }

            for (int i = 0; i < summedArray.Length; i++)
            {
                summedArray[i] = numbersArray1[i] + numbersArray2[i];
            }

            PrintResult(summedArray);
        }

        private static void PrintResult(int[] summedArray)
        {
            for (int i = 0; i < summedArray.Length; i++)
            {
                Console.Write(summedArray[i] + " ");
            }
        }

        private static int[] DuplicateArray(int sizeArray, int[] numbersArray)
        {
            int[] copyArray = new int[sizeArray];

            for (int i = 0; i < numbersArray.Length; i++)
            {
                copyArray[i] = numbersArray[i];
            }

            int p = numbersArray.Length;
            int q = 0;
            while (p < sizeArray)
            {
                copyArray[p] = numbersArray[q];
                p++; q++;

                if (q == numbersArray.Length)
                {
                    q = 0;
                }
            }

            return copyArray;
        }

        private static void SummingTwoArrays()
        {

        }
    }
}
