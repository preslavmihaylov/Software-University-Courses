using System;
using System.Collections.Generic;

enum Direction
{
    Up,
    Down
}


class Operation
{
    public int Setup { get; set; }
    public int MovesCount { get; set; }

    public Operation(int setup, int movesCount)
    {
        this.Setup = setup;
        this.MovesCount = movesCount;
    }
}

class RiskWinsRishLoses
{
    const int ResultNotFound = -1;

    static int initialSetup;
    static int targetSetup;
    static HashSet<int> duplicates = new HashSet<int>();

    static void Main()
    {
        ProcessInput();
        int minMoves = CalculateMinShiftsToTargetSetup();
        PrintOutput(minMoves);
    }

    static int CalculateMinShiftsToTargetSetup()
    {
        Queue<Operation> operationQueue = new Queue<Operation>();

        operationQueue.Enqueue(new Operation(initialSetup, 0));

        while (operationQueue.Count > 0)
        {
            Operation currentOperation = operationQueue.Dequeue();

            if (targetSetup == currentOperation.Setup)
            {
                return currentOperation.MovesCount;
            }

            if (!duplicates.Contains(currentOperation.Setup))
            {
                duplicates.Add(currentOperation.Setup);
                int nextMovesCount = currentOperation.MovesCount + 1;

                operationQueue.Enqueue(
                    new Operation(
                        ShiftDigit(currentOperation.Setup, 4, Direction.Up),
                        nextMovesCount));
                operationQueue.Enqueue(
                    new Operation(
                        ShiftDigit(currentOperation.Setup, 4, Direction.Down),
                        nextMovesCount));
                operationQueue.Enqueue(
                    new Operation(
                        ShiftDigit(currentOperation.Setup, 3, Direction.Up),
                        nextMovesCount));
                operationQueue.Enqueue(
                    new Operation(
                        ShiftDigit(currentOperation.Setup, 3, Direction.Down),
                        nextMovesCount));
                operationQueue.Enqueue(
                    new Operation(
                        ShiftDigit(currentOperation.Setup, 2, Direction.Up),
                        nextMovesCount));
                operationQueue.Enqueue(
                    new Operation(
                        ShiftDigit(currentOperation.Setup, 2, Direction.Down),
                        nextMovesCount));
                operationQueue.Enqueue(
                    new Operation(
                        ShiftDigit(currentOperation.Setup, 1, Direction.Up),
                        nextMovesCount));
                operationQueue.Enqueue(
                    new Operation(
                        ShiftDigit(currentOperation.Setup, 1, Direction.Down),
                        nextMovesCount));
                operationQueue.Enqueue(
                    new Operation(
                        ShiftDigit(currentOperation.Setup, 0, Direction.Up),
                        nextMovesCount));
                operationQueue.Enqueue(
                    new Operation(
                        ShiftDigit(currentOperation.Setup, 0, Direction.Down),
                        nextMovesCount));
            }
        }

        return ResultNotFound;
    }

    static int ShiftDigit(int setup, int digitPos, Direction direction)
    {
        int digit = GetDigit(setup, digitPos);
        if (digit == 0 && direction == Direction.Down)
        {
            return setup + ((int)Math.Pow(10, digitPos) * 9);
        }
        else if (digit == 9 && direction == Direction.Up)
        {
            return setup - ((int)Math.Pow(10, digitPos) * 9);
        }
        else
        {
            if (direction == Direction.Up)
            {
                return setup + (int)Math.Pow(10, digitPos);
            }
            else
            {
                return setup - (int)Math.Pow(10, digitPos);
            }
        }
    }

    static int GetDigit(int number, int position)
    {
        return ( number / (int)Math.Pow(10, position) ) % 10;
    }

    static void PrintOutput(int minMoves)
    {
        Console.WriteLine(minMoves);
    }

    static void ProcessInput()
    {
        initialSetup = int.Parse(Console.ReadLine());
        targetSetup = int.Parse(Console.ReadLine());
        int forbiddenSetupsCount = int.Parse(Console.ReadLine());

        for (int cnt = 0; cnt < forbiddenSetupsCount; cnt++)
        {
            duplicates.Add(int.Parse(Console.ReadLine()));
        }
    }
}