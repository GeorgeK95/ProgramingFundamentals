using System;
using System.Linq;

public class Program
{
    private const char ArgumentsDelimiter = ' ';
    private static int n;
    private static long[] array;

    public static void Main()
    {
        n = int.Parse(Console.ReadLine());
        array = Console.ReadLine().Split(ArgumentsDelimiter).Select(long.Parse).ToArray();
        ExecuteCommands();
    }

    private static void ExecuteCommands()
    {
        string command = "start";
        string line = Console.ReadLine();

        if (line.Equals("lshift") || line.Equals("rshift"))
        {
            PerformAction(line);
        }

        string[] separatedLine = line.Split(' ');
        command = separatedLine[0];

        int[] args = new int[3];

        if (command.Equals("add") || command.Equals("subtract") || command.Equals("multiply"))
        {
            args[0] = int.Parse(separatedLine[1]);
            args[1] = int.Parse(separatedLine[2]);

            PerformAction(command, args);
        }
    }

    static void PerformAction(string action, int[] args)
    {
        int pos = args[0];
        int value = args[1];

        switch (action)
        {
            case "multiply":
                array[pos - 1] *= value;
                PrintArray(array);
                ExecuteCommands();
                break;
            case "add":
                array[pos - 1] += value;
                PrintArray(array);
                ExecuteCommands();
                break;
            case "subtract":
                array[pos - 1] -= value;
                PrintArray(array);
                ExecuteCommands();
                break;
        }
    }

    static void PerformAction(string action)
    {
        switch (action)
        {
            case "lshift":
                ArrayShiftLeft(array);
                PrintArray(array);
                ExecuteCommands();
                break;
            case "rshift":
                ArrayShiftRight(array);
                PrintArray(array);
                ExecuteCommands();
                break;
        }
    }

    private static void ArrayShiftRight(long[] array)
    {
        long lastElement = array[array.Length - 1];

        for (int i = array.Length - 1; i >= 1; i--)
        {
            array[i] = array[i - 1];
        }

        array[0] = lastElement;
    }

    private static void ArrayShiftLeft(long[] array)
    {
        long firstElement = array[0];

        for (int i = 0; i < array.Length - 1; i++)
        {
            array[i] = array[i + 1];
        }

        array[array.Length - 1] = firstElement;
    }

    private static void PrintArray(long[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }

        Console.WriteLine();
    }
}
