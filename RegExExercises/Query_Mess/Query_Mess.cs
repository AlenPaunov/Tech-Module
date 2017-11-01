using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Query_Mess
{
    class Query_Mess
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<key>[^&=?]*)=(?<value>[^&=]*)";
            string splitValuePattern = @"((%20|\+)+)";

            Regex regex = new Regex(pattern);

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "END") break;

                Dictionary<string, List<string>> entries = new Dictionary<string, List<string>>();

                foreach (Match match in regex.Matches(line))
                {
                    string key = match.Groups["key"].Value;
                    key = Regex.Replace(key, splitValuePattern, word => " ").Trim();

                    string value = match.Groups["value"].Value;
                    value = Regex.Replace(value, splitValuePattern, word => " ").Trim();

                    if (entries.ContainsKey(key))
                    {
                        entries[key].Add(value);
                    }
                    else
                    {
                        entries.Add(key, new List<string> { value });
                    }
                }
                foreach (var pair in entries)
                {
                    Console.Write($"{pair.Key}=[{string.Join(", ", pair.Value)}]");
                }
                Console.WriteLine();

            }
        }
    }
}
