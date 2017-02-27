using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.English_Name_of_Last_Digit
{
    class Program
    {
        static void Main(string[] args)
        {
            long num = long.Parse(Console.ReadLine());

            string name = GetLastDigitName(num);

            Console.WriteLine(name);
        }

        private static string GetLastDigitName(long num)
        {
            string numStr = num.ToString();
            char letter = numStr[numStr.Length - 1];
            string returnValue = null;

            switch (letter)
            {
                case '0':
                    returnValue = "zero";
                    break;
                case '1':
                    returnValue = "one";
                    break;
                case '2':
                    returnValue = "two";
                    break;
                case '3':
                    returnValue = "three";
                    break;
                case '4':
                    returnValue = "four";
                    break;
                case '5':
                    returnValue = "five";
                    break;
                case '6':
                    returnValue = "six";
                    break;
                case '7':
                    returnValue = "seven";
                    break;
                case '8':
                    returnValue = "eight";
                    break;
                default:
                    returnValue = "nine";
                    break;
            }

            return returnValue;
        }
    }
}
