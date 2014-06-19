using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Problem 11.	Bitwise: Extract Bit #3 !!!!!
//Using bitwise operators, write an expression for finding the value of the bit #3 of a given unsigned integer. The bits are counted from right to left, starting from bit #0. The result of the expression should be either 1 or 0. 
class ExtractBitNo3
{
    static void Main()
    {
        int input = int.Parse(Console.ReadLine());

        int bit = (input >> 3) & 1;
        Console.WriteLine("The bit at position 3 is {0}", bit);
    }
}
