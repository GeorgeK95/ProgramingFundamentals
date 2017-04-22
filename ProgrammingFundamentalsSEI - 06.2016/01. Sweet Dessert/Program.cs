using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Sweet_Dessert
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal money = decimal.Parse(Console.ReadLine());
            int guests = int.Parse(Console.ReadLine());
            decimal bananaPrice = decimal.Parse(Console.ReadLine());
            decimal eggPrice = decimal.Parse(Console.ReadLine());
            decimal berriesPrice = decimal.Parse(Console.ReadLine());

            int quantity = GetNumberOfPortions(guests);
            decimal neededMoney = GetNeededMoney(bananaPrice, eggPrice, berriesPrice, quantity);

            Print(neededMoney, money);
        }

        private static void Print(decimal neededMoney, decimal money)
        {
            if (neededMoney > money)
            {
                Console.WriteLine("Ivancho will have to withdraw money - he will need {0:F2}lv more.", neededMoney - money);
            }
            else
            {
                Console.WriteLine("Ivancho has enough money - it would cost {0:F2}lv.", neededMoney);
            }
        }

        private static decimal GetNeededMoney(decimal bananaPrice, decimal eggPrice, decimal berriesPrice, int quantity)
        {
            decimal total = 0m;

            total += 2 * quantity * bananaPrice;
            total += 4 * quantity * eggPrice;
            total += 0.2m * quantity * berriesPrice;

            return total;
        }

        private static int GetNumberOfPortions(int guests)
        {
            if (guests % 6 == 0)
            {
                return guests / 6;
            }

            return (guests / 6) + 1;
        }
    }
}
