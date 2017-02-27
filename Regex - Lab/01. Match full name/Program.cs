using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01.Match_full_name
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = "[A-Z][a-z]+ [A-Z][a-z]+";
            Regex regEx = new Regex(pattern);

            Console.WriteLine(regEx.IsMatch(text));
        }
    }
}
