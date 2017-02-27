using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.Cubic_Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            int m = int.Parse(Console.ReadLine());

            while (!line.Equals("Over!"))
            {
                if (IsInputValid(line, m))
                {
                    string[] values = GetValues(line, m);

                    string beforeText = values[0];
                    string text = values[1];
                    string afterText = values[2];

                    string coded = GetMessage(beforeText, text, afterText);

                    Print(text, coded);
                }

                line = Console.ReadLine();
                if (!line.Equals("Over!"))
                {
                    m = int.Parse(Console.ReadLine());
                }
               
            }
        }

        private static void Print(string text, string coded)
        {
            Console.WriteLine($"{text} == {coded}");
        }

        private static string GetMessage(string beforeText, string text, string afterText)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < beforeText.Length; i++)
            {
                int index = int.Parse(beforeText[i].ToString());

                if (index >= 0 && index < text.Length)
                {
                    sb.Append(text[index]);
                }
                else
                {
                    sb.Append(' ');
                }

            }

            for (int i = 0; i < afterText.Length; i++)
            {
                if (afterText[i] >= 48 && afterText[i] <= 57)
                {
                    int index = int.Parse(afterText[i].ToString());

                    if (index >= 0 && index < text.Length)
                    {
                        sb.Append(text[index]);
                    }
                    else
                    {
                        sb.Append(' ');
                    }
                }
            }

            return sb.ToString();
        }

        private static string[] GetValues(string line, int m)
        {
            int startIndex = 0;

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] < 48 || line[i] > 57)
                {
                    startIndex = i;
                    break;
                }
            }

            string bt = GetBeforeTextLine(line, startIndex);
            string t = GetTextLine(line, startIndex, m);
            string at = GetAfterTextLine(line, startIndex, m);

            string[] retVal = new string[] { bt, t, at };
            return retVal;
        }

        private static bool IsInputValid(string line, int m)
        {
            int startIndex = 0;

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] < 48 || line[i] > 57)
                {
                    startIndex = i;
                    break;
                }
            }

            string bt = GetBeforeTextLine(line, startIndex);
            string t = GetTextLine(line, startIndex, m);
            string at = GetAfterTextLine(line, startIndex, m);

            if (BTCheck(bt) || TCheck(t) || ATCheck(at))
            {
                return false;
            }

            return true;
        }

        private static bool ATCheck(string at)
        {
            string pattern = @"[A-Za-z]";
            Regex reg = new Regex(pattern);
            return reg.IsMatch(at);
        }

        private static bool TCheck(string t)
        {
            string pattern = @"[^A-Za-z]";
            Regex reg = new Regex(pattern);
            return reg.IsMatch(t);
        }

        private static bool BTCheck(string bt)
        {
            string pattern = @"[^\d]";
            Regex reg = new Regex(pattern);
            return reg.IsMatch(bt);
        }

        private static string GetAfterTextLine(string line, int startIndex, int m)
        {
            return line.Substring(startIndex + m);
        }

        private static string GetTextLine(string line, int startIndex, int m)
        {
            return line.Substring(startIndex, m);
        }

        private static string GetBeforeTextLine(string line, int startIndex)
        {
            return line.Substring(0, startIndex);
        }
    }
}
