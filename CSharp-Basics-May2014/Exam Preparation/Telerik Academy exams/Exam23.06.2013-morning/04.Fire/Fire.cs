using System;

class Fire
{
    static void Main()
    {
        int fireWidth = int.Parse(Console.ReadLine());

        int left = fireWidth / 2 - 1;
        int right = fireWidth / 2;

        while (left >= 0)
        {
            for (int col = 0; col < fireWidth; col++)
            {
                if (col == left || col == right)
                {
                    Console.Write("#");
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

        left = 0;
        right = fireWidth - 1;

        while (left + (fireWidth / 2) + 1 <= right)
        {
            for (int col = 0; col < fireWidth; col++)
            {
                if (col == left || col == right)
                {
                    Console.Write("#");
                }
                else
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
            left++;
            right--;
        }

        Console.WriteLine(new string('-', fireWidth));
        left = 0;
        right = fireWidth - 1;

        for (int row = 0; row < fireWidth / 2; row++)
        {
            for (int col = 0; col < fireWidth; col++)
            {
                if (col >= left && col < fireWidth / 2)
                {
                    Console.Write("\\");
                }
                else if (col <= right && col >= fireWidth / 2)
                {
                    Console.Write("/");
                }
                else
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
            left++;
            right--;
        }
    }
}
