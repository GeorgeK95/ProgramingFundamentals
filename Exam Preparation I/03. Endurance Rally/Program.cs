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
            double[] trackLayout = GetTrackLayout();
            int[] checkPoints = GetCheckPoints();
            DoEnduranceRally(checkPoints, competitors, trackLayout);
        }

        private static void DoEnduranceRally(int[] checkPoints, string[] competitors, double[] trackLayout)
        {
            for (int competitorIndex = 0; competitorIndex < competitors.Length; competitorIndex++)
            {
                bool isFinished = true;
                double currCompetitorFuel = GetStartingFuel(competitors[competitorIndex]);

                for (int layoutIndex = 0; layoutIndex < trackLayout.Length; layoutIndex++)
                {
                    if (checkPoints.Contains(layoutIndex))
                    {
                        currCompetitorFuel += trackLayout[layoutIndex];
                    }
                    else
                    {
                        currCompetitorFuel -= trackLayout[layoutIndex];
                    }

                    if (currCompetitorFuel <= 0)
                    {
                        Console.WriteLine($"{competitors[competitorIndex]} - reached {layoutIndex}");
                        isFinished = false;
                        break;
                    }
                }

                if (isFinished)
                {
                    double fuelLeft = currCompetitorFuel;
                    Console.WriteLine($"{competitors[competitorIndex]} - fuel left {fuelLeft:F2}");
                }

            }
        }

        private static Dictionary<string, double> FillFuelInfo(string[] competitors)
        {
            var data = new Dictionary<string, double>();

            foreach (var competitor in competitors)
            {
                int startFuel = GetStartingFuel(competitor);
                data.Add(competitor, startFuel);
            }

            return data;
        }

        private static int GetStartingFuel(string competitor)
        {
            return competitor[0];
        }

        private static int[] GetCheckPoints()
        {
            string line = Console.ReadLine();
            if (!line.Equals(string.Empty))
            {
                var competitors = line.Split().Select(int.Parse).ToArray();
                return competitors;
            }

            return new int[0];

        }

        private static double[] GetTrackLayout()
        {
            var competitors = Console.ReadLine().Split().Select(double.Parse).ToArray();
            return competitors;
        }

        private static string[] GetCompetitors()
        {
            var competitors = Console.ReadLine().Split().ToArray();
            return competitors;
        }

    }
}
