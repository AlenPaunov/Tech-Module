using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resurrection
{
    class Resurrection
    {
        static void Main(string[] args)
        {
            int phoenixes = int.Parse(Console.ReadLine());

            for (int i = 0; i < phoenixes; i++)
            {
                var bodyLen = long.Parse(Console.ReadLine());
                var bodyWidth = decimal.Parse(Console.ReadLine());
                int digitsDecimal = 0;
                if (bodyWidth.ToString().Contains('.'))
                {
                    digitsDecimal = bodyWidth.ToString().Split('.').ToArray()[1].Count();
                }
                string decimals = "f" + digitsDecimal.ToString();
                var windLen = int.Parse(Console.ReadLine());

                Phoenix phoenix = new Phoenix()
                {
                    BodyLen = bodyLen,
                    BodyWidth = bodyWidth,
                    WingLen = windLen,
                };
                if (bodyLen == 0 || bodyWidth == 0 && windLen == 0)
                {
                    phoenix.YearsToResurrect = 0;
                }
                else
                {
                    phoenix = Phoenix.GetYears(phoenix);
                }
                Console.WriteLine($"{phoenix.YearsToResurrect.ToString(decimals)}");

            }
            //total len of body int            // total width of body double            // 1 wing length int
            // years to incarnate = total len pow 2 * sum (total width + total wing len
        }
    }

    public class Phoenix
    {
        public long BodyLen;
        public decimal BodyWidth; //20 digits after decimal point
        public int WingLen;
        public decimal YearsToResurrect;

        public static Phoenix GetYears(Phoenix phoenix)
        {
            phoenix.YearsToResurrect = (phoenix.BodyLen * phoenix.BodyLen) * (phoenix.BodyWidth + phoenix.WingLen * 2.0M);
            return phoenix;
        }

    }
}
