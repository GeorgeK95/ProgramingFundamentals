using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            string resources = "";
            Dictionary<string, int> minerHolder = new Dictionary<string, int>();

            while (true)
            {
                resources = Console.ReadLine();

                if (resources.Equals("stop"))
                {
                    break;
                }

                int quantity = int.Parse(Console.ReadLine());
                AddResourses(minerHolder, resources, quantity);
            }

            Print(minerHolder);
        }

        private static void Print(Dictionary<string, int> minerHolder)
        {
            foreach (var pair in minerHolder)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }

        private static void AddResourses(Dictionary<string, int> minerHolder, string resources, int quantity)
        {
            if (minerHolder.ContainsKey(resources))
            {
                minerHolder[resources] += quantity;
            }
            else
            {
                minerHolder.Add(resources, quantity);
            }
        }

    }
}
