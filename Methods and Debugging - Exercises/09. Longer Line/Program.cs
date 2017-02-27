using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Longer_Line
{
    class Program
    {
        static void Main(string[] args)
        {
            //line 1
            decimal x1 = decimal.Parse(Console.ReadLine());
            decimal y1 = decimal.Parse(Console.ReadLine());
            decimal x2 = decimal.Parse(Console.ReadLine());
            decimal y2 = decimal.Parse(Console.ReadLine());
            //line 2
            decimal x3 = decimal.Parse(Console.ReadLine());
            decimal y3 = decimal.Parse(Console.ReadLine());
            decimal x4 = decimal.Parse(Console.ReadLine());
            decimal y4 = decimal.Parse(Console.ReadLine());

            decimal lenghtOfLine1 = GetLineLenght(x1, y1, x2, y2);
            decimal lenghtOfLine2 = GetLineLenght(x3, y3, x4, y4);

            //printing biggest line
            if (lenghtOfLine2 > lenghtOfLine1)
            {
                PrintClosestPoint(x3, y3, x4, y4);
            }
            else
            {
                PrintClosestPoint(x1, y1, x2, y2);
            }
        }

        private static decimal GetLineLenght(decimal x1, decimal y1, decimal x2, decimal y2)
        {
            decimal leg1 = Math.Abs((Math.Abs(x1) + Math.Abs(x2)));
            decimal leg2 = Math.Abs((Math.Abs(y1) + Math.Abs(y2)));

            decimal hypo = leg1 + leg2;

            return hypo;
        }

        private static void PrintClosestPoint(decimal x1, decimal y1, decimal x2, decimal y2)
        {
            decimal c1 = Math.Abs(x1) + Math.Abs(y1);
            decimal c2 = Math.Abs(x2) + Math.Abs(y2);

            if (c1 <= c2)
            {
                Console.Write($"({x1}, {y1})");
                Console.WriteLine($"({x2}, {y2})");
            }
            else
            {
                Console.Write($"({x2}, {y2})");
                Console.WriteLine($"({x1}, {y1})");
            }
        }
    }
}
