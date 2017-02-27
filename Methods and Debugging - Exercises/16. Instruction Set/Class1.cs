using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.Instruction_Set
{
    class Class1
    {
        static List<long> values = new List<long>();

        static void Main()
        {
            ExecuteInstructions();
        }

        private static void ExecuteInstructions()
        {
            string input = Console.ReadLine();
            string[] splitted = input.Split(' ');  

            for (long i = 0; i < splitted.Length; i++)
            {
                string instruction = splitted[i];

                switch (instruction)
                {
                    case "INC":
                        long operand = long.Parse(splitted[i + 1]);
                        i += 1;
                        values.Add(operand + 1);
                        ExecuteInstructions();
                        break;

                    case "ADD":
                        long num1 = long.Parse(splitted[i + 1]);
                        long num2 = long.Parse(splitted[i + 2]);
                        i += 2;
                        values.Add(num1 + num2);
                        ExecuteInstructions();
                        break;

                    case "DEC":
                        long currentOperand = long.Parse(splitted[i + 1]);
                        i += 1;
                        values.Add(currentOperand - 1);
                        ExecuteInstructions();
                        break;

                    case "MLA":
                        long number1 = long.Parse(splitted[i + 1]);
                        long number2 = long.Parse(splitted[i + 2]);
                        i += 2;
                        values.Add(number1 * number2);
                        ExecuteInstructions();
                        break;

                    case "END":
                        PrintValues(values);
                        break;

                }

            }
        }

        private static void PrintValues(List<long> values)
        {
            foreach (var item in values)
            {
                Console.WriteLine(item);
            }
        }
    }
}
