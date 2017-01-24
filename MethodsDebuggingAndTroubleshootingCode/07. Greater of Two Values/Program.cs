using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Greater_of_Two_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();

            if (type.Equals("int"))
            {
                int number1 = int.Parse(Console.ReadLine());
                int number2 = int.Parse(Console.ReadLine());

                Console.WriteLine(GetMax(number1, number2));
            }
            else if (type.Equals("char"))
            {
                char letter1 = char.Parse(Console.ReadLine());
                char letter2 = char.Parse(Console.ReadLine());

                Console.WriteLine(GetMax(letter1, letter2));
            }
            else
            {
                string str1 = Console.ReadLine();
                string str2 = Console.ReadLine();

                Console.WriteLine(GetMax(str1, str2));
            }
            
        }

        private static int GetMax(int number1, int number2)
        {
            if (number1 > number2)
            {
                return number1;
            }
            return number2;
        }
        private static char GetMax(char letter1, char letter2)
        {
            if (letter1 > letter2)
            {
                return letter1;
            }
            return letter2;
        }
        private static string GetMax(string str1, string str2)
        {
            if (str1.CompareTo(str2) >= 0)
            {
                return str1;
            }
            return str2;
        }
    }
}
