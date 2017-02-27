using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _03.Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = File.ReadAllText(@"C:\Users\Georgi\Downloads\SU\FDLab\Resources\03. Word Count\words.txt").Split(' ');
            string[] text = File.ReadAllText(@"C:\Users\Georgi\Downloads\SU\FDLab\Resources\03. Word Count\text.txt").ToLower().Split(new char[] { '\n', '\r', ' ', '.', ',', '!', '?', '-' }, StringSplitOptions.RemoveEmptyEntries);


            Dictionary<string, int> meets = GetMeetTimes(text, words);

            WriteInFile(meets);
        }

        private static void WriteInFile(Dictionary<string, int> meets)
        {
            foreach (var item in meets.OrderByDescending(x => x.Value))
            {
                string line = item.Key + " - " + item.Value + Environment.NewLine;
                File.AppendAllText(@"C:\Users\Georgi\Downloads\SU\FDLab\Resources\03. Word Count\output.txt", line);
            }
        }

        private static Dictionary<string, int> GetMeetTimes(string[] text, string[] words)
        {
            Dictionary<string, int> wordCounter = new Dictionary<string, int>();

            for (int wordIndex = 0; wordIndex < text.Length; wordIndex++)
            {
                for (int wordInTextIndex = 0; wordInTextIndex < words.Length; wordInTextIndex++)
                {
                    if (text[wordIndex].ToLower().Equals(words[wordInTextIndex].ToLower()))
                    {
                        wordCounter = AddToWordCounter(wordCounter, text[wordIndex]);
                    }
                }
            }

            return wordCounter;
        }

        private static Dictionary<string, int> AddToWordCounter(Dictionary<string, int> wordCounter, string word)
        {
            if (!wordCounter.ContainsKey(word))
            {
                wordCounter.Add(word, 1);
            }
            else
            {
                wordCounter[word] += 1;
            }

            return wordCounter;
        }
    }
}
