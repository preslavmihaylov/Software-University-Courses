using System;

class JoroTheFootballPlayer
{
    static void Main()
    {
        string leap = Console.ReadLine();
        int hollidaysCount = int.Parse(Console.ReadLine());
        int weekendsHomeCount = int.Parse(Console.ReadLine());

        int weekendsInYear = 52;
        int normalWeekendsCount = weekendsInYear - weekendsHomeCount;
        double gamesCount =
            normalWeekendsCount * 2d / 3d +
            weekendsHomeCount * 1d +
            hollidaysCount / 2d;
        if (leap == "t")
        {
            gamesCount = gamesCount + 3;
        }
        Console.WriteLine((int)gamesCount);
    }
}
