using System;
class JoroTheFootballPlayer
{
    static void Main()
    {
        string yearType = Console.ReadLine();
        int numberOfHolidays = int.Parse(Console.ReadLine());
        int numberOfHometownWeekends = int.Parse(Console.ReadLine());
        double result = 0;

        result += numberOfHometownWeekends;

        int weekendsInTheYear = 52 - numberOfHometownWeekends;

        result += (weekendsInTheYear * 2) / 3;
        result += numberOfHolidays / 2;

        if (yearType == "t")
        {
            result += 3;
        }
        Console.WriteLine((int)result);
    }
}
