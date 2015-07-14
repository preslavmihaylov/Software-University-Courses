/*

Valid Input Example:

6
0 0 0 x 0 x
0 x 0 x 0 x
0 * x 0 x 0
0 x 0 0 0 0
0 0 0 x x 0
0 0 0 x 0 x
  
*/

using System;

class DistanceInLabyrinth
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());

        string[,] labyrinth = new string[size, size];
        int startingRow = -1;
        int startingCol = -1;

        labyrinth = ReadInputLabyrinthAndGetStartingPosition(size, 
            ref startingRow, 
            ref startingCol);
        
        FindPaths(labyrinth, startingRow, startingCol, 0);
        MarkUnaccessiblePositions(labyrinth);

        Console.WriteLine();
        Console.WriteLine("Result: ");
        PrintLabyrinth(labyrinth);
    }

    private static void FindPaths(string[,] labyrinth, int row, int col, int currentStep)
    {
        int positionValue;

        // If the current position is invalid - exit
        if (!IsInRange(labyrinth, row, col))
        {
            return;
        }
        
        // If the current position is a wall - exit
        if (labyrinth[row, col] == "x")
        {
            return;
        }
        
        if (int.TryParse(labyrinth[row, col], out positionValue))
        {
            // If the previous route is not longer than the current one - stop
            if (positionValue < currentStep && positionValue != 0)
            {
                return;
            }
        }

        // If the current position is different from the starting position:
        // Assign the current step
        if (labyrinth[row, col] != "*")
        {
            labyrinth[row, col] = currentStep.ToString();
        }

        // Increment the step and go through all possible routes
        currentStep++;
        FindPaths(labyrinth, row, col + 1, currentStep);
        FindPaths(labyrinth, row + 1, col, currentStep);
        FindPaths(labyrinth, row, col - 1, currentStep);
        FindPaths(labyrinth, row - 1, col, currentStep);
    }

    static void MarkUnaccessiblePositions(string[,] labyrinth)
    {
        for (int row = 0; row < labyrinth.GetLength(0); row++)
        {
            for (int col = 0; col < labyrinth.GetLength(1); col++)
            {
                if (labyrinth[row, col] == "0")
                {
                    labyrinth[row, col] = "u";
                }
            }
        }
    }

    static string[,] ReadInputLabyrinthAndGetStartingPosition(int size,
        ref int startingRow, 
        ref int startingCol)
    {
        string[,] labyrinth = new string[size, size];

        for (int row = 0; row < size; row++)
        {
            string[] inputRow = Console.ReadLine().Split(' ');

            if (inputRow.Length != size)
            {
                throw new ArgumentException("Invalid input");
            }

            for (int col = 0; col < size; col++)
            {
                labyrinth[row, col] = inputRow[col].ToString();
                if (labyrinth[row, col] == "*")
                {
                    startingRow = row;
                    startingCol = col;
                }
            }
        }

        return labyrinth;
    }

    static bool IsInRange(string[,] labyrinth, int row, int col)
    {
        if (row >= labyrinth.GetLength(0) || 
            row < 0 ||
            col >= labyrinth.GetLength(1) ||
            col < 0)
        {
            return false;
        }

        return true;
    }

    static void PrintLabyrinth(string[,] labyrinth)
    {
        for (int row = 0; row < labyrinth.GetLength(0); row++)
        {
            for (int col = 0; col < labyrinth.GetLength(1); col++)
            {
                Console.Write(labyrinth[row, col].PadLeft(2, ' ') + " ");
            }
            Console.WriteLine();
        }
    }
}