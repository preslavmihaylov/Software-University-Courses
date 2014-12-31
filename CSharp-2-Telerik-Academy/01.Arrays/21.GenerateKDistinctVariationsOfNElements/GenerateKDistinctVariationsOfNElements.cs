﻿using System;
class GenerateKDistinctVariationsOfNElements
{
    static int numberOfLoops;
    static int countOfNumbers;

    static int[] loops;
    static int[] numbers;

    static void Main()
    {
        Console.Write("Enter number count:");
        countOfNumbers = int.Parse(Console.ReadLine());
        Console.Write("Enter distinct variations count: ");
        numberOfLoops = int.Parse(Console.ReadLine());

        numbers = new int[countOfNumbers];

        for (int index = 1; index <= countOfNumbers; index++)
        {
            numbers[index - 1] = index;
        }

        loops = new int[numberOfLoops];
        FindSubsets(0, 0);

    }

    static void FindSubsets(int currentLoop, int lastNumber)
    {
        if (currentLoop == numberOfLoops)
        {
            Console.WriteLine(String.Join(", ", loops));
            return;
        }

        for (int nextNumber = lastNumber; nextNumber < countOfNumbers; nextNumber++)
        {
            loops[currentLoop] = numbers[nextNumber];
            FindSubsets(currentLoop + 1, nextNumber + 1);
        }
    }
}
