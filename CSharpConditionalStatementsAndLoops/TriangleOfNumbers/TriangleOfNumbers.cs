using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleOfNumbers
{
    class TriangleOfNumbers
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            StringBuilder builder = new StringBuilder();
            for (int i = 1; i <= input; i++)
            {
                for (int a = 1; a <= i; a++)
                {

                    builder.Append(i.ToString());
                    builder.Append(" ");
                }
                Console.WriteLine(builder.ToString());
                builder.Clear();
            }
        }
    }
}
