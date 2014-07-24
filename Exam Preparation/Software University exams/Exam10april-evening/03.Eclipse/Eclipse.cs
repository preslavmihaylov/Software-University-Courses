using System;
class Eclipse
{
    static void Main()
    {
        int height = int.Parse(Console.ReadLine());
        char[,] sunglasses = new char[height, 4 * height + height];
        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < 4 * height + height; col++)
            {
                sunglasses[row, col] = ' ';
            }
        }

        int start = 0;
        int end = 2 * height;
        for (int row = 0; row < height; row++)
        {
            for (int col = start; col < end; col++)
            {
                if ((row == 0 && (col == start || col == end - 1)) ||
                    (row == height - 1 && (col == start || col == end - 1)))
                {
                    continue;
                }
                if (row == 0 || row == height - 1 || col == start || col == end - 1)
                {
                    sunglasses[row, col] = '*';
                }
                else
                {
                    sunglasses[row, col] = '/';
                }
            }
        }

        for (int col = end; col < end + height - 1; col++)
        {
            sunglasses[height / 2, col] = '-';
        }

        start = 2 * height + height - 1;
        end = 4 * height + height - 1;

        for (int row = 0; row < height; row++)
        {
            for (int col = start; col < end; col++)
            {
                if ((row == 0 && (col == start || col == end - 1)) ||
                    (row == height - 1 && (col == start || col == end - 1)))
                {
                    continue;
                }
                if (row == 0 || row == height - 1 || col == start || col == end - 1)
                {
                    sunglasses[row, col] = '*';
                }
                else
                {
                    sunglasses[row, col] = '/';
                }
            }
        }

        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < 4 * height + height; col++)
            {
                Console.Write(sunglasses[row, col]);
            }
            Console.WriteLine();
        }
    }
}