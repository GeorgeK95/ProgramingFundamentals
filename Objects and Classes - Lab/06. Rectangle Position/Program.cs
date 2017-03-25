using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Rectangle_Position
{
    class Rectangle
    {
        public double left;
        public double top;
        public double width;
        public double height;

        public double right
        {
            get
            {
                return this.left + this.width;
            }
        }
        public double bottom
        {
            get
            {
                return this.top + this.height;
            }
        }

        public Rectangle(double left, double top, double width, double height)
        {
            this.left = left;
            this.top = top;
            this.width = width;
            this.height = height;
        }

        public bool IsInside(Rectangle r2)
        {
            if (this.left >= r2.left && this.right <= r2.right && this.top <= r2.top && this.bottom <= r2.bottom)
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
            string line1 = Console.ReadLine();
            string line2 = Console.ReadLine();

            Rectangle r1 = new Rectangle(double.Parse(line1.Split(' ')[0]), double.Parse(line1.Split(' ')[1]), double.Parse(line1.Split(' ')[2]), double.Parse(line1.Split(' ')[3]));
            Rectangle r2 = new Rectangle(double.Parse(line2.Split(' ')[0]), double.Parse(line2.Split(' ')[1]), double.Parse(line2.Split(' ')[2]), double.Parse(line2.Split(' ')[3]));

            if (r1.IsInside(r2))
            {
                Console.WriteLine("Inside");
            }
            else
            {
                Console.WriteLine("Not inside");
            }
        }
    }
}