using System;
using System.Collections.Generic;

class SortingNumbers
{
    static void Main()
    {
        int numberOfInputs = int.Parse(Console.ReadLine());
        List<int> numbers = new List<int>();

        for (int index = 0; index < numberOfInputs; index++)
        {
            int number = int.Parse(Console.ReadLine());
            numbers.Add(number);
        }
        numbers.Sort();
        Console.WriteLine();
        Console.WriteLine("Result:");
        foreach (var item in numbers)
        {
            Console.WriteLine(item);
        }
    }
}
