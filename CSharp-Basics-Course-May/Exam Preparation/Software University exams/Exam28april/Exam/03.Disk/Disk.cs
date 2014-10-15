using System;
class Disk
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int radius = int.Parse(Console.ReadLine());
        int[,] field = new int[N, N];
        int rows = N / 2;
        int cols = (N / 2) * (-1);
        int row = -1;
        int col = 0;
        for (int i = rows; i >= (N / 2) * (-1); i--)
        {
            row++;
            col = 0;
            Console.WriteLine();
            for (int k = cols; k <= N / 2; k++)
            {
                if (i * i + k * k <= radius * radius)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
                col++;
            }
        }
    }
}