using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Thea_the_Photographer
{
    class Program
    {
        static void Main(string[] args)
        {
            double amount = double.Parse(Console.ReadLine());
            int filterTime = int.Parse(Console.ReadLine());
            double filterFactor = double.Parse(Console.ReadLine());
            int uploadTime = int.Parse(Console.ReadLine());

            double goodOnes = Math.Ceiling((filterFactor / 100) * amount);
            double totalFilterTime = amount * filterTime;
            double totalUploadTime = goodOnes * uploadTime;

            double resultInSeconds = totalUploadTime + totalFilterTime;

            TimeSpan t = TimeSpan.FromSeconds(resultInSeconds);
            string answer = string.Format("{0:D1}:{1:D2}:{2:D2}:{3:D2}",
                          t.Days,
                          t.Hours,
                          t.Minutes,
                          t.Seconds);
            Console.WriteLine(answer);
        }
    }
}
