using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings___Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string inputReversed = Reverse(input);
            Console.WriteLine(inputReversed);
        }

        private static string Reverse(string input)
        {
            char[] inputArr = input.ToCharArray();
            Array.Reverse(inputArr);
            return new string(inputArr);
        }
    }
}
