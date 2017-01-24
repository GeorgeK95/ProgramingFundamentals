using System;
using System.Text;

class PriceChangeAlert
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        double limit = double.Parse(Console.ReadLine());
        double significance = double.Parse(Console.ReadLine());

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < n - 1; i++)
        {
            double price = double.Parse(Console.ReadLine());
            double contrast = Proc(significance, price);
            bool isSignificantDifference = isDifference(contrast, limit);

            string message = Get(price, significance, contrast, isSignificantDifference);
            sb.Append(message + "\n");

            significance = price;
        }

        Console.WriteLine(sb);
    }

    private static string Get(double price, double significance, double contrast, bool isSignificantDifference)
    {
        string to = "";

        if (contrast == 0)
        {
            to = string.Format("NO CHANGE: {0}", price);
        }

        else if (!isSignificantDifference)
        {
            to = string.Format("MINOR CHANGE: {0} to {1} ({2:F2}%)", significance, price, contrast * 100);
        }

        else if (isSignificantDifference && (contrast > 0))
        {
            to = string.Format("PRICE UP: {0} to {1} ({2:F2}%)", significance, price, contrast * 100);
        }

        else if (isSignificantDifference && (contrast < 0))
        {
            to = string.Format("PRICE DOWN: {0} to {1} ({2:F2}%)", significance, price, contrast * 100);
        }

        return to;
    }
    private static bool isDifference(double limit, double diff)
    {
        if (Math.Abs(limit) >= diff)
        {
            return true;
        }

        return false;
    }

    private static double Proc(double significance, double price)
    {
        double result = (price - significance) / significance;
        return result;
    }
}
