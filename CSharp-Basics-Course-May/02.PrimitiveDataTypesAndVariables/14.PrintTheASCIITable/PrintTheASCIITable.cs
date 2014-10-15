using System;
class PrintTheASCIITable
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.BufferHeight = 300;
        char symbol = (char)0;
        Console.WriteLine("Number 0 ---> {0}", symbol);
        for (int count = 1; count <= 255; count++)
        {
            symbol++;
            Console.WriteLine("Number {0} ---> {1}", count, symbol);
        }
    }
}
