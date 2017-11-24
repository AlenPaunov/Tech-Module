using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Cubic_Messages
{
    class Cubic_Messages
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();

            List<string> results = new List<string>();
            while (line != "Over!")
            {
                int n = int.Parse(Console.ReadLine());
                string pattern = @"^(?<fd>[\d]+)(?<ms>[a-zA-Z]{" + n + "})(?<bd>[^a-zA-Z]*)$";
                Regex regex = new Regex(pattern);

                Match match = regex.Match(line);
                if (match.Success)
                {
                    string message = match.Groups["ms"].Value;
                    string front = match.Groups["fd"].Value;
                    string back = match.Groups["bd"].Value;

                    List<int> indices = new List<int>();
                    foreach (var d in front)
                    {
                        indices.Add(int.Parse(d.ToString()));
                    }
                    foreach (var d in back)
                    {
                        if (char.IsDigit(d))
                        {
                            indices.Add(int.Parse(d.ToString()));
                        }
                    }
                    StringBuilder builder = new StringBuilder();

                    foreach (var index in indices)
                    {
                        if (index >= 0 && index < message.Length)
                        {
                            builder.Append(message[index]);
                        }
                        else
                        {
                            builder.Append(" ");
                        }
                    }
                    results.Add($"{message} == {builder}");
                }
                line = Console.ReadLine();
            }
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }
    }
}

