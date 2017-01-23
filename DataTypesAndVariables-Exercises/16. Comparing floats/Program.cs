using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.Comparing_floats
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal num1 = decimal.Parse(Console.ReadLine());
            decimal num2 = decimal.Parse(Console.ReadLine());

            decimal eps = 0.000001m;
            decimal difference = Math.Abs(num2 - num1);

            if (difference >= eps)
            {
                Console.WriteLine(false);
            }
            else if (difference < eps)
            {
                Console.WriteLine(true);
            }

        }
    }
}
