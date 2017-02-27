using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Circles_Intersection
{
    class Point
    {
        public double x;
        public double y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public Point()
        {

        }

    }

    class Circle
    {
        Point center;
        double radius;

        public Circle()
        {

        }

        public Circle(Point center, double radius)
        {
            this.center = center;
            this.radius = radius;
        }

        public static bool Intersect(Circle c1, Circle c2)
        {
            double side_A = Math.Abs(c1.center.x - c2.center.x);
            double side_B = Math.Abs(c1.center.y - c2.center.y);

            double side_C = Math.Sqrt(side_A * side_A + side_B * side_B);
            double sumRadiuses = Math.Abs(c1.radius + c2.radius);

            if (side_C <= sumRadiuses)
            {
                return true;
            }

            return false;

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string line_1 = Console.ReadLine();
            string line_2 = Console.ReadLine();

            double x_1 = double.Parse(line_1.Split(' ')[0]);
            double y_1 = double.Parse(line_1.Split(' ')[1]);
            double rad_1 = double.Parse(line_1.Split(' ')[2]);

            double x_2 = double.Parse(line_2.Split(' ')[0]);
            double y_2 = double.Parse(line_2.Split(' ')[1]);
            double rad_2 = double.Parse(line_2.Split(' ')[2]);

            Point pointCircle1 = new Point(x_1, y_1);
            Circle c1 = new Circle(pointCircle1, rad_1);

            Point pointCircle2 = new Point(x_2, y_2);
            Circle c2 = new Circle(pointCircle2, rad_2);

            if (Circle.Intersect(c1,c2))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}

