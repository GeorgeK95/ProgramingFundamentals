using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Distance_between_Points
{
    class Point
    {
        public int x { get; set; }
        public int y { get; set; }

        public static double CalcDistance(Point p1, Point p2)
        {
            double distance = 0;

            double sideA = Math.Abs(p1.x - p2.x);
            double sideB = Math.Abs(p1.y - p2.y);

            distance = Math.Sqrt(sideA * sideA + sideB * sideB);

            return distance;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string l1 = Console.ReadLine();
            string l2 = Console.ReadLine();

            Point p1 = new Point();
            p1.x = int.Parse(l1.Split(' ')[0]);
            p1.y = int.Parse(l1.Split(' ')[1]);

            Point p2 = new Point();
            p2.x = int.Parse(l2.Split(' ')[0]);
            p2.y = int.Parse(l2.Split(' ')[1]);

            double result = Point.CalcDistance(p1, p2);

            Console.WriteLine("{0:f3}", result);
        }
    }
}
