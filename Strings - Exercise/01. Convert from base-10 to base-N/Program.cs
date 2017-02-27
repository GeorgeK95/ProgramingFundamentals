using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _01.Convert_from_base_10_to_base_N
{
    class Program
    {
        static void Main(string[] args)
        {

            string line = Console.ReadLine();
            int base_n = int.Parse(line.Split(' ')[0]);
            BigInteger number = BigInteger.Parse(line.Split(' ')[1]);

            string result = DecimalToArbitrarySystem(number, base_n);
            Console.WriteLine(result);

        }
        public static string DecimalToArbitrarySystem(BigInteger decimalNumber, int radix)
        {
            const int BitsInLong = 64;
            const string Digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            if (radix < 2 || radix > 10)
                throw new ArgumentException("The radix must be >= 2 and <= " + Digits.Length.ToString());

            if (decimalNumber == 0)
                return "0";

            int index = BitsInLong - 1;

            if (decimalNumber < 0)
            {
                decimalNumber *= -1;
            }

            BigInteger currentNumber = decimalNumber;
            char[] charArray = new char[BitsInLong];

            while (currentNumber != 0)
            {
                int remainder = (int)(currentNumber % radix);
                charArray[index--] = Digits[remainder];
                currentNumber /= radix;
            }

            string result = new String(charArray, index + 1, BitsInLong - index - 1);

            if (decimalNumber < 0)
            {
                result = "-" + result;
            }

            return result;
        }
    }
}
