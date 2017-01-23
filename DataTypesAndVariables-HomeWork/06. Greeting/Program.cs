using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Greeting
{
    class Program
    {
        static void Main(string[] args)
        {
            string fName = Console.ReadLine();
            string sName = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine($"Hello, {fName} {sName}.\nYou are {age} years old.");
        }
    }
}
