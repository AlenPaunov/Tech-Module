using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountTheIntegers
{
    class CountTheIntegers
    {
        static void Main(string[] args)
        {
            int numbers = 0;
            bool isInt = true;
            while (isInt == true)
            {
                try
                {
                    int.Parse(Console.ReadLine());
                    numbers++;
                }
                catch
                {
                    isInt = false;
                }
            }
            Console.WriteLine(numbers);
        }
    }
}
