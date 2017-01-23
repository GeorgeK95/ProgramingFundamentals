using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _18.Different_Integers_Size
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger input = BigInteger.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();

            if (input >= -128 && input <= 127)
            {
                sb.Append("* sbyte\n");
            }
            if (input >= 0 && input <= 255)
            {
                sb.Append("* byte\n");
            }
            if (input >= -32768 && input <= 32767)
            {
                sb.Append("* short\n");
            }
            if (input >= 0 && input <= 65535)
            {
                sb.Append("* ushort\n");
            }
            if (input >= -2147483647 && input <= 2147483647)
            {
                sb.Append("* int\n");
            }
            if (input >= 0 && input <= 4294967295)
            {
                sb.Append("* uint\n");
            }
            if (input >= -9223372036854775808 && input <= 9223372036854775807)
            {
                sb.Append("* long\n");
            }

            if (sb.Length == 0)
            {
                Console.WriteLine("{0} can't fit in any type", input);
            }
            else
            {
                Console.WriteLine("{0} can fit in:", input);
                Console.WriteLine(sb);
            }
        }
    }
}
