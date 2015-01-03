using System;
using System.Collections.Generic;
class LongestSequenceOfEqualStrings
{
    static string[,] matrix;
    static List<string> maxSequence = new List<string>();
    static void Main()
    {
        Console.Write("Input num of rows: ");
        int rows = int.Parse(Console.ReadLine());
        Console.Write("Input num of cols: ");
        int cols = int.Parse(Console.ReadLine());

        matrix = new string[rows, cols];
        for (int row = 0; row < rows; row++)
        {
            Console.WriteLine("Enter row {0}", (row + 1));
            string[] input = Console.ReadLine().Split();
            for (int index = 0; index < input.Length; index++)
            {
                matrix[row, index] = input[index];
            }
        }

        Console.WriteLine(new string('-', 20));
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Console.Write(matrix[row, col].ToString().PadLeft(4));
            }
            Console.WriteLine();
        }



        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                checkHorizontal(row, col);
                checkVertical(row, col);
                checkDiagonals(row, col);
            }
        }

        Console.WriteLine(new string('-', 20));

        Console.WriteLine(String.Join(", ", maxSequence));
    }

    private static void checkHorizontal(int row, int col)
    {
        List<string> currentSequence = new List<string>();
        string element = matrix[row, col];

        for (int currentCol = col; currentCol < matrix.GetLength(1); currentCol++)
        {
            if (element == matrix[row, currentCol])
            {
                currentSequence.Add(matrix[row, currentCol]);
            }
            else
            {
                break;
            }
        }

        if (currentSequence.Count > maxSequence.Count)
        {
            maxSequence = currentSequence;
        }
    }

    private static void checkVertical(int row, int col)
    {
        List<string> currentSequence = new List<string>();
        string element = matrix[row, col];

        for (int currentRow = row; currentRow < matrix.GetLength(0); currentRow++)
        {
            if (element == matrix[currentRow, col])
            {
                currentSequence.Add(matrix[currentRow, col]);
            }
            else
            {
                break;
            }
        }

        if (currentSequence.Count > maxSequence.Count)
        {
            maxSequence = currentSequence;
        }
    }

    private static void checkDiagonals(int row, int col)
    {
        List<string> currentSequence = new List<string>();
        string element = matrix[row, col];

        for (int currentRow = row, currentCol = col; 
            currentRow < matrix.GetLength(0) && currentCol < matrix.GetLength(1);
            currentRow++, currentCol++)
        {
            if (element == matrix[currentRow, currentCol])
            {
                currentSequence.Add(matrix[currentRow, currentCol]);
            }
            else
            {
                break;
            }
        }

        if (currentSequence.Count > maxSequence.Count)
        {
            maxSequence = currentSequence;
        }

        currentSequence = new List<string>();

        for (int currentRow = row, currentCol = col;
            currentRow < matrix.GetLength(0) && currentCol >= 0;
            currentRow++, currentCol--)
        {
            if (element == matrix[currentRow, currentCol])
            {
                currentSequence.Add(matrix[currentRow, currentCol]);
            }
            else
            {
                break;
            }
        }

        if (currentSequence.Count > maxSequence.Count)
        {
            maxSequence = currentSequence;
        }
    }
}
