using System;
class NewHouse
{
    static void Main()
    {
        int houseHeight = int.Parse(Console.ReadLine());
        int leftPart = houseHeight / 2;
        int rightPart = leftPart;

        while (leftPart >= 0)
        {
            for (int i = 0; i < houseHeight; i++)
            {
                if (i >= leftPart && i <= rightPart)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write("-");
                }
            }
            Console.WriteLine();
            leftPart--;
            rightPart++;
        }

        for (int row = 0; row < houseHeight; row++)
        {
            for (int col = 0; col < houseHeight; col++)
            {
                if (col == 0 || col == houseHeight - 1)
                {
                    Console.Write("|");
                }
                else
                {
                    Console.Write("*");
                }
            }
            Console.WriteLine();
        }

    }
}
