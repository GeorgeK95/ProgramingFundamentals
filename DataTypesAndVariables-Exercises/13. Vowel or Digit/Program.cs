using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Vowel_or_Digit
{
    class Program
    {
        static void Main(string[] args)
        {
            char symbol = char.Parse(Console.ReadLine());
            int ascii = (int)symbol;

            if (ascii >= 48 && ascii <= 58)
            {
                Console.WriteLine("digit");
            }
            else if (ascii == 65 || ascii == 69 || ascii == 73 || ascii == 79 || ascii == 85 || ascii == 97 || ascii == 101 || ascii == 111 || ascii == 117 || ascii == 105)
            {
                Console.WriteLine("vowel");
            }
            else
            {
                Console.WriteLine("other");
            }

        }
    }
}