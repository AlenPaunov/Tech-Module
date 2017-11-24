using System;
using System.Text.RegularExpressions;


namespace Extract_Emails
{
    class Extract_Emails
    {
        static void Main(string[] args)
        {
            //[A-Z][a-z]*; [0-9]+ => \d+; \s+ "matches whitespace (non-empty)"; \S+ "matches non-whitespace"
            string text = Console.ReadLine();
            string pattern = @"\b(?<!\S)[a-z][a-z0-9\.\-_]+[a-z0-9]*@[a-z][a-z\-]+\.[a-z][a-z\.]+[a-z]?\b";

            foreach (Match match in Regex.Matches(text,pattern))
            {
                Console.WriteLine(match);
            } 
            
        }
    }
}
