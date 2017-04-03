using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Book_Library
{
    class Library
    {
        public string name { get; set; }
        public List<Book> books{ get; set; }

        public Library(string name)
        {
            this.name = name;
            this.books = new List<Book_Library.Book>();
        }

    }
    class Book
    {
        public string title { get; set; }
        public string author { get; set; }
        public string publisher { get; set; }
        public DateTime releaseDate { get; set; }
        public string ISBN { get; set; }
        public double price { get; set; }

        public Book(string title, string author, string publisher, DateTime releaseDate, string ISBN, double price)
        {
            this.title = title;
            this.author = author;
            this.publisher = publisher;
            this.releaseDate = releaseDate;
            this.ISBN = ISBN;
            this.price = price;
        }

        
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Library library = new Library("Ivan Vazov");

            for (int i = 0; i < n; i++)
            {
                string[] bookInfo = Console.ReadLine().Split();

                string title = bookInfo[0];
                string author = bookInfo[1];
                string publisher= bookInfo[2];
                DateTime date = DateTime.ParseExact(bookInfo[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                string ISBN = bookInfo[4];
                double price = double.Parse(bookInfo[5]);

                Book book = new Book(title, author, publisher, date, ISBN, price);

                AddCurrentBookToLibrary(book, library);
            }

            PrintLibrary(library);
        }

        private static void AddCurrentBookToLibrary(Book book, Library library)
        {
            bool exists = false;

            for (int i = 0; i < library.books.Count; i++)
            {
                if (library.books[i].author.Equals(book.author))
                {
                    library.books[i].price += book.price;
                    exists = true;
                }
            }

            if (!exists)
            {
                library.books.Add(book);
            }
        }

        private static void PrintLibrary(Library library)
        {
            foreach (var book in library.books.OrderByDescending(x=>x.price).ThenBy(x=>x.author))
            {
                Console.WriteLine($"{book.author} -> {book.price:F2}");
            }
        }
    }
}
