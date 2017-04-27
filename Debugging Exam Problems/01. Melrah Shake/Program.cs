using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01.Melrah_Shake
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            string pattern = Console.ReadLine();

            while (true)
            {
                if (GetCountOccurences(line, pattern) >= 2)
                {
                    line = RemoveFirstAndLast(line, pattern);
                    Console.WriteLine("Shaked it.");
                    pattern = EditPattern(pattern);

                    if (pattern.Length == 0)
                    {
                        Console.WriteLine("No shake.");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("No shake.");
                    break;
                }

            }

            Console.WriteLine(line);
        }
        private static string EditPattern(string pattern)
        {
            int index = pattern.Length / 2;
            return pattern.Remove(index, 1);
        }

        private static string RemoveFirstAndLast(string text, string pattern)
        {
            text = RemoveFirst(text, pattern);
            text = RemoveLast(text, pattern);
            return text;
        }

        private static string RemoveLast(string text, string pattern)
        {
            var regex = new Regex(Regex.Escape(pattern), RegexOptions.RightToLeft);
            string replace = regex.Replace(text, "", 1);
            return replace;
        }

        private static string RemoveFirst(string text, string pattern)
        {
            var regex = new Regex(Regex.Escape(pattern));
            string replace = regex.Replace(text, "", 1);
            return replace;
        }

        private static int GetCountOccurences(string text, string pattern)
        {
            Regex reg = new Regex(Regex.Escape(pattern));
            MatchCollection mc = reg.Matches(text);
            return mc.Count;
        }

    }
}
