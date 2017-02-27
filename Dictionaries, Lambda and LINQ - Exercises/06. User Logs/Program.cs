using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.User_Logs
{
    class Program
    {
        private static SortedDictionary<string, Dictionary<string, int>> userLogs = new SortedDictionary<string, Dictionary<string, int>>();

        static void Main(string[] args)
        {
            while (true)
            {
                string line = Console.ReadLine();

                if (line.Equals("end"))
                {
                    PrintResult();
                    break;
                }

                string[] arr = line.Split(' ');

                string ip = arr[0].Replace("IP=", "");
                string userName = arr[2].Replace("user=", "");

                if (!userLogs.ContainsKey(userName))
                {
                    Dictionary<string, int> newInsertDict = new Dictionary<string, int>();
                    newInsertDict.Add(ip, 1);
                    userLogs.Add(userName, newInsertDict);
                }
                else
                {
                    Dictionary<string, int> info = userLogs[userName];

                    if (info.ContainsKey(ip))
                    {
                        int count = info[ip];
                        info[ip] = count + 1;
                    }
                    else
                    {
                        info.Add(ip, 1);
                    }

                    userLogs[userName] = info;
                }
            }
        }

        private static void PrintResult()
        {
            foreach (var currUser in userLogs)
            {
                Console.WriteLine("{0}: ", currUser.Key);
                int a = currUser.Value.Count;

                foreach (var currUserInfo in currUser.Value)
                {
                    if (a == 1)
                    {
                        Console.WriteLine($"{currUserInfo.Key} => {currUserInfo.Value}.");
                    }
                    else
                    {
                        Console.Write($"{currUserInfo.Key} => {currUserInfo.Value}, ");
                    } 
                    a--;
                }

            }
        }
    }
}
