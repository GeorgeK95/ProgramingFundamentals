using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Odd_Occurrences
{
    class Program
    {

        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ').ToArray();
            words = ToLower(words);

            Dictionary<string, int> dict = PerambulateWords(words);

            PrintDict(dict);
        }

        private static string[] ToLower(string[] words)
        {
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].ToLower();
            }

            return words;
        }

        private static void PrintDict(Dictionary<string, int> dict)
        {
            var results = new List<string>();

            foreach (var pair in dict)
            {
                if (IsOdd(pair))
                {
                    results.Add(pair.Key);
                }
            }
            Console.WriteLine(string.Join(", ", results));
        }

        private static bool IsOdd(KeyValuePair<string, int> item)
        {
            if (item.Value % 2 == 0)
            {
                return false;
            }

            return true;
        }

        private static Dictionary<string, int> PerambulateWords(string[] words)
        {
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                if (wordsCount.ContainsKey(words[i]))
                {
                    wordsCount[words[i]] += 1;
                }
                else
                {
                    wordsCount.Add(words[i], 1);
                }
            }

            return wordsCount;
        }
    }
}
