using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Employee_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            string fName = "Amanda";
            string lName = "Jonson";
            int age = 27;
            char gender = 'f';
            string id = "8306112507";
            string employeeNum = "27563571";

            Console.WriteLine("First name: {0}\nLast name: {1}\nAge: {2}\nGender: {3}\nPersonal ID: {4}\nUnique Employee number: {5}", fName, lName, age, gender, id, employeeNum);
        }
    }
}
