using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.Football_League
{
    class Program
    {
        static List<Team> table = new List<Team>();

        static void Main(string[] args)
        {
            string key = Console.ReadLine();
            string line = Console.ReadLine();

            while (!line.Equals("final"))
            {
                string team1 = GetFirstTeam(line, key, true);
                string team2 = GetFirstTeam(line, key, false);
                int[] score = GetTheResult(line);

                if (score[0] != score[1])
                {
                    if (score[0] > score[1])
                    {
                        Team winTeam = new Team(team1, score[0], 3);
                        Team LoseTeam = new Team(team2, score[1], 0);

                        WriteInTable(winTeam);
                        WriteInTable(LoseTeam);
                    }
                    else
                    {
                        Team winTeam = new Team(team2, score[1], 3);
                        Team LoseTeam = new Team(team1, score[0], 0);

                        WriteInTable(winTeam);
                        WriteInTable(LoseTeam);
                    }
                }
                else
                {
                    Team currTeam1 = new Team(team1, score[0], 1);
                    Team currTeam2 = new Team(team2, score[1], 1);

                    EqualResult(currTeam1, currTeam2);
                }

                line = Console.ReadLine();
            }

            Print();

        }

        private static void Print()
        {
            table = table.OrderByDescending(x => x.points).ThenBy(y => y.name).ToList();
            int place = 1;

            Console.WriteLine("League standings:");
            foreach (var team in table)
            {
                Console.WriteLine($"{place}. {team.name} {team.points}");
                place++;
            }

            Console.WriteLine("Top 3 scored goals:");
            table = table.OrderByDescending(x => x.goals).ThenBy(y => y.name).ToList();

            int brakeCount = 0;
            foreach (var team in table)
            {
                Console.WriteLine($"- {team.name} -> {team.goals}");
                brakeCount++;
                if (brakeCount == 3)
                {
                    break;
                }
            }
        }

        private static void EqualResult(Team currTeam1, Team currTeam2)
        {
            FilPointsInTeam(currTeam1);
            FilPointsInTeam(currTeam2);
        }

        private static void FilPointsInTeam(Team currTeam1)
        {
            bool a = false;
            int index = 0;

            for (int i = 0; i < table.Count; i++)
            {
                if (table[i].name.Equals(currTeam1.name))
                {
                    a = true;
                    index = i;
                    break;
                }
            }

            if (!a)
            {
                table.Add(currTeam1);
            }
            else
            {
                Team old = table[index];
                old.goals += currTeam1.goals;
                old.points += currTeam1.points;
                table[index] = old;
            }
        }

        private static void WriteInTable(Team currTeam)
        {
            bool a = false;
            int index = 0;

            for (int i = 0; i < table.Count; i++)
            {
                if (table[i].name.Equals(currTeam.name))
                {
                    a = true;
                    index = i;
                    break;
                }
            }

            if (!a)
            {
                table.Add(currTeam);
            }
            else
            {
                Team old = table[index];
                old.goals += currTeam.goals;
                old.points += currTeam.points;
                table[index] = old;
            }
        }

        private static int[] GetTheResult(string line)
        {
            string pattern = @"\d*:\d*";
            Match mc = Regex.Match(line, pattern, RegexOptions.RightToLeft);
            int[] arr = new int[2];

            string q = mc.ToString();
            string[] qq = q.Split(':');

            arr[0] = int.Parse(qq[0]);
            arr[1] = int.Parse(qq[1]);

            return arr;
        }

        private static string GetFirstTeam(string line, string key, bool isFirstTeam)
        {
            int st_t1 = line.IndexOf(key);
            int en_t1 = line.IndexOf(key, st_t1 + 1);

            int st_t2 = line.IndexOf(key, en_t1 + 1);
            int en_t2 = line.IndexOf(key, st_t2 + 1);

            /* Console.WriteLine(st_t1);
             Console.WriteLine(en_t1);
             Console.WriteLine(st_t2);
             Console.WriteLine(en_t2);*/

            string t1 = line.Substring(st_t1 + key.Length, en_t1 - st_t1 - key.Length);
            t1 = Reverse(t1);

            string t2 = line.Substring(st_t2 + key.Length, en_t2 - st_t2 - key.Length);
            t2 = Reverse(t2);

            t1 = t1.ToUpper();
            t2 = t2.ToUpper();

            /* Console.WriteLine(t1);
             Console.WriteLine(t2);*/

            if (isFirstTeam)
            {
                return t1;
            }

            return t2;
        }
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }

}
class Team
{
    public string name;
    public int goals;
    public int points;

    public Team(string name, int goals, int points)
    {
        this.name = name;
        this.goals = goals;
        this.points = points;
    }
}

