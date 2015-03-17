using System;
using System.Diagnostics;

class StopwatchDemo
{
    static void DisplayExecutionTime(Action action)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        action();
        stopwatch.Stop();
        Console.WriteLine(stopwatch.Elapsed);
    }

    static void Main()
    {
        Console.Write("operating with ints:\t");
        DisplayExecutionTime(() =>
        {
            int count = 1 + 2;
            count = 1 / 2;
            count = 1 * 2;
            count = 1 - 2;
        });

        Console.Write("operating with long:\t");
        DisplayExecutionTime(() =>
        {
            long count = 1 + 2;
            count = 1 / 2;
            count = 1 * 2;
            count = 1 - 2;
        });

        Console.Write("operating with floats:\t");
        DisplayExecutionTime(() =>
        {
            float count = 1 + 2;
            count = 1 / 2;
            count = 1 * 2;
            count = 1 - 2;
        });

        Console.Write("operating with double:\t");
        DisplayExecutionTime(() =>
        {
            double count = 1 + 2;
            count = 1 / 2;
            count = 1 * 2;
            count = 1 - 2;
        });

        Console.Write("operating with decimal:\t");
        DisplayExecutionTime(() =>
        {
            decimal count = 1 + 2;
            count = 1 / 2;
            count = 1 * 2;
            count = 1 - 2;
        });

        Console.Write("sqrt, log, sin with float:\t");
        DisplayExecutionTime(() =>
        {
            float count = 3;
            Math.Sqrt(count);
            Math.Log(count);
            Math.Sin(count);
        });

        Console.Write("sqrt, log, sin with double:\t");
        DisplayExecutionTime(() =>
        {
            double count = 3;
            Math.Sqrt(count);
            Math.Log(count);
            Math.Sin(count);
        });

        // Does not compile!
        //
        // Console.Write("sqrt, log, sin with decimal:\t");
        // DisplayExecutionTime(() =>
        // {
        //     decimal count = 3;
        //     Math.Sqrt(count);
        //     Math.Log(count);
        //     Math.Sin(count);
        // });
    }
}
