namespace _03.MagicWand
{
    using System;

    class MagicWand
    {
        static void Main()
        {
            int input = int.Parse(Console.ReadLine());

            int width = (input * 3) + 2;

            int left = width / 2;
            int right = left;

            int row = 0;
            
            while (left != (input - 1))
            {
                for (int col = 0; col < width; col++)
                {
                    if (col == left || col == right)
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write('.');
                    }
                }
                Console.WriteLine();

                left--;
                right++;
                row++;
            }

            for (int col = 0; col < width; col++)
            {
                if (col <= left || col >= right)
                {
                    Console.Write('*');
                }
                else
                {
                    Console.Write('.');
                }
            }
            Console.WriteLine();

            left = 1;
            right = width - 2;

            for (row = 0; row < input / 2; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    if (col == left || col == right)
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write('.');
                    }
                }

                left++;
                right--;
                Console.WriteLine();
            }

            left -= 2;
            right += 2;
            int rows = input / 2;
            int leftPillar = input;
            int rightPillar = width - input - 1;

            for (row = 0; row < rows; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    if (col == left ||
                        col == left + rows + 1 ||
                        col == right || 
                        col == right - rows - 1 ||
                        col == leftPillar ||
                        col == rightPillar)
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write('.');
                    }
                }

                left--;
                right++;
                Console.WriteLine();
            }

            for (int col = 0; col < width; col++)
            {
                if (col <= rows ||
                    col >= width - rows - 1 ||
                    col == leftPillar ||
                    col == rightPillar)
                {
                    Console.Write('*');
                }
                else
                {
                    Console.Write('.');
                }
            }
            Console.WriteLine();

            for (row = 0; row < input + 1; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    
                    if (col == leftPillar || col == rightPillar)
                    {
                        Console.Write('*');
                    }
                    else if (row == input &&
                        (col >= leftPillar && col <= rightPillar))
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write('.');
                    }
                }
                Console.WriteLine();
            }
        }
    }
}