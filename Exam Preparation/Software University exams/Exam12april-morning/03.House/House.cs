using System;
class House
{
    static void Main()
    {
        int height = int.Parse(Console.ReadLine());

        int leftPart = height / 2;
        int rightPart = leftPart;
        int roofHeight = 0;

        while (leftPart > 0)
        {
            for (int col = 0; col < height; col++)
            {
                if (col != leftPart && col != rightPart)
                {
                    Console.Write(".");
                }
                else
                {
                    Console.Write("*");
                }
            }
            leftPart--;
            rightPart++;
            roofHeight++;
            Console.WriteLine();
        }

        for (int col = 0; col < height; col++)
        {
            Console.Write("*");
        }
        Console.WriteLine();

        int wallDistance = height / 4;
        int houseHeight = height - (roofHeight + 2);

        for (int row = 0; row < houseHeight; row++)
        {
            for (int col = 0; col < height; col++)
            {
                if (col != wallDistance && col != (height - 1) - wallDistance)
                {
                    Console.Write(".");
                }
                else
                {
                    Console.Write("*");
                }
            }
            Console.WriteLine();
        }

        for (int col = 0; col < height; col++)
        {
            if (col >= wallDistance && col <= (height - 1) - wallDistance)
            {
                Console.Write("*");
            }
            else
            {
                Console.Write(".");
            }
        }
    }
}
