using System;
using System.Collections.Generic;
using System.Linq;

class SumAndAverage
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        List<int> collection = new List<int>(input.Length);

        foreach (string number in input)
        {
            collection.Add(int.Parse(number));
        }

        Console.WriteLine("Average: " + collection.Average());
        Console.WriteLine("Sum: " + collection.Sum());
    }
}