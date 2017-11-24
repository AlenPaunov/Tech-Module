using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Charity_Marathon
{
    class Charity_Marathon
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            long runners = long.Parse(Console.ReadLine());
            int averageLabsCount = int.Parse(Console.ReadLine());

            Track track = new Track()
            {
                Length = long.Parse(Console.ReadLine()),
                Capacity = int.Parse(Console.ReadLine()) * days
            };

            decimal moneyPerKilometer = decimal.Parse(Console.ReadLine());

            if (runners > track.Capacity)
            {
                runners = track.Capacity;
            }

            long totalMeters = runners * averageLabsCount * track.Length;
            long totalKilometers = totalMeters / 1000;
            decimal totalMoney = moneyPerKilometer * totalKilometers;

            Console.WriteLine($"Money raised: {totalMoney:f2}");

        }
    }
    class Track
    {
        public long Length;
        public int Capacity;
        public Track()
        {

        }
    }
}
