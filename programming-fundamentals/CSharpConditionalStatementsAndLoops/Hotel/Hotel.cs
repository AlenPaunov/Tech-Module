using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    class Hotel
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nightsCount = int.Parse(Console.ReadLine());
            double studioPrice = 0.0;
            double doublePrice = 0.0;
            double suitePrice = 0.0;

            switch (month)
            {
                case "May":
                case "October":
                    studioPrice = 50.0;
                    doublePrice = 65.0;
                    suitePrice = 75.0;
                    if (nightsCount > 7)
                    {
                        studioPrice *= 0.95;
                    }
                    break;
                case "June":
                case "September":
                    studioPrice = 60.0;
                    doublePrice = 72.0;
                    suitePrice = 82.0;
                    if (nightsCount > 14)
                    {
                        doublePrice *= 0.90;
                    }
                    break;
                default:
                    studioPrice = 68.0;
                    doublePrice = 77.0;
                    suitePrice = 89.0;
                    if (nightsCount > 14)
                    {
                        suitePrice *= 0.85;
                    }
                    break;
            }
            if (nightsCount > 7 && (month == "October" || month == "September"))
            {
                studioPrice *= nightsCount - 1;
            }
            else
            {
                studioPrice *= nightsCount;
            }
            doublePrice *= nightsCount;
            suitePrice *= nightsCount;

            Console.WriteLine($"Studio: {studioPrice:f2} lv.");
            Console.WriteLine($"Double: {doublePrice:f2} lv.");
            Console.WriteLine($"Suite: {suitePrice:f2} lv.");
        }
    }
}
