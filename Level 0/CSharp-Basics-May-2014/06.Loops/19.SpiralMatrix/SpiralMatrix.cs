using System;

class SpiralMatrix
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        int[,] matrix = new int[number, number];

        int start = 0;
        int end = number - 1;
        int currentNum = 1;

        while (start < end)
        {
            // top
            for (int col = start; col < end; col++)
            {
                matrix[start, col] = currentNum;
                currentNum++;
            }

            // right
            for (int row = start; row < end; row++)
            {
                matrix[row, end] = currentNum;
                currentNum++;
            }

            // bottom
            for (int col = end; col > start; col--)
            {
                matrix[end, col] = currentNum;
                currentNum++;
            }

            // left
            for (int row = end; row > start; row--)
            {
                matrix[row, start] = currentNum;
                currentNum++;
            }

            start++;
            end--;
        }


        if (number % 2 == 1)
        {
            matrix[number / 2, number / 2] = currentNum;
        }

        for (int row = 0; row < number; row++)
        {
            for (int col = 0; col < number; col++)
            {
                if (matrix[row, col] < 10)
                {
                    Console.Write(matrix[row, col] + "  ");
                }
                else
                {
                    Console.Write(matrix[row, col] + " ");
                }
            }
            Console.WriteLine();
        }
        Console.ReadLine();

    }
}
