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
        static void Main(string[] args)
        {
            List<string> singersList = GetSingersList();
            List<string> songsList = GetSongsList();
            Dictionary<string, List<string>> awards = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (!input.Equals("dawn"))
            {
                string singer = GetSinger(input);

                if (singersList.Contains(singer))
                {
                    string song = GetSong(input);

                    if (songsList.Contains(song))
                    {
                        string award = GetAward(input);
                        AddInfoToDict(singer, award, awards);
                    }

                }

                input = Console.ReadLine();
            }

            Print(awards);
        }

        private static void Print(Dictionary<string, List<string>> awards)
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

        private static void AddInfoToDict(string singer, string award, Dictionary<string, List<string>> awards)
        {
            var tempList = new List<string>();

            if (!awards.ContainsKey(singer))
            {
                tempList.Add(award);
            }
            else
            {
                tempList = awards[singer];

                if (!tempList.Contains(award))
                {
                    tempList.Add(award);
                }

            }

            awards[singer] = tempList;

        }
        private static List<string> GetSongsList()
        {
            string songsInput = Console.ReadLine();
            songsInput = Regex.Replace(songsInput, @"\s{2,}", " ");
            string[] songs = songsInput.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            songs = RemoveUnwantedSpaces(songs);
            return songs.ToList();
        }

        private static List<string> GetSingersList()
        {
            string namesInput = Console.ReadLine();
            namesInput = Regex.Replace(namesInput, @"\s{2,}", " ");
            string[] names = namesInput.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            names = RemoveUnwantedSpaces(names);
            return names.ToList();
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
    }
    }