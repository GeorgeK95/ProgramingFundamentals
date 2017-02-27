using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] separators = new char[] { ' ', '/', '\\', '(', ')' };
            string text = Console.ReadLine();
            string[] splitted = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            List<string> names = AddSplittedNamesToList(splitted);
            names = RemoveInvalidNames(names);
            List<string> bestNames = GetBestNamesBySum(names);

            PrintBestNames(bestNames);
        }

        private static void PrintBestNames(List<string> bestNames)
        {
            foreach (var item in bestNames)
            {
                Console.WriteLine(item);
            }
        }

        private static List<string> GetBestNamesBySum(List<string> names)
        {
            List<string> bestNames = new List<string>();
            long bestSum = long.MinValue;

            for (int i = 0; i < names.Count; i++)
            {
                for (int j = i + 1; j < names.Count; j++)
                {
                    long currSum = names[i].Length + names[j].Length;

                    if (currSum > bestSum && (j - i == 1))
                    {
                        bestNames = new List<string>();
                        bestSum = currSum;
                        bestNames.Add(names[i]);
                        bestNames.Add(names[j]);
                    }
                }
            }

            return bestNames;

        }

        private static List<int> GetNamesLengths(List<string> names)
        {
            List<int> lengths = new List<int>();

            foreach (var item in names)
            {
                lengths.Add(item.Length);
            }

            return lengths;
        }

        private static List<string> RemoveInvalidNames(List<string> names)
        {
            int n = names.Count;

            for (int i = 0; i < n; i++)
            {
                string currName = names[i];
                if (!CheckIfCurrentNameIsValid(currName))
                {
                    names.Remove(currName);
                    n--;
                    i = 0;
                }
            }

            return names;
        }

        private static bool CheckIfCurrentNameIsValid(string currName)
        {
            if (CheckLength(currName))
            {
                string pattern = @"\b[A-Za-z]+[A-Za-z0-9_]+";
                Regex re = new Regex(pattern);

                bool isMatch = Regex.IsMatch(currName, pattern);

                if (isMatch)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool CheckLength(string currName)
        {
            if (currName.Length < 3 || currName.Length > 25)
            {
                return false;
            }
            return true;
        }

        private static List<string> AddSplittedNamesToList(string[] splitted)
        {
            List<string> names = new List<string>();

            foreach (var item in splitted)
            {
                names.Add(item);
            }

            return names;
        }

        private static void PrintArr(string[] splitted)
        {
            for (int i = 0; i < splitted.Length; i++)
            {
                Console.WriteLine(splitted[i]);
            }
        }
    }
}
