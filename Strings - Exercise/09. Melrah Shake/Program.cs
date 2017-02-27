using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Melrah_Shake
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] a = new string[] { "pederas" , "dva", "tri" };
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < a.Length; i++)
            {
                sb.Append(a[i]);
                sb.Append(" ");
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
