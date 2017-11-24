using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectangleArea
{
    class RectangleArea
    {
        static void Main(string[] args)
        {
            float height = float.Parse(Console.ReadLine());
            float width = float.Parse(Console.ReadLine());
            double area = height * width;
            Console.WriteLine($"{area:f2}");
        }
    }
}
