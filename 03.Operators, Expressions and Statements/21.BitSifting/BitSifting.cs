using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
class BitSifting
{
    static void Main()
    {
        BigInteger number = BigInteger.Parse(Console.ReadLine());
        int numberOfSieves = int.Parse(Console.ReadLine());

        for (int index = 0; index < numberOfSieves; index++)
        {
            BigInteger sieve = BigInteger.Parse(Console.ReadLine());

            for (int bit = 0; bit < 64; bit++)
            {
                BigInteger bitToCheck = (number >> bit) & 1;
                if (bitToCheck == 1)
                {
                    BigInteger bitToSieve = (sieve >> bit) & 1;
                    number ^= bitToSieve << bit;
                }
            }
        }

        int result = 0;
        while (number > 0)
        {
            int check = (int)(number & 1);
            if (check == 1)
            {
                result++;
            }
            number >>= 1;
        }

        Console.WriteLine(result);
    }
}
