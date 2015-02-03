using System;
using System.Linq;

class CoffeeMachine
{
    static void Main()
    {
        decimal[] availableCoins = new decimal[] { 0.05m, 0.10m, 0.20m, 0.50m, 1.00m};

        for (int index = 0; index < availableCoins.Length; index++)
        {
            decimal coinCount = decimal.Parse(Console.ReadLine());

            availableCoins[index] *= coinCount;
        }

        decimal inputAmount = decimal.Parse(Console.ReadLine());
        decimal drinkPrice = decimal.Parse(Console.ReadLine());

        if (inputAmount < drinkPrice)
        {
            Console.WriteLine("More {0:0.00}", drinkPrice - inputAmount);
        }
        else if (inputAmount - drinkPrice <= availableCoins.Sum())
        {
            Console.WriteLine("Yes {0:0.00}", availableCoins.Sum() - (inputAmount - drinkPrice));
        }
        else
        {
            Console.WriteLine("No {0:0.00}", (inputAmount - drinkPrice) - availableCoins.Sum());
        }
    }
}
