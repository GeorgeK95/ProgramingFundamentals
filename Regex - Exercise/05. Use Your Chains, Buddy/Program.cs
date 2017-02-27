using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Demo
{
    class Program
    {
        static Dictionary<char, char> letters = new Dictionary<char, char>();

        static void Main(string[] args)
        {
            FillDictionary();
            string text = Console.ReadLine();
            StringBuilder sb = FillStringBuilder(text);
            string treatenText = TreatText(sb);
            StringBuilder sb1 = Descriptins(treatenText);
            Console.WriteLine(sb1.ToString());
        }

        private static StringBuilder Descriptins(string treatenText)
        {
            StringBuilder sb1 = new StringBuilder();

            for (int i = 0; i < treatenText.Length; i++)
            {
                sb1.Append(letters[treatenText[i]]);
            }

            return sb1;
        }

        private static string TreatText(StringBuilder sb)
        {
            string patt = @"[^a-z\d]";
            string str = sb.ToString();
            str = Regex.Replace(str, patt, " ");
            str = Regex.Replace(str, @"\s{2,}", " ");
            str = Regex.Replace(str, @"/^ +/", "");
            str = Regex.Replace(str, @"[ \t]+$", "");

            return str;
        }

        private static StringBuilder FillStringBuilder(string text)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                int a = text.IndexOf("<p>", i);
                int b = text.IndexOf("</p>", i);

                if (a != -1 && b != -1)
                {
                    string inTag = text.Substring(a + 3, b - a - 3);
                    sb.Append(inTag);
                    i = b;
                }
                else
                {
                    break;
                }
            }

            return sb;
        }

        private static void FillDictionary()
        {
            char[] aToM = "abcdefghijklm".ToArray();
            char[] nToZ = "nopqrstuvwxyz".ToArray();
            char[] number = "0123456789".ToArray();

            int n = aToM.Length;

            for (int i = 0; i < n; i++)
            {
                letters.Add(aToM[i], nToZ[i]);
            }
            for (int i = 0; i < n; i++)
            {
                letters.Add(nToZ[i], aToM[i]);
            }
            for (int i = 0; i < number.Length; i++)
            {
                letters.Add(number[i], number[i]);
            }
            letters.Add(' ', ' ');
        }
    }
}
