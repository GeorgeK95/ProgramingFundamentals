using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.TeamworkProjects
{
    class Team
    {
        public string creator;
        public List<string> members = new List<string>();
        public string teamName;

        public Team(string creator, string teamName)
        {
            this.creator = creator;
            this.teamName = teamName;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = FillTeams();
            teams = JoinTeam(teams);
            PrintTeams(teams);

        }

        private static void PrintTeams(List<Team> teams)
        {
            teams = teams.OrderByDescending(x => x.members.Count()).ThenBy(x => x.teamName).ToList();
            List<Team> disband = new List<Team>();

            List<Team> disbanded = new List<Team>();
            foreach (var currTeam in teams)
            {
                if (currTeam.members.Count > 0)
                {
                    Console.WriteLine(currTeam.teamName);
                    Console.WriteLine("- " + currTeam.creator);

                    foreach (var member in currTeam.members.OrderBy(p => p))
                    {
                        Console.WriteLine($"-- {member}");
                    }
                }
                else
                {
                    disband.Add(currTeam);
                }
            }

            PrintDisbanded(disband);
        }

        private static void PrintDisbanded(List<Team> disbanded)
        {
            disbanded = disbanded.OrderBy(x => x.teamName).ToList();

            Console.WriteLine("Teams to disband:");
            foreach (var item in disbanded)
            {
                Console.WriteLine(item.teamName);
            }
        }

        private static List<Team> JoinTeam(List<Team> teams)
        {
            char[] sep = new char[] { '-', '>' };
            string line = Console.ReadLine();

            while (!line.Equals("end of assignment"))
            {
                string[] arr = line.Split(sep, StringSplitOptions.RemoveEmptyEntries);

                string joiningName = arr[0];
                string joininngTeam = arr[1];

                bool isThisTeamExist = IsThisTeamExist(teams, joininngTeam);

                if (!isThisTeamExist)
                {
                    Console.WriteLine("Team {0} does not exist!", joininngTeam);
                }
                else
                {
                    bool isThisPersonExistInOtherTeam = IsThisPersonExistInOtherTeam(teams, joiningName);

                    if (isThisPersonExistInOtherTeam)
                    {
                        Console.WriteLine("Member {0} cannot join team {1}!", joiningName, joininngTeam);
                    }
                    else
                    {
                        teams = JoinTeam(teams, joiningName, joininngTeam);
                    }
                }

                line = Console.ReadLine();
            }

            return teams;

        }

        private static List<Team> JoinTeam(List<Team> teams, string joiningName, string joiningTeam)
        {
            foreach (var currTeam in teams)
            {
                if (currTeam.teamName.Equals(joiningTeam) && !(currTeam.creator.Equals(joiningName))) //o6te 1 chek dali nqma takova ime v teama???
                {
                    currTeam.members.Add(joiningName);
                }
            }

            return teams;
        }

        private static bool IsThisPersonExistInOtherTeam(List<Team> teams, string joiningName)
        {
            bool check = false;

            foreach (var team in teams)
            {
                if (team.members.Contains(joiningName) || team.creator.Equals(joiningName))
                {
                    check = true;
                }
            }

            return check;
        }

        private static bool IsThisTeamExist(List<Team> teams, string joiningTeam)
        {
            bool check = false;

            foreach (var team in teams)
            {
                if (team.teamName.Equals(joiningTeam))
                {
                    check = true;
                }
            }

            return check;
        }

        private static List<Team> FillTeams()
        {
            List<Team> teamsList = new List<Team>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                string creatorName = line.Split('-')[0];
                string teamName = line.Split('-')[1];

                bool isThisTeamExist = IsThisTeamExist(teamName, teamsList);

                if (isThisTeamExist)
                {
                    Console.WriteLine("Team {0} was already created!", teamName);
                }
                else
                {
                    bool hasCreatorAlreadyTeam = HasCreatorAlreadyTeam(creatorName, teamsList);

                    if (hasCreatorAlreadyTeam)
                    {
                        Console.WriteLine("{0} cannot create another team!", creatorName);
                    }
                    else
                    {
                        Team currTeam = new Team(creatorName, teamName);
                        teamsList.Add(currTeam);
                        Console.WriteLine("Team {0} has been created by {1}!", teamName, creatorName);
                    }
                }
            }

            return teamsList;
        }

        private static bool HasCreatorAlreadyTeam(string creatorName, List<Team> teamsList)
        {
            bool check = false;

            foreach (var team in teamsList)
            {
                if (team.creator.Equals(creatorName))
                {
                    check = true;
                }
            }

            return check;
        }

        private static bool IsThisTeamExist(string teamName, List<Team> teamsList)
        {
            bool check = false;

            foreach (var team in teamsList)
            {
                if (team.teamName.Equals(teamName))
                {
                    check = true;
                }
            }

            return check;
        }

    }
}
