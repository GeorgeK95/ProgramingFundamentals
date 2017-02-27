using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Logs_Aggregator
{
    class Program
    {
        private static SortedDictionary<string, SortedDictionary<string, int>> logs = new SortedDictionary<string, SortedDictionary<string, int>>();

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();

                string ip = line.Split(' ')[0];
                string user = line.Split(' ')[1];
                int duration = int.Parse(line.Split(' ')[2]);

                if (!logs.ContainsKey(user))
                {
                    SortedDictionary<string, int> dict = new SortedDictionary<string, int>();
                    dict.Add(ip, duration);
                    logs.Add(user, dict);
                }
                else
                {
                    SortedDictionary<string, int> info = logs[user];

                    if (!info.ContainsKey(ip))
                    {
                        info.Add(ip, duration);
                    }
                    else
                    {
                        int oldDuration = info[ip];
                        int newDuration = oldDuration + duration;
                        info[ip] = newDuration;
                        logs[user] = info;
                    }

                }
            }

            PrintLogs();
        }

        private static void PrintLogs()
        {
            foreach (var user in logs)
            {
                int total = GetDuration(user.Value);
                Console.Write($"{user.Key}: {total} [");

                int countForComma = user.Value.Count;

                foreach (var item in user.Value)
                {
                    if (countForComma == 1)
                    {
                        Console.Write($"{item.Key}");
                    }
                    else
                    {
                        Console.Write($"{item.Key}, ");
                    }
                    countForComma--;
                }

                Console.WriteLine("]");
            }
        }

        private static int GetDuration(SortedDictionary<string, int> value)
        {
            int res = 0;

            foreach (var item in value)
            {
                res += item.Value;
            }

            return res;
        }
    }
}
