using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

class Team
{
    public string teamName { get; set; }
    public string creatorName { get; set; }
    public List<string> members { get; set; }

    public Team()
    {

    }

    public Team(string teamName, string creatorName)
    {
        this.teamName = teamName;
        this.creatorName = creatorName;
        this.members = new List<string>();
    }
}
class Program
{
    static void Main()
    {
        List<Team> teams = new List<Team>();
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string inputTeam = Console.ReadLine();
            string[] splittedInputTeam = inputTeam.Split('-');

            string creator = splittedInputTeam[0];
            string team = splittedInputTeam[1];

            if (IsThereTeamWithThisName(teams, team))
            {
                Console.WriteLine($"Team {team} was already created!");
            }
            else if (ItThisCreatorAlreadyHasTeam(teams, creator))
            {
                Console.WriteLine($"{creator} cannot create another team!");
            }
            else
            {
                Team newTeam = new Team(team, creator);
                teams.Add(newTeam);
                Console.WriteLine($"Team {team} has been created by {creator}!");
            }
        }

        string inputJoin = Console.ReadLine();

        while (!inputJoin.Equals("end of assignment"))
        {
            string[] splittedInputJoin = inputJoin.Split(new char[] { '-', '>' }, StringSplitOptions.RemoveEmptyEntries);

            string memberName = splittedInputJoin[0];
            string joiningTeam = splittedInputJoin[1];

            if (!DoesThisTeamExists(teams, joiningTeam))
            {
                Console.WriteLine($"Team {joiningTeam} does not exist!");
            }
            else if (IsThisCreatorMemberInAnotherTeam(teams, memberName))
            {
                Console.WriteLine($"Member {memberName} cannot join team {joiningTeam}!");
            }
            else
            {
                Team temp = GetThisMemberTeam(teams, joiningTeam, memberName);
                temp.members.Add(memberName);
            }


            inputJoin = Console.ReadLine();
        }

        Print(teams);
    }

    private static void Print(List<Team> teams)
    {
        List<Team> disbanded = teams.FindAll(x => x.members.Count == 0).OrderBy(x => x.teamName).ToList();

        foreach (var currTeam in teams.OrderByDescending(x => x.members.Count).ThenBy(x => x.teamName))
        {
            if (currTeam.members.Count > 0)
            {
                Console.WriteLine(currTeam.teamName);
                Console.WriteLine($"- {currTeam.creatorName}");

                foreach (var currMember in currTeam.members.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {currMember}");
                }
            }
        }

        PrintDisbanded(disbanded);
    }

    private static void PrintDisbanded(List<Team> disbanded)
    {
        Console.WriteLine("Teams to disband:");
        foreach (var item in disbanded)
        {
            Console.WriteLine(item.teamName);
        }
    }

    private static Team GetThisMemberTeam(List<Team> teams, string teamToJoin, string joiningName)
    {
        Team temp = new Team();

        foreach (var currTeam in teams)
        {
            if (currTeam.teamName.Equals(teamToJoin) && !(currTeam.creatorName.Equals(joiningName)))
            {
                temp = currTeam;
            }
        }

        return temp;
    }

    private static bool IsThisCreatorMemberInAnotherTeam(List<Team> teams, string memberName)
    {
        foreach (var currTeam in teams)
        {
            if (currTeam.creatorName.Equals(memberName) || currTeam.members.Contains(memberName))
            {
                return true;
            }
        }

        return false;
    }

    private static bool DoesThisTeamExists(List<Team> teams, string joiningTeam)
    {
        foreach (var currTeam in teams)
        {
            if (currTeam.teamName.Equals(joiningTeam))
            {
                return true;
            }
        }

        return false;
    }

    private static bool ItThisCreatorAlreadyHasTeam(List<Team> teams, string creator)
    {
        foreach (var currTeam in teams)
        {
            if (currTeam.creatorName.Equals(creator))
            {
                return true;
            }
        }

        return false;
    }

    private static bool IsThereTeamWithThisName(List<Team> teams, string team)
    {
        foreach (var currTeam in teams)
        {
            if (currTeam.teamName.Equals(team))
            {
                return true;
            }
        }

        return false;
    }
}