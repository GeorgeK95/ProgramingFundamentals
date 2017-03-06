using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Compare_Char_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string line1 = Console.ReadLine();
            string line2 = Console.ReadLine();

            char[] chArr1 = line1.Split(' ').Select(char.Parse).ToArray();
            char[] chArr2 = line2.Split(' ').Select(char.Parse).ToArray();

            bool isPrinted = false;

            for (int i = 0; i < Math.Min(chArr1.Length, chArr2.Length); i++)
            {
                if (chArr1[i] < chArr2[i])
                {
                    Print(chArr1, chArr2);
                    isPrinted = true;
                    break;
                }
                else if (chArr1[i] > chArr2[i])
                {
                    Print(chArr2, chArr1);
                    isPrinted = true;
                    break;
                }
            }

            if (!isPrinted)
            {
                if (chArr1.Length < chArr2.Length)
                {
                    Print(chArr1, chArr2);
                }
                else
                {
                    Print(chArr2, chArr1);
                }
            }
        }

        private static void Print(char[] first, char[] second)
        {
            Console.WriteLine(string.Join("", first));
            Console.WriteLine(string.Join("", second));
        }
    }
}
