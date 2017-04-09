using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01.Replace_a_tag
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while(!input.Equals("end"))
            {
                Regex reg = new Regex(@"<a.*?href=""(.*)"">(.*)<\/a>");
                input = reg.Replace(input, @"[URL href=""$1""]$2[/URL]");
                Console.WriteLine(input);
                input = Console.ReadLine();
            }

            
        }
    }
}
