using System;
using System.ComponentModel;

class Plane
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int width = N * 3;
        int height = (N * 3) - (N / 2);

        int left = ((3 * N) - 1) / 2;
        int right = left;

        while (left >= N - 2)
        {
            for (int col = 0; col < N * 3; col++)
            {
                if (col == left || col == right)
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
        left--;
        right++;

        while (left >= 1)
        {
            for (int col = 0; col < N * 3; col++)
            {
                if (col == left || col == right)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
            left-= 2;
            right+= 2;
        }

        left = N - 1;
        right = width - N;
        int initialLeft = left;
        int initialRight = right;

        while (left >= 2)
        {
            for (int col = 0; col < N * 3; col++)
            {
                if (col == left || col == right ||
                    col == 0 || col == width - 1 ||
                    col == initialLeft || col == initialRight)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
            left -= 2;
            right += 2;
        }

        left = initialLeft;
        right = initialRight;

        while (left >= 0)
        {
            for (int col = 0; col < N * 3; col++)
            {
                if (col == left || col == right ||
                    left == 0)
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

    }
}
