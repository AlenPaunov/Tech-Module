using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trainers
{
    class Trainers
    {
        static void Main(string[] args)
        {
            //Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

            //foreach (var keyValuePair in dictionary)
            //{

            //    var ordered = keyValuePair.Value.OrderByDescending(
            //        (a) => { return int.Parse(a.Split(new string[] { " <-> " }, StringSplitOptions.RemoveEmptyEntries)[1]); }
            //    );
            //}

            int participantsCount = int.Parse(Console.ReadLine());

            Dictionary<string, decimal> teams = new Dictionary<string, decimal>
            {
                ["Technical"] = 0,
                ["Practical"] = 0,
                ["Theoretical"] = 0
            };


            for (int i = 0; i < participantsCount; i++)
            {
                const decimal _oneMile = 1600M;
                const decimal _oneTon = 1000M ;
                const decimal _perKilo = 1.5M;
                const decimal _consumption = 0.7M;
                const decimal _perLitter = 2.5M;

                decimal distanceMiles = decimal.Parse(Console.ReadLine());
                decimal cargoTons = decimal.Parse(Console.ReadLine());
                string teamName = Console.ReadLine();

                if (teams.ContainsKey(teamName))
                {
                    decimal distanceInKilometers = distanceMiles * _oneMile;
                    decimal cargoKilos = cargoTons * _oneTon;

                    decimal income = (cargoKilos * _perKilo);
                    decimal expense = ((_consumption * distanceInKilometers) * _perLitter);
                    decimal profit = income - expense;

                    teams[teamName] += profit;
                }
            }
            var winner = teams.OrderBy(x => x.Value).ThenBy(x => x.Key);

            Console.WriteLine($"The {winner.Last().Key} Trainers win with ${winner.Last().Value:f3}.");

        }
    }
}
