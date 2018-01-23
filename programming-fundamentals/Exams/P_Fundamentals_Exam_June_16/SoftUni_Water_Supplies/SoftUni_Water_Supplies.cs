using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUni_Water_Supplies
{
    class SoftUni_Water_Supplies
    {
        static void Main(string[] args)
        {
            decimal totalWater = decimal.Parse(Console.ReadLine());
            List<decimal> bottles = Console.ReadLine()
                .Split(' ')
                .Select(x => decimal.Parse(x))
                .ToList();
            decimal capacity = decimal.Parse(Console.ReadLine());
            bool enough = true;
            bool even = totalWater % 2 == 0 ? true : false;

            int index = 0;
            if (even)
            {
                index = 0;
            }
            else
            {
                index = bottles.Count - 1;
            }

            while (true)
            {
                if (index >= bottles.Count || index < 0) break;
                decimal bottle = bottles[index];

                if (bottle < capacity)
                {
                    if (capacity - bottle > totalWater)
                    {
                        enough = false;
                        break;
                    }
                    bottles[index] = capacity;
                    totalWater -= capacity - bottle;
                }
                if (even)
                {
                    index++;
                }
                else
                {
                    index--;
                }
            }


            if (enough)
            {
                Console.WriteLine("Enough water!");
                Console.WriteLine($"Water left: {totalWater.ToString()}l.");
            }
            else
            {
                int bottlesNeeded = bottles.Where(x => x != capacity).Count();
                List<int> indices = new List<int>();
                if (even)
                {
                    for (int i = 0; i < bottlesNeeded; i++)
                    {
                        indices.Add(index + i);
                    }
                }
                else
                {
                    for (int i = 0; i < bottlesNeeded; i++)
                    {
                        indices.Add(index - i);
                    }
                }
                decimal neededWater = bottles.Count * capacity - bottles.Sum() - totalWater;
                Console.WriteLine("We need more water!");
                Console.WriteLine($"Bottles left: {bottlesNeeded}");
                Console.WriteLine($"With indexes: {string.Join(", ", indices)}");
                Console.WriteLine($"We need {neededWater.ToString()} more liters!");
            }
        }
    }
}
