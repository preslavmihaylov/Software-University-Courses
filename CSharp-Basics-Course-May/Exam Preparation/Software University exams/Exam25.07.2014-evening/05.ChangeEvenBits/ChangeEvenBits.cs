using System;

class ChangeEvenBits
{
    static void Main()
    {
        int numOfInputs = int.Parse(Console.ReadLine());
        long[] nums = new long[numOfInputs];

        for (int index = 0; index < numOfInputs; index++)
        {
            long number = long.Parse(Console.ReadLine());
            nums[index] = number;
        }

        long numToChange = long.Parse(Console.ReadLine());
        long changesCount = 0;

        for (int index = 0; index < numOfInputs; index++)
        {
            int count = 0;

            if (nums[index] == 0)
            {
                count = 1;
            }

            while (nums[index] > 0)
            {
                count++;
                nums[index] >>= 1;
            }

            for (int bit = 0; bit < 64; bit++)
            {
                if (bit % 2 == 0)
                {
                    count--;
                    long checkBit = (numToChange >> bit) & 1;
                    if (checkBit == 0)
                    {
                        numToChange ^= (long)1 << bit;
                        changesCount++;
                    }
                }

                if (count == 0)
                {
                    break;
                }
            }
        }

        Console.WriteLine(numToChange);
        Console.WriteLine(changesCount);
    }
}
