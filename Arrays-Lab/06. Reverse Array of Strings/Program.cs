using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Reverse_Array_of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] stringArray = Console.ReadLine().Split(' ').ToArray();
            PrintReversedString(stringArray);
        }

        private static void PrintReversedString(string[] stringArray)
        {
            Array.Reverse(stringArray);

            for (int i = 0; i < stringArray.Length; i++)
            {
                Console.Write(stringArray[i] + " ");
            }

        }
    }
}
