using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SoftUni_Coffee_Supplies
{
    class Program
    {
        private static Dictionary<string, string> personCoffee = new Dictionary<string, string>();
        private static Dictionary<string, int> coffeeQuantity = new Dictionary<string, int>();

        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string firstDelimer = input.Split()[0];
            string secondDelimer = input.Split()[1];

            while (true)
            {
                string coffee = Console.ReadLine();

                if (coffee.Equals("end of info"))
                {
                    break;
                }

                if (coffee.Contains(firstDelimer))
                {
                    string personName = GetPersonName(coffee, firstDelimer);
                    string coffeeType = GetTypeOfCoffee(coffee, firstDelimer);

                    personCoffee.Add(personName, coffeeType);
                    AddInfo(coffeeType, 0);
                }
                else
                {
                    string coffeeType = GetAnotherTypeOfCoffee(coffee, secondDelimer);
                    int quantity = GetCoffeeQuantity(coffee, secondDelimer);

                    AddInfo(coffeeType, quantity);
                }

            }

            PrintFirstResult();

            while (true)
            {
                string line = Console.ReadLine();

                if (line.Equals("end of week"))
                {
                    break;
                }

                string personName = GetPersonName(line);
                int quantity = GetQuantity(line);

                MakeOrder(personName, quantity);
            }

            PrintSecondResult();
        }

        private static void PrintFirstResult()
        {
            foreach (var item in coffeeQuantity)
            {
                if (item.Value <= 0)
                {
                    Console.WriteLine($"Out of {item.Key}");
                }
            }
        }

        private static void PrintSecondResult()
        {
            var list = coffeeQuantity.Where(x => x.Value > 0).ToList();
            PrintCoffeeLeft(list);

            PrintForPart(list);
        }

        private static void PrintForPart(List<KeyValuePair<string, int>> list)
        {
            Console.WriteLine("For:");
            foreach (var item in list.OrderBy(x => x.Key))
            {
                foreach (var item2 in personCoffee.OrderByDescending(x => x.Key))
                {
                    if (item.Key.Equals(item2.Value))
                    {
                        Console.WriteLine($"{item2.Key} {item2.Value}");
                    }
                }

            }
        }

        private static void PrintCoffeeLeft(List<KeyValuePair<string, int>> list)
        {
            Console.WriteLine("Coffee Left:");

            foreach (var item in list.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{item.Key} {item.Value}");
            }
        }

        private static void MakeOrder(string personName, int quantity)
        {
            string type = personCoffee[personName];
            int count = coffeeQuantity[type];
            count -= quantity;
            coffeeQuantity[type] = count;



            if (count <= 0)
            {
                Console.WriteLine($"Out of {type}");
            }
        }

        private static int GetQuantity(string line)
        {
            string[] splitted = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return int.Parse(splitted[1]);
        }

        private static string GetPersonName(string line)
        {
            string[] splitted = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return splitted[0];
        }

        private static string GetAnotherTypeOfCoffee(string coffee, string delimer2)
        {

            string[] splitted = coffee.Split(new string[] { delimer2 }, StringSplitOptions.RemoveEmptyEntries);
            return splitted[0];
        }

        private static int GetCoffeeQuantity(string coffee, string delimer2)
        {
            string[] splitted = coffee.Split(new string[] { delimer2 }, StringSplitOptions.RemoveEmptyEntries);
            return int.Parse(splitted[1]);
        }

        private static string GetTypeOfCoffee(string coffee, string delimer)
        {
            string[] splitted = coffee.Split(new string[] { delimer }, StringSplitOptions.RemoveEmptyEntries);
            return splitted[1];
        }

        private static void AddInfo(string coffeeType, int quantity)
        {
            if (coffeeQuantity.ContainsKey(coffeeType))
            {
                coffeeQuantity[coffeeType] += quantity;
            }
            else
            {
                coffeeQuantity.Add(coffeeType, quantity);
            }
        }

        private static string GetPersonName(string coffee, string delimer1)
        {
            string[] splitted = coffee.Split(new string[] { delimer1 }, StringSplitOptions.RemoveEmptyEntries);
            return splitted[0];
        }
    }
}
