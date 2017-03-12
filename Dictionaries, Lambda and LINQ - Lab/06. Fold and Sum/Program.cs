using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int k = inputNumbers.Length / 4;

            int[] row_1 = inputNumbers.Take(k).Reverse().ToArray();
            inputNumbers = inputNumbers.Reverse().ToArray();

            int[] row_2 = inputNumbers.Take(k).ToArray();
            inputNumbers = inputNumbers.Reverse().ToArray();

            List<int> sum = new List<int>();

            int[] concatedPart = row_1.Concat(row_2).ToArray();
            int[] centerPart = inputNumbers.Skip(k).Take(2 * k).ToArray();

            for (int i = 0; i < concatedPart.Length; i++)
            {
                sum.Add(concatedPart[i] + centerPart[i]);
            }

            Console.WriteLine(string.Join(" ", sum));
        }
    }
}
