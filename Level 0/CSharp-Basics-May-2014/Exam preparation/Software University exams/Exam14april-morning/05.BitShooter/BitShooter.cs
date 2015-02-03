using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

class BitShooter
{
    static void Main()
    {
        ulong number = ulong.Parse(Console.ReadLine());
        int[] positions = new int[3];
        int[] shots = new int[3];

        for (int count = 0; count < 3; count++)
        {
            string[] input = Console.ReadLine().Split();
            positions[count] = Convert.ToInt32(Convert.ToString(input[0]));
            shots[count] = Convert.ToInt32(Convert.ToString(input[1]));
        }

        for (int index = 0; index < positions.Length; index++)
        {
            for (int bit = positions[index] - (shots[index] / 2); bit <= positions[index] + (shots[index] / 2); bit++)
            {
                if (bit < 0 || bit > 63)
                {
                    continue;
                }
                ulong temp = ((ulong)1 << bit);
                ulong checkBit = (number >> bit) & 1;
                if (checkBit == 1)
                {
                    number ^= ((ulong)1 << bit);
                }
            }
        }

        int leftPart = 0;
        int rightPart = 0;

        for (int bit = 0; bit < 64; bit++)
        {
            ulong currentBit = (number >> bit) & 1;
            if (bit < 32)
            {
                if (currentBit == 1)
                {
                    rightPart++;
                }
            }
            else
            {
                if (currentBit == 1)
                {
                    leftPart++;
                }
            }
        }
        Console.WriteLine("left: {0}", leftPart);
        Console.WriteLine("right: {0}", rightPart);
    }
}
