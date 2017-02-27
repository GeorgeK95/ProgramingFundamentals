using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02.Extract_sentences_by_keyword
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string text = Console.ReadLine(); ;
            char[] seps = new char[] { '.', '!', '?' };

            List<string> a = new List<string>();

            string[] spl = text.Split(seps, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < spl.Length; i++)
            {
                if (IfCurrentSentenceContainsWord(spl[i], word))
                {
                    a.Add(spl[i]);
                }
            }

            PrintList(a);
        }

        private static void PrintList(List<string> a)
        {
            foreach (var item in a)
            {
                Console.WriteLine(item);
            }
        }

        private static bool IfCurrentSentenceContainsWord(string v, string word)
        {
            string pattern = @"\W"; 
            string[] words = Regex.Split(v, pattern);

            if (words.Any(w => w.Equals(word)))
            {
                return true;
            }
            else
            {
                return false;
            }

            
        }

    }
}
