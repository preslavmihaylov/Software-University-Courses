using System;
using System.Collections.Generic;

class Program
{
    static int matrixLength;
    static int[,] matrix;
    static List<int> longestSequence = new List<int>();
    static List<int> currentSequence = new List<int>();

    static void Main()
    {
        string input = Console.ReadLine();
        matrixLength = int.Parse(Console.ReadLine());

        matrix = new int[matrixLength, matrixLength];
        int letterCount = 0;

        for (int row = 0; row < matrixLength; row++)
        {
            for (int col = 0; col < matrixLength; col++)
            {
                matrix[row, col] = input[letterCount];
                letterCount++;
                if (letterCount == input.Length)
                {
                    letterCount = 0;
                }
            }
        }

        for (int row = 0; row < matrixLength; row++)
        {
            for (int col = 0; col < matrixLength; col++)
            {
                CheckSequence(row, col);
            }
        }

        foreach (var item in longestSequence)
        {
            Console.Write((char)item);
        }
    }

    private static void CheckSequence(int row, int col)
    {
        int currentLetter = 0;
        // right
        for (int currCol = col; currCol < matrixLength; currCol++)
        {
            if (matrix[row, currCol] > currentLetter)
            {
                currentSequence.Add(matrix[row, currCol]);
                currentLetter = matrix[row, currCol];
            }
            else
            {
                break;
            }
        }

        LongestSequenceCheck();

        // left
        currentLetter = 0;
        for (int currCol = col; currCol >= 0; currCol--)
        {
            if (matrix[row, currCol] > currentLetter)
            {
                currentSequence.Add(matrix[row, currCol]);
                currentLetter = matrix[row, currCol];
            }
            else
            {
                break;
            }
        }

        LongestSequenceCheck();

        // down
        currentLetter = 0;
        for (int currRow = row; currRow < matrixLength; currRow++)
        {
            if (matrix[currRow, col] > currentLetter)
            {
                currentSequence.Add(matrix[currRow, col]);
                currentLetter = matrix[currRow, col];
            }
            else
            {
                break;
            }
        }

        LongestSequenceCheck();

        // up
        currentLetter = 0;
        for (int currRow = row; currRow >= 0; currRow--)
        {
            if (matrix[currRow, col] > currentLetter)
            {
                currentSequence.Add(matrix[currRow, col]);
                currentLetter = matrix[currRow, col];
            }
            else
            {
                break;
            }
        }

        LongestSequenceCheck();
    }

    private static void LongestSequenceCheck()
    {
        if (currentSequence.Count > longestSequence.Count)
        {
            longestSequence.Clear();
            foreach (int character in currentSequence)
            {
                longestSequence.Add(character);
            }
        }
        else if (currentSequence.Count == longestSequence.Count)
        {
            for (int index = 0; index < longestSequence.Count; index++)
            {
                if (longestSequence[index] < currentSequence[index])
                {
                    break;
                }
                else if (longestSequence[index] > currentSequence[index])
                {
                    longestSequence.Clear();
                    foreach (int character in currentSequence)
                    {
                        longestSequence.Add(character);
                    }
                    break;
                }
            }
        }

        currentSequence.Clear();
    }
}
