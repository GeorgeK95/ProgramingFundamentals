using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Triples_of_Latin_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int index1 = 0; index1 < number; index1++)
            {
                for (int index2 = 0; index2 < number; index2++)
                {
                    for (int index3 = 0; index3 < number; index3++)
                    {
                        Console.WriteLine((char)(index1+ 97) + "" + (char)(index2 + 97) + "" + (char)(index3 + 97));
                    }

                }

            }
        }
    }
}
