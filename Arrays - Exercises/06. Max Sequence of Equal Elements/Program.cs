using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string line1 = Console.ReadLine();
            int[] array = line1.Split(' ').Select(int.Parse).ToArray();
            int number = 0;
            int count = 1;

            for (int i = 0; i < array.Length; i++)
            {
                int tempNum = array[i];
                int tempCount = 1;

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] == array[i])
                    {
                        tempCount++;

                        if (tempCount > count)
                        {
                            count = tempCount;
                            number = tempNum;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            PrintResult(number, count);
        }

        private static void PrintResult(int number, int count)
        {
            for (int i = 0; i < count; i++)
            {
                if (i == count - 1)
                {
                    Console.Write(number);
                }
                else
                {
                    Console.Write(number + " ");
                }

            }
        }
    }
}
