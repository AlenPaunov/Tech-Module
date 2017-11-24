using System;

namespace CubeProperties
{
    class CubeProperties
    {
        static void Main(string[] args)
        {
            Cube cubeFigure = Cube.Parse();
            string property = Console.ReadLine();

            switch (property)
            {
                case "face":
                    Console.WriteLine(cubeFigure.Face.ToString("0.00"));
                    break;

                case "area":
                    Console.WriteLine(cubeFigure.Area.ToString("0.00"));
                    break;

                case "space":
                    Console.WriteLine(cubeFigure.Space.ToString("0.00"));
                    break;

                case "volume":
                    Console.WriteLine(cubeFigure.Volume.ToString("0.00"));
                    break;
            }
        }

        public class Cube
        {
            private double face;
            private double space;
            private double volume;
            private double area;

            public double Side { get; set; }
            public double Face
            {
                get { return face; }
                private set { face = value; }
            }

            public double Space
            {
                get { return space; }
                private set { space = value; }
            }
            public double Volume
            {
                get { return volume; }
                private set { volume = value; }
            }
            public double Area
            {
                get { return area; }
                private set { area = value; }
            }

            public Cube(double side)
            {
                Side = side;
                face = GetFace();
                area = GetSurfaceArea();
                volume = GetVolume();
                space = GetSpace();
            }

            public static Cube Parse()
            {
                return new Cube(double.Parse(Console.ReadLine()));
            }

            private double GetVolume()
            {
                return Side * Side * Side;
            }
            private double GetSurfaceArea()
            {
                return 6 * Side * Side;
            }
            private double GetSpace()
            {
                return Math.Sqrt(3 * Side * Side);
            }
            private double GetFace()
            {
                return Math.Sqrt(2 * Side * Side);
            }
        }
    }
}
