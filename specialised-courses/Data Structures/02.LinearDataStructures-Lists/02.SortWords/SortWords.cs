using System;
using System.Collections.Generic;
using System.Linq;

class SortWords
{
    static void Main()
    {
        List<string> words = Console.ReadLine().Split(' ').ToList();
        words.Sort();
        Console.WriteLine(string.Join(", ", words));
    }
}