using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Trainegram
{
    class Trainegram
    {
        static void Main(string[] args)
        {
            List<string> trains = new List<string>();

            string pattern = @"^(?<loco>\<\[[^a-zA-Z\d]*\]\.(?!\]\.))(?<wagon>\.\[([a-zA-Z\d])*\]\.)*$";
            Regex regex = new Regex(pattern);

            string line = Console.ReadLine();

            while (line != "Traincode!")
            {
                Match match = regex.Match(line);
                if (match.Success)
                {
                    trains.Add(line);
                }
                line = Console.ReadLine();
            }

            foreach (var train in trains)
            {
                Console.WriteLine(train);
            }

        }
    }
}
