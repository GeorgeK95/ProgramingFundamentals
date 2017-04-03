using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.AndreyAndBilliard
{
    class Client
    {
        public string name { get; set; }
        public Dictionary<string, int> orders { get; set; }
        public Client(string name, Dictionary<string, int> orders)
        {
            this.name = name;
            this.orders = orders;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, decimal> shop = new Dictionary<string, decimal>();
            List<Client> ordersList = new List<Client>();

            for (int i = 0; i < n; i++)
            {
                string[] stock = Console.ReadLine().Split('-');
                AddStockToShop(shop, stock);
            }

            string clientInput = Console.ReadLine();

            while (!clientInput.Equals("end of clients"))
            {
                string[] order = clientInput.Split(',');

                string name = GetName(order[0]);
                string product = GetProduct(order[0]);
                int quantity = GetQuantity(order[1]);
                Dictionary<string, int> orders = new Dictionary<string, int>();

                bool isValid = MakeOrders(shop, product, quantity, orders, ordersList, name);

                if (isValid)
                {
                    Client client = new Client(name, orders);
                    AddToOrdersList(client, ordersList);
                }

                clientInput = Console.ReadLine();
            }

            Print(shop, ordersList);
        }

        private static void AddToOrdersList(Client client, List<Client> ordersList)
        {
            bool nameExist = false;

            for (int i = 0; i < ordersList.Count; i++)
            {
                if (ordersList[i].name.Equals(client.name))
                {
                    nameExist = true;
                    var temp = new Dictionary<string, int>();
                    foreach (var order in client.orders.Keys)
                    {
                        if (ordersList[i].orders.ContainsKey(order))
                        {
                            ordersList[i].orders[order] += client.orders[order];
                        }
                        else
                        {
                            ordersList[i].orders.Add(order, client.orders[order]);
                        }
                    }
                }
            }

            if (!nameExist)
            {
                ordersList.Add(client);
            }
        }

        private static bool MakeOrders(Dictionary<string, decimal> shop, string product, int quantity, Dictionary<string, int> orders, List<Client> ordersList, string name)
        {
            if (shop.ContainsKey(product))
            {
                orders.Add(product, quantity);
                return true;
            }

            return false;
        }

        private static void Print(Dictionary<string, decimal> shop, List<Client> ordersList)
        {
            decimal totalBill = 0;

            foreach (var name in ordersList.OrderBy(x => x.name))
            {
                Console.WriteLine($"{name.name}");
                decimal currentClientBill = 0;

                foreach (var orders in name.orders)
                {
                    Console.WriteLine($"-- {orders.Key} - {orders.Value}");
                    currentClientBill += orders.Value * shop[orders.Key];
                }

                totalBill += currentClientBill;
                Console.WriteLine($"Bill: {currentClientBill:F2}");
            }

            Console.WriteLine($"Total bill: {totalBill:F2}");
        }

        private static int GetQuantity(string order)
        {
            return int.Parse(order);
        }

        private static string GetProduct(string order)
        {
            return order.Split('-')[1];
        }

        private static string GetName(string order)
        {
            return order.Split('-')[0];
        }

        private static void AddStockToShop(Dictionary<string, decimal> shop, string[] stock)
        {
            if (shop.ContainsKey(stock[0]))
            {
                shop[stock[0]] = decimal.Parse(stock[1]);
            }
            else
            {
                shop.Add(stock[0], decimal.Parse(stock[1]));
            }
        }
    }
}
