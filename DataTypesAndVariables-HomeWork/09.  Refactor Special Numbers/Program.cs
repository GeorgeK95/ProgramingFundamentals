using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Refactor_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int index = 1; index <= number; index++)
            {
                int currNum = index;
                int sum = 0;

                while (currNum > 0)
                {
                    sum += currNum % 10;
                    currNum /= 10;
                }

                bool result = (sum == 5) || (sum == 7) || (sum == 11);

                Console.WriteLine(index + " -> " + result);
            }
        }
    }
}
