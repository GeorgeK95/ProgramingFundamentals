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
            int totalPictures = int.Parse(Console.ReadLine());
            long filterTime = long.Parse(Console.ReadLine());
            long filterFactor = long.Parse(Console.ReadLine());
            long uploadTime = long.Parse(Console.ReadLine());

            long filteredPictures = GetFilteredPictures(filterFactor, totalPictures);
            long timeForFiltring = totalPictures * filterTime;
            long totalUploadTime = filteredPictures * uploadTime;

            long totalSeconds = timeForFiltring + totalUploadTime;

            TimeSpan t = TimeSpan.FromSeconds(totalSeconds);

            string answer = string.Format("{0:D1}:{1:D2}:{2:D2}:{3:D2}",
                            t.Days,
                            t.Hours,
                            t.Minutes,
                            t.Seconds);

            Console.WriteLine(answer);
        }

        private static long GetFilteredPictures(long filterFactor, long totalPictures)
        {
            if ((filterFactor * totalPictures) % 100 != 0)
            {
                return ((filterFactor * totalPictures) / 100) + 1;
            }

            return (filterFactor * totalPictures) / 100;
        }
    }
}
