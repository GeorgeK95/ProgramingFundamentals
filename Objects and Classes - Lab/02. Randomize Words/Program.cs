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
            string[] words = input.Split(' ');

            Random rand = new Random();

            for (int i = 0; i < words.Length; i++)
            {
                int indexFirst = rand.Next(0, words.Length);
                int indexSecond = rand.Next(0, words.Length);

                string helper = words[indexFirst];
                words[indexFirst] = words[indexSecond];
                words[indexSecond] = helper;
            }

            Console.WriteLine(string.Join("\n", words));
        }
    }
}
