using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Population_Counter
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Dictionary<string, Dictionary<string, long>> report = new Dictionary<string, Dictionary<string, long>>();
            Dictionary<string, long> countryPopulation = new Dictionary<string, long>();

            while (!text.Equals("report"))
            {
                string[] splitted = text.Split('|');

                string country = GetCountry(splitted);
                string city = GetCity(splitted);
                long pop = GetPopulation(splitted);

                if (!report.ContainsKey(country))
                {
                    var temp = new Dictionary<string, long>();
                    temp.Add(city, pop);
                    report.Add(country, temp);
                    countryPopulation.Add(country, pop);
                }
                else
                {
                    var temp = report[country];
                    temp.Add(city, pop);
                    report[country] = temp;
                    countryPopulation[country] += pop;
                }

                text = Console.ReadLine();
            }

            Print(report, countryPopulation);
        }

        private static void Print(Dictionary<string, Dictionary<string, long>> report, Dictionary<string, long> countryPopulation)
        {
            foreach (var country in countryPopulation.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{country.Key} (total population: {country.Value})");

                foreach (var currentCity in report[country.Key].OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"=>{currentCity.Key}: {currentCity.Value}");
                }
            }
        }


        private static long GetPopulation(string[] splitted)
        {
            return long.Parse(splitted[2]);
        }

        private static string GetCountry(string[] splitted)
        {
            return splitted[1];
        }

        private static string GetCity(string[] splitted)
        {
            return splitted[0];
        }
    }
}
