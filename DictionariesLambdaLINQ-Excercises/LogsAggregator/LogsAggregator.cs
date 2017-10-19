using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogsAggregator
{
    class LogsAggregator
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, SortedDictionary<string, int>> input =
                new SortedDictionary<string, SortedDictionary<string, int>>();

            int logsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < logsCount; i++)
            {
                string[] logsInfo = Console.ReadLine().Split();
                string ip = logsInfo[0];
                string user = logsInfo[1];
                int duration = int.Parse(logsInfo[2]);

                if (!input.ContainsKey(user))
                {
                    input.Add(user, new SortedDictionary<string, int>());
                }
                if (!input[user].ContainsKey(ip))
                {
                    input[user][ip] = 0;
                }

                input[user][ip] += duration;
            }

            foreach (var pair in input)
            {
                var sum = pair.Value.Values.Sum();

                Console.Write("{0}: {1} ", pair.Key, sum);
                Console.Write("[");
                Console.Write(string.Join(", ", pair.Value.Keys));
                Console.WriteLine("]");
            }
        }
    }
}
