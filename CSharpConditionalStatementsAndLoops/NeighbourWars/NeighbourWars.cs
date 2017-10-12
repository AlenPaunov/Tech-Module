using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighbourWars
{
    class NeighbourWars
    {
        static void Main(string[] args)
        {
            int peshoDamage = int.Parse(Console.ReadLine());
            int goshoDamage = int.Parse(Console.ReadLine());

            int peshoHealth = 100;
            int goshoHealth = 100;
            int turn = 1;

            string attackerName = "";
            string defenderName = "";
            int defenderHealth = 0;
            int attackerDamage = 0;

            string winner = "";
            string move = "";

            while (true)
            {
                if (turn % 2 == 0)
                {
                    attackerName = "Gosho";
                    defenderName = "Pesho";
                    move = "Thunderous fist";
                    attackerDamage = goshoDamage;
                    peshoHealth -= attackerDamage;
                    defenderHealth = peshoHealth;
                }
                else
                {
                    attackerName = "Pesho";
                    defenderName = "Gosho";
                    move = "Roundhouse kick";
                    attackerDamage = peshoDamage;
                    goshoHealth -= attackerDamage;
                    defenderHealth = goshoHealth; 
                }
                //Attack
                
                if (defenderHealth<=0)
                {
                    winner = attackerName;
                    break;
                }

                Console.WriteLine($"{attackerName} used {move} and reduced {defenderName} to {defenderHealth} health.");

                if (turn % 3 == 0)
                {
                    goshoHealth += 10;
                    peshoHealth += 10;
                }
                turn++;
            }
            Console.WriteLine($"{winner} won in {turn}th round.");
        }
    }
}
