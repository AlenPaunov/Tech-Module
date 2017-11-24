using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    class Phonebook
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> phonebook = new Dictionary<string, string>();

            string[] commands = Console.ReadLine()
                .Split(' ');

            while (commands[0] != "END")
            {
                switch (commands[0])
                {
                    case "A":
                        if (phonebook.ContainsKey(commands[1]))
                        {
                            phonebook[commands[1]] = commands[2];
                        }
                        else
                        {
                            phonebook.Add(commands[1], commands[2]);
                        }
                        break;

                    case "S":
                        if (phonebook.ContainsKey(commands[1]))
                        {
                            Console.WriteLine($"{commands[1]} -> {phonebook[commands[1]]}");
                        }
                        else
                        {
                            Console.WriteLine($"Contact {commands[1]} does not exist.");
                        }
                        break;
                }
                commands = Console.ReadLine()
                .Split(' ');
            }
        }
    }
}
