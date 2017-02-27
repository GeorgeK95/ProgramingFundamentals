using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Fibonacci_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int fibNumber = int.Parse(Console.ReadLine());
            int result = Fib(fibNumber);
            Console.WriteLine(result);
        }

        private static int Fib(int fibNumber)
        {
            if (fibNumber <= 1)
            {
                return 1;
            }

            return Fib(fibNumber - 1) + Fib(fibNumber - 2);
        }
    }
}
