using System;
using System.Collections.Generic;
using System.Linq;

class CountOfNames
{
    static void Main()
    {
    string[] input = Console.ReadLine().Split();
    Dictionary<string, int> letters = new Dictionary<string, int>();

    for (int index = 0; index < input.Length; index++)
    {
        if (letters.ContainsKey(input[index]))
        {
            letters[input[index]]++;
        }
        else
        {
            letters.Add(input[index], 1);
        }
    }

    var sortedKeys = letters.Keys.ToList();
    sortedKeys.Sort();

    Console.WriteLine();
    Console.WriteLine("Result:");
    foreach (var item in sortedKeys)
    {
        Console.WriteLine("{0} -> {1}", item, letters[item]);
    }
    }
}
