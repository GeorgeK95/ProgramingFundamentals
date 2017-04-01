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
            List<string> palindromes = new List<string>();

            for (int i = 0; i < text.Length; i++)
            {
                if (IsWordPalindrome(text[i]))
                {
                    palindromes.Add(text[i]);
                }
            }

            palindromes = palindromes.OrderBy(x => x).ToList();
            Console.WriteLine(string.Join(", ", palindromes.Distinct()));
        }


        private static bool IsWordPalindrome(string v)
        {
            string reversed = Reverse(v);
            return v.Equals(reversed);
        }
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
