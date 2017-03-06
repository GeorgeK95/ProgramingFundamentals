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
            int n = int.Parse(Console.ReadLine());
            bool[] sieve = BoolValuesReady(n);

            for (int i = 0; i < sieve.Length; i++)
            {
                if (sieve[i])
                {
                    Console.Write(i + " ");
                    sieve = MakeAllOthersFalse(sieve, i);
                }
            }

        }

        private static bool[] BoolValuesReady(int n)
        {
            bool[] arr = new bool[n + 1];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = true;
            }

            arr[0] = false;
            arr[1] = false;

            return arr;
        }

        private static bool[] MakeAllOthersFalse(bool[] sieve, int index)
        {
            for (int i = index; i < sieve.Length; i += index)
            {
                sieve[i] = false;
            }

            return sieve;
        }
    }
}
