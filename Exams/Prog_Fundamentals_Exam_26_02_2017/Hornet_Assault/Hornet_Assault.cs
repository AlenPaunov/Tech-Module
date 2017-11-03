using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hornet_Assault
{
    class Hornet_Assault
    {
        static void Main(string[] args)
        {

            List<long> beehives = Console.ReadLine()
                .Split(' ')
                .Select(x => long.Parse(x))
                .ToList();

            List<long> hornets = Console.ReadLine()
                .Split(' ')
                .Select(x => long.Parse(x))
                .ToList();

            int beehiveIndex = 0;
            long hornetsPower = hornets.Sum();

            while (true)
            {
                if (beehiveIndex >= beehives.Count||hornets.Count==0||beehives.Count == 0)
                {
                    break;
                }
                long bees = beehives[beehiveIndex];

                if (bees >= hornetsPower)
                {
                    hornets.RemoveAt(0);
                    beehives[beehiveIndex] -= hornetsPower;
                    if (beehives[beehiveIndex] == 0)
                    {
                        beehives.RemoveAt(beehiveIndex);
                    }
                    else
                    {
                        beehiveIndex++;
                    }
                    hornetsPower = hornets.Sum();
                    
                }
                else
                {
                    beehives.RemoveAt(beehiveIndex);
                }

            }
            if (beehives.Sum() != 0)
            {
                Console.WriteLine(string.Join(" ", beehives));
            }
            else
            {
                Console.WriteLine(string.Join(" ", hornets));
            }
        }
    }
}
