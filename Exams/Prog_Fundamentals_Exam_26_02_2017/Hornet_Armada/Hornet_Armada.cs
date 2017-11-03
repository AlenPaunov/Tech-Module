using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hornet_Armada
{
    class Hornet_Armada
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"(?<index>[\d]+) = (?<legion>[^=->:\s]+) -> (?<type>[^=->:\s]+):(?<count>\d+)");

            int legionsCount = int.Parse(Console.ReadLine());

            List<Legion> legions = new List<Legion>();

            for (int i = 0; i < legionsCount; i++)
            {
                Match match = regex.Match(Console.ReadLine());
                if (match.Success)
                {
                    string name = match.Groups["legion"].Value;
                    int lastActivity = int.Parse(match.Groups["index"].Value);
                    string type = match.Groups["type"].Value;
                    long count = long.Parse(match.Groups["count"].Value);

                    Legion legion = new Legion(name, lastActivity, new Dictionary<string, long>(){ { type, count } });
                    if (legions.Any(x => x.Name == legion.Name))
                    {
                        Legion existingLegion = legions.Find(l => l.Name == legion.Name);
                        if (existingLegion.LastActivity<lastActivity)
                        {
                            existingLegion.LastActivity = lastActivity;
                        }
                        
                        if (!existingLegion.Units.ContainsKey(type))
                        {
                            existingLegion.Units.Add(type, 0);
                        }
                        existingLegion.Units[type] += count;
                    }
                    else
                    {
                        legions.Add(legion);
                    }
                }
            }

            string[] commandTokens = Console.ReadLine().Split('\\');

            if (commandTokens.Length == 1)
            {
                string type = commandTokens[0];

                foreach (var legion in legions.Where(l=>l.Units.ContainsKey(type)).OrderByDescending(x=>x.LastActivity))
                {
                    Console.WriteLine($"{legion.LastActivity} : {legion.Name}");
                }
            }
            else
            {
                int activity = int.Parse(commandTokens[0]);
                string type = commandTokens[1];

                foreach (var legion in legions.Where(l=>l.Units.ContainsKey(type)&&l.LastActivity<activity).OrderByDescending(l=>l.Units[type]))
                {
                    Console.WriteLine($"{legion.Name} -> {legion.Units[type]}");
                }
            }
        }
    }
    class Legion
    {
        public string Name;
        public int LastActivity;
        public Dictionary<string, long> Units;

        public Legion(string name, int lastActivity, Dictionary<string, long> units)
        {
            Name = name;
            LastActivity = lastActivity;
            Units = units;
        }
    }
}
