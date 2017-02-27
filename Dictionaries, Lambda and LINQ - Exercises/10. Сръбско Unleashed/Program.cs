using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _10.Сръбско_Unleashed
{
    class Program
    {
        private static Dictionary<string, Dictionary<string, long>> venues = new Dictionary<string, Dictionary<string, long>>();

        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"(\w+(?: \w+)*) @(\w+(?: \w+)*) (\d+) (\d+)";
            Regex regex = new Regex(pattern);

            while (!input.Equals("End"))
            {
                if (regex.IsMatch(input))
                {
                    string singer = GetName(input);
                    string venue = GetVenue(input);
                    int price = GetPrice(input);
                    int count = GetCount(input);
                    long total = price * count;

                    AddInfoToVenuesDictionary(venue, singer, total);
                }


                input = Console.ReadLine();
            }

            PrintVenues();
        }

        private static void PrintVenues()
        {
            foreach (var item in venues)
            {
                Console.WriteLine(item.Key);
                foreach (var item1 in item.Value.OrderByDescending(val => val.Value))
                {
                    Console.WriteLine($"#  {item1.Key}-> {item1.Value}");
                }
            }
        }

        private static void AddInfoToVenuesDictionary(string venue, string singer, long total)
        {
            if (!venues.ContainsKey(venue))
            {
                Dictionary<string, long> helpVariable = new Dictionary<string, long>();
                helpVariable.Add(singer, total);
                venues.Add(venue, helpVariable);
            }
            else
            {
                Dictionary<string, long> valueOfVenue = venues[venue];

                if (!valueOfVenue.ContainsKey(singer))
                {
                    valueOfVenue.Add(singer, total);
                    venues[venue] = valueOfVenue;
                }
                else
                {
                    long totalForNow = valueOfVenue[singer];
                    long totalNew = totalForNow + total;
                    valueOfVenue[singer] = totalNew;
                    venues[venue] = valueOfVenue;
                }

            }
        }

        private static int GetCount(string input)
        {
            int firstSpace = 0;

            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (input[i] == ' ')
                {
                    firstSpace = i;
                    break;
                }
            }

            int ticketCount = int.Parse(input.Substring(firstSpace));
            return ticketCount;
        }

        private static int GetPrice(string input)
        {
            int count = 0;
            int firstIntIndex = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if ((int)input[i] >= 48 && (int)input[i] <= 57)
                {
                    firstIntIndex = i;
                    break;
                }
            }

            for (int i = firstIntIndex + 1; i < input.Length; i++)
            {
                if (input[i] == ' ')
                {
                    break;
                }
                else
                {
                    count++;

                }
            }
            int price = int.Parse(input.Substring(firstIntIndex, count + 1));

            return price;
        }

        private static string GetVenue(string input)
        {
            //getting venue from '@' to first int value
            int monkeyIndex = 0;
            int firstIntIndex = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '@')
                {
                    monkeyIndex = i;
                    break;
                }
            }

            for (int i = monkeyIndex + 1; i < input.Length; i++)
            {
                if ((int)input[i] >= 48 && (int)input[i] <= 57)
                {
                    firstIntIndex = i - 2 - monkeyIndex;
                    break;
                }
            }
            string venue = input.Substring(monkeyIndex + 1, firstIntIndex + 1);

            return venue;
        }

        private static string GetName(string input)
        {
            int monkeyIndex = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '@')
                {
                    monkeyIndex = i;
                    break;
                }
            }

            string name = input.Substring(0, monkeyIndex);

            return name;
        }
    }
}
