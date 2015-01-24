using System;
using System.Linq;
class WorkDays
{
    static void Main()
    {
        Console.Write("Input the date to calculate to: ");
        DateTime date = DateTime.Parse(Console.ReadLine());
        DateTime now = DateTime.Now;
        if (date.Subtract(now).Days < 0)
        {
            Console.WriteLine("The date is before today");
            return;
        }

        Console.Write("Input holidays in format dd/MM/yyyy: ");
        string[] holidays = Console.ReadLine().Split();

        while (!areEqualDates(now, date))
        {
            if (isWorkDay(now) && !holidays.Contains(now.ToString("dd/MM/yyyy")))
            {
                Console.WriteLine(now.ToString("dd/MM/yyyy"));
            }
            now = now.AddDays(1);
        }
    }

    private static bool areEqualDates(DateTime now, DateTime date)
    {
        if (now.Day == date.Day && now.Month == date.Month && now.Year == date.Year)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private static bool isWorkDay(DateTime date)
    {
        if (date.DayOfWeek == DayOfWeek.Saturday ||
            date.DayOfWeek == DayOfWeek.Sunday)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
