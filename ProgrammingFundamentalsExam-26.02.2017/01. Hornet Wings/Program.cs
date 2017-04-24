using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Hornet_Wings
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            decimal m = decimal.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());

            decimal meters = (n / 1000) * m;
            decimal secondsFly = (n / 100);
            decimal secondsRest = (n / p) * 5;
            decimal totalSeconds = secondsFly + secondsRest;

            Console.WriteLine("{0:F2} m.", meters);
            Console.WriteLine("{0} s.", totalSeconds);
        }
    }
}
