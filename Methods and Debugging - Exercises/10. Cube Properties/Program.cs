using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Cube_Properties
{
    class Program
    {
        static void Main(string[] args)
        {
            double lenght = double.Parse(Console.ReadLine());
            string parameter = Console.ReadLine();

            switch (parameter)
            {
                case "face":
                    PrintFace(lenght);
                    break;
                case "space":
                    PrintSpace(lenght);
                    break;
                case "volume":
                    PrintVolume(lenght);
                    break;
                case "area":
                    PrintArea(lenght);
                    break;
            }
        }

        private static void PrintArea(double lenght)
        {
            Console.WriteLine(Math.Round(6 * Math.Pow(lenght, 2), 2));
        }

        private static void PrintVolume(double lenght)
        {
            Console.WriteLine(Math.Round(Math.Pow(lenght, 3), 2));
        }

        private static void PrintSpace(double lenght)
        {
            Console.WriteLine(Math.Round(Math.Sqrt(3 * lenght * lenght), 2));
        }

        private static void PrintFace(double lenght)
        {
            Console.WriteLine(Math.Round(Math.Sqrt(2 * lenght * lenght), 2));
        }
    }
}
