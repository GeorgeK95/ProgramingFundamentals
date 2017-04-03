using System;
using System.Collections.Generic;
using System.Globalization;

namespace _01.Count_Work_Days
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstInput = Console.ReadLine();
            string secondInput = Console.ReadLine();

            DateTime startDate = DateTime.ParseExact(firstInput, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(secondInput, "dd-MM-yyyy", CultureInfo.InvariantCulture);

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
                DateTime tempDate = new DateTime(4, date.Month, date.Day);

                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday && !arr.Contains(tempDate))
                {
                    workingDaysCounter++;
                }

            }
            Console.WriteLine(workingDaysCounter);
        }
    }
}
