using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Regexmon
{
    class Regexmon
    {
        static void Main(string[] args)
        {
            string bojomonPattern = @"[A-Za-z]+-[A-Za-z]+";
            string didimonPattern = @"[^A-Za-z\-]+";

            string text = Console.ReadLine();   

            Regex regexBojo = new Regex(bojomonPattern);
            Regex regexDidi = new Regex(didimonPattern);

            while (true)
            {
                if (regexDidi.Match(text).Success)
                {
                    Match match = regexDidi.Match(text);
                    string found = match.Value;
                    Console.WriteLine(found);

                    text = text.Remove(0, match.Index + match.Length);
                }
                else
                {
                    break;
                }

                if (regexBojo.Match(text).Success)
                {
                    Match match = regexBojo.Match(text);
                    string found = match.Value;
                    Console.WriteLine(found);

                    text = text.Remove(0, match.Index + match.Length);
                }
                else
                {
                    break;
                }

            }
        }
    }
}
