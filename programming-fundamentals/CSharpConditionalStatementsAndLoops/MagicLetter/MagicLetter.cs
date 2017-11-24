using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicLetter
{
    class MagicLetter
    {
        static void Main(string[] args)
        {
            char a = char.Parse(Console.ReadLine());
            char b = char.Parse(Console.ReadLine());
            char c = char.Parse(Console.ReadLine());

            for (char i = a; i <= b; i++)
            {
                for (char x = a; x <= b; x++)
                {
                    for (char y = a; y <= b; y++)
                    {
                        string combination = $"{i}{x}{y}";

                        if (combination.Contains(c) != true)
                        {
                            Console.Write($"{combination} ");
                        }
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
