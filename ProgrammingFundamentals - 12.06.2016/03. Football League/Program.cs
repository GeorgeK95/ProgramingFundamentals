using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Football_League
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> teamPoints = new Dictionary<string, int>();
            Dictionary<string, int> teamGoals = new Dictionary<string, int>();
            string key = Console.ReadLine();

            while (true)
            {
                string line = Console.ReadLine();

                if (line.Equals("final"))
                {
                    Print(teamPoints, teamGoals);
                    break;
                }

                PlayMatch(teamGoals, teamPoints, line, key);
            }
        }

        private static void Print(Dictionary<string, int> teamPoints, Dictionary<string, int> teamGoals)
        {
            Console.WriteLine("League standings:");
            int position = 1;

            foreach (var team in teamPoints.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{position}. {team.Key} {team.Value}");
                position++;
            }

            Console.WriteLine("Top 3 scored goals:");

            foreach (var team in teamGoals.OrderByDescending(x => x.Value).ThenBy(x => x.Key).Take(3))
            {
                Console.WriteLine($"- {team.Key} -> {team.Value}");
            }
        }

        private static void PlayMatch(Dictionary<string, int> teamGoals, Dictionary<string, int> teamPoints, string line, string key)
        {
            string firstTeam = GetFirstTeam(line, key).ToUpper();
            string secondTeam = GetSecondTeam(line, key).ToUpper();

            int firstTeamGoals = GetFirstTeamGoals(line);
            int secondTeamGoals = GetSecondTeamGoals(line);

            int firstTeamPoints = GetFirstTeamPoints(firstTeamGoals, secondTeamGoals);
            int secondTeamPoints = GetSecondTeamPoints(firstTeamGoals, secondTeamGoals);

            UpdateFirstTeamPoints(teamPoints, firstTeam, firstTeamPoints);
            UpdateSecondTeamPoints(teamPoints, secondTeam, secondTeamPoints);

            UpdateFirstTeamGoals(teamGoals, firstTeam, firstTeamGoals);
            UpdateSecondTeamGoals(teamGoals, secondTeam, secondTeamGoals);
        }

        private static int GetSecondTeamPoints(int firstTeamGoals, int secondTeamGoals)
        {
            if (secondTeamGoals > firstTeamGoals)
            {
                return 3;
            }
            else if (secondTeamGoals < firstTeamGoals)
            {
                return 0;
            }

            return 1;
        }

        private static int GetFirstTeamPoints(int firstTeamGoals, int secondTeamGoals)
        {
            if (firstTeamGoals > secondTeamGoals)
            {
                return 3;
            }
            else if (firstTeamGoals < secondTeamGoals)
            {
                return 0;
            }

            return 1;
        }

        private static int GetSecondTeamGoals(string line)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = line.Length - 1; i >= 0; i--)
            {
                if (line[i] == ':')
                {
                    break;
                }

                sb.Append(line[i]);
            }

            string numStr = Reverse(sb.ToString());
            return int.Parse(numStr);
        }

        private static int GetFirstTeamGoals(string line)
        {
            StringBuilder sb = new StringBuilder();
            bool toWrite = false;

            for (int i = line.Length - 1; i >= 0; i--)
            {
                if (toWrite)
                {
                    if (line[i] < 48 || line[i] > 57)
                    {
                        break;
                    }

                    sb.Append(line[i]);
                }
                if (line[i] == ':')
                {
                    toWrite = true;
                }

            }

            string numStr = Reverse(sb.ToString());
            return int.Parse(numStr);
        }

        private static string GetSecondTeam(string line, string key)
        {
            int start1 = line.IndexOf(key);
            int end1 = line.IndexOf(key, start1 + 1);

            int start = line.IndexOf(key, end1 + 1);
            int end = line.IndexOf(key, start + 1);

            string team = line.Substring(start + key.Length, end - start - key.Length);
            team = Reverse(team);
            return team;
        }

        private static string GetFirstTeam(string line, string key)
        {
            int start = line.IndexOf(key);
            int end = line.IndexOf(key, start + 1);

            string team = line.Substring(start + key.Length, end - start - key.Length);
            team = Reverse(team);
            return team;
        }
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        private static void UpdateSecondTeamGoals(Dictionary<string, int> teamGoals, string secondTeam, int secondTeamGoals)
        {
            if (teamGoals.ContainsKey(secondTeam))
            {
                int currentGoals = teamGoals[secondTeam];
                currentGoals += secondTeamGoals;
                teamGoals[secondTeam] = currentGoals;
            }
            else
            {
                teamGoals.Add(secondTeam, secondTeamGoals);
            }
        }

        private static void UpdateFirstTeamGoals(Dictionary<string, int> teamGoals, string firstTeam, int firstTeamGoals)
        {
            if (teamGoals.ContainsKey(firstTeam))
            {
                int currentGoals = teamGoals[firstTeam];
                currentGoals += firstTeamGoals;
                teamGoals[firstTeam] = currentGoals;
            }
            else
            {
                teamGoals.Add(firstTeam, firstTeamGoals);
            }
        }

        private static void UpdateSecondTeamPoints(Dictionary<string, int> teamPoints, string secondTeam, int secondTeamPoints)
        {
            if (teamPoints.ContainsKey(secondTeam))
            {
                int currentPoints = teamPoints[secondTeam];
                currentPoints += secondTeamPoints;
                teamPoints[secondTeam] = currentPoints;
            }
            else
            {
                teamPoints.Add(secondTeam, secondTeamPoints);
            }
        }

        private static void UpdateFirstTeamPoints(Dictionary<string, int> teamPoints, string firstTeam, int firstTeamPoints)
        {
            if (teamPoints.ContainsKey(firstTeam))
            {
                int currentPoints = teamPoints[firstTeam];
                currentPoints += firstTeamPoints;
                teamPoints[firstTeam] = currentPoints;
            }
            else
            {
                teamPoints.Add(firstTeam, firstTeamPoints);
            }
        }
    }
}

