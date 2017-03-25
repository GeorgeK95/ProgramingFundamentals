using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Distance_between_Points
{
    class Point
    {
        public double x { get; set; }
        public double y { get; set; }

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            string firstPoint = Console.ReadLine();
            double x1 = GetX(firstPoint);
            double y1 = GetY(firstPoint);
            Point p1 = new Point(x1, y1);

            string secondPoint = Console.ReadLine();
            double x2 = GetX(secondPoint);
            double y2 = GetY(secondPoint);
            Point p2 = new Point(x2, y2);

            double distance = CalculateDistance(p1, p2);
            Console.WriteLine("{0:0.000}", distance);
        }
        public static double CalculateDistance(Point p1, Point p2)
        {
            double x = Math.Abs(p1.x - p2.x);
            double y = Math.Abs(p1.y - p2.y);

            return Math.Sqrt(x * x + y * y);
        }
        private static double GetY(string input)
        {
            string[] splitted = input.Split();
            return double.Parse(splitted[1]);
        }

        private static double GetX(string input)
        {
            string[] splitted = input.Split();
            return double.Parse(splitted[0]);
        }
    }
}

