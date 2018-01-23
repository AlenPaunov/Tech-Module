using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class TeamworkProjects
{
    static void Main()
    {
        int teamsCount = int.Parse(Console.ReadLine());
        List<Team> teams = new List<Team>();

        RegisterTeams(teams, teamsCount);
        RegisterMembers(teams);
        PrintReport(teams);
    }

    static void RegisterTeams(List<Team> teams, int teamsCount)
    {
        for (int i = 0; i < teamsCount; i++)
        {
            Team newTeam = new Team();

            var str = Console.ReadLine().Split('-');
            var creatorName = str[0];
            var teamName = str[1];

            newTeam.Name = teamName;
            newTeam.Cteator = creatorName;
            newTeam.Members = new List<string>();

            if (teams.Any(t => t.Name == teamName))
            {
                Console.WriteLine($"Team {teamName} was already created!");
                continue;
            }
            if (teams.Any(c => c.Cteator == creatorName))
            {
                Console.WriteLine($"{creatorName} cannot create another team!");
                continue;
            }

            Console.WriteLine($"Team {teamName} has been created by {creatorName}!");
            teams.Add(newTeam);
        }
    }


    static void RegisterMembers(List<Team> teams)
    {
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "end of assignment") break;
            string[] split = input.Split(new char[] { '-', '>' });
            string member = split[0];
            string teamToJoin = split[2];

            if (!teams.Any(t => t.Name == teamToJoin))
            {
                Console.WriteLine($"Team {teamToJoin} does not exist!");
                continue;
            }

            if (teams.Any(t => t.Cteator == member) || teams.Any(t => t.Members.Contains(member)))
            {
                Console.WriteLine($"Member {member} cannot join team {teamToJoin}!");
                continue;
            }

            if (teams.Any(t => t.Name == teamToJoin))
            {
                Team existingTeam = teams.First(t => t.Name == teamToJoin);

                existingTeam.Members.Add(member);
                continue;
            }

        }
    }

    static void PrintReport(List<Team> teams)
    {
        List<string> teamsDisband = teams.Where(t => t.Members.Count == 0).Select(x => x.Name).ToList();

        foreach (var team in teams.OrderByDescending(m => m.Members.Count).ThenBy(z => z.Name))
        {
            if (team.Members.Count == 0) continue;

            Console.WriteLine(team.Name);
            Console.WriteLine($"- {team.Cteator}");

            foreach (var member in team.Members.OrderBy(x => x))
            {
                Console.WriteLine($"-- {member}");
            }
        }
        Console.WriteLine("Teams to disband:");
        foreach (var team in teamsDisband.OrderBy(x => x))
        {

            Console.WriteLine(team);
        }
    }
}

public class Team
{
    public string Name { get; set; }
    public List<string> Members { get; set; }
    public string Cteator { get; set; }
}