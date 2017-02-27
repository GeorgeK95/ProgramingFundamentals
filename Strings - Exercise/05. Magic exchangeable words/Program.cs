using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Magic_exchangeable_words
{
    class Program
    {
        static string str_1;
        static string str_2;
        static Dictionary<char, char> letters = new Dictionary<char, char>();
        static bool isExchangleable = true;

        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            str_1 = line.Split(' ')[0];
            str_2 = line.Split(' ')[1];

            ChangeStrings();
            IterateToShorterString();
            IterateFromShorterStringToEndOfLongerOne();

            PrintResult();
        }

        private static void PrintResult()
        {
            if (isExchangleable)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }

        private static void IterateFromShorterStringToEndOfLongerOne()
        {
            if (str_1.Length - str_2.Length != 0)
            {
                int index = str_2.Length;
                for (int i = 0; i < (str_1.Length - str_2.Length); i++)
                {
                    char charStr1 = str_1[index];
                    index++;

                    if (!letters.ContainsKey(charStr1))
                    {
                        isExchangleable = false;
                        break;
                    }

                }
            }

        }

        private static void IterateToShorterString()
        {

            for (int i = 0; i < str_2.Length; i++)
            {
                char charStr1 = str_1[i];
                char charStr2 = str_2[i];

                if (!letters.ContainsKey(charStr1))
                {
                    letters.Add(charStr1, charStr2);
                }
                else
                {
                    if (!letters[charStr1].Equals(charStr2))
                    {
                        isExchangleable = false;
                        break;
                    }
                }
            }
        }

        private static void ChangeStrings()
        {
            if (str_2.Length > str_1.Length)
            {
                string a = str_2;
                str_2 = str_1;
                str_1 = a;
            }
        }
    }
}
