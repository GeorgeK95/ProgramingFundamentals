using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Refactor_Volume_Of_Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Length: ");
            double length = double.Parse(Console.ReadLine());
            Console.Write("Width: ");
            double width = double.Parse(Console.ReadLine());
            Console.Write("Heigth: ");
            double heigth = double.Parse(Console.ReadLine());

            double volume = (length + width + heigth) / 3;

            Console.WriteLine("Pyramid Volume: {0:f12}", volume);

        }
    }
}
