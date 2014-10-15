using System;
using System.Collections.Generic;

class Neurons
{
    static void Main()
    {
        string input = Console.ReadLine();
        List<long> outputNumbers = new List<long>();

        while (input != "-1")
        {
            long number = Convert.ToInt64(input);
            long currentNumber = 0;

            long check = number;
            long onesCount = 0;
            long onesCountCheck = 0;

            while (check > 0)
            {
                long bit = check & 1;
                if (bit == 1)
                {
                    onesCount++;
                }
                check >>= 1;
            }

            for (int bit = 0; bit < 32; bit++)
            {
                long currentBit = (number >> bit) & 1;
                if (currentBit == 1 && onesCountCheck + 1 != onesCount)
                {
                    onesCountCheck++;
                    currentBit = (number >> (bit + 1)) & 1;
                    int count = bit + 1;

                    while (currentBit != 1 && count < 32)
                    {
                        currentBit = (number >> count) & 1;

                        if (currentBit == 0)
                        {
                            currentNumber ^= (long)1 << count;
                            count++;
                        }
                    }

                    bit = count - 1;
                }
            }

            number = currentNumber;
            outputNumbers.Add(number);

            input = Console.ReadLine();
        }

        foreach (long num in outputNumbers)
        {
            Console.WriteLine(num);
        }
        
    }
}
