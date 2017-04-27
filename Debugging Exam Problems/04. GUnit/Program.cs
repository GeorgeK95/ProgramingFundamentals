using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.GUnit
{
    class GClass
    {
        public string className { get; set; }
        public List<GMethod> methods { get; set; }
        public GClass(string className, List<GMethod> methods)
        {
            this.className = className;
            this.methods = methods;
        }
    }
    class GMethod
    {
        public string methodName { get; set; }
        public List<string> tests { get; set; }
        public GMethod(string name, List<string> tests)
        {
            this.methodName = name;
            this.tests = tests;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<GClass> tests = new List<GClass>();

            while (true)
            {
                string inputLine = Console.ReadLine();

                if (inputLine.Equals("It's testing time!"))
                {
                    Print(tests);
                    break;
                }

                if (IsInputLineValid(inputLine))
                {
                    string GClass = GetClass(inputLine);
                    string GMethod = GetMethod(inputLine);
                    string GTest = GetTest(inputLine);

                    AddToList(GClass, GMethod, GTest, tests);
                }
            }
        }

        private static string GetTest(string inputLine)
        {
            return inputLine.Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries)[2];
        }

        private static string GetMethod(string inputLine)
        {
            return inputLine.Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries)[1];
        }

        private static string GetClass(string inputLine)
        {
            return inputLine.Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries)[0];
        }

        private static bool IsInputLineValid(string inputLine)
        {
            string pattern = @"^[A-Z][A-Za-z0-9]{2,}\s\|\s[A-Z][A-Za-z0-9]{2,}\s\|\s[A-Z][A-Za-z0-9]{2,}$";
            Regex reg = new Regex(pattern);
            return reg.IsMatch(inputLine);
        }

        private static void Print(List<GClass> tests)
        {

            foreach (var currentClass in tests.OrderByDescending(x => x.methods.Sum(y => y.tests.Count)).ThenBy(x => x.className))
            {
                Console.WriteLine($"{currentClass.className}:");

                foreach (var currentMethod in currentClass.methods.OrderByDescending(x => x.tests.Count).ThenBy(x => x.methodName))
                {
                    Console.WriteLine($"##{currentMethod.methodName}");

                    foreach (var currentTest in currentMethod.tests.OrderBy(x => x.Length).ThenBy(x => x))
                    {
                        Console.WriteLine($"####{currentTest}");
                    }
                }
            }

        }

        private static void AddToList(string gClass, string gMethod, string gTest, List<GClass> tests)
        {
            bool foundClass = false;

            foreach (var currentClass in tests)
            {
                if (currentClass.className.Equals(gClass))
                {
                    foundClass = true;
                    bool foundMethod = false;

                    foreach (var currentMethod in currentClass.methods)
                    {
                        if (currentMethod.methodName.Equals(gMethod))
                        {
                            foundMethod = true;
                            bool foundTest = false;

                            foreach (var currentTest in currentMethod.tests)
                            {
                                if (currentTest.Equals(gTest))
                                {
                                    foundTest = true;
                                }
                            }

                            if (!foundTest)
                            {
                                currentMethod.tests.Add(gTest);
                            }
                        }
                    }

                    if (!foundMethod)
                    {
                        List<string> varTests = new List<string>();
                        varTests.Add(gTest);
                        GMethod newMethod = new GMethod(gMethod, varTests);
                        currentClass.methods.Add(newMethod);
                    }
                }
            }

            if (!foundClass)
            {
                List<string> varTests = new List<string>();
                varTests.Add(gTest);
                GMethod newMethod = new GMethod(gMethod, varTests);
                List<GMethod> varMethods = new List<GMethod>();
                varMethods.Add(newMethod);

                GClass newClass = new GClass(gClass, varMethods);
                tests.Add(newClass);
            }
        }
    }
}
