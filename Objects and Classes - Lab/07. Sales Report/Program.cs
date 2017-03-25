using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Sales_Report
{
    class Sale
    {
        public string town { get; set; }
        public string product { get; set; }
        public double money { get; set; }

        public Sale()
        {

        }
        public Sale(string town, string product, double money)
        {
            this.town = town;
            this.product = product;
            this.money = money;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Sale> sales = new List<Sale>();

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                string[] splitted = line.Split();

                string town = splitted[0];
                string product = splitted[1];
                double price = double.Parse(splitted[2]);
                double quantity = double.Parse(splitted[3]);
                double total = price * quantity;

                Sale newSale = new Sale(town, product, total);
                AddToSales(newSale, sales);
            }

            Print(sales);
        }

        private static void AddToSales(Sale currentSale, List<Sale> sales)
        {
            bool contains = false;

            for (int i = 0; i < sales.Count; i++)
            {
                if (sales[i].town.Equals(currentSale.town))
                {
                    sales[i].money += currentSale.money;
                    contains = true;
                }
            }

            if (!contains)
            {
                sales.Add(currentSale);
            }
        }

        private static void Print(List<Sale> sales)
        {
            foreach (var sale in sales.OrderBy(x => x.town))
            {
                Console.WriteLine($"{sale.town} -> {string.Format("{0:0.00}", sale.money)}");
            }
        }
    }
}
