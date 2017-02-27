using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Count_Work_Days
{
    class Program
    {
        static void Main(string[] args)
        {
            string d1 = Console.ReadLine();
            string d2 = Console.ReadLine();

            DateTime startDate = DateTime.ParseExact(d1, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(d2, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            List<DateTime> arr = new List<DateTime>()
            {
                new DateTime(4, 01, 01),
                new DateTime(4, 03, 03),
                new DateTime(4, 05, 01),
                new DateTime(4, 05, 06),
                new DateTime(4, 05, 24),
                new DateTime(4, 09, 06),
                new DateTime(4, 09, 22),
                new DateTime(4, 11, 01),
                new DateTime(4, 12, 24),
                new DateTime(4, 12, 25),
                new DateTime(4, 12, 26),
            };

            int workingDaysCounter = 0;

            for (var date = startDate; date <= endDate; date = date.AddDays(1))
            {
                DateTime temp = new DateTime(4, date.Month, date.Day);

                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday && !arr.Contains(temp))
                {
                    workingDaysCounter++;
                }

            }
            Console.WriteLine(workingDaysCounter);
        }
    }
}
