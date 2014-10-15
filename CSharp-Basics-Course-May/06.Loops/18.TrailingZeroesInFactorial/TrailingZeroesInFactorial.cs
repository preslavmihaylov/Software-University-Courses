using System;
using System.Numerics;

class TrailingZeroesInFactorial
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        BigInteger result = 1;

        for (int index = 1; index <= number; index++)
        {
            result *= index;
        }

        int currentDigit;
        int trailingZeroes = 0;

        do
        {
            currentDigit = (int)(result % 10);
            result /= 10;

            if (currentDigit == 0)
            {
                trailingZeroes++;
            }
        } while (currentDigit == 0);

        Console.WriteLine("Trailing zeroes: {0}", trailingZeroes);
    }
}
