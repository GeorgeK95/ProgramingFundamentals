using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Endurance_Rally
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] competitors = GetCompetitors();
            double[] zones = GetZones();
            int[] checkPoints = GetCheckPoints();

            for (int i = 0; i < competitors.Length; i++)
            {
                double fuel = (int)competitors[i][0];
                bool success = true;

                for (int j = 0; j < zones.Length; j++)
                {

                    if (checkPoints.Contains(j))
                    {
                        fuel += zones[j];
                    }
                    else
                    {
                        fuel -= zones[j];
                    }

                    if (fuel <= 0)
                    {
                        Console.WriteLine($"{competitors[i]} - reached {j}");
                        success = false;
                        break;
                    }
                }

                if (success)
                {
                    string formatted = string.Format("{0:F2}", fuel);
                    Console.WriteLine($"{competitors[i]} - fuel left {formatted}");
                }
            }
        }

        private static int[] GetCheckPoints()
        {
            string input = Console.ReadLine();
            int[] zones = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            return zones;
        }

        private static double[] GetZones()
        {
            double[] zones = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

            return zones;
        }

        private static string[] GetCompetitors()
        {
            string input = Console.ReadLine();
            string[] splitted = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            return splitted;
        }
    }
}
