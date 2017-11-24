using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordInPlural
{
    class WordInPlural
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            char lastChar = word.Last();
            string [] esList = new string[] { "o", "s", "x", "z" }; 

            if (lastChar == 'y')
            {
                word = word.Remove(word.Length - 1);
                word += "ies";
            }
            else if (word.EndsWith("ch")||word.EndsWith("sh"))
            {
                word += "es";
            }
            else if (esList.Contains(lastChar.ToString()))
            {
                word += "es";
            }
            else
            {
                word += "s";
            }
            Console.WriteLine(word);
        }
    }
}
