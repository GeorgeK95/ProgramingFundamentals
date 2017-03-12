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
            char[] separators = new char[] { '.', ',', ':', ';', '(', ')', '[', ']', '\"', '\'', '\\', '/', '!', '?', ' ', '.' };
            string text = Console.ReadLine().ToLower();
            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            var test = words.Where(x => x.Length < 5).Distinct().OrderBy(x => x);
            Console.WriteLine(string.Join(", ", test));
        }
    }
}
