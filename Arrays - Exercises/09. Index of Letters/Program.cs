using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Index_of_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            char[] letters = line.ToCharArray();

            for (int i = 0; i < letters.Length; i++)
            {
                int value = letters[i] - 97;
                Console.WriteLine($"{letters[i]} -> {value}");
            }
        }
    }
}
