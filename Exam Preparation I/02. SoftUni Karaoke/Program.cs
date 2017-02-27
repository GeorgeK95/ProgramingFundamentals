using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02.SoftUni_Karaoke
{
    class Program
    {
        static Dictionary<string, List<string>> awards = new Dictionary<string, List<string>>();

        static void Main(string[] args)
        {
            List<string> names = GetNames().ToList();
            List<string> songs = GetSongs().ToList();
            string input = Console.ReadLine();

            while (!input.Equals("dawn"))
            {
                string singer = GetSinger(input);

                if (names.Contains(singer))
                {
                    string song = GetSong(input);

                    if (songs.Contains(song))
                    {
                        string award = GetAward(input);
                        AddAwardToDictionary(singer, award);
                    }

                }

                input = Console.ReadLine();
            }

            PrintDict();
        }

        private static void PrintDict()
        {
            if (awards.Count == 0)
            {
                Console.WriteLine("No awards");
            }
            else
            {
                var awards1 = awards.OrderByDescending(x => x.Value.Count).ThenBy(y => y.Key);
                foreach (var pair in awards1)
                {
                    Console.WriteLine(pair.Key + ": " + pair.Value.Count + " awards");
                    foreach (var award in pair.Value.OrderBy(z => z))
                    {
                        Console.WriteLine($"--{award}");
                    }
                }
            }
           
        }

        private static void AddAwardToDictionary(string singer, string award)
        {
            if (!awards.ContainsKey(singer))
            {
                List<string> temp = new List<string>();
                temp.Add(award);
                awards.Add(singer, temp);
            }
            else
            {
                List<string> temp = awards[singer];
                if (!temp.Contains(award))
                {
                    temp.Add(award);
                }
                awards[singer] = temp;
            }
        }

        private static string GetAward(string input)
        {
            string[] arrSplitted = input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < arrSplitted.Length; i++)
            {
                arrSplitted[i] = arrSplitted[i].TrimStart();
                arrSplitted[i] = arrSplitted[i].TrimEnd();
            }

            return arrSplitted[2];
        }

        private static string GetSong(string input)
        {
            string[] arrSplitted = input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < arrSplitted.Length; i++)
            {
                arrSplitted[i] = arrSplitted[i].TrimStart();
                arrSplitted[i] = arrSplitted[i].TrimEnd();
            }

            return arrSplitted[1];
        }

        private static string GetSinger(string input)
        {
            string[] arrSplitted = input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < arrSplitted.Length; i++)
            {
                arrSplitted[i] = arrSplitted[i].TrimStart();
                arrSplitted[i] = arrSplitted[i].TrimEnd();
            }

            return arrSplitted[0];
        }

        private static void PrintStrArr(List<string> str)
        {
            for (int i = 0; i < str.Count; i++)
            {
                Console.WriteLine(str[i]);
            }
        }

        private static string[] GetSongs()
        {
            string songsInput = Console.ReadLine();
            songsInput = Regex.Replace(songsInput, @"\s{2,}", " ");
            string[] songs = songsInput.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            songs = RemoveUnwantedSpaces(songs);
            return songs;
        }

        private static string[] GetNames()
        {
            string namesInput = Console.ReadLine();
            namesInput = Regex.Replace(namesInput, @"\s{2,}", " ");
            string[] names = namesInput.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            names = RemoveUnwantedSpaces(names);
            return names;
        }

        private static string[] RemoveUnwantedSpaces(string[] str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                str[i] = str[i].TrimStart();
                str[i] = str[i].TrimEnd();
            }

            return str;
            
        }
    }
}
