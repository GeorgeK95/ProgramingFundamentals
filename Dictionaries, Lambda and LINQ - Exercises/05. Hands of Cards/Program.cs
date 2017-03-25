using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Hands_of_Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            Dictionary<string, List<int>> deck = new Dictionary<string, List<int>>();
            Dictionary<string, int> typesDict = DeclarateTypesDictionary();

            while (!line.Equals("JOKER"))
            {
                string name = line.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries)[0];
                string[] cardsArray = GetCards(line.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries)[1]);

                foreach (var currentCard in cardsArray)
                {
                    string type = currentCard[currentCard.Length - 1].ToString();
                    int power = GetPower(currentCard, typesDict);
                    var temp = new List<int>();

                    if (deck.ContainsKey(name))
                    {
                        temp = deck[name];

                        if (!temp.Contains(power * typesDict[type]))
                        {
                            temp.Add(power * typesDict[type]);
                            deck[name] = temp;
                        }

                    }
                    if (!temp.Contains(power * typesDict[type]))
                    {
                        temp.Add(power * typesDict[type]);
                        deck[name] = temp;
                    }
                }

                line = Console.ReadLine();
            }

            Print(deck);
        }

        private static void Print(Dictionary<string, List<int>> deck)
        {
            foreach (var pair in deck)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value.Sum()}");
            }
        }

        private static Dictionary<string, int> DeclarateTypesDictionary()
        {
            var typesDict = new Dictionary<string, int>();
            typesDict.Add("S", 4);
            typesDict.Add("H", 3);
            typesDict.Add("D", 2);
            typesDict.Add("C", 1);
            return typesDict;
        }

        private static int GetPower(string currentCard, Dictionary<string, int> typesDict)
        {
            Dictionary<string, int> powers = new Dictionary<string, int>();
            powers.Add("J", 11);
            powers.Add("Q", 12);
            powers.Add("K", 13);
            powers.Add("A", 14);

            string powerStr = currentCard.Substring(0, currentCard.Length - 1);

            if (powers.ContainsKey(powerStr))
            {
                return powers[powerStr];
            }

            return int.Parse(powerStr.ToString());
        }

        private static string[] GetCards(string v)
        {
            v = v.Trim();
            string[] cards = v.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return cards;
        }
    }
}
