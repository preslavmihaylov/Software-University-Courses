using System;

class BitFlipper
{
    static void Main()
    {
        ulong number = ulong.Parse(Console.ReadLine());
        int count = 1;
        ulong startBit = (number >> 63) & 1;
        
        for (int bit = 62; bit >= 0; bit--)
        {
            ulong currentBit = (number >> bit) & 1;
            if (currentBit == startBit)
            {
                count++;
            }
            else
            {
                count = 1;
                startBit = currentBit;
            }

            if (count == 3)
            {
                for (int bitsToSwap = bit + 2; bitsToSwap >= bit; bitsToSwap--)
                {
                    number ^= (ulong)1 << bitsToSwap;
                }
                bit--;
                count = 1;
                startBit = (number >> bit) & 1;
            }
        }
        Console.WriteLine(number);
        
    }
}
