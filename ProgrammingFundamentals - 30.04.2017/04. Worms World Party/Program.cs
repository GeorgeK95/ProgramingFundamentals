using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Worms_World_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> allNames = new List<string>();
            Dictionary<string, Dictionary<string, long>> primary = new Dictionary<string, Dictionary<string, long>>();
            string line = Console.ReadLine();

            while (!line.Equals("quit"))
            {
                string[] splittedLine = line.Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries);

                string name = splittedLine[0];
                string team = splittedLine[1];
                long score = long.Parse(splittedLine[2]);

                Add(name, team, score, allNames, primary);

                line = Console.ReadLine();
            }

            PrintResult(allNames, primary);
        }

        private static void PrintResult(List<string> allNames, Dictionary<string, Dictionary<string, long>> primary)
        {
            long teamCount = 1;

            foreach (var team in primary.OrderByDescending(x => x.Value.Sum(y => y.Value)).ThenByDescending(x => x.Value.Sum(y => y.Value) / x.Value.Count))
            {
                long totalScore = team.Value.Sum(y => y.Value);
                Console.WriteLine($"{teamCount}. Team:{team.Key}- {totalScore}");
                teamCount++;

                foreach (var worm in team.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"###{worm.Key}: {worm.Value}");
                }
            }
        }

        private static void Add(string name, string team, long score, List<string> allNames, Dictionary<string, Dictionary<string, long>> primary)
        {
            if (!allNames.Contains(name))
            {
                if (primary.ContainsKey(team))
                {
                    Dictionary<string, long> worms = primary[team];
                    worms.Add(name, score);
                    primary[team] = worms;
                }
                else
                {
                    var temp = new Dictionary<string, long>();
                    temp.Add(name, score);
                    primary.Add(team, temp);
                }

                allNames.Add(name);
            }
        }

    }
}
