using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterStats
{
    class CharacterStats
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int healthCurrent = int.Parse(Console.ReadLine());
            int healthMax = int.Parse(Console.ReadLine());
            int energyCurrent = int.Parse(Console.ReadLine());
            int energyMax = int.Parse(Console.ReadLine());

            StringBuilder builderHealth = new StringBuilder();
            builderHealth.Append('|', healthCurrent);
            builderHealth.Append('.', healthMax - healthCurrent);

            StringBuilder builderEnergy = new StringBuilder();
            builderEnergy.Append('|', energyCurrent);
            builderEnergy.Append('.', energyMax - energyCurrent);


            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Health: |{builderHealth.ToString()}|");
            Console.WriteLine($"Energy: |{builderEnergy.ToString()}|");
        }
    }
}
