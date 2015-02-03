using System;
using System.Collections.Generic;
using System.Text;

class SubstringExtensionsDemo
{
    static void Main()
    {
        StringBuilder text = new StringBuilder("SoftUni");
        Console.WriteLine(text.Substring(4, 3));
        text.RemoveText("Uni");
        Console.WriteLine(text);
        List<int> integers = new List<int>() { 1, 2, 4, 5 };
        text.AppendAll(integers);
        Console.WriteLine(text);
    }
}
