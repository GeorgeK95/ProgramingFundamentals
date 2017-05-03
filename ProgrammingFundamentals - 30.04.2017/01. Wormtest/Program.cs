using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Wormtest
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine()) * 100;
            double width = double.Parse(Console.ReadLine());
            double rem = length % width;
            PrintResult(rem, length, width);
        }

        private static void PrintResult(double rem, int length, double width)
        {
            if (width == 0)
            {
                Console.WriteLine("{0:F2}", (length * width));
            }
            else
            {
                if (rem != 0)
                {
                    Console.WriteLine("{0:F2}%", (length / width) * 100);

                }
                else
                {
                    Console.WriteLine("{0:F2}", (length * width));
                }
            }
        }
    }
}
