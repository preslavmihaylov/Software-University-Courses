using System;

class Eggcelent
{
    static void Main()
    {
        int input = int.Parse(Console.ReadLine());

        int drawingField = 3 * input + 1;
        int eggHeight = 2 * input;
        int eggBottom = input - 1;

        int leftPart = (drawingField - eggBottom) / 2;
        int rightPart = leftPart + eggBottom - 1;

        int centerPartCount = input - 1;

        // top
        for (int row = 0; row < eggHeight / 2; row++)
        {
            for (int col = 0; col < drawingField; col++)
            {
                if (row == 0 && (col >= leftPart && col <= rightPart))
                {
                    Console.Write("*");
                }
                else if (row == eggHeight / 2 - 1)
                {
                    if (col > leftPart && col < rightPart && col % 2 == 0)
                    {
                        Console.Write("@");
                    }
                    else if (col == leftPart || col == rightPart)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                else if (col == leftPart || col == rightPart)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
            }

            leftPart -= 2;
            rightPart += 2;
            Console.WriteLine();

            if (leftPart < 0)
            {
                leftPart += 2;
                rightPart -= 2;
                centerPartCount--;
            }
        }

        // bot
        for (int row = 0; row < eggHeight / 2; row++)
        {
            for (int col = 0; col < drawingField; col++)
            {
                if (row == eggHeight / 2 - 1 && (col >= leftPart && col <= rightPart))
                {
                    Console.Write("*");
                }
                else if (row == 0)
                {
                    if (col > leftPart && col < rightPart && col % 2 == 1)
                    {
                        Console.Write("@");
                    }
                    else if (col == leftPart || col == rightPart)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                else if (col == leftPart || col == rightPart)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
            }

            leftPart += 2;
            rightPart -= 2;
            Console.WriteLine();

            if (centerPartCount > 0)
            {
                leftPart -= 2;
                rightPart += 2;
                centerPartCount--;
            }
        }
    }
}
