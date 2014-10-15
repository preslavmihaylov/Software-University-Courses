using System;
using System.Numerics;

class CatalanNumbers
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        BigInteger factNumber = 1;
        BigInteger factNumberTimes2 = 1;
        BigInteger factNumberPlus1 = 1;

        for (int count = 1; count <= number * 2; count++)
        {
            if (count <= number + 1)
            {
                factNumberPlus1 *= count;
            }

            if (count <= number)
            {
                factNumber *= count;
            }

            factNumberTimes2 *= count;
        }

        Console.WriteLine(factNumberTimes2 / (factNumberPlus1 * factNumber));
    }
}
