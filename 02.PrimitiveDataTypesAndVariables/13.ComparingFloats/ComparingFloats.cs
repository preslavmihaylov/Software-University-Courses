using System;
using System.Globalization;
using System.Threading;
class ComparingFloats
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");

        double eps = 0.000001;

        Console.WriteLine("Input first value:");
        double firstValue = double.Parse(Console.ReadLine());
        Console.WriteLine("Input second value:");
        double secondValue = double.Parse(Console.ReadLine());

        if (Math.Abs(firstValue - secondValue) < eps)
        {
            Console.WriteLine("True");
        }
        else
        {
            Console.WriteLine("False");
        }
        Console.WriteLine();
    }
}
