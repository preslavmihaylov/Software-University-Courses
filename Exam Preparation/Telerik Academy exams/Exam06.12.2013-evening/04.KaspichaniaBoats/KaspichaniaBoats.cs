using System;

class KaspichaniaBoats
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        int boatWidth = (2 * N) + 1;
        int boatHeight = 6 + ((N - 3) / 2) * 3;
        int center = boatWidth / 2;
        int leftPart = center;
        int rightPart = center;

        int heightCount = 0;

        while (leftPart != 0)
        {
            for (int col = 0; col < boatWidth; col++)
            {
                if (col == center || col == leftPart || col == rightPart)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
            leftPart--;
            rightPart++;
            heightCount++;
        }

        for (int row = 0; row < boatHeight - heightCount; row++)
        {
            for (int col = 0; col < boatWidth; col++)
            {
                if (row == 0 || col == leftPart || col == rightPart || col == center ||
                    (row == boatHeight - heightCount - 1 && col >= leftPart && col <= rightPart))
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
            }
            leftPart++;
            rightPart--;
            Console.WriteLine();
        }
    }
}
