using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Use_Your_Chains_Buddy
{
    class Use_Your_Chains_Buddy 
    {
        static void Main(string[] args)
        {
            string textPattern = @"<p>(?<text>.+?)<\/p>";
            string specialCharsPattern = @"[^a-z\d]";
            string whiteSpacePattern = @"\s+|\n+";

            // + 13 to convert 

            string input = Console.ReadLine();

            Regex regex = new Regex(textPattern);
            string output = string.Empty;


            foreach (Match match in regex.Matches(input))
            {
                output += match.Groups["text"].Value.ToString();
            }

                output = Regex.Replace(output, specialCharsPattern, " ");
                output = Regex.Replace(output, whiteSpacePattern, " ");

            StringBuilder builder = new StringBuilder(output.Length);

            foreach (var ch in output)
            {
                if (ch >= 'a' && ch <= 'm')
                {
                    builder.Append((char)(ch + 13));
                }
                else if (ch >= 'n' && ch <= 'z')
                {
                    builder.Append((char)(ch - 13));
                }
                else
                {
                    builder.Append(ch);
                }
            }
            
            Console.WriteLine(builder);

        }
    }
}
