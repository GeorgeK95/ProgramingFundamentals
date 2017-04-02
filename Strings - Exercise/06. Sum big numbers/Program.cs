using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Sum_big_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string num1 = Console.ReadLine();
            string num2 = Console.ReadLine();

            if (num1.Length > num2.Length)
            {
                num2 = RoundUpWithZeroes(num2, num1.Length - num2.Length);
            }
            else if (num1.Length < num2.Length)
            {
                num1 = RoundUpWithZeroes(num1, num2.Length - num1.Length);
            }

            string res = SumNumbers(num1, num2);
            Console.WriteLine(res);
        }

        private static string SumNumbers(string num1, string num2)
        {
            string res = string.Empty;
            int accumulation = 0;

            for (int i = num1.Length - 1; i >= 0; i--)
            {
                int currNumberNum1 = int.Parse(num1[i].ToString());
                int currNumberNum2 = int.Parse(num2[i].ToString());

                int sum = currNumberNum1 + currNumberNum2 + accumulation;
                accumulation = 0;

                if (sum >= 10)
                {
                    accumulation++;
                    res = res.Insert(0, (sum - 10).ToString());
                }
                else
                {
                    accumulation = 0;
                    res = res.Insert(0, sum.ToString());
                }

                if (i == 0 && accumulation != 0)
                {
                    res = res.Insert(0, accumulation.ToString());
                }
            }

            res = res.TrimStart(new char[] { '0' });

            return res;
        }

        private static string RoundUpWithZeroes(string str, int length)
        {
            for (int i = 0; i < length; i++)
            {
                str = str.Insert(0, "0");
            }

            return str;
        }
    }
}
