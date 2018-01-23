using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entertrain
{
    class Entertrain
    {
        static void Main(string[] args)
        {
            long power = long.Parse(Console.ReadLine());
            List<long> wagons = new List<long>();

            string line = Console.ReadLine();
            while (line != "All ofboard!")
            {
                long wagon = long.Parse(line);
                wagons.Add(wagon);
                long sum = wagons.Aggregate((a, b) => a + b); ;

                if (sum > power)
                {
                    long average = sum / wagons.Count();
                    long closest = wagons.Aggregate((x, y) => Math.Abs(x - average) < Math.Abs(y - average) ? x : y);
                    wagons.Remove(closest);
                }
                line = Console.ReadLine();
            };
            wagons.Reverse();
            wagons.Add(power);

            Console.WriteLine(string.Join(" ",wagons));
        }
    }
}
