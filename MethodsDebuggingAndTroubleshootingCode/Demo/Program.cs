using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string input2 = Console.ReadLine();

            DateTime db;
            db = Convert.ToDateTime(input);

            DateTime db2;
            db2 = Convert.ToDateTime(input2);

            int holidaysCount = 0;

            for (var date = db; date <= db2; date = date.AddDays(1))
            {
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                {
                    holidaysCount++;
                }
            }
               
            Console.WriteLine(holidaysCount);
        }
    }
}
