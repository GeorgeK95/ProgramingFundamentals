using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Rage_Quit
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            string result = MakeResult(line);
            int unique = GetUniqueCharacters(result);
            Console.WriteLine("Unique symbols used: {0}", unique);
            Console.WriteLine(result);
        }

        private static int GetUniqueCharacters(string result)
        {
            return result.ToString().Distinct().Count();
        }

        private static string MakeResult(string line)
        {
            StringBuilder res = new StringBuilder();
            StringBuilder sb = new StringBuilder();
            StringBuilder count = new StringBuilder();

            for (int i = 0; i < line.Length; i++)
            {
                char curr = line[i];

                if (curr < 48 || curr > 57)//not num
                {
                    if (count.Length != 0)
                    {
                        int times = int.Parse(count.ToString());

                        for (int j = 0; j < times; j++)
                        {
                            string str = sb.ToString().ToUpper();
                            res.Append(str);
                        }

                        sb = new StringBuilder();
                        count = new StringBuilder();
                    }
                    sb.Append(curr);

                }
                else
                {
                    count.Append(curr);
                }

            }
            if (count.Length != 0)
            {
                int times = int.Parse(count.ToString());

                for (int j = 0; j < times; j++)
                {
                    string str = sb.ToString().ToUpper();
                    res.Append(str);
                }

                sb = new StringBuilder();
            }

            string resString = string.Join("", res);
            return resString;
        }
    }
}
