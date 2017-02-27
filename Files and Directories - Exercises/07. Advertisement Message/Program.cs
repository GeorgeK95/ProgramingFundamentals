using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _07.Advertisement_Message
{
    class Program
    {
        static string INPUT_PATH = "C:\\Users\\Georgi\\Downloads\\SU\\FDEExercises\\ex7\\input.txt";
        static string OUTPUT_PATH = "C:\\Users\\Georgi\\Downloads\\SU\\FDEExercises\\ex7\\output.txt";

        static void Main(string[] args)
        {
            int n = int.Parse(File.ReadAllText(INPUT_PATH));

            string[] phrases = new string[] { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can’t live without this product." };
            string[] events = new string[] { "Now I feel good.", "I have succeeded with this product.", "Makes miracles.I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };
            string[] authors = new string[] { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
            string[] cities = new string[] { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            Random rand = new Random();

            StringBuilder results = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                
                int phrasesIndex = rand.Next(0, phrases.Length);
                int eventsIndex = rand.Next(0, events.Length);
                int authorsIndex = rand.Next(0, authors.Length);
                int citiesIndex = rand.Next(0, cities.Length);

                results.Append($"{phrases[phrasesIndex]} {events[eventsIndex]} {authors[authorsIndex]} - {cities[citiesIndex]}");
                results.Append(Environment.NewLine);
            }

            File.WriteAllText(OUTPUT_PATH, results.ToString());

        }
    }
}
