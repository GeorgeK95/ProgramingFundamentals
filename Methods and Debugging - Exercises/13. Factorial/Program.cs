using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _13.Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int factorial = int.Parse(Console.ReadLine());
            BigInteger result = CalculateFactorial(factorial);
            Console.WriteLine(result);
        }

        private static BigInteger CalculateFactorial(int factorial)
        {
            if (factorial == 1)
            {
                return 1;
            }

            return factorial * CalculateFactorial(factorial - 1);
        }
    }
}
