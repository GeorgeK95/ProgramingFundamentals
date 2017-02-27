using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Letters_Change_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            string[] strings = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            double total = 0;

            for (int i = 0; i < strings.Length; i++)
            {
                string currStr = strings[i];
                double result = DoActionsOnCurrentString(currStr);
                total += result;
            }

            Console.WriteLine("{0:f2}", total);
        }

        private static double DoActionsOnCurrentString(string currStr)
        {
            char firstLetter = currStr[0];
            char lastLetter = currStr[currStr.Length - 1];
            string str = currStr.Substring(1, currStr.Length - 2);
            int number = int.Parse(str);
            double result = number;

            bool isFirstLetterUpper = IsUpperFirstLetter(firstLetter);
            bool isLastLetterUpper = IsUpperFirstLetter(lastLetter);

            int firstLetterPosition = GetValue(isFirstLetterUpper, firstLetter);
            int lastLetterPosition = GetValue(isLastLetterUpper, lastLetter);

            if (isFirstLetterUpper)
            {
                result /= firstLetterPosition;
            }
            else
            {
                result *= firstLetterPosition;
            }

            if (isLastLetterUpper)
            {
                result -= lastLetterPosition;
            }
            else
            {
                result += lastLetterPosition;
            }

            return result;
        }

        private static int GetValue(bool isFirstLetterUpper, char firstLetter)
        {
            int res = 0;

            if (isFirstLetterUpper)
            {
                res = (int)firstLetter - 64;
            }
            else
            {
                res = (int)firstLetter - 96;
            }

            return res;
        }

        private static bool IsUpperFirstLetter(char firstLetter)
        {
            if ((int)firstLetter >= 65 && (int)firstLetter <= 90)
            {
                return true;
            }

            return false;
        }
    }
}
