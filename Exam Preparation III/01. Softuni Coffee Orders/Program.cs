using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Softuni_Coffee_Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<decimal> check = new List<decimal>();

            for (int i = 0; i < n; i++)
            {
                decimal ppc = decimal.Parse(Console.ReadLine());
                string[] da = Console.ReadLine().Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                decimal daysInMonth = DateTime.DaysInMonth(int.Parse(da[2]), int.Parse(da[1]));
                int count = int.Parse(Console.ReadLine());

                decimal currCheck = daysInMonth * count * ppc;
                check.Add(currCheck);
            }

            foreach (var item in check)
            {
                Console.WriteLine($"The price for the coffee is: ${item:f2}");
            }
            Console.WriteLine($"Total: ${check.Sum():f2}");
        }
    }
}
