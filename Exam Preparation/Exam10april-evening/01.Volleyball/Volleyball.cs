using System;
class Volleyball
{
    static void Main()
    {
        string yearType = Console.ReadLine();
        double numOfHolidays = double.Parse(Console.ReadLine());
        double numOfHomeweeks = double.Parse(Console.ReadLine());
        double result = 0;

        result += numOfHomeweeks;
        result += (48 - numOfHomeweeks) * 3 / 4;
        result += numOfHolidays * 2 / 3;
        if (yearType == "leap")
        {
            result += 15 * result / 100;
        }
        Console.WriteLine((int)result);
    }
}
