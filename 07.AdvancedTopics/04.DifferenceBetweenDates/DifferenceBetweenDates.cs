using System;

class DifferenceBetweenDates
{
    static void Main()
    {
        DateTime firstDate = DateTime.Parse(Console.ReadLine());
        DateTime secondDate = DateTime.Parse(Console.ReadLine());

        TimeSpan result = new TimeSpan();

        result = firstDate.Subtract(secondDate);

        Console.WriteLine(result.Days);
    }
}
