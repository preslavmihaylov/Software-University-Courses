using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class BitRoller
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int position = int.Parse(Console.ReadLine());
        int rolls = int.Parse(Console.ReadLine());

        int extractedBit = 0;
        int newNumber = 0;

        for (int bit = 0; bit < 19; bit++)
        {
            if (bit != position)
            {
                int modifyBit = (number >> bit) & 1;
                newNumber >>= 1;
                newNumber |= modifyBit << 17;
            }
            else
            {
                extractedBit = (number >> bit) & 1;
            }
        }

        for (int count = 0; count < rolls; count++)
        {
            int modifyBit = newNumber & 1;
            newNumber >>= 1;
            newNumber |= (modifyBit << 17);
        }

        number = 0;
        for (int bit = 0; bit < 18; bit++)
        {
            if (bit != position)
            {
                number >>= 1;
                int modifyBit = (newNumber >> bit) & 1;
                number |= modifyBit << 18;
            }
            else if (bit == position)
            {
                bit--;
                number >>= 1;
                number |= extractedBit << 18;
                position = -1;
            }
        }
        if (position != -1)
        {
            number >>= 1;
            number |= extractedBit << 18;
        }
        Console.WriteLine(number);
    }
}
