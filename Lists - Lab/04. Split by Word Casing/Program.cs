using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Split_by_Word_Casing
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] separators = new char[] { ',', ';', ':', '.', '!', '(', ')', '\"', '\\', '\'', '\\', '/', '[', ']', ',', ' ' };
            string input = Console.ReadLine();
            string[] words = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            List<string> low = new List<string>();
            List<string> up = new List<string>();
            List<string> mixed = new List<string>();

            for (int i = 0; i < words.Length; i++)
            {
                string type = GetWordType(words[i]);

                switch (type)
                {
                    case "up":
                        up.Add(words[i]);
                        break;
                    case "down":
                        low.Add(words[i]);
                        break;
                    case "mixed":
                        mixed.Add(words[i]);
                        break;
                }
            }

            Print(low, mixed, up);
        }

        private static string GetWordType(string v)
        {
            if (IsAllUpper(v))
            {
                return "up";
            }
            else if (IsAllLower(v))
            {
                return "down";
            }

            return "mixed";
        }

        private static bool IsAllLower(string v)
        {
            for (int i = 0; i < v.Length; i++)
            {
                if (!Char.IsLower(v[i]))
                    return false;
            }

            return true;
        }

        static bool IsAllUpper(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (!Char.IsUpper(input[i]))
                    return false;
            }

            return true;
        }

        private static void Print(List<string> low, List<string> mixed, List<string> up)
        {
            Console.WriteLine($"Lower-case: {string.Join(", ", low)}");
            Console.WriteLine($"Mixed-case: {string.Join(", ", mixed)}");
            Console.WriteLine($"Upper-case: {string.Join(", ", up)}");
        }
    }
}
