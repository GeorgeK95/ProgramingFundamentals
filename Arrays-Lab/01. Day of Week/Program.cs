using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Day_of_Week
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string[] days = fillDaysOfWeek();

            if (number > 0 && number < 8)
            {
                Console.WriteLine(days[number]);
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }
        }

        private static string[] fillDaysOfWeek()
        {
            string[] days = new string[] { "zero", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            return days;
        }
    }
}
