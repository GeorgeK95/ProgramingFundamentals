using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Population_Counter
{
    class Program
    {
        private static Dictionary<string, long> countryPop = new Dictionary<string, long>();
        private static Dictionary<string, Dictionary<string, long>> mainDict = new Dictionary<string, Dictionary<string, long>>();

        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (!input.Equals("report"))
            {
                string town = input.Split('|')[0];
                string country = input.Split('|')[1];
                long pop = long.Parse(input.Split('|')[2]);

                AddDataToDictionaries(town, country, pop);

                input = Console.ReadLine();
            }

            MakeOutput();
        }

        private static void AddDataToDictionaries(string town, string country, long pop)
        {
            if (!countryPop.ContainsKey(country))
            {
                countryPop.Add(country, pop);
            }
            else
            {
                countryPop[country] += pop;
            }

            if (!mainDict.ContainsKey(country))
            {
                Dictionary<string, long> pilot = new Dictionary<string, long>();
                pilot.Add(town, pop);
                mainDict.Add(country, pilot);
            }
            else
            {
                Dictionary<string, long> anotherPilot = mainDict[country];
                anotherPilot.Add(town, pop);
                mainDict[country] = anotherPilot;
            }

        }

        private static void MakeOutput()
        {
            var sortedCountryPop = countryPop.OrderByDescending(TotalPopulation => TotalPopulation.Value);

            foreach (var country in sortedCountryPop)
            {
                string currCountry = country.Key;
                long currCountryPop = country.Value;
                Console.WriteLine($"{currCountry} (total population: {currCountryPop})");

                Dictionary<string, long> countryValue = mainDict[country.Key];  
                var sortedCountryValue = countryValue.OrderByDescending(val => val.Value);

                foreach (var item in sortedCountryValue)
                {
                    string town = item.Key;
                    long pop = item.Value;

                    Console.WriteLine($"=>{town}: {pop}");
                }
            }

        }
    }
}
