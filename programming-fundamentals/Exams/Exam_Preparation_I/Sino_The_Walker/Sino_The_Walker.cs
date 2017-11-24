using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sino_The_Walker
{
    class Sino_The_Walker
    {
        static void Main(string[] args)
        {
            int secondsPerDay = 86400;

            TimeSpan time = TimeSpan.ParseExact(Console.ReadLine(), @"hh\:mm\:ss", System.Globalization.CultureInfo.InvariantCulture);

            long steps = long.Parse(Console.ReadLine());
            long secondsPerStep = long.Parse(Console.ReadLine());
            long secondsToAdd = steps * secondsPerStep;

            if (secondsToAdd > secondsPerDay)
            {
                long days = secondsToAdd / secondsPerDay;
                secondsToAdd -= days * secondsPerDay;
            }
            
            time = time.Add(TimeSpan.FromSeconds(secondsToAdd));
            Console.WriteLine($"Time Arrival: {time.ToString(@"hh\:mm\:ss")}");
        }
    }
}
