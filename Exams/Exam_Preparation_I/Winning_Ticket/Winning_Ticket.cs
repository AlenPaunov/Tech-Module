using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Winning_Ticket
{
    class Winning_Ticket
    {
        static void Main(string[] args)
        {
            var ticketsToCheck = Console.ReadLine()
     .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
     .Select(t => t.Trim())
     .ToArray();

            var winningTicket = false;

            foreach (var ticket in ticketsToCheck)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }

                var leftPart = new string(ticket.Take(10).ToArray());
                var rightPart = new string(ticket.Skip(10).ToArray());

                winningTicket = false;

                var winningSymbols = new string[] { "#", "@", "\\^", "\\$" };

                foreach (var winningSymbol in winningSymbols)
                {
                    var win = new Regex($"{winningSymbol}{{6,}}");
                    var leftPartMatch = win.Match(leftPart);

                    if (leftPartMatch.Success)
                    {
                        var rigtParthMatch = win.Match(rightPart);

                        if (rigtParthMatch.Success)
                        {
                            winningTicket = true;

                            var leftWinLenght = leftPartMatch.Value.Length;
                            var rightWinLenght = rigtParthMatch.Value.Length;

                            var jackpot = string.Empty;
                            if (leftWinLenght == 10 && rightWinLenght == 10)
                            {
                                jackpot = "Jackpot!";
                            }

                            Console.WriteLine($"ticket \"{ticket}\" - {Math.Min(leftWinLenght, rightWinLenght)}{winningSymbol.Trim('\\')} {jackpot}");

                            break;
                        }
                    }
                }
                if (!winningTicket)
                {
                    Console.WriteLine($"ticket \"{ticket}\" - no match");
                }
            }
        }

        class Ticket
        {
            public string Text;
            private string[] TextArr;
            public string FirstPart;
            public string SecondPart;
            public bool IsValid = false;
            public bool Winning = false;
            public bool Jackpot = false;

            public Ticket(string text)
            {
                Text = text;
                FirstPart = string.Join("", text.Take(10));
                SecondPart = string.Join("", text.Skip(10));
                TextArr = new string[] { FirstPart, SecondPart };
                if (text.Length == 20)
                {
                    IsValid = true;
                }
                char[] winningChars = new char[] { '#', '@', '$', '^' };
                if (text.All(x => x == text[0] && winningChars.Contains(text[0])))
                {
                    Jackpot = true;
                }
            }

            public static Ticket Parse(string text)
            {
                Ticket ticket = new Ticket(text);
                return ticket;
            }
        }
    }
}