using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTimes
{
    class SortTimes
    {
        static void Main(string[] args)
        {
            List<TimeSpan> times = ReadTimes();
            SortAndPrintTimes(times);
        }

        public static List<TimeSpan> ReadTimes()
        {
            List<TimeSpan> times = new List<TimeSpan>();
            times = Console.ReadLine().Split(' ').Select(t => TimeSpan.ParseExact(t, "g", System.Globalization.CultureInfo.InvariantCulture)).ToList();
            return times;
        }

        public static void SortAndPrintTimes(List<TimeSpan> times)
        {
            times.Sort();
            Console.WriteLine(string.Join(", ", times.Select(t => t.ToString(@"hh\:mm"))).ToArray());
        }
    }
}
