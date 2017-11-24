using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Football_League
{
    class Football_League
    {
        static void Main(string[] args)
        {
            string key = Regex.Escape(string.Join("", Console.ReadLine()));
            //key = ReplaceSymbols(key);
            string resultPattern = @"\d+\:\d+";
            string teamPattern = $@"^.*(?:{key})(?<team1>[A-Za-z]*)(?:{key}).*(?:{key})(?<team2>[A-Za-z]*)(?:{key})";

            Regex teamsRegex = new Regex(teamPattern);
            Regex resultRegex = new Regex(resultPattern);

            List<string> lines = new List<string>();
            string line = Console.ReadLine();

            while (line != "final")
            {
                lines.Add(line);
                line = Console.ReadLine();
            }

            Dictionary<string, Team> league = new Dictionary<string, Team>();

            foreach (var l in lines)
            {
                Match match = teamsRegex.Match(l);

                int[] score = Regex.Match(l, resultPattern)
                    .Value
                    .Split(':')
                    .Select(x => int.Parse(x))
                    .ToArray();

                Team teamA = new Team()
                {
                    Name = new string(match.Groups["team1"].Value.ToCharArray().Reverse().ToArray()).ToUpper(),
                    Goals = score[0]
                };

                Team teamB = new Team()
                {
                    Name = new string(match.Groups["team2"].Value.ToCharArray().Reverse().ToArray()).ToUpper(),
                    Goals = score[1]
                };

                if (teamA.Goals == teamB.Goals)
                {
                    teamA.Points = 1;
                    teamB.Points = 1;
                }
                else
                {
                    if (teamA.Goals > teamB.Goals)
                    {
                        teamA.Points = 3;
                        teamB.Points = 0;
                    }
                    else
                    {
                        teamB.Points = 3;
                        teamA.Points = 0;
                    }
                }
                List<Team> currentTeams = new List<Team> { teamA, teamB };
                
                foreach (var t in currentTeams)
                {
                    if (!league.ContainsKey(t.Name))
                    {
                        league.Add(t.Name, new Team() { Name = t.Name, Goals = 0, Points = 0 });
                    }
                    league[t.Name].Points += t.Points;
                    league[t.Name].Goals += t.Goals;
                }

            }

            Console.WriteLine("League standings:");
            int index = 1;
            var sorted = league.Values.OrderByDescending(x => x.Points).ThenBy(x => x.Name);
            foreach (var t in sorted)
            {
                Console.WriteLine($"{index}. {t.Name} {t.Points}");
                index++;
            }

            Console.WriteLine("Top 3 scored goals:");
            var goalSorted = league.Values.OrderByDescending(x => x.Goals).ThenBy(x => x.Name);

            index = 0;

            foreach (var t in goalSorted)
            {
                if (index >= goalSorted.Count() || index > 2) break;
                Console.WriteLine($"- {t.Name} -> {t.Goals}");
                index++;
            }
        }
        public static string ReplaceSymbols(string input)
        {
            string result = Regex.Replace(input, @"[-[\]{ } () * +?.,\\^$|#\s]", "\\$&");
            return result;
        }
    }
    class Team
    {
        public string Name;
        public int Goals;
        public int Points;
    }
}
