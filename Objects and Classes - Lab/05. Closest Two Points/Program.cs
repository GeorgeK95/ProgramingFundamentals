using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Closest_Two_Points
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
        class Program
        {
            static void Main(string[] args)
            {
                int n = int.Parse(Console.ReadLine());
                Point[] points = new Point[n];
                int index = 0;

                for (int i = 0; i < n; i++)
                {
                    string firstPoint = Console.ReadLine();
                    double x1 = GetX(firstPoint);
                    double y1 = GetY(firstPoint);
                    Point p1 = new Point(x1, y1);
                    points[index] = p1;
                    index++;
                }

                PrintClosestPoints(points);
            }

            private static void PrintClosestPoints(Point[] points)
            {
                double shortestDistance = double.MaxValue;
                Point[] bestPoints = new Point[2];

                for (int i = 0; i < points.Length - 1; i++)
                {
                    for (int j = i + 1; j < points.Length; j++)
                    {
                        double distance = CalculateDistance(points[i], points[j]);

                        if (distance < shortestDistance)
                        {
                            shortestDistance = distance;
                            bestPoints[0] = points[i];
                            bestPoints[1] = points[j];
                        }
                    }
                }

                Console.WriteLine("{0:0.000}", shortestDistance);
                Console.WriteLine($"({bestPoints[0].x}, {bestPoints[0].y})");
                Console.WriteLine($"({bestPoints[1].x}, {bestPoints[1].y})");
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
}
