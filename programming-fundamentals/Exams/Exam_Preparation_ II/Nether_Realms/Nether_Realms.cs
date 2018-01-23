using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Nether_Realms
{
    class Nether_Realms
    {
        static void Main(string[] args)
        {
            List<Demon> demons = Regex.Split(Console.ReadLine(), @"[,\s]+").Select(x=>Demon.Parse(x)).ToList();
            
            foreach (var demon in demons.OrderBy(d=>d.Name))
            {
                Console.WriteLine($"{demon.Name} - {demon.Health} health, {demon.Damage:f2} damage");
            }
        }
    }
    class Demon
    {
        public string Name;
        public int Health;
        public double Damage;

        public Demon(string name)
        {
            Name = name;
            int health = 0;
            double damage = 0.0;
            foreach (Match letter in Regex.Matches(name, @"[^\d-+*\/.]"))
            {
                health += char.Parse(letter.Value);
            }
            Health = health;
            foreach (Match digit in Regex.Matches(name, @"[\+\-]?\d+\.?\d*"))
            {
                damage += double.Parse(digit.Value);
            }
            foreach (Match asterisk in Regex.Matches(name,"[*]"))
            {
                damage *= 2;
            }
            foreach (Match divider in Regex.Matches(name, @"[\/]"))
            {
                damage /= 2;
            }

            Damage = damage;
        }

        public static Demon Parse(string input)
        {
            Demon demon = new Demon(input);

            return demon;
        }
    }
}
