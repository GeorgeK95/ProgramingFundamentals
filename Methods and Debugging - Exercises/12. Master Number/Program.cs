using System;
using System.Text;

namespace MasterNumber
{
    class MasterNumber
    {
        static void Main(string[] args)
        {
            int limit = int.Parse(Console.ReadLine());

            for (int testedNumber = 1; testedNumber <= limit; testedNumber++)
            {
                if (MagicNumberFinder(testedNumber))
                {
                    Console.WriteLine(testedNumber);
                }
            }

        }
        public static bool MagicNumberFinder(int inputNumber)
        {
            bool result = false;

            if (NumbersWithDevBy2Number(inputNumber))
            {
                if (NumbersDevisibleBy7(inputNumber))
                {
                    if (SymetricNumbers(inputNumber))
                    {
                        result = true;
                    }
                }
            }

            return result;
        }
        public static bool SymetricNumbers(int inputNumber)
        {
            string originalNumber = inputNumber.ToString();

            StringBuilder sb = new StringBuilder();

            int numberLenght = originalNumber.Length;
            for (int position = 0; position < numberLenght; position++)
            {
                sb.Append(originalNumber[numberLenght - (position + 1)]);
            }
            if (originalNumber.Equals(sb.ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool NumbersDevisibleBy7(int inputNumber)
        {
            int numberForTest = inputNumber;
            int testingNumber = 0;

            while (numberForTest > 0)
            {
                testingNumber += numberForTest % 10;
                numberForTest /= 10;
            }
            if (testingNumber % 7 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool NumbersWithDevBy2Number(int inputNumber)
        {
            int testedNumber = inputNumber;
            while (testedNumber > 0)
            {
                if (testedNumber % 2 == 0)
                {
                    return true;

                }
                else
                {
                    testedNumber /= 10;
                }
            }
            return false;
        }
    }
}