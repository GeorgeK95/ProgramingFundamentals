using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Blank_Receipt
{
    class Program
    {
        static void Main(string[] args)
        {
            BlankCashReceipt();
        }

        private static void BlankCashReceipt()
        {
            Header();
            Body();
            Footer();
        }

        private static void Footer()
        {
            Console.WriteLine("------------------------------\n© SoftUni");
        }

        private static void Body()
        {
            Console.WriteLine("Charged to____________________\nReceived by___________________");
        }

        private static void Header()
        {
            Console.WriteLine("CASH RECEIPT\n------------------------------");
        }
    }
}
