using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            var resources = FillResources();
            PrintResources(resources);
        }

        private static void PrintResources(Dictionary<string, long> resources)
        {
            foreach (var currItem in resources)
            {
                Console.WriteLine($"{currItem.Key} -> {currItem.Value}");
            }
        }

        private static Dictionary<string, long> FillResources()
        {
            int evenOddChecker = 1;
            string lastLine = null;
            Dictionary<string, long> resources = new Dictionary<string, long>();

            while (true)
            {
                string line = Console.ReadLine();


                if (line.Equals("stop"))
                {
                    break;
                }

                if (Odd(evenOddChecker))
                {
                    lastLine = line;

                    if (!resources.ContainsKey(line))
                    {
                        resources.Add(line, 0);
                    }

                }
                else
                {
                    long oldValue = 0;

                    if (resources.ContainsKey(lastLine))
                    {
                        oldValue = resources[lastLine];
                    }

                    resources[lastLine] = long.Parse(line) + oldValue;
                }

                evenOddChecker++;
            }

            return resources;
        }

        private static bool Odd(int evenOddChecker)
        {
            if (evenOddChecker % 2 == 0)
            {
                return false;
            }

            return true;
        }
    }
}
