using System;

public class Cinema
{
    public static void Main()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture =
            System.Globalization.CultureInfo.InvariantCulture;

        string movieType = Console.ReadLine();
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());

        decimal price = 0;

        switch (movieType)
        {
            case "Premiere":
                price = 12;
                break;
            case "Normal":
                price = 7.5m;
                break;
            case "Discount":
                price = 5;
                break;
        }

        decimal result = rows * cols * price;
        Console.WriteLine("{0:F2} leva", result);
    }
}
