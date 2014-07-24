using System;
class JoroTheFootballPlayer
{
    static void Main()
    {
        // input data from the console
        string LeapYearInput = Console.ReadLine();
        double holidays = double.Parse(Console.ReadLine());
        double hometownWeekends = double.Parse(Console.ReadLine());
        // the main variables
        double weekends = 52;
        double result = 0;
        // check if the year is leap
        if (LeapYearInput == "t")
        {
            result += 3;
        }
        // add the additional values
        result += holidays / 2;
        result += hometownWeekends;
        // subtract the 52 weekends from the hometownWeekends
        weekends -= hometownWeekends;
        // main formula
        result += (weekends * 2) / 3;
        // output the result casting is as an int
        Console.WriteLine((int)result);

    }
}