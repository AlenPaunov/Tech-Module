using System;

class GeometryCalculator
{
    static void Main(string[] args)
    {
        ReadFigure parameters = new ReadFigure(Console.ReadLine());
        GeometryFigure shape = GeometryFigure.ParseFigure(parameters.Sides, parameters.SideRadiusWidth, parameters.Height, parameters.IsSquare);
        Console.WriteLine(shape.Area.ToString("0.00"));
    }

    public class ReadFigure
    {
        public int Sides;
        public double SideRadiusWidth;
        public double Height = 0;
        public bool IsSquare = false;

        public ReadFigure(string input)
        {
            switch (input)
            {
                case "triangle":
                    Sides = 3;
                    SideRadiusWidth = double.Parse(Console.ReadLine());
                    Height = double.Parse(Console.ReadLine());
                    break;
                case "square":
                    Sides = 4;
                    SideRadiusWidth = double.Parse(Console.ReadLine());
                    IsSquare = true;
                    break;
                case "rectangle":
                    Sides = 4;
                    SideRadiusWidth = double.Parse(Console.ReadLine());
                    Height = double.Parse(Console.ReadLine());
                    break;
                case "circle":
                    Sides = 1;
                    SideRadiusWidth = double.Parse(Console.ReadLine());
                    break;
            }

        }
    }

    public class GeometryFigure
    {
        public double Area { get; set; }

        public static GeometryFigure ParseFigure(int sidesCount, double sideRadiusWidth, double height = 0, bool isSquare = true)
        {
            switch (sidesCount)
            {
                case 1:
                    return new Circle(sidesCount, sideRadiusWidth, height, isSquare);

                case 3:
                    return new Triangle(sidesCount, sideRadiusWidth, height, isSquare);

                case 4:
                    switch (isSquare)
                    {
                        case true:
                            return new Square(sidesCount, sideRadiusWidth, height, isSquare);
                        case false:
                            return new Rectangle(sidesCount, sideRadiusWidth, height, isSquare);
                    }
                    break;
            }
            return null;
        }

    }

    public class Triangle : GeometryFigure
    {
        double Width;
        double Height;

        public Triangle(int sidesCount, double width, double height = 0, bool isSquare = true)
        {
            Width = width;
            Height = height;
            Area = height * width / 2;
        }
    }

    public class Square : GeometryFigure
    {
        public double Side;

        public Square(int sidesCount, double sideRadiusWidth, double height, bool isSquare)
        {
            Side = sideRadiusWidth;
            Area = sideRadiusWidth * sideRadiusWidth;
        }
    }

    public class Rectangle : GeometryFigure
    {
        public double Height;
        public double Width;

        public Rectangle(int sidesCount, double width, double height, bool isSquare = false)
        {

            Width = width;
            Height = height;
            Area = width * height;

        }
    }

    public class Circle : GeometryFigure
    {
        public double Radius;

        public Circle(int sidesCount, double radius, double height = 0, bool isSquare = false)
        {
            Radius = radius;
            Area = Math.PI * radius * radius;
        }
    }
}

