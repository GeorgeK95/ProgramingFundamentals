using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Book_Library_Modification
{
    class Program
    {
        static string INPUT_PATH = "C:\\Users\\Georgi\\Downloads\\SU\\FDEExercises\\ex10\\input.txt";
        static string OUTPUT_PATH = "C:\\Users\\Georgi\\Downloads\\SU\\FDEExercises\\ex10\\output.txt";

        static void Main(string[] args)
        {
            string[] inputInfo = GetInput();
            int n = int.Parse(inputInfo[0]);
            int index = 1;
            Library lib = new Library("LibraryVip");
            DateTime limitDate;

            for (int i = 0; i < n; i++)
            {
                string line = inputInfo[index];
                index++;

                string[] splitted = line.Split(' ');

                string title = splitted[0];
                string author = splitted[1];
                double price = double.Parse(splitted[5]);
                string fullDate = splitted[3];

                DateTime datePublish = new DateTime(int.Parse(fullDate.Split('.')[2]), int.Parse(fullDate.Split('.')[1]), int.Parse(fullDate.Split('.')[0]));

                Book book = new Book(title, author, price, datePublish);

                lib.AddBook(book);
            }

            string limitDateStr = inputInfo[n + 1];
            string[] limitDateArr = limitDateStr.Split('.');

            limitDate = new DateTime(int.Parse(limitDateArr[2]), int.Parse(limitDateArr[1]), int.Parse(limitDateArr[0]));
            Print(lib.getBooksList(), limitDate);

        }
        private static string[] GetInput()
        {
            string[] inputInfo = File.ReadAllText(INPUT_PATH).Split('\n');
            inputInfo = RemoveNewLineChars(inputInfo);
            return inputInfo;
        }

        private static string[] RemoveNewLineChars(string[] inputInfo)
        {
            for (int i = 0; i < inputInfo.Length; i++)
            {
                inputInfo[i] = inputInfo[i].Replace("\r", "");
            }

            return inputInfo;
        }
        private static void Print(Dictionary<string, DateTime> dictionary, DateTime limitDate)
        {
            var a = dictionary.OrderBy(x => x.Value).ThenBy(x => x.Key).ToList();
            string format = "dd.MM.yyyy";
            StringBuilder sb = new StringBuilder();

            foreach (var item in a)
            { 
                if (item.Value.Date > limitDate.Date)
                {
                    sb.Append($"{item.Key} -> {item.Value.ToString(format)}");
                    sb.Append(Environment.NewLine);
                }

            }

            File.WriteAllText(OUTPUT_PATH, sb.ToString());
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



