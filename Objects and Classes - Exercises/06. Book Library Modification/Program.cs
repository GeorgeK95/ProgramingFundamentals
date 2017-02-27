using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Book_Library_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Library lib = new Library("LibraryVip");
            DateTime limitDate;

            for (int i = 0; i < n; i++)
            {

                string line = Console.ReadLine();

                string[] splitted = line.Split(' ');

                string title = splitted[0];
                string author = splitted[1];
                double price = double.Parse(splitted[5]);
                string fullDate = splitted[3];

                DateTime datePublish = new DateTime(int.Parse(fullDate.Split('.')[2]), int.Parse(fullDate.Split('.')[1]), int.Parse(fullDate.Split('.')[0]));

                Book book = new Book(title, author, price, datePublish);

                lib.AddBook(book);
            }

            string limitDateStr = Console.ReadLine();
            string[] limitDateArr = limitDateStr.Split('.');

            limitDate = new DateTime(int.Parse(limitDateArr[2]), int.Parse(limitDateArr[1]), int.Parse(limitDateArr[0]));
            Print(lib.getBooksList(), limitDate);
        }

        private static void Print(Dictionary<string, DateTime> dictionary, DateTime limitDate)
        {
            var a = dictionary.OrderBy(x => x.Value).ThenBy(x => x.Key).ToList();
            string format = "dd.MM.yyyy";

            foreach (var item in a)
            {
                if (item.Value.Date > limitDate.Date)
                {
                    Console.WriteLine($"{item.Key} -> {item.Value.ToString(format)}");
                }
                
            }
        }

    }

    class Book
    {
        public string author;
        public double price;
        public string title;
        public DateTime date;

        public Book(string title, string author, double price, DateTime publishDate)
        {
            this.title = title;
            this.author = author;
            this.price = price;
            this.date = publishDate;
        }
    }

    class Library
    {
        public Dictionary<string, DateTime> books = new Dictionary<string, DateTime>();
        public string libName;

        public Library(string libraryName)
        {
            this.libName = libraryName;
        }

        public void AddBook(Book book)
        {
            if (!this.books.ContainsKey(book.title))
            {
                this.books.Add(book.title, book.date);
            }
            else
            {
               // DateTime newDate = this.books[book.title];
                this.books[book.title] = book.date;
            }
        }

        public Dictionary<string, DateTime> getBooksList()
        {
            return this.books;
        }
    }
}
