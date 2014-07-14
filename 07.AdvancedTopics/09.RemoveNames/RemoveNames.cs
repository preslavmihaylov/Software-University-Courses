using System;
using System.Collections.Generic;

class RemoveNames
{
    static void Main()
    {
        string[] input1 = Console.ReadLine().Split();
        string[] input2 = Console.ReadLine().Split();

        List<string> names = new List<string>();
        List<string> removeNames = new List<string>();

        for (int index = 0; index < input1.Length; index++)
        {
            names.Add(input1[index]);
        }

        for (int index = 0; index < input2.Length; index++)
        {
            removeNames.Add(input2[index]);
        }

        for (int index = 0; index < removeNames.Count; index++)
        {
            // using lambda expression
            names.RemoveAll(item => item == removeNames[index]);
        }

        Console.WriteLine();
        Console.WriteLine("Result:");
        foreach (var item in names)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}
