using System;


namespace LongerLine
{
    class LongerLine
    {
        static void Main(string[] args)
        {
            Line firstLine = Line.Parse();
            Line secondLine = Line.Parse();

            if (firstLine.Lenght >= secondLine.Lenght)
            {
                Console.WriteLine(firstLine.Coordinates);
            }
            else
            {
                Console.WriteLine(secondLine.Coordinates);
            }
        }

        public class Line
        {
            public Point A { get; set; }
            public Point B { get; set; }
            private double lenght;
            private string coordinates;
            public string Coordinates
            {
                get { return coordinates; }
                set { coordinates = value; }
            }
            public double Lenght
            {
                get { return lenght; }
                set { lenght = value; }
            }
            private double Len()
            {
                double sideA = Math.Pow(A.X - B.X, 2);
                var sideB = Math.Pow(A.Y - B.Y, 2);
                double lenght = Math.Sqrt(sideA + sideB);
                return lenght;
            }

            public Line(Point a, Point b)
            {
                A = a;
                B = b;
                coordinates = PrintCoordinates();
                lenght = Len();
            }

            public static Line Parse()
            {
                return new Line(Point.ReadPoint(), Point.ReadPoint());
            }

            private string PrintCoordinates()
            {
                double firstDist = Point.CalcDistance(A, new Point(0, 0));
                double secondDist = Point.CalcDistance(B, new Point(0, 0));

                if (firstDist <= secondDist)
                {
                    return $"{A.Print()}{B.Print()}";
                }
                else
                {
                    return $"{B.Print()}{A.Print()}";
                }
            }
        }

        public class Point
        {
            public double X { get; set; }
            public double Y { get; set; }

            public Point(double x, double y)
            {
                X = x;
                Y = y;
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

            public static double CalcDistance(Point p1, Point p2)
            {
                double sideA = Math.Pow(p1.X - p2.X, 2);
                double sideB = Math.Pow(p1.Y - p2.Y, 2);
                double distance = Math.Sqrt(sideA + sideB);
                return distance;
            }
        }
    }
}
