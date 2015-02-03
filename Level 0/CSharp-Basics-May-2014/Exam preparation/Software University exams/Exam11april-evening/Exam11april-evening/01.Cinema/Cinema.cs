using System;
using System.Globalization;
using System.Threading;
class Cinema
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");

        string TypeOfProjection = Console.ReadLine();
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());
        double result = 0;

        switch (TypeOfProjection)
        {
            case "Premiere":
                result = 12;
                break;
            case "Normal":
                result = 7.50;
                break;
            default:
                result = 5;
                break;
        }
        result *= rows * cols;
        Console.WriteLine("{0:0.00} leva", result);
    }
}
