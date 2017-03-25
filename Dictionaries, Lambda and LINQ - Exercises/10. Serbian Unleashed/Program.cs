using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _10.Serbian_Unleashed
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> singers = new Dictionary<string, Dictionary<string, long>>();

            while (true)
            {
                string line = Console.ReadLine();
                string pattern = @"(\w+(?: \w+)*) @(\w+(?: \w+)*) (\d+) (\d+)";
                Regex regex = new Regex(pattern);

                if (line.Equals("End"))
                {
                    break;
                }

                if (regex.IsMatch(line))
                {
                    string singer = GetSinger(line);
                    string venue = GetVenue(line);
                    long money = GetMoney(line);

                    AddSingersInfoToDict(singer, venue, singers, money);
                }
            }

            Print(singers);
        }

        private static void Print(Dictionary<string, Dictionary<string, long>> singers)
        {
            foreach (var venue in singers.Keys)
            {
                Dictionary<string, long> temp = singers[venue];
                Console.WriteLine(venue);
                foreach (var singer in temp.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {singer.Key} -> {singer.Value}");
                }
            }
        }

        private static void AddSingersInfoToDict(string singer, string venue, Dictionary<string, Dictionary<string, long>> singers, long money)
        {
            if (singers.ContainsKey(venue))
            {
                Dictionary<string, long> temp = singers[venue];
                if (temp.ContainsKey(singer))
                {
                    temp[singer] += money;
                }
                else
                {
                    temp.Add(singer, money);
                }
                singers[venue] = temp;
            }
            else
            {
                Dictionary<string, long> temp = new Dictionary<string, long>();
                temp.Add(singer, money);
                singers.Add(venue, temp);
            }
        }

        private static long GetMoney(string line)
        {
            int[] result = GetPriceAndCount(line);
            return result[0] * result[1];
        }

        private static int[] GetPriceAndCount(string line)
        {
            StringBuilder sb = new StringBuilder();
            int count = 0;
            int[] result = new int[2];

            for (int i = line.Length - 1; i >= 0; i--)
            {
                if (line[i] == ' ')
                {
                    count = GetPrice(i, line);
                    break;
                }

                sb.Append(line[i]);
            }

            string numberStr = sb.ToString();
            numberStr = Reverse(numberStr);
            int price = int.Parse(numberStr);

            result[0] = price;
            result[1] = count;

            return result;
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private static string GetVenue(string line)
        {
            StringBuilder venue = new StringBuilder();
            bool write = false;

            for (int i = 1; i < line.Length; i++)
            {
                if (line[i] == '@')
                {
                    write = true;
                }

                if (line[i] >= 48 && line[i] <= 57)
                {
                    break;
                }

                if (write)
                {
                    venue.Append(line[i]);
                }
            }

            venue.Remove(venue.Length - 1, 1);
            venue.Remove(0, 1);
            return venue.ToString();
        }

        private static string GetSinger(string line)
        {
            StringBuilder singer = new StringBuilder();

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '@')
                {
                    break;
                }
                else
                {
                    singer.Append(line[i]);
                }
            }

            singer.Remove(singer.Length - 1, 1);
            return singer.ToString();
        }

        private static int GetPrice(int startIndex, string line)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = startIndex - 1; i >= 0; i--)
            {
                if (line[i] == ' ')
                {
                    break;
                }

                sb.Append(line[i]);
            }

            string numberStr = sb.ToString();
            numberStr = Reverse(numberStr);
            return int.Parse(numberStr);
        }
    }
}
