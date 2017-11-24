using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Anonymous_Vox
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
            foreach (Match match in matches)
            {
                if (keys.Count > 0)
                {
                    text = ReplaceFirstOccurrence(text, match.Groups["placeholder"].Value, keys[0]);
                    keys.RemoveAt(0);
                }
            }
        }
        Console.WriteLine(text);
    }
    public static string ReplaceFirstOccurrence(string target, string find, string replacement)
    {
        int Place = target.IndexOf(find);
        string result = target.Remove(Place, find.Length).Insert(Place, replacement);
        return result;
    }
}


