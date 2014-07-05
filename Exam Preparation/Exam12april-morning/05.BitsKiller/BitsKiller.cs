using System;

class BitsKiller
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());
        int count = 1;
        int newByte = 0;
        int bitCount = 0;

        for (int numOfInput = 0; numOfInput < n; numOfInput++)
        {
            int number = int.Parse(Console.ReadLine());

            for (int bit = 7; bit >= 0; bit--)
            {
                if (count != 0)
                {
                    int newBit = (number >> bit) & 1;
                    newByte <<= 1;
                    newByte |= newBit;
                    string temp = Convert.ToString(newByte, 2).PadLeft(8, '0');
                    bitCount++;
                    count--;
                }
                else
                {
                    count = step - 1;
                }


                if (bitCount == 8)
                {
                    Console.WriteLine(newByte);
                    newByte = 0;
                    bitCount = 0;
                }
            }
        }

        if (bitCount < 8 && bitCount > 0)
        {
            while (bitCount != 8)
            {
                newByte <<= 1;
                bitCount++;
            }
            Console.WriteLine(newByte);
        }
    }
}