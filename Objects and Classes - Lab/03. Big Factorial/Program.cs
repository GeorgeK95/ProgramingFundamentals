using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _03.Big_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(recursive(int.Parse(Console.ReadLine())));
        }

        private static BigInteger recursive(BigInteger n)
        {
            if (n == 1)
            {
                return 1;
            }
            else
            {
                BigInteger p = n * recursive(n - 1);
                return p;
            }
        }
    }
}
