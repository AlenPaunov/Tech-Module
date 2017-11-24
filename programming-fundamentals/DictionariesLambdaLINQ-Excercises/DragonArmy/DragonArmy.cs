using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonArmy
{
    class DragonArmy
    {
        static void Main(string[] args)
        {
            int dragonsCount = int.Parse(Console.ReadLine());
            string type;
            string name;
            int damage;
            int health;
            int armor;

            Dictionary
                <string, SortedDictionary
                <string, List<long>>>
                dragons = new Dictionary<string, SortedDictionary<string, List<long>>>();

            Dictionary
                <string, List<long>>
                totalStatsPerType = new Dictionary<string, List<long>>();

            for (int i = 0; i < dragonsCount; i++)
            {
                string[] dragonParams = Console.ReadLine().Split(' ');
                type = dragonParams[0];
                name = dragonParams[1];
                damage = CheckDamage(dragonParams[2]);
                health = CheckHealth(dragonParams[3]);
                armor = CheckArmor(dragonParams[4]);

                dragons.FillData(type, name, damage, health, armor);
                totalStatsPerType.CalculateTotalStatsPerType(type, damage, health, armor);
            }

            foreach (var value in dragons)
            {
                Console.WriteLine("{0}::({1:F2}/{2:F2}/{3:F2})", 
                    value.Key,
                    value.Value.Select(x => x.Value[0]).Average(), 
                    value.Value.Select(x => x.Value[1]).Average(), 
                    value.Value.Select(x => x.Value[2]).Average());
            
                foreach (var dragon in dragons[value.Key])
                {
                    Console.WriteLine("-{0} -> damage: {1}, health: {2}, armor: {3}", 
                        dragon.Key, 
                        dragon.Value[0], 
                        dragon.Value[1], 
                        dragon.Value[2]);
                }
            }
        }

        private static int CheckDamage(string damage)
        {
            int result;
            try
            {
                return result = int.Parse(damage);
            }
            catch (Exception)
            {
                return 45;
            }
        }

        private static int CheckArmor(string armor)
        {
            int result;
            try
            {
                return result = int.Parse(armor);
            }
            catch (Exception)
            {
                return 10;
            }
        }

        private static int CheckHealth(string health)
        {
            int result;
            try
            {
                return result = int.Parse(health);
            }
            catch (Exception)
            {
                return 250;
            }
        }
    }

    public static class DragonOperator
    {
        public static Dictionary<string, SortedDictionary<string, List<long>>>
      FillData(this Dictionary<string, SortedDictionary<string, List<long>>> dragons, string type, string name, int damage, int health, int armor)
        {
            if (!dragons.ContainsKey(type))
            {
                dragons[type] = new SortedDictionary<string, List<long>>
                {
                    { name, new List<long>() }
                };
                dragons[type][name].Add(damage);
                dragons[type][name].Add(health);
                dragons[type][name].Add(armor);
            }
            else
            {
                if (!dragons[type].ContainsKey(name))
                {
                    dragons[type].Add(name, new List<long>());
                    dragons[type][name].Add(damage);
                    dragons[type][name].Add(health);
                    dragons[type][name].Add(armor);
                }
                else
                {
                    dragons[type][name][0] = damage;
                    dragons[type][name][1] = health;
                    dragons[type][name][2] = armor;
                }
            }

            return dragons;
        }

        public static Dictionary<string, List<long>> CalculateTotalStatsPerType(this Dictionary<string, List<long>> totalStatsPerType, string type, int damage, int health, int armor)
        {
            if (!totalStatsPerType.ContainsKey(type))
            {
                totalStatsPerType[type] = new List<long>
                {
                    damage,
                    health,
                    armor
                };
            }
            else
            {
                totalStatsPerType[type][0] += damage;
                totalStatsPerType[type][1] += health;
                totalStatsPerType[type][2] += armor;
            }
            return totalStatsPerType;
        }
    }
}
