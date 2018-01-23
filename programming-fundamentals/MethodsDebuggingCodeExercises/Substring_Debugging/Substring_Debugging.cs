using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substring_Debugging
{
    class Substring_Debugging
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int jump = int.Parse(Console.ReadLine());

            const char charToSearch = 'p';
            bool hasMatch = false;

            for (int i = 0; i < text.Length; i++)
            {
                char letter = text[i];
                if (letter == charToSearch)
                {
                    hasMatch = true;

                    int lenght = jump+1;

                    if (lenght+i >= text.Length)
                    {
                        lenght = text.Length-i;
                    }

                    string matchedString = text.Substring(i, lenght);
                    Console.WriteLine(matchedString);
                    i += jump;
                }
            }

            if (!hasMatch)
            {
                Console.WriteLine("no");
            }
        }
    }
}
