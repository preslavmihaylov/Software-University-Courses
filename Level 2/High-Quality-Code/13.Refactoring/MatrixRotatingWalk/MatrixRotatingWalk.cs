using System;

class MatrixRotatingWalk
{
    static int[,] matrix;
    static int currentNumber = 1;
    static int directionX = 1;
    static int directionY = 1;
    static int currentRow = 0;
    static int currentCol = 0;

    static void Main()
    {
        int matrixSize = int.Parse(Console.ReadLine());
        matrix = new int[matrixSize, matrixSize];

        ExecuteRotatingWalk();

        FindCell();
        currentNumber++;

        if (currentRow != 0 && currentCol != 0)
        {
            directionX = 1; 
            directionY = 1;

            ExecuteRotatingWalk();
        }

        PrintMatrix();
    }

    private static void ExecuteRotatingWalk()
    {
        while (true)
        {
            matrix[currentRow, currentCol] = currentNumber;

            if (!AnyPathAvailable())
            {
                break;
            }

            while (IsValidPosition())
            {
                ChangeDirection();
            }

            currentRow += directionX;
            currentCol += directionY;
            currentNumber++;
        }
    }

    private static bool IsValidPosition()
    {
        return currentRow + directionX >= matrix.GetLength(0) ||
               currentRow + directionX < 0 ||
               currentCol + directionY >= matrix.GetLength(1) ||
               currentCol + directionY < 0 ||
               matrix[currentRow + directionX, currentCol + directionY] != 0;
    }

    static void ChangeDirection() 
    {
        int[] directionsX = {1, 1, 1, 0, -1, -1, -1 , 0};
		int[] directionsY = {1, 0, -1, -1, -1, 0, 1, 1};
        int newDirection = 0;

        for (int count = 0; count < 8; count++)
        {
            if (directionsX[count] == directionX && directionsY[count] == directionY)
            {
                newDirection = count; 
                break;
            }
        }

        if (newDirection == 7)
        {
            directionX = directionsX[0];
            directionY = directionsY[0];
            return;
        }

        directionX = directionsX[newDirection+1];
        directionY = directionsY[newDirection + 1];
    }

    static bool AnyPathAvailable() 
    {
        int[] directionsX = { 1, 1, 1, 0, -1, -1, -1, 0 };
        int[] directionsY = { 1, 0, -1, -1, -1, 0, 1, 1 };

        for (int i = 0; i < 8; i++)
        {
            if (currentRow + directionsX[i] < matrix.GetLength(0) &&
                currentRow + directionsX[i] >= 0 && 
                currentCol + directionsY[i] < matrix.GetLength(0) &&
                currentCol + directionsY[i] >= 0 &&
                matrix[currentRow + directionsX[i], currentCol + directionsY[i]] == 0)
            {
                return true;
            }   
        }

        return false;
    }

    static void FindCell ()
    {
        currentRow = 0;
        currentCol = 0;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == 0)
                {
                    currentRow = i;
                    currentCol = j;
                    return;
                }                  
            } 
        }
    }

    private static void PrintMatrix()
    {
        for (int currentRow = 0; currentRow < matrix.GetLength(0); currentRow++)
        {
            for (int currentCol = 0; currentCol < matrix.GetLength(1); currentCol++)
            {
                Console.Write("{0,3}", matrix[currentRow, currentCol]);
            }

            Console.WriteLine();
        }
    }
}