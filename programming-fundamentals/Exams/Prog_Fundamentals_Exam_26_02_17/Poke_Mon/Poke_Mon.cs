using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poke_Mon
{
    class Poke_Mon
    {
        static void Main(string[] args)
        {
            int pokePower = int.Parse(Console.ReadLine());
            int distanceBetweenTargets = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());
            double halfPower = pokePower / 2.0;

            int pokedCount = 0;

            while (true)
            {
                if (pokePower < distanceBetweenTargets)
                {
                    break;
                }

                pokePower -= distanceBetweenTargets;
                pokedCount++;

                if (pokePower == halfPower && exhaustionFactor != 0)
                {
                    if ((pokePower / exhaustionFactor) % 1 == 0)
                    {
                        pokePower /= exhaustionFactor;
                    }
                }

            }
            Console.WriteLine(pokePower);
            Console.WriteLine(pokedCount);

        }
    }
}
