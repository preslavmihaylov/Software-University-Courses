using System;
using System.Collections.Generic;

class RandomizeNumbers
{
    static void Main()
    {
        int input = int.Parse(Console.ReadLine());

        List<int> numbers = new List<int>();
        Random randomGenerator = new Random();

        for (int index = 1; index <= input; index++)
        {
            numbers.Add(index);
        }

        int counter = numbers.Count;

        for (int index = 0; index < counter; index++)
        {
            int currentNumber = numbers[randomGenerator.Next(0, numbers.Count)];
            Console.Write(currentNumber + " ");
            numbers.Remove(currentNumber);
        }
        Console.WriteLine();
    }
}
