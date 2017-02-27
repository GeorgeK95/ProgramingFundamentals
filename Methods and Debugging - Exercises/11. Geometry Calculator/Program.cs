using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Geometry_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //triangle, square, rectangle and circle.
            string type = Console.ReadLine().ToLower();

            switch (type)
            {
                case "triangle":
                    double sideTriangle = double.Parse(Console.ReadLine());
                    double height = double.Parse(Console.ReadLine());
                    PrintTriangleArea(sideTriangle, height);
                    break;
                case "square":
                    double sideSquare = double.Parse(Console.ReadLine());
                    PrintSquareArea(sideSquare);
                    break;
                case "rectangle":
                    double width = double.Parse(Console.ReadLine());
                    double heightRectangle = double.Parse(Console.ReadLine());
                    PrintRectangleArea(width, heightRectangle);
                    break;
                default:
                    double radius = double.Parse(Console.ReadLine());
                    PrintCircleArea(radius);
                    break;
            }
        }

        private static void PrintCircleArea(double radius)
        {
            Console.WriteLine("{0:f2}", Math.Round(Math.PI * radius * radius, 2));
        }

        private static void PrintRectangleArea(double width, double heightRectangle)
        {
            Console.WriteLine("{0:f2}", Math.Round(width * heightRectangle, 2));
        }

        private static void PrintSquareArea(double sideSquare)
        {
            Console.WriteLine("{0:f2}", Math.Round(sideSquare * sideSquare, 2));
        }

        private static void PrintTriangleArea(double sideTriangle, double height)
        {
            Console.WriteLine("{0:f2}", Math.Round(sideTriangle * height / 2, 2));
        }
    }
}
