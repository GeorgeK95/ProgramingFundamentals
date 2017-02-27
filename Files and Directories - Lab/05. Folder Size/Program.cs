using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _05.Folder_Size
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles("C:\\Users\\Georgi\\Downloads\\SU\\FDLab\\Resources\\05. Folder Size\\TestFolder");

            double bytes = GetBytes(files);
            double toMegaBytes = 1024 * 1024;
            bytes /= toMegaBytes;

            WriteInFile(bytes);
        }

        private static void WriteInFile(double bytes)
        {
            File.WriteAllText("C:\\Users\\Georgi\\Downloads\\SU\\FDLab\\Resources\\05. Folder Size\\TestFolder\\output.txt", bytes.ToString());
        }

        private static double GetBytes(string[] files)
        {
            double bytes = 0;

            foreach (var currFile in files)
            {
                FileInfo fi = new FileInfo(currFile);
                bytes += fi.Length;
            }

            return bytes;
        }
    }
}
