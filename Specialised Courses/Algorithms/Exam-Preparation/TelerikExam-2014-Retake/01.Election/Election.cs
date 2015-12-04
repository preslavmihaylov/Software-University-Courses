using System;
using System.Numerics;

class Election
{
    private static int[] seats;
    private static BigInteger[] subsetSums;

    private static int minimumSeats;
    private static BigInteger totalCombinations;

    static void Main()
    {
        ProcessInput();
        ProcessAlgorithm();
        PrintOutput();
    }

    // A dynamic programming approach
    static void ProcessAlgorithm()
    {
        int maxSum = 0;

        // pI - partyIndex
        for (int pI = 0; pI < seats.Length; pI++)
        {
            // sI - sumIndex
            for (int sI = maxSum; sI >= 0; sI--)
            {
                if (subsetSums[sI] > 0)
                {
                    int newSum = sI + seats[pI];
                    subsetSums[newSum] += subsetSums[sI];
                    maxSum = Math.Max(maxSum, newSum);
                }
            }
        }

        for (int index = minimumSeats; index <= maxSum; index++)
        {
            if (subsetSums[index] > 0)
            {
                totalCombinations += subsetSums[index];
            }
        }
    }

    static void PrintOutput()
    {
        Console.WriteLine(totalCombinations);
    }

    static void ProcessInput()
    {
        minimumSeats = int.Parse(Console.ReadLine());
        int totalParties = int.Parse(Console.ReadLine());

        seats = new int[totalParties];

        for (int i = 0; i < totalParties; i++)
        {
            seats[i] = int.Parse(Console.ReadLine());
        }

        subsetSums = new BigInteger[(100 * 1000) + 1];
        subsetSums[0] = 1;
    }
}