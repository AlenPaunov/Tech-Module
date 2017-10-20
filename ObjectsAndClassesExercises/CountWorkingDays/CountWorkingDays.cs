using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace CountWorkingDays
{
    class CountWorkingDays
    {
        static void Main(string[] args)
        {
            DateTime startDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            int workingDays = 0;

            List<DateTime> holidays = new List<DateTime>()
            {
                new DateTime(4, 1, 1),
                new DateTime(4, 3, 3),
                new DateTime(4, 5, 1),
                new DateTime(4, 5, 6),
                new DateTime(4, 5, 24),
                new DateTime(4, 9, 6),
                new DateTime(4, 9, 22),
                new DateTime(4, 11, 1),
                new DateTime(4, 12, 24),
                new DateTime(4, 12, 25),
                new DateTime(4, 12, 26)
            };

            for (DateTime i = startDate; i <= endDate; i = i.AddDays(1))
            {
                DayOfWeek day = i.DayOfWeek;
                DateTime dateToCheck = new DateTime(4, i.Month, i.Day);

                if (!holidays.Contains(dateToCheck) && !day.Equals(DayOfWeek.Saturday) && !day.Equals(DayOfWeek.Sunday))
                {
                    workingDays++;
                }
            }
            Console.WriteLine(workingDays);
        }
    }
}
