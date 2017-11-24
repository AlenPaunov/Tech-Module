using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Task_1
{
    class Anonymous_Downsite
    {
        static void Main(string[] args)
        {
            int websitesCount = int.Parse(Console.ReadLine());
            int key = int.Parse(Console.ReadLine());

            List<string> websites = new List<string>();

            decimal totalLoss = 0.0M;

            for (int i = 0; i < websitesCount; i++)
            {
                string line = Console.ReadLine();

                string[] tokens = line.Split(' ');

                if (tokens.Count() == 3)
                {
                    string name = tokens[0];
                    long visits = long.Parse(tokens[1]);
                    decimal pricePerVisit = decimal.Parse(tokens[2]);

                    decimal siteLoss = visits * pricePerVisit;

                    totalLoss += siteLoss;
                    websites.Add(name);
                }
            }
            BigInteger token = 0;
            if (key > 0 && websites.Count > 0)
            {
                token = BigInteger.Pow(key, websites.Count());
                foreach (var site in websites)
                {
                    Console.WriteLine(site);
                }

                Console.WriteLine($"Total Loss: {totalLoss:f20}");
                Console.WriteLine($"Security Token: {token}");
            }

        }
    }
}
