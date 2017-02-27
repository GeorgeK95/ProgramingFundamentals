using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Closest_Two_Points
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Point> points = ReadPoints(n);

            Point[] closestTwoPoints = GetClosestTwoPoints(points);

            PrintShortestDistance(closestTwoPoints);

            PrintPoint(closestTwoPoints[0]);
            PrintPoint(closestTwoPoints[1]);
        }

        private static void PrintPoint(Point point)
        {
            Console.WriteLine("({0}, {1})", point.x, point.y);
        }

        private static void PrintShortestDistance(Point[] closestTwoPoints)
        {
            double dist = Point.CalcDistance(closestTwoPoints[0], closestTwoPoints[1]);
            Console.WriteLine("{0:f3}", dist);
        }

        private static Point[] GetClosestTwoPoints(List<Point> points)
        {
            double minDistance = double.MaxValue;

            Point[] closest = new Point[2];

            Point p1 = new Point();
            Point p2 = new Point();

            for (int i = 0; i < points.Count; i++)
            {
                for (int j = i + 1; j < points.Count; j++)
                {
                    double dist = Point.CalcDistance(points[i], points[j]);

                    if (dist < minDistance)
                    {
                        minDistance = dist;
                        p1 = points[i];
                        p2 = points[j];
                    }
                }

            }

            closest[0] = p1;
            closest[1] = p2;

            return closest;
        }

        private static List<Point> ReadPoints(int n)
        {
            List<Point> points = new List<Point>();

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();

                double a = double.Parse(line.Split(' ')[0]);
                double b = double.Parse(line.Split(' ')[1]);

                Point currPoint = new Point(a, b);
                points.Add(currPoint);
            }

            return points;
        }


    }

    class Point
    {
        public double x { get; set; }
        public double y { get; set; }

        public static double CalcDistance(Point p1, Point p2)
        {
            double distance = 0;

            double sideA = p1.x - p2.x;
            double sideB = p1.y - p2.y;

            distance = Math.Sqrt(sideA * sideA + sideB * sideB);

            return distance;
        }

        public Point() { }

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
