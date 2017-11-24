using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicode_Characters
{
    class Unicode_Characters
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();

            StringBuilder builder = new StringBuilder();

            foreach (var c in input)
            {
                builder.Append(GetEscapeSequence(c));
            }
            Console.WriteLine(builder);
        }

        static string GetEscapeSequence(char c)
        {
            return "\\u" + ((int)c).ToString("X4").ToLower();
        }
    }
}
