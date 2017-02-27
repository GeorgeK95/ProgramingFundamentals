using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Condense_Array_to_Number
{
    class Program
    {
        static int[] numbersArray;

        static void Main(string[] args)
        {
            numbersArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int n = numbersArray.Length;

            for (int i = 0; i < n - 1; i++)
            {
                DoCondenseArrayToNumber();
            }

            Console.WriteLine(numbersArray[0]);
        }

        private static void DoCondenseArrayToNumber()
        {
            int[] newArray = new int[numbersArray.Length - 1];

            for (int j = 0; j < numbersArray.Length - 1; j++)
            {
                int sum = numbersArray[j] + numbersArray[j + 1];
                newArray[j] = sum;
            }

            numbersArray = newArray;
        }
    }
}
