using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace _01.Softuni_Coffee_Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            decimal total = 0;

            for (int i = 0; i < n; i++)
            {
                decimal price = decimal.Parse(Console.ReadLine());
                DateTime orderDate = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
                long count = long.Parse(Console.ReadLine());

                int days = DateTime.DaysInMonth(orderDate.Year, orderDate.Month);
                decimal result = days * count * price;

                Console.WriteLine($"The price for the coffee is: ${result:F2}");
                total += result;
            }

            Console.WriteLine($"Total: ${total:F2}");
        }
    }
}
