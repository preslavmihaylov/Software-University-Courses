using System;
using System.Numerics;

class PeaceOfCake
{
    static void Main()
    {
        BigInteger A = BigInteger.Parse(Console.ReadLine());
        BigInteger B = BigInteger.Parse(Console.ReadLine());
        BigInteger C = BigInteger.Parse(Console.ReadLine());
        BigInteger D = BigInteger.Parse(Console.ReadLine());

        BigInteger denominator = B * D;
        BigInteger nominator = A * D + C * B;

        if (nominator >= denominator)
        {
            Console.WriteLine((BigInteger)nominator / (BigInteger)denominator);
        }
        else
        {
            decimal result = (decimal)nominator / (decimal)denominator;
            Console.WriteLine("{0:F22}", result);
        }
        Console.WriteLine("{0}/{1}", nominator, denominator);
    }
}
