using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SoftUni_Water_Supplies
{
    class Program
    {
        private static decimal totalWater;
        private static bool isOver = false;
        static void Main(string[] args)
        {
            totalWater = decimal.Parse(Console.ReadLine());
            decimal[] bottles = GetBottles();
            int capacity = int.Parse(Console.ReadLine());

            if (totalWater % 2 == 0)
            {
                SupplyEven(bottles, capacity);
            }
            else
            {
                SupplyOdd(bottles, capacity);
            }

            if (!isOver)
            {
                Console.WriteLine("Enough water!");
                Console.WriteLine($"Water left: {totalWater}l.");
            }
        }

        private static void SupplyOdd(decimal[] bottles, int capacity)
        {

            for (int i = bottles.Length - 1; i >= 0; i--)
            {
                decimal old = bottles[i];
                decimal need = capacity - old;

                if (totalWater - need < 0)
                {
                    PrintOdd(i, bottles, capacity, need - totalWater);
                    isOver = true;
                    break;
                }
                else
                {
                    totalWater -= need;
                }
            }
        }

        private static void PrintOdd(int startIndex, decimal[] bottles, int capacity, decimal lastAdded)
        {
            List<decimal> indexes = new List<decimal>();
            decimal bb = 0m;

            for (int j = startIndex; j >= 0; j--)
            {
                indexes.Add(j);

                if (j == startIndex)
                {
                    bb += lastAdded;
                }
                else
                {
                    bb += (capacity - bottles[j]);
                }

            }

            Console.WriteLine("We need more water!");
            Console.WriteLine($"Bottles left: {indexes.Count}");
            Console.WriteLine($"With indexes: {string.Join(", ", indexes)}");
            Console.WriteLine($"We need {bb} more liters!");
        }

        private static void SupplyEven(decimal[] bottles, int capacity)
        {
            for (int i = 0; i < bottles.Length; i++)
            {
                decimal old = bottles[i];
                decimal need = capacity - old;

                if (totalWater - need < 0)
                {
                    Print(i, bottles, capacity, need - totalWater);
                    isOver = true;
                    break;
                }
                else
                {
                    totalWater -= need;
                }
            }

        }

        private static void Print(int startIndex, decimal[] bottles, int capacity, decimal lastAdded)
        {
            List<decimal> indexes = new List<decimal>();
            decimal bb = 0m;

            for (int j = startIndex; j < bottles.Length; j++)
            {
                indexes.Add(j);

                if (j == startIndex)
                {
                    bb += lastAdded;
                }
                else
                {
                    bb += (capacity - bottles[j]);
                }

            }

            Console.WriteLine("We need more water!");
            Console.WriteLine($"Bottles left: {indexes.Count}");
            Console.WriteLine($"With indexes: {string.Join(", ", indexes)}");
            Console.WriteLine($"We need {bb} more liters!");

        }

        private static decimal[] GetBottles()
        {
            return Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).ToArray();
        }
    }
}
