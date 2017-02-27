using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Count_Substring_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string subString = Console.ReadLine();
            int count = GetSubstringOccurrences(text, subString);

            Console.WriteLine(count);
        }

        private static int GetSubstringOccurrences(string text, string subString)
        {
            int p = 0;

            for (int i = 0; i < text.Length - subString.Length; i++)
            {
                string opalq = text.Substring(i, subString.Length);

                if (subString.ToLower().Equals(opalq.ToLower()))
                {
                    p++;
                }
            }

            return p;
        }
    }
}
