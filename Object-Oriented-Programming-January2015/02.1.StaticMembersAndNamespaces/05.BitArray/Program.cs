using System;

class Program
{
    static void Main()
    {
        BitArray bits = new BitArray(100000);
        bits[99999] = 1;

        Console.WriteLine(bits.ToString());
    }
}
