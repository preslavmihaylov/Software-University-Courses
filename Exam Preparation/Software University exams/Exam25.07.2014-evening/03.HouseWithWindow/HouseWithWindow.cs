using System;

class HouseWithWindow
{
    static void Main()
    {
        int input = int.Parse(Console.ReadLine());

        int width = 2 * input - 1;
        int height = 2 * input + 2;
        int roofHeight = input;
        int baseHeight = input + 2;
        int windowHeight = input / 2;
        int windowWidth = input - 3;

        int left = width / 2;
        int right = left;

        // roof
        for (int row = 0; row < roofHeight + 1; row++)
        {
            for (int col = 0; col < width; col++)
            {
                if (col == left || col == right)
                {
                    Console.Write("*");
                }
                else if (row == roofHeight)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
            left--;
            right++;
        }

        // base
        for (int row = 0; row < baseHeight - 1; row++)
        {
            for (int col = 0; col < width; col++)
            {
                if (col > input / 2 && col <= input / 2 + windowWidth && row >= input / 4 && row < input / 4 + windowHeight)
                {
                    Console.Write("*");
                }
                else if (col == 0 || col == width - 1 || row == baseHeight - 2)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
        }
    }
}
