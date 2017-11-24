using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Roli_The_Coder
{
    class Roli_The_Coder
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"^(?<id>\d+)\s*?#(?<event>[a-zA-Z\d'-]+)\s*@?(?<participants>.*)?$");
            Dictionary<string, Event> events = new Dictionary<string, Event>();

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "Time for Code") break;

                Match match = regex.Match(line);
                if (match.Success)
                {
                    string id = match.Groups["id"].Value;
                    string name = match.Groups["event"].Value;
                    string participantsString = match.Groups["participants"].Value;
                    List<string> participants = new List<string>();

                    foreach (Match participant in Regex.Matches(participantsString, @"[a-zA-Z\d'-]+"))
                    {
                        participants.Add(participant.Value);
                    }

                    if (events.ContainsKey(id))
                    {
                        if (events[id].Name == name)
                        {
                            events[id].Participants.AddRange(participants);
                            events[id].Participants = events[id].Participants.Distinct().ToList();
                        }
                        
                    }
                    else
                    {
                        events.Add(id, new Event(id,name,participants.Distinct().ToList()));
                    }
                }
            }

            foreach (var aEvent in events.OrderByDescending(x=>x.Value.Participants.Count).ThenBy(x=>x.Value.Name))
            {
                Console.WriteLine($"{aEvent.Value.Name} - {aEvent.Value.Participants.Count}");
                foreach (var participant in aEvent.Value.Participants.OrderBy(x => x))
                {
                    Console.WriteLine($"@{participant}");
                }
            }

        }
    }
    class Event
    {
        public string Id;
        public string Name;
        public List<string> Participants;

        public Event()
        {

        }
        public Event(string id, string name, List<string> participants)
        {
            Id = id;
            Name = name;
            Participants = participants;
        }

    }
}
