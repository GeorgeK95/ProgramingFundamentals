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
            int part = int.Parse(Console.ReadLine());
            int laps = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());
            double money = double.Parse(Console.ReadLine());

            long runners = days * capacity;

            if (part < runners)
            {
                runners = part;
            }

            long km = runners * laps * length;
            km /= 1000;

            Console.WriteLine("Money raised: {0:0.00}", km * money);
        }
    }
}
