using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmuneSystem
{
    class ImmuneSystem
    {
        static void Main(string[] args)
        {
            Organism organism = new Organism(int.Parse(Console.ReadLine()));

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end") break;

                Virus virus = new Virus(input);
                if (organism.ImmuneSystem.Any(x=> x.Name == virus.Name))
                {
                    virus.TimeToDefeat = TimeSpan.FromSeconds((int)(virus.TimeToDefeat.TotalSeconds/3));
                }
                Console.WriteLine($"Virus {virus.Name}: {virus.Strenght} => {virus.TimeToDefeat.TotalSeconds.ToString()} seconds");
                organism.Health -= (int)virus.TimeToDefeat.TotalSeconds;
                if (organism.Health<=0)
                {
                    Console.WriteLine($"Immune System Defeated.");
                    return;
                }
                Console.WriteLine($"{virus.Name} defeated in {virus.TimeToDefeat.Minutes}m {virus.TimeToDefeat.Seconds}s.");
                Console.WriteLine($"Remaining health: {organism.Health}");
                organism.ImmuneSystem.Add(virus);
                Organism.RegenHealth(organism);
            }
            Console.WriteLine($"Final Health: {organism.Health}");
        }
    }

    class Virus
    {
        public string Name;
        public int Strenght;
        public TimeSpan TimeToDefeat;

        public Virus(string name)
        {
            Name = name;
            Strenght = CalculateStrenght(name);
            TimeToDefeat = TimeSpan.FromSeconds(Strenght * Name.Length);
        }

        private int CalculateStrenght(string name)
        {
            int sum = 0;
            foreach (var character in name)
            {
                sum += (int)character;
            }
            return sum/3;
        }

    }

    class Organism
    {
        public int InnitialHealth;
        public int Health;
        public List<Virus> ImmuneSystem;

        public Organism(int health)
        {
            InnitialHealth = health;
            Health = health;
            ImmuneSystem = new List<Virus>();
        }

        public static void RegenHealth(Organism organism)
        {
            organism.Health += (int)(organism.Health * 0.20);
            if (organism.Health>organism.InnitialHealth)
            {
                organism.Health = organism.InnitialHealth;
            }
        }
    }
}
