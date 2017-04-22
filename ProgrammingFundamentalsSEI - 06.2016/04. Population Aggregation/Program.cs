using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Population_Aggregation
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, int> countries = new SortedDictionary<string, int>();
            Dictionary<string, long> cities = new Dictionary<string, long>();

            while (true)
            {
                string input = Console.ReadLine();


                if (input.Equals("stop"))
                {
                    PrintResult(countries, cities);
                    break;
                }

                ExecuteCommand(input, countries, cities);
            }
        }

        private static void PrintResult(SortedDictionary<string, int> countries, Dictionary<string, long> cities)
        {
            foreach (var country in countries)
            {
                Console.WriteLine($"{country.Key} -> {country.Value}");
            }

            var topThree = cities.OrderByDescending(x => x.Value).Take(3);
            foreach (var town in topThree)
            {
                Console.WriteLine($"{town.Key} -> {town.Value}");
            }
        }

        private static void ExecuteCommand(string input, SortedDictionary<string, int> countries, Dictionary<string, long> cities)
        {
            input = ClearInput(input);

            string[] splittedInput = input.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);

            string country = GetCountry(splittedInput);
            string city = GetCity(splittedInput);
            long population = GetPopulation(splittedInput);

            AddInfo(countries, cities, country, city, population);
        }

        private static long GetPopulation(string[] splittedInput)
        {
            return long.Parse(splittedInput[2]);
        }

        private static string GetCity(string[] splittedInput)
        {
            if (splittedInput[0][0] >= 65 && splittedInput[0][0] <= 90)
            {
                return splittedInput[1];
            }

            return splittedInput[0];
        }

        private static string GetCountry(string[] splittedInput)
        {
            if (splittedInput[0][0] >= 65 && splittedInput[0][0] <= 90)
            {
                return splittedInput[0];
            }

            return splittedInput[1];
        }

        private static string ClearInput(string input)
        {
            StringBuilder sb = new StringBuilder();

            input = input.Replace("@", "");
            input = input.Replace("#", "");
            input = input.Replace("$", "");
            input = input.Replace("&", "");

            int limit = input.LastIndexOf("\\");
            for (int i = 0; i < limit; i++)
            {
                if (!(input[i] >= 48 && input[i] <= 57))
                {
                    sb.Append(input[i]);
                }
            }

            for (int i = limit; i < input.Length; i++)
            {
                sb.Append(input[i]);
            }

            return sb.ToString();
        }

        private static void AddInfo(SortedDictionary<string, int> countries, Dictionary<string, long> cities, string country, string city, long population)
        {
            if (countries.ContainsKey(country))
            {
                countries[country]++;
            }
            else
            {
                countries.Add(country, 1);
            }

            if (cities.ContainsKey(city))
            {
                cities[city] = population;
            }
            else
            {
                cities.Add(city, population);
            }
        }
    }
}
