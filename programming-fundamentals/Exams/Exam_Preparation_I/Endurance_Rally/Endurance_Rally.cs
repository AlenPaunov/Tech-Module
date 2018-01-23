using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endurance_Rally
{
    class Endurance_Rally
    {
        static void Main(string[] args)
        {
            List<Driver> drivers = Console.ReadLine().Split(' ').Select(x => Driver.Parse(x)).ToList();
            List<decimal> track = Console.ReadLine().Split(' ').Select(x => decimal.Parse(x)).ToList();
            List<long> checkpoints = Console.ReadLine().Split(' ').Select(i => long.Parse(i)).ToList();

            for (int index = 0; index < track.Count; index++)
            {
                decimal zone = track[index];

                foreach (var driver in drivers.Where(d => d.HasFuel == true))
                {
                    if (checkpoints.Contains(index))
                    {
                        driver.Fuel += zone;
                    }
                    else
                    {
                        driver.Fuel -= zone;
                    }
                    if (driver.Fuel <= 0)
                    {
                        driver.HasFuel = false;
                        driver.ReachedZone = index;
                    }
                }
            }
            foreach (var driver in drivers)
            {
                if (driver.HasFuel)
                {
                    Console.WriteLine($"{driver.Name} - fuel left {driver.Fuel:f2}");
                }
                else
                {
                    Console.WriteLine($"{driver.Name} - reached {driver.ReachedZone}");
                }
            }

        }
    }

    class Driver
    {
        public string Name;
        public decimal Fuel;
        public bool HasFuel = true;
        public long ReachedZone;

        public Driver(string name)
        {
            decimal fuel = name[0];
            Name = name;
            Fuel = name[0];
        }
        public static Driver Parse(string driverName)
        {
            Driver driver = new Driver(driverName);
            return driver;
        }
    }
}
