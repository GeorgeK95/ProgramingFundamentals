using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Book_Library
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Library lib = new Library("LibraryVip");

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();

                string[] splitted = line.Split(' ');

                string author = splitted[1];
                double price = double.Parse(splitted[5]);

                Book book = new Book(author, price);

                lib.AddBook(book);
            }

            Print(lib.getBooksList());
        }

        private static void Print(Dictionary<string, double> dictionary)
        {
            var a = dictionary.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToList();

            foreach (var item in a)
            {
                Console.WriteLine($"{item.Key} -> {item.Value:f2}");
            }
        }


    }

    class Book
    {
        public string author;
        public double price;

        public Book(string author, double price)
        {
            this.author = author;
            this.price = price;
        }
    }

    class Library
    {
        public Dictionary<string, double> books = new Dictionary<string, double>();
        public string libName;

        public Library(string libraryName)
        {
            this.libName = libraryName;
        }

        public void AddBook(Book book)
        {
            if (!books.ContainsKey(book.author))
            {
                this.books.Add(book.author, book.price);
            }
            else
            {
                double oldPrice = this.books[book.author];
                double newPrice = book.price + oldPrice;
                books[book.author] = newPrice;
            }
        }

        public Dictionary<string, double> getBooksList()
        {
            return this.books;
        }
    }
}
