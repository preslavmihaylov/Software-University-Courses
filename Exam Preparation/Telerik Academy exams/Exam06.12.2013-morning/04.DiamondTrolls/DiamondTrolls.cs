using System;

class DiamondTrolls
{
    static void Main()
    {
        int input = int.Parse(Console.ReadLine());

        int width = input * 2 + 1;
        int height = (6 + ((input - 3) / 2) * 3);

        int center = width / 2;
        int left = (width - input) / 2;
        int right = left + input - 1;

        bool backwards = false;

        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                if (row == 0 && col >= left && col <= right)
                {
                    Console.Write("*");
                }
                else if (row == height - input - 1)
                {
                    Console.Write("*");
                }
                else if (col == center || col == left || col == right)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();

            if (backwards)
            {
                left++;
                right--;
            }
            else
            {
                left--;
                right++;
            }

            if (left == 0)
            {
                backwards = true;
            }
        }
    }
}
