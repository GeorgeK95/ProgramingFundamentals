using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Compare_Char_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] array1 = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
            char[] array2 = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();

            PrintInOrder(array1, array2);
        }

        private static void PrintInOrder(char[] array1, char[] array2)
        {
            int lenght = Math.Max(array1.Length, array2.Length);

            for (int i = 0; i < lenght; i++)
            {
                if (array1[i] != array2[i])
                {
                    PrintEarlier(array1, array2, i);
                    break;
                }
                else
                {
                    if (i == array1.Length - 1)
                    {
                        PrintEarlier(array1);
                        PrintEarlier(array2);
                        break;
                    }
                    if (i == array2.Length - 1)
                    {
                        PrintEarlier(array2);
                        PrintEarlier(array1);
                        break;
                    }
                }
            }

        }

        private static void PrintEarlier(char[] array)
        {

            for (int index = 0; index < array.Length; index++)
            {
                Console.Write(array[index]);
            }

            Console.WriteLine();

        }

        private static void PrintEarlier(char[] array1, char[] array2, int i)
        {
            if (array1[i] < array2[i])
            {
                PrintEarlier(array1);
                PrintEarlier(array2);
            }
            else
            {
                PrintEarlier(array2);
                PrintEarlier(array1);
            }
        }
    }
}
