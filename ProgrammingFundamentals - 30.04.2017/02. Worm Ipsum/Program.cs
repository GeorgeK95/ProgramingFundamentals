using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Worm_Ipsum
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();

            while (!line.Equals("Worm Ipsum"))
            {
                if (IsValid(line))
                {
                    ThreadLine(line);
                }

                line = Console.ReadLine();
            }
        }

        private static void ThreadLine(string line)
        {
            List<char> separators = GetSeparators(line);
            List<string> words = GetWords(line);
            string fixedLine = GetFixedLine(line, separators, words);
            Console.WriteLine(fixedLine);
        }

        private static List<string> GetWords(string line)
        {
            List<string> words = line.Split(new char[] { '.', ',', '\'', '"', ';', '/', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            for (int i = 0; i < words.Count; i++)
            {
                char mostCommon = GetMostCommonChar(words[i]);

                if (mostCommon != '\0')
                {
                    words[i] = new string(mostCommon, words[i].Length);
                }
            }

            return words;
        }

        private static List<char> GetSeparators(string line)
        {
            List<char> separators = new List<char>();

            foreach (var currentSeparator in line)
            {
                if (currentSeparator == ',' || currentSeparator == '.' || currentSeparator == ' ' || currentSeparator == '\'' || currentSeparator == '\"' || currentSeparator == ',')
                {
                    separators.Add(currentSeparator);
                }
            }

            return separators;
        }

        private static string GetFixedLine(string line, List<char> separators, List<string> words)
        {
            StringBuilder newLine = new StringBuilder();
            int index = 0;

            foreach (var currentWord in words)
            {
                newLine.Append(currentWord);
                newLine.Append(separators[index]);

                if (separators[index] == ',')
                {
                    index++;
                    newLine.Append(separators[index]);
                }
                index++;
            }

            return newLine.ToString();
        }

        private static bool IsValid(string line)
        {
            if (line[0] < 65 || line[0] > 90)
            {
                return false;
            }
            if (line[line.Length - 1] != '.')
            {
                return false;
            }

            string[] spl = line.Split('.');
            if (spl.Length > 2)
            {
                return false;
            }


            return true;
        }

        private static void PrintSentence(string line)
        {
            StringBuilder total = new StringBuilder();
            StringBuilder sb = new StringBuilder();

            foreach (var bukfa in line)
            {
                if (bukfa == ',' || bukfa == ' ' || bukfa == '.')
                {
                    //duma
                    char common = GetMostCommonChar(sb.ToString());
                    if (common != '\0')
                    {
                        total.Append(new string(common, sb.ToString().Length));
                        total.Append(bukfa);
                    }
                    else
                    {
                        total.Append(sb);
                    }
                    sb = new StringBuilder();

                }

                sb.Append(bukfa);

            }

            Console.WriteLine(sb.ToString());
        }

        private static char GetMostCommonChar(string word)
        {

            Dictionary<char, int> letters = new Dictionary<char, int>();

            foreach (var currentChar in word)
            {
                if (letters.ContainsKey(currentChar))
                {
                    letters[currentChar]++;
                }
                else
                {
                    letters.Add(currentChar, 1);
                }
            }

            int max = int.MinValue;
            char best = '\0';

            foreach (var currLet in letters)
            {
                if (letters[currLet.Key] > max && letters[currLet.Key] >= 2)
                {
                    best = currLet.Key;
                    max = letters[currLet.Key];
                }
            }

            return best;
        }

    }
}
