using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Append_Lists
{
    class Append_Lists
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split('|').ToList();
            input.Reverse();

            List<string> result = new List<string>();

            foreach (string item in input)
            {
                List<string> numbers = item.Split(' ').ToList();

                foreach (string num in numbers)
                {
                    if (num != "")
                    {
                        result.Add(num);
                    }
                }

            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}