using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.A_Miner_Task
{
    class Program
    {
        static string INPUT_PATH = "C:\\Users\\Georgi\\Downloads\\SU\\FDEExercises\\ex5\\input.txt";
        static string OUTPUT_PATH = "C:\\Users\\Georgi\\Downloads\\SU\\FDEExercises\\ex5\\output.txt";

        static void Main(string[] args)
        {
            var resources = FillResources();
            PrintResources(resources);
        }

        private static void PrintResources(Dictionary<string, long> resources)
        {
            StringBuilder outputResult = new StringBuilder();

            foreach (var currItem in resources)
            {
                outputResult.Append($"{currItem.Key} -> {currItem.Value}");
                outputResult.Append(Environment.NewLine);
            }

            File.WriteAllText(OUTPUT_PATH, outputResult.ToString());
        }

        private static Dictionary<string, long> FillResources()
        {
            int evenOddChecker = 1;
            string lastLine = null;
            Dictionary<string, long> resources = new Dictionary<string, long>();
            string[] resourcesArray = File.ReadAllLines(INPUT_PATH);
            int index = 0;

            while (true)
            {
                string line = resourcesArray[index];
                index++;


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
