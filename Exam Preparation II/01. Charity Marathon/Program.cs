using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Charity_Marathon
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            long runners = long.Parse(Console.ReadLine());
            int laps = int.Parse(Console.ReadLine());
            int trackLength = int.Parse(Console.ReadLine());
            int trackCapacity = int.Parse(Console.ReadLine());
            double money = double.Parse(Console.ReadLine());

            if (runners > days * trackCapacity)
            {
                runners = days * trackCapacity;
            }

            long km = (runners * laps * trackLength / 1000);
            Console.WriteLine("Money raised: {0:F2}", km * money);
        }
    }
}
