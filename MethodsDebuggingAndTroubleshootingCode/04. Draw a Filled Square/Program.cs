using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Draw_a_Filled_Square
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            DrawFillerSquare(input);
        }

        private static void DrawFillerSquare(int input)
        {
            PrintFirstLine(input);
            PrintMiddlePart(input);
            PrintLastLine(input);
        }

        private static void PrintMiddlePart(int input)
        {
            for (int rowsCounter = 0; rowsCounter < input - 2; rowsCounter++)
            {
                Console.Write('-');

                for (int printCounter = 1; printCounter < input; printCounter++)
                {
                    Console.Write("\\");
                    Console.Write("/");
                }

                Console.WriteLine('-');
            }

        }

        private static void PrintLastLine(int input)
        {
            Console.WriteLine(new string('-', input * 2));
        }

        private static void PrintFirstLine(int input)
        {
            Console.WriteLine(new string('-', input * 2));
        }
    }
}
