using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntersectionOfCircles
{
    class IntersectionOfCircles
    {
        static void Main(string[] args)
        {
            Circle circleA = Circle.ParseCircle(Console.ReadLine());
            Circle circleB = Circle.ParseCircle(Console.ReadLine());

            Console.WriteLine(circleA.Intersect(circleB) == true ? "Yes" : "No");
        }
    }
    public class Circle
    {
        public Point Center;
        public int Radius;

        public Circle(Point center, int radius)
        {
            Center = center;
            Radius = radius;
        }
        public static Circle ParseCircle(string input)
        {
            int[] parameters = input.Split(' ').Select(x => int.Parse(x)).ToArray();
            Point center = new Point(parameters[0], parameters[1]);
            int radius = parameters[2];

            return new Circle(center, radius);
        }
    }

    public class Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public static class CircleOperator
    {
        public static bool Intersect(this Circle circleA, Circle circleB)
        {
            double distance = circleA.DistanceBetweenCenters(circleB);
            if (distance <= circleA.Radius + circleB.Radius)
            {
                return true;
            }

            return false;
        }

        public static double DistanceBetweenCenters(this Circle circleA, Circle circleB)
        {
            int a = (circleA.Center.X - circleB.Center.X);
            int b = (circleA.Center.Y - circleB.Center.Y);

            return Math.Sqrt(a * a + b * b);
        }
    }
}
