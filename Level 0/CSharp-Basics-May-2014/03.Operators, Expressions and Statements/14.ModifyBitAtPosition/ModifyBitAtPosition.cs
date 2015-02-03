using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Problem 14.	Modify a Bit at Given Position
//We are given an integer number n, a bit value v (v=0 or 1) and a position p.
//Write a sequence of operators (a few lines of C# code) that modifies n to hold
//the value v at the position p from the binary representation of n while 
//preserving all other bits in n. 

class ModifyBitAtPosition
{
    static void Main()
    {
        int input = int.Parse(Console.ReadLine());
        int position = int.Parse(Console.ReadLine());
        int bitToChange = int.Parse(Console.ReadLine());

        if (bitToChange == 1)
        {
            input |= bitToChange << position;
        }
        else
        {
            input &= ~(1 << position);
        }
        Console.WriteLine("Result: " + input);
    }
}
