using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hornet_Wings
{
    class Hornet_Wings
    {
        static void Main(string[] args)
        {
            int wingFlaps = int.Parse(Console.ReadLine());
            double metersPer1000Flaps = double.Parse(Console.ReadLine());
            int endurance = int.Parse(Console.ReadLine());

            double secondsRest = 5.0;
            double flapsPerSecond = 100.0;

            double distanceInMeters = wingFlaps / 1000 * metersPer1000Flaps;
            double seconds = wingFlaps / flapsPerSecond;

            double totalTime = seconds + wingFlaps / endurance * secondsRest;

            Console.WriteLine("{0} m.", distanceInMeters.ToString("f2"));
            Console.WriteLine($"{totalTime.ToString("f0")} s.");

        }
    }
}
