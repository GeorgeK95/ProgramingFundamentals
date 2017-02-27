using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Hands_of_Cards
{
    class Program
    {
        private static Dictionary<string, long> results = new Dictionary<string, long>();
        private static Dictionary<string, List<string>> hands = new Dictionary<string, List<string>>();

        static void Main(string[] args)
        {
            char[] separators = new char[] { ' ', ',' };

            while (true)
            {
                string line = Console.ReadLine();

                if (line.Equals("JOKER"))
                {
                    CalculateAndPrint();
                    break;
                }
                string[] splitted = line.Split(':').ToArray();
                string[] cards = splitted[1].Split(separators, StringSplitOptions.RemoveEmptyEntries).ToArray();

                string personName = splitted[0];
                AddCardsInDictionary(cards, personName);

            }

        }

        private static void CalculateAndPrint()
        {
            foreach (var person in hands)
            {
                string name = person.Key;
                List<string> cards = person.Value;
                long cardsPower = CalculateCurrentPersonHandPower(cards);

                Console.WriteLine($"{person.Key}: {cardsPower}");
            }
        }

        private static long CalculateCurrentPersonHandPower(List<string> cards)
        {
            long totalResult = 0;

            foreach (var currCard in cards)
            {
                string power = currCard.Substring(0, currCard.Length - 1);
                string type = currCard.Substring(currCard.Length - 1);

                int powerValue = CalculatePower(power);
                int typeValue = CalculateValue(type);

                long totalPower = powerValue * typeValue;
                totalResult += totalPower;

            }

            return totalResult;
        }

        private static int CalculateValue(string type)
        {
            int result = 0;

            switch (type)
            {
                case "S":
                    result = 4;
                    break;
                case "H":
                    result = 3;
                    break;
                case "D":
                    result = 2;
                    break;
                case "C":
                    result = 1;
                    break;
            }

            return result;
        }

        private static int CalculatePower(string power)
        {
            int result = 0;

            switch (power)
            {
                case "2":
                    result = 2;
                    break;
                case "3":
                    result = 3;
                    break;
                case "4":
                    result = 4;
                    break;
                case "5":
                    result = 5;
                    break;
                case "6":
                    result = 6;
                    break;
                case "7":
                    result = 7;
                    break;
                case "8":
                    result = 8;
                    break;
                case "9":
                    result = 9;
                    break;
                case "10":
                    result = 10;
                    break;
                case "J":
                    result = 11;
                    break;
                case "Q":
                    result = 12;
                    break;
                case "K":
                    result = 13;
                    break;
                case "A":
                    result = 14;
                    break;
            }

            return result;
        }

        private static void AddCardsInDictionary(string[] splittedClearLine, string name)
        {
            for (int i = 0; i < splittedClearLine.Length; i++)
            {
                string currCard = splittedClearLine[i];

                if (hands.ContainsKey(name))
                {
                    List<string> currCardDeck = hands[name];

                    if (!currCardDeck.Contains(currCard))
                    {
                        currCardDeck.Add(currCard);
                    }

                    hands[name] = currCardDeck;
                }
                else
                {
                    List<string> newCardDeck = new List<string>();
                    newCardDeck.Add(currCard);
                    hands.Add(name, newCardDeck);
                }
            }
        }

        private static int CalculateValue(char type)
        {
            int typeVal = 0;

            switch (type)
            {
                case 'C':
                    typeVal = 1;
                    break;
                case 'D':
                    typeVal = 2;
                    break;
                case 'H':
                    typeVal = 3;
                    break;
                default:
                    typeVal = 4;
                    break;
            }

            return typeVal;
        }

        private static int CalculatePower(char power)
        {
            int ascii = (int)power;
            int pow = 0;

            if (ascii >= 50 && ascii <= 57)
            {
                pow = int.Parse(power.ToString());
            }
            else
            {
                switch (power)
                {
                    case 'J':
                        pow = 11;
                        break;
                    case 'Q':
                        pow = 12;
                        break;
                    case 'K':
                        pow = 13;
                        break;
                    default:
                        pow = 14;
                        break;
                }
            }

            return pow;
        }

        private static string[] ClearEmptyLines(string[] splitted)
        {
            List<string> a = new List<string>();

            for (int i = 0; i < splitted.Length; i++)
            {
                if (splitted[i] != "")
                {
                    a.Add(splitted[i]);
                }
            }

            return a.ToArray();
        }
    }
}
