using System;
using System.Collections.Generic;

class Labyrinth3D
{
    static char[,,] labyrinth;
    static Point startingPosition = new Point();
    static bool[,,] used;

    static void Main()
    {
        ProcessInput();
        FindShortestPathToExit();
    }

    static void FindShortestPathToExit()
    {
        Queue<Move> operationQueue = new Queue<Move>();
        operationQueue.Enqueue(new Move() { CurrentPosition = startingPosition, MovesCount = 0 });

        while (operationQueue.Count > 0)
        {
            Move currentMove = operationQueue.Dequeue();
            int x = currentMove.CurrentPosition.X;
            int y = currentMove.CurrentPosition.Y;
            int z = currentMove.CurrentPosition.Z;

            if (labyrinth[x, y, z] == '#')
            {
                continue;
            }

            int nextMovesCount = currentMove.MovesCount + 1;

            #region Advance to currentLevel
            if (labyrinth[x, y, z] == '.')
            {
                if (IsValidPosition(x, y + 1, z) && !used[x, y + 1, z])
                {
                    Point nextPoint = new Point() { X = x, Y = y + 1, Z = z };
                    used[x, y + 1, z] = true;
                    operationQueue.Enqueue(
                        new Move() { CurrentPosition = nextPoint, MovesCount = nextMovesCount });
                }

                if (IsValidPosition(x + 1, y, z) && !used[x + 1, y, z])
                {
                    Point nextPoint = new Point() { X = x + 1, Y = y, Z = z };
                    used[x + 1, y, z] = true;
                    operationQueue.Enqueue(
                        new Move() { CurrentPosition = nextPoint, MovesCount = nextMovesCount });
                }

                if (IsValidPosition(x, y - 1, z) && !used[x, y - 1, z])
                {
                    Point nextPoint = new Point() { X = x, Y = y - 1, Z = z };
                    used[x, y - 1, z] = true;
                    operationQueue.Enqueue(
                        new Move() { CurrentPosition = nextPoint, MovesCount = nextMovesCount });
                }

                if (IsValidPosition(x - 1, y, z) && !used[x - 1, y, z])
                {
                    Point nextPoint = new Point() { X = x - 1, Y = y, Z = z };
                    used[x - 1, y, z] = true;
                    operationQueue.Enqueue(
                        new Move() { CurrentPosition = nextPoint, MovesCount = nextMovesCount });
                }
            }
            #endregion

            if (labyrinth[x, y, z] == 'D')
            {
                if (IsExit(z - 1))
                {
                    PrintResult(nextMovesCount);
                    return;
                }

                if (!used[x, y, z - 1])
                {
                    Point nextPoint = new Point() { X = x, Y = y, Z = z - 1 };
                    used[x, y, z - 1] = true;
                    operationQueue.Enqueue(
                        new Move() { CurrentPosition = nextPoint, MovesCount = nextMovesCount });
                }
            }
            else if (labyrinth[x, y, z] == 'U')
            {
                if (IsExit(z + 1))
                {
                    PrintResult(nextMovesCount);
                    return;
                }

                if (!used[x, y, z + 1])
                {
                    Point nextPoint = new Point() { X = x, Y = y, Z = z + 1 };
                    used[x, y, z + 1] = true;
                    operationQueue.Enqueue(
                        new Move() { CurrentPosition = nextPoint, MovesCount = nextMovesCount });
                }
            }
        }
    }

    static bool IsValidPosition(int x, int y, int z)
    {
        return x >= 0 && x < labyrinth.GetLength(0) && 
               y >= 0 && y < labyrinth.GetLength(1) && 
               z >= 0 && z < labyrinth.GetLength(2);
    }

    static bool IsExit(int z)
    {
        return z < 0 || z >= labyrinth.GetLength(2);
    }

    static void PrintResult(int movesCount)
    {
        Console.WriteLine(movesCount);
    }

    static void ProcessInput()
    {
        string[] input = Console.ReadLine().Split(' ');
        startingPosition.Z = int.Parse(input[0]);
        startingPosition.X = int.Parse(input[1]);
        startingPosition.Y = int.Parse(input[2]);

        input = Console.ReadLine().Split(' ');
        int levels = int.Parse(input[0]);
        int rows = int.Parse(input[1]);
        int cols = int.Parse(input[2]);
        labyrinth = new char[rows, cols, levels];
        used = new bool[rows, cols, levels];

        string labyrinthRow;

        for (int level = 0; level < levels; level++)
        {
            for (int row = 0; row < rows; row++)
            {
                labyrinthRow = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    labyrinth[row, col, level] = labyrinthRow[col];
                }
            }
        }
    }
}

class Move
{
    public Point CurrentPosition { get; set; }

    public int MovesCount { get; set; }
}

class Point
{
    public int X { get; set; }

    public int Y { get; set; }

    public int Z { get; set; }
}