using System;

class Portals
{
    private const int ResultNotFound = -1;

    static int[,] matrix;
    private static bool[,] taken;
    private static int startX;
    private static int startY;
    private static int maxPower = 0;

    static void Main()
    {
        ProcessInput();
        int result = FindMaxPower(startX, startY);

        Console.WriteLine(result);
    }

    static int FindMaxPower(int row, int col)
    {
        if (!AreValidCoords(row, col) || matrix[row, col] == ResultNotFound || taken[row, col])
        {
            return 0;
        }

        int currentPower = matrix[row, col];
        int currentMaxPower = 0;

        taken[row, col] = true;

        currentMaxPower = Math.Max(currentMaxPower, FindMaxPower(row, col + currentPower));
        currentMaxPower = Math.Max(currentMaxPower, FindMaxPower(row + currentPower, col));
        currentMaxPower = Math.Max(currentMaxPower, FindMaxPower(row, col - currentPower));
        currentMaxPower = Math.Max(currentMaxPower, FindMaxPower(row - currentPower, col));

        taken[row, col] = false;

        if (IsValidEndpoint(row, col, currentPower))
        {
            return currentMaxPower + currentPower;
        }
        else
        {
            return 0;
        }
    }

    static bool IsValidEndpoint(int row, int col, int currentPower)
    {
        if (AreValidCoords(row, col + currentPower) && matrix[row, col + currentPower] != ResultNotFound)
        {
            return true;
        }

        if (AreValidCoords(row + currentPower, col) && matrix[row + currentPower, col] != ResultNotFound)
        {
            return true;
        }

        if (AreValidCoords(row, col - currentPower) && matrix[row, col - currentPower] != ResultNotFound)
        {
            return true;
        }

        if (AreValidCoords(row - currentPower, col) && matrix[row - currentPower, col] != ResultNotFound)
        {
            return true;
        }

        return false;
    }

    static bool AreValidCoords(int row, int col)
    {
        return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
    }

    static void ProcessInput()
    {
        string[] input;
        input = Console.ReadLine().Split(' ');

        startX = int.Parse(input[0]);
        startY = int.Parse(input[1]);

        input = Console.ReadLine().Split(' ');

        int rows = int.Parse(input[0]);
        int cols = int.Parse(input[1]);

        matrix = new int[rows, cols];
        taken = new bool[rows, cols];

        for (int row = 0; row < rows; ++row)
        {
            input = Console.ReadLine().Split(' ');

            for (int col = 0; col < cols; ++col)
            {
                matrix[row, col] = input[col] != "#" ? int.Parse(input[col]) : ResultNotFound;
            }
        }
    }
}