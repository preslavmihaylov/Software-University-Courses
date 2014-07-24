using System;
using System.Linq;

class NaBabaMiSmetalnika
{
    static void Main()
    {
        long[] numbers = new long[8];

        int width = int.Parse(Console.ReadLine());

        int numberLength = 0;
        for (int i = 0; i < width; i++)
        {
            numberLength <<= 1;
            numberLength |= 1;
        }

        for (int index = 0; index < 8; index++)
        {
            long number = long.Parse(Console.ReadLine());
            number &= numberLength;
            numbers[index] = number;
        }

        while (true)
        {
            string command = Console.ReadLine();

            if (command == "right")
            {
                int row = int.Parse(Console.ReadLine());
                int col = int.Parse(Console.ReadLine());
                long mask = 0;

                for (int bit = width - col - 1; bit >= 0; bit--)
                {
                    if (bit < width && bit >= 0)
                    {
                        long currentBit = (numbers[row] >> bit) & 1;
                        if (currentBit == 1)
                        {
                            numbers[row] ^= (long)1 << bit;
                            mask <<= 1;
                            mask |= 1;
                        }
                    }
                }

                numbers[row] |= mask;
            }
            else if (command == "left")
            {
                int row = int.Parse(Console.ReadLine());
                int col = int.Parse(Console.ReadLine());
                long mask = 0;
                int maskCount = 0;

                for (int bit = width - col - 1; bit < width; bit++)
                {
                    if (bit < width && bit >= 0)
                    {
                        long currentBit = (numbers[row] >> bit) & 1;
                        if (currentBit == 1)
                        {
                            numbers[row] ^= (long)1 << bit;
                            mask <<= 1;
                            mask |= 1;
                            maskCount++;
                        }
                    }
                }

                mask <<= width - maskCount;
                numbers[row] |= mask;
            }
            else if (command == "reset")
            {
                for (int row = 0; row < 8; row++)
                {
                    int col = width;
                    long mask = 0;
                    int maskCount = 0;

                    for (int bit = width - col - 1; bit < width; bit++)
                    {
                        if (bit < width && bit >= 0)
                        {
                            long currentBit = (numbers[row] >> bit) & 1;
                            if (currentBit == 1)
                            {
                                numbers[row] ^= (long)1 << bit;
                                mask <<= 1;
                                mask |= 1;
                                maskCount++;
                            }
                        }
                    }

                    mask <<= width - maskCount;
                    numbers[row] |= mask;
                }
            }
            else if (command == "stop")
            {
                break;
            }
        }

        int zeroColumnsCount = 0;

        for (int bit = 0; bit < width; bit++)
        {
            bool hasZero = false;

            foreach (var item in numbers)
            {
                long currentBit = (item >> bit) & 1;
                if (currentBit == 1)
                {
                    hasZero = true;
                }
            }

            if (!hasZero)
            {
                zeroColumnsCount++;
            }
        }

        long result = numbers.Sum() * zeroColumnsCount;
        Console.WriteLine(result);
    }
}
