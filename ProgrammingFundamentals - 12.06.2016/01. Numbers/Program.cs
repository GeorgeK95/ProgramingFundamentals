using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbersArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Array.Sort(numbersArray);
            Array.Reverse(numbersArray);
            double avg = numbersArray.Average();
            int[] result = numbersArray.Take(5).Where(x => x > avg).ToArray();

            if (result.Length > 0)
            {
                Array.Sort(result);
                Array.Reverse(result);
                Console.WriteLine(string.Join(" ", result));
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
