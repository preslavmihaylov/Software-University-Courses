using System;

class Program
{
    static void Main()
    {
        long A = long.Parse(Console.ReadLine());
        long B = long.Parse(Console.ReadLine());
        long C = long.Parse(Console.ReadLine());
        long result = 0;

        switch (B)
        {
            case 2:
                result = A % C;
                break;
            case 4:
                result = A + C;
                break;
            case 8:
                result = A * C;
                break;
        }

        double firstOutput;

        if (result % 4 == 0)
        {
            firstOutput = result / 4;
        }
        else
        {
            firstOutput = result % 4;   
        }

        Console.WriteLine(firstOutput);
        Console.WriteLine(result);
    }
}
