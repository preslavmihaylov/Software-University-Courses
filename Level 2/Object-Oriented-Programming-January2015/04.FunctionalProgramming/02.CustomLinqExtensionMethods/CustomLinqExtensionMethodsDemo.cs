using System;
using System.Collections.Generic;
using System.Linq;

class CustomLinqExtensionMethodsDemo
{
    static void Main()
    {
        List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };

        var result = numbers.WhereNot(c => c == 1);
        foreach (var item in result)
        {
            Console.WriteLine(item);
        }

        result = numbers.Repeat(3);

        Console.WriteLine();
        foreach (var item in result)
        {
            Console.WriteLine(item);
        }

        List<string> randomStrings = new List<string>() { "uni", "softuni", "asdasd", "universe" };

        var newResult = randomStrings.WhereEndsWith(new List<string>() { "uni"});
        Console.WriteLine();
        foreach (var item in newResult)
        {
            Console.WriteLine(item);
        }
    }
}