using System;

public class Substring_broken
{
    public static void Main()
    {
        string text = Console.ReadLine();// "phahah put";// 
        int jump = int.Parse(Console.ReadLine());//3;// 

        const char Search = 'p';
        bool hasMatch = false;

        for (int i = 0; i < text.Length; i++)
        {
            if (text[i].Equals(Search))
            {
                /*hasMatch = true;

                if (jump + 1 >= text.Length)
                {
                    jump = text.Length - i - 1;
                }

                string matchedString = text.Substring(i, jump);

                i += jump - 1;
                Console.WriteLine(matchedString);*/
                hasMatch = true;
                if (jump + 1 >= text.Length)
                {
                    jump = text.Length - i - 1;
                }
                string a = text.Substring(i, jump);
                
                Console.WriteLine(a);
            }
        }

        if (!hasMatch)
        {
            Console.WriteLine("no");
        }
    }
}