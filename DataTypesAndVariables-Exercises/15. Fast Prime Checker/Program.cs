using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.Fast_Prime_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            int range = int.Parse(Console.ReadLine());
            for (int index = 2; index <= range; index++)
            {
                bool isPrime = true;
                for (int divisor = 2; divisor <= Math.Sqrt(index); divisor++)
                {
                    if (index % divisor == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                Console.WriteLine($"{index} -> {isPrime}");
            }

        }
    }
}
