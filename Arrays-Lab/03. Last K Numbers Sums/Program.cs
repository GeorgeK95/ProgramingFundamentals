using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Last_K_Numbers_Sums
{
    class Program
    {
        static long[] values;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            FillValuesArray(n, k);

            PrintValuesArray();
        }

        private static void FillValuesArray(int n, int k)
        {
            values = new long[n];
            values[0] = 1;

            for (int i = 1; i < n; i++)
            {
                long sum = GetSumOfPreviousKElements(k, i);
                values[i] = sum;
            }
        }

        private static void PrintValuesArray()
        {
            for (int i = 0; i < values.Length; i++)
            {
                Console.Write(values[i] + " ");
            }
        }

        private static long GetSumOfPreviousKElements(int k, int index)
        {
            int start = index - k;
            int end = start + k;
            long sum = 0;

            if (start < 0)
            {
                start = 0;
            }

            for (int i = start; i < end; i++)
            {
                sum += values[i];
            }

            return sum;
        }
    }
}
