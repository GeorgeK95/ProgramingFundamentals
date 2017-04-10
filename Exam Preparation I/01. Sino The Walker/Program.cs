namespace _01._Sino_The_Walker
{
    using System;
    using System.Globalization;
    public class Program
    {
        public static void Main()
        {
            string time = Console.ReadLine();
            int steps = int.Parse(Console.ReadLine()) % 86400;
            int seconds = int.Parse(Console.ReadLine()) % 86400;

            long totalSeconds = steps * seconds;

            DateTime date = DateTime.ParseExact(time, "HH:mm:ss", CultureInfo.InvariantCulture);
            date = date.AddSeconds(totalSeconds);
            Console.WriteLine("Time Arrival: " + date.ToString("HH:mm:ss"));
        }
    }
}
