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
            string text = Console.ReadLine();//@"<ul> <li> <a href=""http://softuni.bg"" > SoftUni</a></ li > </ ul >";
            string pattern = @"<a.*href=(.*)>(.*)<\/a>";
            Regex regEx = new Regex(pattern);
           // Console.WriteLine(regEx.IsMatch(text));


            while (!text.Equals("end"))
            {
                string res = regEx.Replace(text, @"[URL href=$1]$2[/URL]");
                Console.WriteLine(res);
                text = Console.ReadLine();
            }
        }
    }
}
