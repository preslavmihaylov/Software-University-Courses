using System;

class OnesAndZeroes
{
    static string[,] ones = new string[,]
        {
            {".#."},
            {"##."},
            {".#."},
            {".#."},
            {"###"}
        };

    static string[,] zeroes = new string[,]
        {
            {"###"},
            {"#.#"},
            {"#.#"},
            {"#.#"},
            {"###"}
        };

    static string[,] output = new string[5, 16];

    static void Main()
    {
        int input = int.Parse(Console.ReadLine());
        int count = 0;

        for (int bit = 15; bit >= 0; bit--)
        {
            int currentBit = (input >> bit) & 1;

            if (bit != 0)
            {
                ModifyArray(currentBit, ".", count);
                count++;
            }
            else
            {
                ModifyArray(currentBit, "", count);
                count++;
            }
        }

        for (int row = 0; row < 5; row++)
        {
            for (int col = 0; col < 16; col++)
            {
                Console.Write(output[row, col]);
            }
            Console.WriteLine();
        }

    }

    private static void ModifyArray(int currentBit, string dot, int count)
    {
        if (currentBit == 1)
        {
            for (int row = 0; row < 5; row++)
            {
                for (int col = count; col < count + 1; col++)
                {
                    output[row, count] = ones[row, 0] + dot;
                }
            }
        }
        else
        {
            for (int row = 0; row < 5; row++)
            {
                for (int col = count; col < count + 1; col++)
                {
                    output[row, count] = zeroes[row, 0] + dot;
                }
            }
        }
    }
}
