using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Last_K_Numbers_Sums
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            long[] numbers = new long[n];
            numbers[0] = 1;

            for (int i = 1; i < n; i++)
            {
                long sum = GetCurrentSum(i, k, numbers);
                numbers[i] = sum;

            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static long GetCurrentSum(int i, int k, long[] numbers)
        {
            int startIndex = i - k;

            if (startIndex < 0)
            {
                startIndex = 0;
            }

            long sum = 0;
            for (int j = startIndex; j < i; j++)
            {
                sum += numbers[j];
            }

            return sum;
        }
    }
}
