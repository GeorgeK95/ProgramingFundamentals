using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.Hornet_Armada
{
    class Legion
    {
        public int LastActivity { get; set; }
        public string LegionName { get; set; }
        public Dictionary<string, long> typeAndCount { get; set; }

        public Legion(int LastActivity, string legionName, Dictionary<string, long> typeAndCount)
        {
            this.LastActivity = LastActivity;
            this.LegionName = legionName;
            this.typeAndCount = typeAndCount;
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Legion> legions = new List<Legion>();

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();

                int lastAct = GetLastActivity(line);
                string legName = GetLegionName(line);
                string soldType = GetSoldierType(line);
                int soldCount = GetSoldierCount(line);

                Dictionary<string, long> temp = new Dictionary<string, long>();
                temp.Add(soldType, soldCount);

                Legion newLeg = new Legion(lastAct, legName, temp);
                AddLegions(newLeg, legions);
            }

            PrintResults(legions);
        }

        private static void AddLegions(Legion newLeg, List<Legion> legions)
        {
            bool ContainsLegionName = false;

            foreach (var currLeg in legions)
            {
                if (currLeg.LegionName.Equals(newLeg.LegionName))
                {
                    if (currLeg.typeAndCount.ContainsKey(newLeg.typeAndCount.Keys.First()))
                    {
                        currLeg.typeAndCount[newLeg.typeAndCount.Keys.First()] += newLeg.typeAndCount.Values.First();
                    }
                    else
                    {
                        currLeg.typeAndCount.Add(newLeg.typeAndCount.Keys.First(), newLeg.typeAndCount.Values.First());
                    }

                    if (currLeg.LastActivity < newLeg.LastActivity)
                    {
                        currLeg.LastActivity = newLeg.LastActivity;
                    }

                    ContainsLegionName = true;
                }
            }

            if (!ContainsLegionName)
            {
                legions.Add(newLeg);
            }
        }

        private static void PrintResults(List<Legion> legions)
        {
            string command = Console.ReadLine();
            Regex reg = new Regex(@"[\d]+\\.*");

            if (reg.IsMatch(command))
            {
                PrintFirstCase(command, legions);
            }
            else
            {
                PrintSecondCase(command, legions);
            }

        }

        private static void PrintSecondCase(string givenType, List<Legion> legions)
        {
            Dictionary<int, List<string>> activityAndLegion = GetPrintingValues(legions, givenType);

            foreach (var activityAndLegionPair in activityAndLegion.OrderByDescending(x => x.Key))
            {
                foreach (var activityAndLegionPairValues in activityAndLegionPair.Value)
                {
                    Console.WriteLine($"{activityAndLegionPair.Key} :{activityAndLegionPairValues}");
                }

            }
        }

        private static Dictionary<int, List<string>> GetPrintingValues(List<Legion> legions, string givenType)
        {
            Dictionary<int, List<string>> toReturn = new Dictionary<int, List<string>>();

            foreach (var currentLeg in legions)
            {
                foreach (var type in currentLeg.typeAndCount)
                {
                    if (type.Key.Equals(givenType))
                    {
                        var temp = new List<string>();

                        if (toReturn.ContainsKey(currentLeg.LastActivity))
                        {
                            temp = toReturn[currentLeg.LastActivity];
                            temp.Add(currentLeg.LegionName);
                            toReturn[currentLeg.LastActivity] = temp;
                        }
                        else
                        {
                            temp.Add(currentLeg.LegionName);
                            toReturn.Add(currentLeg.LastActivity, temp);

                        }

                    }
                }
            }

            return toReturn;
        }

        private static void PrintFirstCase(string command, List<Legion> legions)
        {
            int givenAct = int.Parse(command.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries)[0].ToString());
            string givenType = command.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries)[1].ToString();
            Dictionary<string, long> typeAndCount = GetTypesAndCounts(givenAct, givenType, legions);

            foreach (var currentTypeAndCountPair in typeAndCount.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{currentTypeAndCountPair.Key} -> {currentTypeAndCountPair.Value}");
            }
        }

        private static Dictionary<string, long> GetTypesAndCounts(int givenActivity, string givenType, List<Legion> legions)
        {
            Dictionary<string, long> toReturn = new Dictionary<string, long>();

            foreach (var currentLegion in legions)
            {
                if (currentLegion.LastActivity < givenActivity)
                {
                    foreach (var currentTypeAndCountPair in currentLegion.typeAndCount.OrderByDescending(x => x.Value))
                    {
                        if (currentTypeAndCountPair.Key.Equals(givenType))
                        {
                            toReturn.Add(currentLegion.LegionName.Substring(1), currentTypeAndCountPair.Value);
                        }
                    }
                }
            }

            return toReturn;
        }

        private static int GetSoldierCount(string line)
        {
            string typeAndCount = line.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries)[1];
            int count = int.Parse(typeAndCount.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries)[1]);
            return count;
        }

        private static string GetSoldierType(string line)
        {
            string typeAndCount = line.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries)[1];
            string type = typeAndCount.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries)[0];
            return type;
        }

        private static string GetLegionName(string line)
        {
            string activityAndName = line.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries)[0];
            string legName = activityAndName.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries)[1];
            return legName;
        }

        private static int GetLastActivity(string line)
        {
            return int.Parse(line.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries)[0]);
        }
    }
}
