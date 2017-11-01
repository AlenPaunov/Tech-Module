using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Extract_Sentences_By_Keyword
{
    class Extract_Sentences_By_Keyword
    {
        static void Main(string[] args)
        {
            string wordToContain = Console.ReadLine();
            string text = Console.ReadLine();
            string pattern = @"\b" + wordToContain + @"\b";
            
            foreach (string sentence in Regex.Split(text, @"[.?!]+"))
            {
                if (Regex.IsMatch(sentence.Trim(), pattern))
                {
                    Console.WriteLine(sentence.Trim());
                }
            }
        }
    }
}
