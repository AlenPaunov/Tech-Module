using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogs
{
    class UserLogs
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> userIPs =
                new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] tokens = input.Split();
                string ip = tokens[0].Split('=')[1];
                string user = tokens[2].Split('=')[1];

                if (!userIPs.ContainsKey(user))
                {
                    userIPs[user] = new Dictionary<string, int>();
                }

                if (!userIPs[user].ContainsKey(ip))
                {
                    userIPs[user][ip] = 0;
                }

                userIPs[user][ip]++;
                input = Console.ReadLine();
            }

            foreach (var item in userIPs.OrderBy(x => x.Key))
            {
                Console.WriteLine(item.Key + ":");
                Console.WriteLine(string.Join(", ", item.Value.Select(x => $"{x.Key} => {x.Value}")) + ".");
            }
        }
    }
}
