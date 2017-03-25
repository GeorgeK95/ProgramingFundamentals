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
            int n = int.Parse(Console.ReadLine());
            BigInteger factorial = GetFactorial(n);
            Console.WriteLine(factorial);
        }

        private static BigInteger GetFactorial(int n)
        {
            if (n == 1)
            {
                return 1;
            }

            return GetFactorial(n - 1) * n;
        }
    }
}
