using System;
class BreadthFirstSearch
{
    static Random randGenerator = new Random();
    static int currentCount = 0;
    static int maxCount = 0;
    static int maxCountValue = 0;
    static int[,] matrix;
    static void Main()
    {
        matrix = new int[5, 5];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = randGenerator.Next(4) + 1;
            }
        }

        printMatrix(matrix);

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int currentValue = matrix[row, col];
                if (matrix[row, col] != -1)
                {
                    breadthFirstSearch(row, col, matrix[row, col]);
                }

                if (currentCount > maxCount)
                {
                    maxCount = currentCount;
                    maxCountValue = currentValue;
                }
                currentCount = 0;
            }
        }

        Console.WriteLine(maxCountValue + " --> " + maxCount);
    }

    private static void breadthFirstSearch(int row, int col, int value)
    {

        if (!inRange(row, col))
        {
            return;
        }

        if (matrix[row, col] != value)
        {
            return;
        }

        matrix[row, col] = -1;
        currentCount++;
        breadthFirstSearch(row, col + 1, value); // right
        breadthFirstSearch(row, col - 1, value); // left
        breadthFirstSearch(row - 1, col, value); // top
        breadthFirstSearch(row + 1, col, value); // bottom
    }

    private static bool inRange(int row,int col)
    {
        if (row < 0 || row >= matrix.GetLength(0) ||
            col < 0 || col >= matrix.GetLength(1))
        {
            return false;
        }

        return true;
    }

    private static void printMatrix(int[,] matrix)
    {
        string output = "";
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (col != matrix.GetLength(1) - 1)
                {
                    output += matrix[row, col] + ", ";
                }
                else
                {
                    output += matrix[row, col] + "\n";
                }
            }
        }

        Console.WriteLine(output);
        Console.WriteLine(new string('-', 20));
    }
}
