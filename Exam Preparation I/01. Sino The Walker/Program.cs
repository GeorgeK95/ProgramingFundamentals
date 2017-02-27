using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _01.Sino_The_Walker
{
    class Program
    {
        static void Main(string[] args)
        {
            string timeInput = Console.ReadLine();
            int inputSeconds = int.Parse(Console.ReadLine()) % 86400;
            int steps = int.Parse(Console.ReadLine()) % 86400;

            long multiplyStepsAndSeconds = steps * inputSeconds;

            long hours = multiplyStepsAndSeconds / 3600;
            long minutes = (multiplyStepsAndSeconds % 3600) / 60;
            long seconds = (multiplyStepsAndSeconds % 60);

            DateTime time = DateTime.Parse(timeInput);
            time = time.AddHours(hours);
            time = time.AddMinutes(minutes);
            time = time.AddSeconds(seconds);

            string format = "HH:mm:ss";
            Console.WriteLine("Time Arrival: " + time.ToString(format));
        }
    }
}

