using System;
class IsLeapYearCheck
{
    static void Main()
    {
        int year = int.Parse(Console.ReadLine());
        Console.Write("Is Leap Year? ");
        Console.WriteLine(DateTime.IsLeapYear(year));
    }
}
