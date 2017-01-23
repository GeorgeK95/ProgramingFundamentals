using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Convert_Speed_Units
{
    class Program
    {
        static void Main(string[] args)
        {
            float meters = float.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int seconds = int.Parse(Console.ReadLine());

            float totalTimeInSeconds = (hours * 60 * 60) + (minutes * 60) + seconds;

            Console.WriteLine(meters / totalTimeInSeconds);
            Console.WriteLine((meters / 1000) / (totalTimeInSeconds / 3600));
            Console.WriteLine((meters / 1609) / (totalTimeInSeconds / 3600));
        }
    }
}