using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Logs_Aggregator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, long> nameDuration = new Dictionary<string, long>();
            Dictionary<string, List<string>> nameIpList = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                string text = Console.ReadLine();
                string[] splitted = text.Split(' ');

                string ip = splitted[0];
                string name = splitted[1];
                long duration = long.Parse(splitted[2]);

                if (!nameDuration.ContainsKey(name))
                {
                    nameDuration.Add(name, duration);
                    var tempList = new List<string>();
                    tempList.Add(ip);
                    nameIpList.Add(name, tempList);
                }
                else
                {
                    var tempList = nameIpList[name];

                    if (!tempList.Contains(ip))
                    {
                        tempList.Add(ip);
                    }

                    nameDuration[name] += duration;
                }
            }

            Print(nameDuration, nameIpList);
        }

        private static void Print(Dictionary<string, long> nameDuration, Dictionary<string, List<string>> nameIpList)
        {
            foreach (var nameDurPair in nameDuration.OrderBy(x => x.Key))
            {
                Console.Write($"{nameDurPair.Key}: {nameDurPair.Value} ");
                Console.WriteLine("[" + string.Join(", ", nameIpList[nameDurPair.Key].OrderBy(x => x)) + "]");
            }
        }
    }
}
