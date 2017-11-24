using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CenterPoint
{
    class CenterPoint
    {
        static void Main(string[] args)
        {
            Point firstPoint = Point.ReadPoint();
            Point secondPoint = Point.ReadPoint();
            double firstDist = CalcDistance(firstPoint, new Point(0, 0));
            double secondDist = CalcDistance(secondPoint, new Point(0, 0));

            if (firstDist <= secondDist)
            {
                Console.WriteLine(firstPoint.Print());
            }
            else
            {
                Console.WriteLine(secondPoint.Print());
            }
        }

        public class Point
        {
            public double X { get; set; }
            public double Y { get; set; }

            public Point(double x, double y)
            {
                this.X = x;
                this.Y = y;
            }


            public string Print()
            {
                return $"({X}, {Y})";
            }
            public static Point ReadPoint()
            {
                double x = double.Parse(Console.ReadLine());
                double y = double.Parse(Console.ReadLine());
                return new Point(x, y);
            }
        }

        public static double CalcDistance(Point p1, Point p2)
        {
            double sideA = Math.Pow(p1.X - p2.X, 2);
            double sideB = Math.Pow(p1.Y - p2.Y, 2);
            double distance = Math.Sqrt(sideA + sideB);
            return distance;
        }
    }
}
