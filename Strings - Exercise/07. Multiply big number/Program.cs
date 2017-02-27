using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Multiply_big_number
{
    class Program
    {
        static void Main(string[] args)
        {
            string num1 = Console.ReadLine(); ;
            string num2 = Console.ReadLine(); ;

            if (num1.Equals("0") || num2.Equals("0"))
            {
                Console.WriteLine("0");
            }
            else
            {
                if (num1.Length < num2.Length)
                {
                    string temp = num1;
                    num1 = num2;
                    num2 = temp;
                }

                List<string> arr = PrepareArray(num1, num2);

                Sum(arr);
            }
        }

        private static List<string> PrepareArray(string num1, string num2)
        {
            List<string> arr = new List<string>();

            for (int i = 0; i < int.Parse(num2) / 2; i++)
            {
                string res = SumNumbers(num1);
                arr.Add(res);
            }

            if (int.Parse(num2) % 2 != 0)
            {
                arr.Add(num1);
            }

            return arr;
        }

        private static void Sum(List<string> arr)
        {
            List<string> currList = new List<string>();

            if (arr.Count == 1)
            {
                Console.WriteLine(arr[0]);
                return;
            }
            for (int i = 0; i < arr.Count; i += 2)
            {
                string firstNum = arr[i];

                if (i != arr.Count - 1)
                {
                    string secondNum = arr[i + 1];
                    string summed = SumTwoNumbers(firstNum, secondNum);
                    currList.Add(summed);
                }
                else
                {
                    currList.Add(firstNum);
                }

            }

            Sum(currList);
        }

        private static void PrintArr(List<string> arr)
        {
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }

        private static string SumNumbers(string num1)
        {
            string res = string.Empty;
            int naum = 0;

            for (int i = num1.Length - 1; i >= 0; i--)
            {
                int currNumberNum1 = int.Parse(num1[i].ToString());
                int currNumberNum2 = int.Parse(num1[i].ToString());

                int sum = currNumberNum1 + currNumberNum2 + naum;
                naum = 0;

                if (sum >= 10)
                {
                    naum++;
                    res = res.Insert(0, (sum - 10).ToString());
                }
                else
                {
                    naum = 0;
                    res = res.Insert(0, sum.ToString());
                }

                if (i == 0 && naum != 0)
                {
                    res = res.Insert(0, naum.ToString());
                }
            }

            res = res.TrimStart(new char[] { '0' });

            return res;
        }

        private static string SumTwoNumbers(string num1, string num2)
        {
            if (num1.Length > num2.Length)
            {
                num2 = RoundUpWithZeroes(num2, num1.Length - num2.Length);
            }
            else if (num1.Length < num2.Length)
            {
                num1 = RoundUpWithZeroes(num1, num2.Length - num1.Length);
            }

            string res = string.Empty;
            int naum = 0;

            for (int i = num1.Length - 1; i >= 0; i--)
            {
                int currNumberNum1 = int.Parse(num1[i].ToString());
                int currNumberNum2 = int.Parse(num2[i].ToString());

                int sum = currNumberNum1 + currNumberNum2 + naum;
                naum = 0;

                if (sum >= 10)
                {
                    naum++;
                    res = res.Insert(0, (sum - 10).ToString());
                }
                else
                {
                    naum = 0;
                    res = res.Insert(0, sum.ToString());
                }

                if (i == 0 && naum != 0)
                {
                    res = res.Insert(0, naum.ToString());
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
