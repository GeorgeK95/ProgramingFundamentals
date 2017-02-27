using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] separators = new char[] { ' ', '!', '.', ',', '\\', '/', '?' };
            string[] text = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
            List<string> words = new List<string>();

            for (int i = 0; i < text.Length; i++)
            {
                string currWord = text[i];

                if (IsPalindrome(currWord) && !words.Contains(currWord))
                {
                    words.Add(currWord);
                }
            }

            Print(words);

        }

        private static void Print(List<string> words)
        {
            words = words.OrderBy(x => x).ToList();

            for (int i = 0; i < words.Count; i++)
            {
                if (i == words.Count - 1)
                {
                    Console.Write(words[i]);
                }
                else
                {
                    Console.Write(words[i] + ", ");
                }
            }
        }

        private static bool IsPalindrome(string currWord)
        {
            string frontToEnd = GetString(currWord, true);
            string backToFront = GetString(currWord, false);

            if (frontToEnd.Equals(backToFront))
            {
                return true;
            }

            return false;
        }

        private static string GetString(string currWord, bool v)
        {
            StringBuilder sb = new StringBuilder();

            if (v)
            {
                for (int i = 0; i < currWord.Length; i++)
                {
                    sb.Append(currWord[i]);
                }
            }
            else
            {
                for (int i = currWord.Length - 1; i >= 0; i--)
                {
                    sb.Append(currWord[i]);
                }
            }
            

            return sb.ToString();
        }
    }
}
