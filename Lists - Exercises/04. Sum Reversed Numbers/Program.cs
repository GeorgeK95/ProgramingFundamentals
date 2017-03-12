using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Sum_Reversed_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int[] numbers = input.Split(' ').Select(int.Parse).ToArray();
            long sum = 0;

            foreach (var number in numbers)
            {
                string num = number.ToString();
                num = Reverse(num);
                sum += int.Parse(num);
            }

            Console.WriteLine(sum);
        }
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
