using System;
class Budget
{
    static void Main()
    {
        long money = long.Parse(Console.ReadLine());
        long weekdaysGoingOut = long.Parse(Console.ReadLine());
        long hometownWeekends = long.Parse(Console.ReadLine());

        long normalWeekdays = 22 - weekdaysGoingOut;
        long totalWeekendsDays = 8;

        totalWeekendsDays -= (hometownWeekends * 2);

        // 10 * ((3% of 800) + 10)
        long moneySpent = normalWeekdays * 10;
        moneySpent += weekdaysGoingOut * ((((long)3 * money) / 100) + 10);
        moneySpent += 150;
        moneySpent += totalWeekendsDays * 20;

        long moneyLeft = money - moneySpent;
        if (moneyLeft > 0)
        {
            Console.WriteLine("Yes, leftover {0}.", moneyLeft);
        }
        else if (moneyLeft < 0)
        {
            Console.WriteLine("No, not enough {0}.", Math.Abs(moneyLeft));
        }
        else
        {
            Console.WriteLine("Exact Budget.");
        }







    }
}
