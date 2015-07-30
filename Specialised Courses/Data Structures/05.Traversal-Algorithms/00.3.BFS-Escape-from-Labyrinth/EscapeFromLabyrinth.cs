using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class EscapeFromLabyrinth
{
    private static char[,] labyrinth;
    private static bool[,] visitedPositions;
    private static Queue<Position> operationQueue;

    public static void Main()
    {
        int width = int.Parse(Console.ReadLine());
        int height = int.Parse(Console.ReadLine());

        labyrinth = new char[height, width];
        visitedPositions = new bool[height, width];
        operationQueue = new Queue<Position>();
        Position startingPosition = null;

        for (int row = 0; row < height; row++)
        {
            string currentRow = Console.ReadLine();
            if (width != currentRow.Length)
            {
                throw new InvalidOperationException("The labyrinth is invalid");
            }

            for (int col = 0; col < width; col++)
            {
                labyrinth[row, col] = currentRow[col];
                visitedPositions[row, col] = false;

                if (currentRow[col] == 's')
                {
                    startingPosition = new Position(row, col, 'S', null);
                }
            }
        }

        // PrintLabyrinth();

        if (startingPosition != null)
        {
            FindNearestExit(startingPosition);   
        }
        else
        {
            PrintExitPath(null);
        }
    }

    /* Implementing the BFS Algorithm */
    static void FindNearestExit(Position startingPosition)
    {
        operationQueue.Enqueue(startingPosition);

        while (operationQueue.Count > 0)
        {
            Position currentPosition = operationQueue.Dequeue();
            if (IsExit(currentPosition))
            {
                PrintExitPath(currentPosition);
                return;
            }
            else
            {
                if (AreValidCoordinates(currentPosition.Row - 1, currentPosition.Col) &&
                    IsValidPositionType(labyrinth[currentPosition.Row - 1, currentPosition.Col]))
                {
                    Position upPosition = new Position(currentPosition.Row - 1, 
                        currentPosition.Col, 
                        'U', 
                        currentPosition);

                    operationQueue.Enqueue(upPosition);

                    visitedPositions[currentPosition.Row - 1, currentPosition.Col] = true;
                }

                if (AreValidCoordinates(currentPosition.Row, currentPosition.Col + 1) &&
                    IsValidPositionType(labyrinth[currentPosition.Row, currentPosition.Col + 1]))
                {
                    Position rightPosition = new Position(currentPosition.Row, 
                        currentPosition.Col + 1, 
                        'R', 
                        currentPosition);

                    operationQueue.Enqueue(rightPosition);

                    visitedPositions[currentPosition.Row, currentPosition.Col + 1] = true;
                }

                if (AreValidCoordinates(currentPosition.Row + 1, currentPosition.Col) &&
                    IsValidPositionType(labyrinth[currentPosition.Row + 1, currentPosition.Col]))
                {
                    Position downPosition = new Position(currentPosition.Row + 1, 
                        currentPosition.Col, 
                        'D', 
                        currentPosition);

                    operationQueue.Enqueue(downPosition);

                    visitedPositions[currentPosition.Row + 1, currentPosition.Col] = true;
                }

                if (AreValidCoordinates(currentPosition.Row, currentPosition.Col - 1) &&
                    IsValidPositionType(labyrinth[currentPosition.Row, currentPosition.Col - 1]))
                {
                    Position leftPosition = new Position(currentPosition.Row, 
                        currentPosition.Col - 1, 
                        'L', 
                        currentPosition);

                    operationQueue.Enqueue(leftPosition);

                    visitedPositions[currentPosition.Row, currentPosition.Col - 1] = true;
                }
            }
        }

        PrintExitPath(null);
    }

    private static bool AreValidCoordinates(int row, int col)
    {
        if (row < 0 ||
            row >= labyrinth.GetLength(0) ||
            col < 0 || 
            col >= labyrinth.GetLength(1) ||
            visitedPositions[row, col] == true)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    static bool IsValidPositionType(char element)
    {
        if (element == '-')
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    static bool IsExit(Position position)
    {
        if (position.Row == 0 || 
            position.Row == labyrinth.GetLength(0) - 1 ||
            position.Col == 0 || 
            position.Col == labyrinth.GetLength(1) - 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    static void PrintExitPath(Position exitPosition)
    {
        string exitPath = GetExitPathDirections(exitPosition);

        if (exitPosition == null)
        {
            Console.WriteLine("No exit!");
        }
        else if (exitPath.Length == 0)
        {
            Console.WriteLine("Start is at the exit.");
        }
        else
        {
            Console.WriteLine("Shortest exit: {0}", exitPath);
        }
    }

    static string GetExitPathDirections(Position exitPosition)
    {
        StringBuilder path = new StringBuilder();
        Position currentPosition = exitPosition;

        while (currentPosition != null)
        {
            if (currentPosition.Direction == 'S')
            {
                break;
            }

            path.Insert(0, currentPosition.Direction);
            currentPosition = currentPosition.PreviousPosition;
        }

        return path.ToString();
    }

    static void PrintLabyrinth()
    {
        for (int row = 0; row < labyrinth.GetLength(0); row++)
        {
            for (int col = 0; col < labyrinth.GetLength(1); col++)
            {
                Console.Write(labyrinth[row, col]);
            }
            Console.WriteLine();
        }
    }
}
