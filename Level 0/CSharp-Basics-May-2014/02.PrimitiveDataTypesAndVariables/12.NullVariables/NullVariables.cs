using System;
class NullVariables
{
    static void Main()
    {
        int? integerValue = null;
        double? doubleValue = null;
        Console.WriteLine("Null Value of Integer --> {0}", integerValue);
        Console.WriteLine("Null Value of Double --> {0}", doubleValue);

        integerValue += 5;
        doubleValue += 12.23;

        Console.WriteLine();
        Console.WriteLine("Value of Integer --> {0}", integerValue);
        Console.WriteLine("Value of Double --> {0}", doubleValue);

        integerValue = 5;
        doubleValue = 12.23;

        Console.WriteLine();
        Console.WriteLine("Value of Integer --> {0}", integerValue);
        Console.WriteLine("Value of Double --> {0}", doubleValue);
    }
}
