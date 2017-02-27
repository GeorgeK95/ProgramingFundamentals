using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Short_Words_Sorted
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] separators = new char[] { '.', ',', ':', ';', '(', ')', '[', ']', '"', '\'', '\\', '/', '!', '?', ' '};
            string[] text = Console.ReadLine().Split(separators).ToArray();

            SortedSet<string> setOfWords = GetSetOfWords(text);

            PrintSetOfWords(setOfWords);
        }

        private static void PrintSetOfWords(SortedSet<string> setOfWords)
        {
            List<string> forPrint = new List<string>();

            for (int i = 0; i < setOfWords.Count; i++)
            {
                if (i == setOfWords.Count - 1 || i == 0)
                {
                    Console.Write(setOfWords.ElementAt(i));
                }
                else
                {
                    Console.Write(setOfWords.ElementAt(i) + ", ");
                }
            }

        }

        private static SortedSet<string> GetSetOfWords(string[] text)
        {
            SortedSet<string> sortedSetOfWords = new SortedSet<string>();

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].Length < 5 && !sortedSetOfWords.Contains(text[i]))
                {
                    sortedSetOfWords.Add(text[i].ToLower());
                }
            }

            return sortedSetOfWords;
        }
    }
}
