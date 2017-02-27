using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.AndreyAndBilliard
{
    class Class1
    {

        static Dictionary<string, double> entities = new Dictionary<string, double>();
        static SortedSet<Order> orders = new SortedSet<Order>();

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Add();
            }

            string clientsList = Console.ReadLine();//Mira-Sandwich,1

            while (!clientsList.Equals("end of clients"))
            {
                MakeOrders(clientsList);
                clientsList = Console.ReadLine();     
            }

            PrintResult();
        }

        private static void PrintResult()
        {
            foreach (var item in orders)
            {
                Console.WriteLine(item.clientName);
                Console.WriteLine($"-- {item.clientOrder} - {item.quantity}");
                Console.WriteLine("Bill: " + item.clientBill);
            }
            Console.WriteLine("Total bill: " + GetTotalBill());
        }

        private static double GetTotalBill()
        {
            double total = 0;

            for (int i = 0; i < orders.Count; i++)
            {
                total += orders.ElementAt(i).clientBill;
            }

            return total;
        }

        private static void MakeOrders(string clientsList)
        {
            string[] split = clientsList.Split(','); //[mira-sandwich], [1]
            string[] split2 = split[0].Split('-');// [mira] [sandwich]

            string clientName = split2[0];
            string stockName = split2[1];
            int quantity = int.Parse(split[1]);


            if (entities.ContainsKey(stockName))
            {
                double price = entities[stockName];
                double bill = price * quantity;

                Order newOrder = new Order(clientName, stockName, quantity, bill);

                orders.Add(newOrder);
            }

        }

        private static void Add()
        {
            string line = Console.ReadLine(); //"Cola-1.25"

            string productName = line.Split('-')[0];
            double productPrice = double.Parse(line.Split('-')[1]);

            if (!entities.ContainsKey(productName))
            {
                entities.Add(productName, productPrice);
            }
            else
            {
                entities[productName] = productPrice;
            }
        }
    }

    class Order
    {
        public string clientName;
        public string clientOrder;
        public double quantity;
        public double clientBill;

        public Order(string name, string stock, double quantity, double bill)
        {
            this.clientName = name;
            this.clientOrder = stock;
            this.quantity = quantity;
            this.clientBill = bill;
        }
    }
}
