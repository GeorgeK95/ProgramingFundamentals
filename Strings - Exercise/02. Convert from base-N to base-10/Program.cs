using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _02.Convert_from_base_N_to_base_10
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            int base_n = int.Parse(line.Split(' ')[0]);
            BigInteger number = BigInteger.Parse(line.Split(' ')[1]);

            string result = ConvertToBase_10(number, base_n);
            Console.WriteLine(result);
        }

        private static string ConvertToBase_10(BigInteger number, int base_n)
        {
            string characters = "0123456789ABCDEF";

            BigInteger input = number;
            int cbase = base_n;
            BigInteger results = 0;

            foreach (char digit in input.ToString().ToArray())
            {
                results = (cbase * results) + characters.ToUpper().IndexOf(digit);
            }

            return results.ToString();
        }

    }
}