using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.Query_Mess
{
    class Program
    {
        static Dictionary<string, List<string>> pairs = new Dictionary<string, List<string>>();

        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            while (!text.Equals("END"))
            {
                text = text.Replace("?", "&");
                text = text.Replace("%20", " ");
                text = text.Replace("+", " ");
                string[] splittedByAmpersand = text.Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries);

                MakeResult(splittedByAmpersand);
                PrintResult();

                pairs = new Dictionary<string, List<string>>();
                text = Console.ReadLine();
            }

        }

        private static void PrintResult()
        {
            foreach (var pair in pairs)
            {
                string a = pair.Key;

                Console.Write(a + "=[");

                List<string> current = new List<string>();
                foreach (var item in pair.Value)
                {
                    string b = item;
                    current.Add(b);
                }

                Console.Write(string.Join(", ", current) + "]");

            }
            Console.WriteLine();

        }

        private static void MakeResult(string[] splittedByAmpersand)
        {

            foreach (var str in splittedByAmpersand)
            {
                if (str.Contains("="))
                {
                    int index = str.IndexOf("=");

                    string key = str.Substring(0, index);
                    string value = str.Substring(index + 1);

                    AddToDict(key, value);
                }

            }
        }

        private static void AddToDict(string key, string value)
        {
            key = TreatKeyOrValue(key);
            value = TreatKeyOrValue(value);

            if (!pairs.ContainsKey(key))
            {
                List<string> current = new List<string>();
                current.Add(value);
                pairs.Add(key, current);
            }
            else
            {
                List<string> old = pairs[key];
                old.Add(value);
                pairs[key] = old;
            }
        }

        private static string TreatKeyOrValue(string str)
        {
            str = RemoveSpacesAndTabsFromBeginningAndEnd(str);
            str = ManyWhiteSpacesToOne(str);
            return str;
        }

        private static string ManyWhiteSpacesToOne(string value)
        {
            string pat = @"\s{2,}";
            Match res = Regex.Match(value, pat);
            string replacedOne = Regex.Replace(value, pat, " ");

            return replacedOne;
        }

        private static string RemoveSpacesAndTabsFromBeginningAndEnd(string value)
        {
            int st = 0;
            int en = 0;

            for (int i = 0; i < value.Length; i++)
            {
                if (value[i] != ' ' && value[i] != '\t')
                {
                    st = i;
                    break;
                }
            }

            for (int i = value.Length - 1; i >= 0; i--)
            {
                if (value[i] != ' ' && value[i] != '\t')
                {
                    en = i;
                    break;
                }
            }

            string res = value.Substring(st, en - st + 1);
            return res;
        }

    }
}
