using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int matches = int.MinValue;
            int key = 0;

            for (int i = 0; i < inputList.Count - 1; i++)
            {
                int count = 0;

                for (int j = i + 1; j < inputList.Count; j++)
                {
                    if (inputList[i] == inputList[j])
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
                   
                }
                if (count > matches)
                {
                    matches = count;
                    key = inputList[i];
                }

            }

            for (int i = 0; i < matches + 1; i++)
            {
                Console.Write(key + " ");
            }
        }
    }
}
