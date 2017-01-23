using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19.Thea_The_Photographer
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPictures = int.Parse(Console.ReadLine());
            int filterTime = int.Parse(Console.ReadLine());
            int filterFactor = int.Parse(Console.ReadLine());
            int uploadTime = int.Parse(Console.ReadLine());

            long timeForFiltring = (long)numberOfPictures * filterTime;
            long goodPictures = (long)Math.Ceiling((filterFactor * numberOfPictures) / 100.0);
            long totalUploadTime = goodPictures * uploadTime;

            long resultInSeconds = totalUploadTime + timeForFiltring;

            TimeSpan ts = TimeSpan.FromSeconds(resultInSeconds);

            Console.WriteLine("{0:D1}:{1:D2}:{2:D2}:{3:D2}", ts.Days, ts.Hours, ts.Minutes, ts.Seconds);
        }
    }
}
