using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Unicode_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            System.Text.UTF32Encoding encoding = new System.Text.UTF32Encoding();
            byte[] bytes = encoding.GetBytes(s);

            for (int i2 = 0; i2 < bytes.Length; i2 += sizeof(int))
            {
                Console.Write("\\u00" + BitConverter.ToInt32(bytes, i2) + " ");
            }
        }
    }
}
