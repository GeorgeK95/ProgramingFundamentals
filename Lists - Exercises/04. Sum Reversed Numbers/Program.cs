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
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            long sum = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                int currNum = numbers[i];

                string currNumStr = currNum.ToString();
                char[] charArray = currNumStr.ToCharArray();
                Array.Reverse(charArray);

                currNum = int.Parse(new string(charArray));

                sum += currNum;
            }

            Console.WriteLine(sum);
        }
    }
}
