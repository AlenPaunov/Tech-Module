using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Rage_Quit
{
    class Rage_Quit
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<symbol>[\D]+)(?<number>[\d]*)";
            Regex regex = new Regex(pattern);
            string input = Console.ReadLine();

            List<int> uniqueSymbols = new List<int>();
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Match match in regex.Matches(input))
            {
                string symbol = match.Groups["symbol"].Value.ToUpper();
                int count = int.Parse(match.Groups["number"].Value);

                foreach (var character in symbol)
                {
                    if (!uniqueSymbols.Contains(character)&&count>0)
                    {
                        uniqueSymbols.Add(character);
                    }
                }

                for (int i = 0; i < count; i++)
                {
                    stringBuilder.Append(symbol);
                }
            }
            int counter = uniqueSymbols.Count;
            //if (uniqueSymbols.Contains(32))
            //{
            //  counter -= 1;
            //}
            Console.WriteLine($"Unique symbols used: {counter}");
            Console.WriteLine(stringBuilder);
        }
    }
}
