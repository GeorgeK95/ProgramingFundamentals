using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02.Append_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<string> res = new List<string>();
            GetResultList(input, res);
            Console.WriteLine(string.Join(" ", res));
        }

        private static void GetResultList(string input, List<string> res)
        {
            StringBuilder current = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != '|')
                {
                    current.Append(input[i]);
                }
                else
                {
                    string[] tempArr = current.ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    res.InsertRange(0, tempArr);
                    current = new StringBuilder();
                }
            }

            string[] tempArr1 = current.ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            res.InsertRange(0, tempArr1);
        }
    }
}
