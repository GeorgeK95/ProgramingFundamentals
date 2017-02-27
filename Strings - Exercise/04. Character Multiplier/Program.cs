using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();

            string first = line.Split(' ')[0];
            string second = line.Split(' ')[1];

            long sum = MultiplyTwoStringsCharacters(first, second);

            Console.WriteLine(sum);
        }

        private static long MultiplyTwoStringsCharacters(string first, string second)
        {
            long sum = 0;

            bool ch = false;

            if (first.Length > second.Length)
            {
                ch = true;
            }

            int difference = Math.Abs(first.Length - second.Length);

            for (int i = 0; i < Math.Min(first.Length, second.Length); i++)
            {
                sum += (int)first[i] * (int)second[i];
            }

            for (int i = Math.Min(first.Length, second.Length); i < difference + Math.Min(first.Length, second.Length); i++)
            {
                if (ch)
                {
                    sum += (int)first[i];
                }
                else
                {
                    sum += (int)second[i];
                }
            }

            return sum;
        }
    }
}
