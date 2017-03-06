using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Fold_and_Sum
{
    static class Program
    {
        static void Main(string[] args)
        {
            string line1 = Console.ReadLine();
            int[] array = line1.Split(' ').Select(int.Parse).ToArray();
            int k = array.Length / 4;

            List<int> foldedNumbers = GetFoldedNumbers(array, k);
            int[] summedNumbers = SumArrays(foldedNumbers.ToArray(), SubArray(array, k, 2 * k));

            Console.WriteLine(string.Join(" ", summedNumbers));
        }
        public static T[] SubArray<T>(this T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }

        private static int[] SumArrays(int[] v, int[] array)
        {
            int[] result = new int[v.Length];

            for (int i = 0; i < v.Length; i++)
            {
                result[i] = v[i] + array[i];
            }

            return result;
        }

        private static List<int> GetFoldedNumbers(int[] array, int k)
        {
            List<int> foldedNumbers = new List<int>();
            int counter = 0;

            for (int i = k - 1; i >= 0; i--)
            {
                foldedNumbers.Add(array[i]);
            }

            for (int i = array.Length - 1; i > array.Length - 1 - k; i--)
            {
                foldedNumbers.Add(array[i]);
                counter++;
            }

            return foldedNumbers;
        }
    }
}
