using System;
using System.Collections;
using System.Collections.Generic;

class RideTheHorse
{
    struct Cell
    {
        private int row;
        private int col;

        public Cell(int row, int col)
        {
            this.row = row;
            this.col = col;
        }

        public int Row
        {
            get { return this.row; }
            set { this.row = value; }
        }

        public int Col
        {
            get { return this.col; }
            set { this.col = value; }
        }

    }

    private static int[,] matrix;

    static void Main()
    {
        int matrixRows = int.Parse(Console.ReadLine());
        int matrixCols = int.Parse(Console.ReadLine());
        int horseStartingRow = int.Parse(Console.ReadLine());
        int horseStartingCol = int.Parse(Console.ReadLine());

        matrix = new int[matrixRows, matrixCols];

        TraverseField(horseStartingRow, horseStartingCol);

        PrintMatrix();

        Console.WriteLine();

        PrintColumn(matrixCols / 2);
    }

    /* Implementing BFS */
    private static void TraverseField(int startingRow, int startingCol)
    {
        Queue<Cell> operationQueue = new Queue<Cell>();

        operationQueue.Enqueue(new Cell(startingRow, startingCol));
        matrix[startingRow, startingCol] = 1;

        while (operationQueue.Count > 0)
        {
            Cell currentCell = operationQueue.Dequeue();

            /* Bottom-Right-Up */
            if (IsValidCellCoordinates(currentCell.Row + 1, currentCell.Col + 2))
            {
                operationQueue.Enqueue(new Cell(currentCell.Row + 1, currentCell.Col + 2));
                matrix[currentCell.Row + 1, currentCell.Col + 2] = matrix[currentCell.Row, currentCell.Col] + 1;
            }

            /* Bottom-Right-Down */
            if (IsValidCellCoordinates(currentCell.Row + 2, currentCell.Col + 1))
            {
                operationQueue.Enqueue(new Cell(currentCell.Row + 2, currentCell.Col + 1));
                matrix[currentCell.Row + 2, currentCell.Col + 1] = matrix[currentCell.Row, currentCell.Col] + 1;
            }

            /* Bottom-Left-Up */
            if (IsValidCellCoordinates(currentCell.Row + 1, currentCell.Col - 2))
            {
                operationQueue.Enqueue(new Cell(currentCell.Row + 1, currentCell.Col - 2));
                matrix[currentCell.Row + 1, currentCell.Col - 2] = matrix[currentCell.Row, currentCell.Col] + 1;
            }

            /* Bottom-Left-Down */
            if (IsValidCellCoordinates(currentCell.Row + 2, currentCell.Col - 1))
            {
                operationQueue.Enqueue(new Cell(currentCell.Row + 2, currentCell.Col - 1));
                matrix[currentCell.Row + 2, currentCell.Col - 1] = matrix[currentCell.Row, currentCell.Col] + 1;
            }

            /* Top-Left-Up */
            if (IsValidCellCoordinates(currentCell.Row - 2, currentCell.Col - 1))
            {
                operationQueue.Enqueue(new Cell(currentCell.Row - 2, currentCell.Col - 1));
                matrix[currentCell.Row - 2, currentCell.Col - 1] = matrix[currentCell.Row, currentCell.Col] + 1;
            }

            /* Top-Left-Down */
            if (IsValidCellCoordinates(currentCell.Row - 1, currentCell.Col - 2))
            {
                operationQueue.Enqueue(new Cell(currentCell.Row - 1, currentCell.Col - 2));
                matrix[currentCell.Row - 1, currentCell.Col - 2] = matrix[currentCell.Row, currentCell.Col] + 1;
            }

            /* Top-Right-Up */
            if (IsValidCellCoordinates(currentCell.Row - 2, currentCell.Col + 1))
            {
                operationQueue.Enqueue(new Cell(currentCell.Row - 2, currentCell.Col + 1));
                matrix[currentCell.Row - 2, currentCell.Col + 1] = matrix[currentCell.Row, currentCell.Col] + 1;
            }

            /* Top-Right-Down */
            if (IsValidCellCoordinates(currentCell.Row - 1, currentCell.Col + 2))
            {
                operationQueue.Enqueue(new Cell(currentCell.Row - 1, currentCell.Col + 2));
                matrix[currentCell.Row - 1, currentCell.Col + 2] = matrix[currentCell.Row, currentCell.Col] + 1;
            }
        }
    }

    private static bool IsValidCellCoordinates(int row, int col)
    {
        if (row >= 0 && row < matrix.GetLength(0) &&
            col >= 0 && col < matrix.GetLength(1) &&
            matrix[row, col] == 0)
        {
            return true;
        }

        return false;
    }

    private static void PrintMatrix()
    {
        Console.WriteLine(new string('-', (matrix.GetLength(1) * 3) + matrix.GetLength(1) + 1));
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (col == 0 || col == matrix.GetLength(1))
                {
                    Console.Write("|" + matrix[row, col].ToString().PadLeft(2, ' ') + " |");
                }
                else
                {
                    Console.Write(matrix[row, col].ToString().PadLeft(2, ' ') + " |");
                }
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', (matrix.GetLength(1) * 3) + matrix.GetLength(1) + 1));
        }
    }

    static void PrintColumn(int col)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            Console.Write(matrix[row, col] + " ");
        }
        Console.WriteLine();
    }
}