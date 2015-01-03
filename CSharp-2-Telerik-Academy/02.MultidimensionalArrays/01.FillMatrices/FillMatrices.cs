using System;
class FillMatrices
{
    static int[,] matrix;
    static int limit;

    static void Main()
    {
        Console.Write("Enter matrix size: ");
        int matrixSize = int.Parse(Console.ReadLine());

        matrix = new int[matrixSize, matrixSize];
        limit = matrixSize * matrixSize;

        Console.Write("Enter selection type: ");
        string selection = Console.ReadLine();

        switch (selection)
        {
            case "a":
                selectionA();
                break;
            case "b":
                selectionB();
                break;
            case "c":
                selectionC();
                break;
            case "d":
                selectionD();
                break;
            default:
                Console.WriteLine("Invalid selection");
                return;
        }

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write((matrix[row, col]).ToString().PadRight(4));
            }
            Console.WriteLine();
        }
    }

    private static void selectionA()
    {
        int count = 1;
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                matrix[row, col] = count++;
            }
        }
    }

    private static void selectionB()
    {
        int count = 1;
        int col = 0;
        while (count <= limit)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                matrix[row, col] = count++;
            }

            col++;

            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                matrix[row, col] = count++;
            }

            col++;
        }
    }

    private static void selectionC()
    {
        int count = 1;
        int startRow = matrix.GetLength(0) - 1;
        int startCol = 0;

        while (count <= limit)
        {
            int col = startCol;
            int row = startRow;

            while (row < matrix.GetLength(0) && col < matrix.GetLength(1))
            {
                matrix[row++, col++] = count++;
            }

            if (startRow != 0)
            {
                startRow--;
            }
            else
            {
                startCol++;
            }
        }
    }

    private static void selectionD()
    {
        int count = 1;
        int row = -1;
        int col = 0;
        int rowVelocity = 1;
        int colVelocity = 0;

        while (count <= limit)
        {
            while (row + rowVelocity < matrix.GetLength(0) && col + colVelocity < matrix.GetLength(1) 
                && row + rowVelocity >= 0 && col + colVelocity >= 0
                && matrix[row + rowVelocity, col + colVelocity] == 0)
            {
                row += rowVelocity;
                col += colVelocity;
                matrix[row, col] = count++;
            }

            // turn
            if (colVelocity == 1)
            {
                rowVelocity = -1;
                colVelocity = 0;
            }
            else if (colVelocity == -1)
            {
                rowVelocity = 1;
                colVelocity = 0;
            }
            else if (rowVelocity == 1) 
            {
                rowVelocity = 0;
                colVelocity = 1;
            }
            else
            {
                rowVelocity = 0;
                colVelocity = -1;
            }
        }
    }
}
