using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Randomize_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] splitted = input.Split(' ');
            Random rand = new Random();

            for (int i = 0; i < splitted.Length; i++)
            {
                int index = rand.Next(0, splitted.Length - 1);
                string temp = splitted[i];
                splitted[i] = splitted[index];
                splitted[index] = temp;
            }

            Print(splitted);
        }

        private static void Print(string[] splitted)
        {
            foreach (var item in splitted)
            {
                Console.WriteLine(item);
            }
        }
    }
}
