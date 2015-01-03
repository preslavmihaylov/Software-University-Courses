using System;
class FindMaxSumOfElementsInSquare
{
    static Random randGenerator = new Random();
    static void Main()
    {
        Console.Write("Input num of rows: ");
        int rows = int.Parse(Console.ReadLine());
        Console.Write("Input num of cols: ");
        int cols = int.Parse(Console.ReadLine());

        Console.WriteLine(new string('-', 20));

        int[,] matrix = new int[rows, cols];

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = randGenerator.Next(100);
            }
        }

        int maxSum = int.MinValue;
        int startRow = 0;
        int startCol = 0;

        for (int row = 0; row < rows - 2; row++)
        {
            for (int col = 0; col < cols - 2; col++)
            {
                int currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                    matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                    matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                if (maxSum < currentSum)
                {
                    maxSum = currentSum;
                    startRow = row;
                    startCol = col;
                }
            }
        }


        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Console.Write(matrix[row, col].ToString().PadLeft(4));
            }
            Console.WriteLine();
        }

        Console.WriteLine(new string('-', 20));

        // print the part of the matrix with largest sum
        for (int row = startRow; row < startRow + 3; row++)
        {
            for (int col = startCol; col < startCol + 3; col++)
            {
                Console.Write(matrix[row, col].ToString().PadLeft(4));
            }
            Console.WriteLine();
        }

        Console.WriteLine(new string('-', 20));
        Console.Write("The max sum is: ");
        Console.WriteLine(maxSum);
    }
}
