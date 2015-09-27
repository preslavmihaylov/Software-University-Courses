namespace LiveDemo
{
    using System;

    class LiveDemo
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            int cols = number * 3;

            int leftRay = 0;
            int rightRay = cols - 1;

            // Upper part
            for (int row = 0; row < number; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (cols / 2 == col)
                    {
                        Console.Write("*");
                    }
                    else if (row != 0 && (col == leftRay || col == rightRay))
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }

                leftRay++;
                rightRay--;
                Console.WriteLine();
            }

            // Middle part
            for (int row = 0; row < number; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (cols / 2 == col || number / 2 == row)
                    {
                        Console.Write("*");
                    }
                    else if (col >= number && col < cols - number)
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

            leftRay--;
            rightRay++;

            // Lower part
            for (int row = 0; row < number; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (cols / 2 == col)
                    {
                        Console.Write("*");
                    }
                    else if ((row != number - 1) && (col == leftRay || col == rightRay))
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
                leftRay--;
                rightRay++;
            }
        }
    }
}