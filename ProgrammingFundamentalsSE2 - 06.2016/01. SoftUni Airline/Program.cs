using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SoftUni_Airline
{
    class Program
    {
        static void Main(string[] args)
        {
            int flightsNumber = int.Parse(Console.ReadLine());
            decimal overall = 0;

            for (int i = 0; i < flightsNumber; i++)
            {
                int adultsNumber = int.Parse(Console.ReadLine());
                decimal adultTicketsPrice = decimal.Parse(Console.ReadLine());
                int youngsNumber = int.Parse(Console.ReadLine());
                decimal youngTicketsPrice = decimal.Parse(Console.ReadLine());
                decimal fuelPricePerHour = decimal.Parse(Console.ReadLine());
                decimal fuelConsumationPerHour = decimal.Parse(Console.ReadLine());
                int flightDuration = int.Parse(Console.ReadLine());

                decimal profit = (adultsNumber * adultTicketsPrice) + (youngsNumber * youngTicketsPrice);
                decimal loss = fuelPricePerHour * fuelConsumationPerHour * flightDuration;
                decimal result = profit - loss;

                PrintResult(result);

                overall += result;
            }

            PrintOverallAverage(overall, flightsNumber);
        }

        private static void PrintOverallAverage(decimal overall, int flightsNumber)
        {
            Console.WriteLine($"Overall profit -> {overall:F3}$.");
            Console.WriteLine($"Average profit -> {overall / flightsNumber:F3}$.");
        }

        private static void PrintResult(decimal result)
        {
            if (result >= 0)
            {
                Console.WriteLine($"You are ahead with {result:F3}$.");
            }
            else
            {
                Console.WriteLine($"We've got to sell more tickets! We've lost {result:F3}$.");
            }
        }
    }
}
