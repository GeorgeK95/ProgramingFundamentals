using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Sieve_of_Eratosthenes
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            bool[] flag = new bool[num + 1];

            flag = SetFlagTrue(flag);

            PrintSieveOfEratosthenes(num, flag);
        }

        private static bool[] SetFlagTrue(bool[] flag)
        {
            for (int i = 2; i < flag.Length; i++)
            {
                flag[i] = true;
            }

            return flag;
        }

        private static void PrintSieveOfEratosthenes(int num, bool[] flag)
        {
            for (int i = 2; i < num; i++)
            {
                if (flag[i])
                {

                    for (long p = 2; (p * i) <= num; p++)
                    {
                        flag[p * i] = false;
                    }

                }
            }

            PrintResult(flag);
        }

        private static void PrintResult(bool[] flag)
        {
            for (int i = 0; i < flag.Length; i++)
            {
                if (flag[i])
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
