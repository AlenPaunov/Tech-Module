using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOfCards
{
    class HandsOfCards
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>> personHands = new Dictionary<string, HashSet<string>>();
            var input = Console.ReadLine();


            while (input != "JOKER")
            {
                var arr = input.Split(':');
                var player = arr[0].Trim();
                var cards = arr[1].Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (!personHands.ContainsKey(player))
                {
                    personHands.Add(player, new HashSet<string>());
                }

                foreach (var card in cards)
                {
                    personHands[player].Add(card);
                }
                input = Console.ReadLine();
            }

            foreach (var nameAndList in personHands)
            {
                string nameOfPerson = nameAndList.Key;
                double resultTotal = 0;
                double resultPersonOne = 0;
                double resultPersonTwo = 0;

                foreach (var hands in nameAndList.Value)
                {
                    string newHands = hands.Remove(hands.Length - 1, 1);

                    switch (newHands)
                    {
                        case "2": resultPersonOne = 2; break;
                        case "3": resultPersonOne = 3; break;
                        case "4": resultPersonOne = 4; break;
                        case "5": resultPersonOne = 5; break;
                        case "6": resultPersonOne = 6; break;
                        case "7": resultPersonOne = 7; break;
                        case "8": resultPersonOne = 8; break;
                        case "9": resultPersonOne = 9; break;
                        case "10": resultPersonOne = 10; break;
                        case "J": resultPersonOne = 11; break;
                        case "Q": resultPersonOne = 12; break;
                        case "K": resultPersonOne = 13; break;
                        case "A": resultPersonOne = 14; break;
                    }

                    char lastLetter = hands[hands.Length - 1];

                    switch (lastLetter)
                    {
                        case 'C': resultPersonTwo = 1; break;
                        case 'D': resultPersonTwo = 2; break;
                        case 'H': resultPersonTwo = 3; break;
                        case 'S': resultPersonTwo = 4; break;
                    }

                    resultTotal += resultPersonOne * resultPersonTwo;
                }
                Console.WriteLine($"{nameOfPerson}: {resultTotal}");
            }
        }
    }
}
