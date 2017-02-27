using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Center_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal x1 = decimal.Parse(Console.ReadLine());
            decimal y1 = decimal.Parse(Console.ReadLine());
            decimal x2 = decimal.Parse(Console.ReadLine());
            decimal y2 = decimal.Parse(Console.ReadLine());

            PrintClosestPoint(x1, y1, x2, y2);
        }

        private static void PrintClosestPoint(decimal x1, decimal y1, decimal x2, decimal y2)
        {
            decimal c1 = Math.Abs(x1) + Math.Abs(y1);
            decimal c2 = Math.Abs(x2) + Math.Abs(y2);

            if (c1 <= c2)
            {
                Console.WriteLine($"({x1}, {y1})");
            }
            else
            {
                Console.WriteLine($"({x2}, {y2})");
            }
        }
    }
}
