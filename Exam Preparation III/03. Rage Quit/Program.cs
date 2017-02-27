using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.Rage_Quit
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine().ToUpper();
            MatchCollection mc = Regex.Matches(line, @"[^\d]+");
            MatchCollection mc2 = Regex.Matches(line, @"[\d]+");
            StringBuilder res = new StringBuilder();

            for (int i = 0; i < mc.Count; i++)
            {
                string text = mc[i].ToString();
                int num = int.Parse(mc2[i].ToString());

                for (int j = 0; j < num; j++)
                {
                    res.Append(text);
                }
            }

            var count = res.ToString().Distinct().Count();
            Console.WriteLine($"Unique symbols used: {count}");
            Console.WriteLine(res);
        }

    }
}
