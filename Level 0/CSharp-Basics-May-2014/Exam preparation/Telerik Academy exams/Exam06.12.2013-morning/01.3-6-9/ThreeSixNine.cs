using System;
using System.Numerics;

class ThreeSixNine
{
    static void Main()
    {
        int A = int.Parse(Console.ReadLine());
        int B = int.Parse(Console.ReadLine());
        int C = int.Parse(Console.ReadLine());
        BigInteger result = 0;

        switch (B)
        {
            case 3:
                result = A + C;
                break;
            case 6:
                result = (BigInteger)A * C;
                break;
            case 9:
                result = A % C;
                break;
            default:
                break;
        }

        BigInteger newResult = 0;
        if (result % 3 == 0)
        {
            newResult = result / 3;
        }
        else
        {
            newResult = result % 3;
        }

        Console.WriteLine(newResult);
        Console.WriteLine(result);

    }
}
