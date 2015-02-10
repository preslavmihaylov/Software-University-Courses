using System;

class StringDisperserDemo
{
    static void Main()
    {
        StringDisperser first = new StringDisperser("gosho", "pesho");
        StringDisperser second = new StringDisperser("gosho", "pesho");
        StringDisperser third = new StringDisperser("notgosho", "pesho");

        foreach (var ch in first)
        {
            Console.Write(ch + " ");
        }
        Console.WriteLine();

        Console.WriteLine(first == second);
        Console.WriteLine(first != third);

        third = (StringDisperser)first.Clone();

        Console.WriteLine(Object.ReferenceEquals(first, third));
        Console.WriteLine(first == third);
        Console.WriteLine(first.ToString());
    }
}
