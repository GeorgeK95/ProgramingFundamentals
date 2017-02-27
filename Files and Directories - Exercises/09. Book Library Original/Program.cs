using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _09.Book_Library_Original
{
    class Program
    {
        static string INPUT_PATH = "C:\\Users\\Georgi\\Downloads\\SU\\FDEExercises\\ex9\\input.txt";
        static string OUTPUT_PATH = "C:\\Users\\Georgi\\Downloads\\SU\\FDEExercises\\ex9\\output.txt";

        static void Main(string[] args)
        {
            string[] inputInfo = File.ReadAllLines(INPUT_PATH);
            int n = int.Parse(inputInfo[0]);
            int index = 1;

            Library lib = new Library("LibraryVip");

            for (int i = 0; i < n; i++)
            {
                string line = inputInfo[index];
                index++;

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
            StringBuilder sb = new StringBuilder();

            foreach (var item in a)
            {
                sb.Append($"{item.Key} -> {item.Value:f2}");
                sb.Append(Environment.NewLine);
            }

            File.WriteAllText(OUTPUT_PATH, sb.ToString());
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
            // this.books.Add(book);
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
