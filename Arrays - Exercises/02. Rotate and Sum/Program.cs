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
            string line1 = Console.ReadLine();
            string line2 = Console.ReadLine();
            int[] array = line1.Split(' ').Select(int.Parse).ToArray();
            int k = int.Parse(line2);

            int[] resultArray = GetResultArray(array, k);
            int[] finalArray = MakeResult(array, resultArray);

            Console.WriteLine(string.Join(" ", finalArray));
        }

        private static int[] GetResultArray(int[] array, int k)
        {
            int[] result = new int[array.Length * k];
            int index = 0;

            for (int i = 0; i < k; i++)
            {
                int el = array[array.Length - 1];
                int[] tempArr = new int[array.Length];

                for (int j = 1; j < array.Length; j++)
                {
                    tempArr[j] = array[j - 1];
                }

                tempArr[0] = el;

                for (int j = 0; j < tempArr.Length; j++)
                {
                    result[index] = tempArr[j];
                    index++;
                }

                array = tempArr;
            }

            return result;
        }

        private static int[] MakeResult(int[] array, int[] result)
        {
            int[] finalArr = new int[array.Length];
            int findex = 0;

            for (int i = 0; i < array.Length; i++)
            {
                int sum = 0;

                for (int j = i; j < result.Length; j += array.Length)
                {
                    sum += result[j];
                }

                finalArr[findex] = sum;
                findex++;
            }

            return finalArr;
        }
    }
}
