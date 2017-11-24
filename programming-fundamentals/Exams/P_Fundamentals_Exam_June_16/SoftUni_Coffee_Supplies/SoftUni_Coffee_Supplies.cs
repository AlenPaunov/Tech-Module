using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Management.Instrumentation;

namespace SoftUni_Coffee_Supplies
{
    class SoftUni_Coffee_Supplies
    {

        static void Main(string[] args)
        {
            string[] delimiters = Console.ReadLine().Split();


            string delimiterOne = delimiters[0];
            string delimiterTwo = delimiters[1];

            string line = Console.ReadLine();

            List<Drinker> coffeeDrinkers = new List<Drinker>();
            List<Coffee> coffeeTypes = new List<Coffee>();

            while (line != "end of info")
            {
                if (Regex.IsMatch(line, $"(\\w+)(?:{Regex.Escape(delimiterOne)})(\\w+)"))
                {
                    string[] personAndCoffee = Regex.Split(line, Regex.Escape(delimiterOne));

                    Drinker drinker = new Drinker
                    {
                        Name = personAndCoffee[0],
                        Type = new Coffee { Name = personAndCoffee[1] }
                    };
                    if (!coffeeTypes.Any(x => x.Name == drinker.Type.Name))
                    {
                        coffeeTypes.Add(new Coffee { Name = personAndCoffee[1] });
                    }

                    coffeeDrinkers.Add(drinker);
                }
                else
                {
                    string[] coffeeAndQuantity = Regex.Split(line, Regex.Escape(delimiterTwo));

                    Coffee coffee = new Coffee
                    {
                        Name = coffeeAndQuantity[0],
                        Quantity = int.Parse(coffeeAndQuantity[1])
                    };

                    if (coffeeTypes.Any(x => x.Name == coffee.Name))
                    {
                        var indx = coffeeTypes.FindIndex(x => x.Name == coffee.Name);

                        coffeeTypes[indx].Quantity += coffee.Quantity;
                    }
                    else
                    {
                        coffeeTypes.Add(coffee);
                    }
                }

                line = Console.ReadLine();
            }

            line = Console.ReadLine();

            foreach (var c in coffeeTypes.Where(x => x.Quantity <= 0))
            {
                Console.WriteLine($"Out of {c.Name}");
            }

            while (line != "end of week")
            {
                string[] tokens = line.Split();
                string person = tokens[0];
                int drinks = int.Parse(tokens[1]);

                int indxP = coffeeDrinkers.FindIndex(x => x.Name == person);

                string coffeeName = coffeeDrinkers[indxP].Type.Name;

                int indxC = coffeeTypes.FindIndex(x => x.Name == coffeeName);


                coffeeTypes[indxC].Quantity -= drinks;
                if (coffeeTypes[indxC].Quantity <= 0)
                {
                    Console.WriteLine($"Out of {coffeeName}");
                }

                line = Console.ReadLine();
            }
            List<string> coffeeNames = new List<string>();

            Console.WriteLine("Coffee Left:");
            foreach (var c in coffeeTypes.Where(x => x.Quantity > 0).OrderByDescending(x => x.Quantity))
            {
                Console.WriteLine($"{c.Name} {c.Quantity}");
                coffeeNames.Add(c.Name);
            }

            var results = new List<Drinker>();

            foreach (var cName in coffeeNames)
            {
                foreach (var drinker in coffeeDrinkers)
                {
                    if (drinker.Type.Name == cName)
                    {
                        results.Add(drinker);
                    }
                }
            }

            Console.WriteLine("For:");

            foreach (var drinker in results.OrderBy(x => x.Type.Name).ThenByDescending(p => p.Name))
            {
                Console.WriteLine($"{drinker.Name} {drinker.Type.Name}");
            }
        }
    }

    class Drinker
    {
        public string Name { get; set; }
        public Coffee Type { get; set; }
    }

    class Coffee
    {
        public string Name { get; set; }
        public int Quantity { get; set; } = 0;
    }
}
