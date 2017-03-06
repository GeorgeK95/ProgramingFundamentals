using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Square_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> squares = GetSquares(numbers);
            Console.WriteLine(string.Join(" ", squares.OrderByDescending(x => x)));
        }

        private static List<int> GetSquares(List<int> numbers)
        {
            List<int> squares = new List<int>();

            foreach (var number in numbers)
            {
                if ((int)Math.Sqrt(number) == Math.Sqrt(number))
                {
                    squares.Add(number);
                }
            }

            return squares;
        }
    }
}
