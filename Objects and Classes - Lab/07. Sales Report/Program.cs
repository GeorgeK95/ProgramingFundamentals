using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Sales_Report
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();

                string town = line.Split(' ')[0];
                string product = line.Split(' ')[1];
                double price = double.Parse(line.Split(' ')[2]);
                double quantity = double.Parse(line.Split(' ')[3]);

                Sale sale = new Sale(town, product, price, quantity);
            }

            var result = Sale.GetCities();

            PrintResult(result);
        }

        private static void PrintResult(SortedDictionary<string, double> result)
        {
            foreach (var city in result)
            {
                Console.WriteLine("{0} -> {1:f2}", city.Key, city.Value);
            }
        }
    }

    class Sale
    {
        static SortedDictionary<String, double> cities = new SortedDictionary<string, double>();

        string town;
        string product;
        double price;
        double quantity;

        public Sale(string town, string product, double price, double quantity)
        {
            this.town = town;
            this.product = product;
            this.price = price;
            this.quantity = quantity;

            AddToCities();
        }

        public Sale()
        {

        }

        private void AddToCities()
        {
            if (!cities.ContainsKey(this.town))
            {
                cities.Add(this.town, this.price * this.quantity);
            }
            else
            {
                double prev = cities[town];
                double current = this.price * this.quantity;
                current += prev;
                cities[town] = current;
            }
        }

        public static SortedDictionary<String, double> GetCities()
        {
            return cities;
        }
    }
}
