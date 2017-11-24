using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Camera_View
{
    class Camera_View
    {
        static void Main(string[] args)
        {
            int [] input = Console.ReadLine().Split(' ').Select(x=>int.Parse(x)).ToArray();
            string text = Console.ReadLine();
            // pattern = $"\\|\\<(.{{{m}}})(.{{{n}}})"
            string pattern = @"(\|<\w{0," + input[0] + @"})(?<view>\w{0," + input[1] + "})";
            
            Regex regex = new Regex(pattern);
            List<string> result = new List<string>();

            foreach (Match match in regex.Matches(text))
            {
               result.Add(match.Groups[2].Value);
            }

            Console.WriteLine(string.Join(", ",result));
        }
    }
}
