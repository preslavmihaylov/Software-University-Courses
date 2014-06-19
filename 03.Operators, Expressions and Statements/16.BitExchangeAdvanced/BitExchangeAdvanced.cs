using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Problem 16.	** Bit Exchange (Advanced)
//Write a program that exchanges bits {p, p+1, …, p+k-1} with bits {q, q+1, …, q+k-1}
//of a given 32-bit unsigned integer. The first and the second sequence of bits may not overlap. 

class BitExchangeAdvanced
{
    static void Main()
    {
        long input = long.Parse(Console.ReadLine());
        int position1 = int.Parse(Console.ReadLine());
        int position2 = int.Parse(Console.ReadLine());
        int numberOfSwaps = int.Parse(Console.ReadLine());

        if (position1 > position2)
        {
            int temp = position1;
            position1 = position2;
            position2 = temp;
        }
        
        if (position2 + numberOfSwaps > 32)
        {
            Console.WriteLine("Out of range");
            return;
        }
        if (position1 + numberOfSwaps >= position2)
        {
            Console.WriteLine("Overlapping");
            return;
        }

        int counter = position1;
        for (int bit = position1; bit < position1 + numberOfSwaps; bit++)
        {
            uint bitToBeChanged1 = (uint)(input >> bit) & 1;
            uint bitToBeChanged2 = (uint)(input >> position2) & 1;

            if (bitToBeChanged1 != bitToBeChanged2)
            {
                input ^= (uint)1 << bit;
                input ^= (uint)1 << position2;
            }
            position2++;
        }

        Console.WriteLine("Result: " + input);
    }
}