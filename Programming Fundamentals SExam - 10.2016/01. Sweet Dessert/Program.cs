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
            double cash = double.Parse(Console.ReadLine());
            int guests = int.Parse(Console.ReadLine());
            double bananasPrice = double.Parse(Console.ReadLine());
            double eggsPrice = double.Parse(Console.ReadLine());
            double berriesPrice = double.Parse(Console.ReadLine());

            int portions = CalculatePortions(guests);

            double needForBan = portions * 2 * bananasPrice;
            double needForEggs = portions * 4 * eggsPrice;
            double needForBerries = portions * 0.2 * berriesPrice;

            double res = needForBan + needForBerries + needForEggs;
            res = Math.Round(res, 2);

            if (res <= cash)
            {
                Console.WriteLine("Ivancho has enough money - it would cost {0:0.00}lv.", res);
            }
            else
            {
                Console.WriteLine("Ivancho will have to withdraw money - he will need {0:0.00}lv more.", Math.Round((res - cash), 2));
            }
        }

        private static int CalculatePortions(int guests)
        {
            int total = guests / 6;
            int portions = 0;

            if (guests % 6 != 0)
            {
                total += 1;
            }

            portions = total * 6;
            return portions / 6;
        }
    }
}
