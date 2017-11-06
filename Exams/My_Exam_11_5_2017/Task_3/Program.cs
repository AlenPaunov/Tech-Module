using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<start>[a-zA-Z]+)(?<placeholder>.*)(\k<start>)";

            Regex regex = new Regex(pattern);

            string text = Console.ReadLine();
            List<string> keys = Console.ReadLine().Split(new char[] { '{', '}' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            
            var matches = regex.Matches(text);

            if (matches.Count > 0)
            {
                StringBuilder builder = new StringBuilder();
                foreach (Match match in matches)
                {
                   
                    if (keys.Count > 0)
                    {
                        text = ReplaceFirstOccurrence(text,match.Groups["placeholder"].Value, keys[0]);
                        keys.RemoveAt(0);
                    }

                }


            }

            Console.WriteLine(text);

        }
        public static string ReplaceFirstOccurrence(string Source, string Find, string Replace)
        {
            int Place = Source.IndexOf(Find);
            string result = Source.Remove(Place, Find.Length).Insert(Place, Replace);
            return result;
        }

    }
}

