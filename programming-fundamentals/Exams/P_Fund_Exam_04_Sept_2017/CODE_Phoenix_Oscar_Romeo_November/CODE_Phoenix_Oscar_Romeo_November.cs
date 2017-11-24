using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODE_Phoenix_Oscar_Romeo_November
{
    class CODE_Phoenix_Oscar_Romeo_November
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> squad = new Dictionary<string, List<string>>();
            string line = Console.ReadLine();

            while (line != "Blaze it!")
            {
                string[] tokens = line.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                string creature = tokens[0].Trim();
                string mate = tokens[1].Trim();

                if (creature != mate)
                {

                    if (!squad.ContainsKey(creature))
                    {
                        squad.Add(creature, new List<string>() { mate});
                    }
                    else if (!squad[creature].Contains(mate))
                    {
                        squad[creature].Add(mate);
                    }
                }
                line = Console.ReadLine();
            }

            foreach (var creature in squad.Keys)
            {
                List<string> myMates = squad[creature];

                foreach (var mate in squad.Where(x => x.Key != creature))
                {
                    if (mate.Value.Contains(creature) && myMates.Contains(mate.Key))
                    {
                        squad[creature].Remove(mate.Key);
                        squad[mate.Key].Remove(creature);
                    }
                }
            }

            foreach (var mate in squad.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{mate.Key} : {mate.Value.Count}");
            }
        }
    }
}
