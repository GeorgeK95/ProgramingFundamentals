using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _04.Merge_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] file_1 = File.ReadAllLines(@"C:\Users\Georgi\Downloads\SU\FDLab\Resources\04. Merge Files\FileOne.txt");
            string[] file_2 = File.ReadAllLines(@"C:\Users\Georgi\Downloads\SU\FDLab\Resources\04. Merge Files\FileTwo.txt");

            string[] arr = Merge(file_1, file_2);

            File.WriteAllLines(@"C:\Users\Georgi\Downloads\SU\FDLab\Resources\04. Merge Files\output.txt", arr);
        }

        private static string[] Merge(string[] file_1, string[] file_2)
        {
            string[] arr = new string[file_1.Length * 2];
            int p = 0;

            for (int i = 0; i < file_1.Length; i++)
            {
                /*for (int j = 0; j < file_2.Length; j++)
                {
                    
                }*/
                arr[p] = file_1[i];
                p++;
                arr[p] = file_2[i];
                p++;
            }

            return arr;
        }
    }
}
