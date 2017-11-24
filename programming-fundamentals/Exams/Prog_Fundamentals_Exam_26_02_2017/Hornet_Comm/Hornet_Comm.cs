using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace Hornet_Comm
{
    class Hornet_Comm
    {
        static void Main(string[] args)
        {
            Regex messageRegex = new Regex(@"^([\d]+) <-> ([a-zA-Z0-9]+)$");
            Regex broadcastRegex = new Regex(@"^([^\d]+) <-> ([a-zA-Z0-9]+)$");

            string line = Console.ReadLine();

            List<string> messages = new List<string>();
            List<string> broadcasts = new List<string>();

            while (line != "Hornet is Green")
            {
                Match matchMessage = messageRegex.Match(line);
                Match matchBroadcast = broadcastRegex.Match(line);

                if (matchMessage.Success)
                {
                    string[] messageTokens = line
                        .Split(new string[] { "<->" }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.Trim())
                        .ToArray();

                    char [] recipientLetters = messageTokens[0].ToCharArray();
                    Array.Reverse(recipientLetters);

                    var recipient = new string(recipientLetters);
                    var message = messageTokens[1];

                    string resultMessage = recipient + " -> " + message;
                    messages.Add(resultMessage);

                }
                else if (matchBroadcast.Success)
                {
                    string [] broadcastTokens = line.Split(new string[] { " <-> " }, StringSplitOptions.RemoveEmptyEntries);

                    var message = broadcastTokens[0];
                    var frequency = broadcastTokens[1];

                    StringBuilder builder = new StringBuilder();

                    for (int i = 0; i < frequency.Length; i++)
                    {
                        char a = frequency[i];
                        if (char.IsLower(a))
                        {
                            a = Char.ToUpper(a);

                        }
                        else if (char.IsUpper(a))
                        {
                            a = Char.ToLower(a);

                        }

                        builder.Append(a);
                    }
                    string resultMessage = builder + " -> " + message;
                    broadcasts.Add(resultMessage);
                }

                line = Console.ReadLine();
            }

            Console.WriteLine("Broadcasts:");
            if (broadcasts.Count == 0)
            {
                Console.WriteLine("None");
            }
            else
            {
                foreach (var broadcast in broadcasts)
                {
                    Console.WriteLine(broadcast);
                }
            }

            Console.WriteLine("Messages:");

            if (messages.Count == 0)
            {
                Console.WriteLine("None");
            }
            else
            {
                foreach (var message in messages)
                {
                    Console.WriteLine(message);
                }
            }
        }
    }
}