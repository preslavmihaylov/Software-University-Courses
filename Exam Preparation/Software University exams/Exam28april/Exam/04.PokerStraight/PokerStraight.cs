using System;
class PokerStraight
{
    static void Main()
    {
        int input = int.Parse(Console.ReadLine());
        int cardCount = 0;
        for (int i = 1; i <= 10; i++)
        {
            int result = 10 * i + 20 * (i + 1) + 30 * (i + 2) + 40 * (i + 3) + 50 * (i + 4);
            if (input - result >= 5 && input - result <= 20)
            {
                result = input - result;
                for (int suit1 = 1; suit1 <= 4; suit1++)
                {
                    for (int suit2 = 1; suit2 <= 4; suit2++)
                    {
                        for (int suit3 = 1; suit3 <= 4; suit3++)
                        {
                            for (int suit4 = 1; suit4 <= 4; suit4++)
                            {
                                for (int suit5 = 1; suit5 <= 4; suit5++)
                                {
                                    if (suit1 + suit2 + suit3 + suit4 + suit5 == result)
                                    {
                                        cardCount++;
                                    }
                                }
                            }

                        }

                    }
                }
            }
        }
        Console.WriteLine(cardCount);
    }
}
