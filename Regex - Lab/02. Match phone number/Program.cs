using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02.Match_phone_number
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = @"\+\d{3}(\s|-)\d\1\d{3}\1\d{4}";
            Regex regEx = new Regex(pattern);

            /*string[] arr = new string[] { "359-2-222-2222", "+359/2/222/2222", "+359-2 222 2222 ", "+359 2-222-2222", "+359-2-222-222", "+359-2-222-22222", " +359 2 222 2222 ", "+359-2-222-2222" };

            for (int i = 0; i < arr.Length; i++)
            {
                Regex regEx = new Regex(pattern);

                Console.WriteLine(regEx.IsMatch(arr[i]));
            }*/

            Console.WriteLine(regEx.IsMatch(text));

        }
    }
}
