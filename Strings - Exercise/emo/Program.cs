using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace emo
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "astalavista baby";
            string patt = "sta";

            for (int i = 0; i < 3; i++)
            {
                int index = patt.Length / 2;
                patt = patt.Remove(index, 1);
                Console.WriteLine(patt);
            }

            Console.WriteLine(patt);
            Console.WriteLine(patt.Length);

        }
    }
}
