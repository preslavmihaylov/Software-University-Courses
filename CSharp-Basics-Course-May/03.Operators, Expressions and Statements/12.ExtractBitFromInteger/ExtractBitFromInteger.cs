using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Problem 12.	Extract Bit from Integer
//Write an expression that extracts from given integer n the value of given bit at index p. 

class ExtractBitFromInteger
{
    static void Main()
    {
        int input = int.Parse(Console.ReadLine());
        int position = int.Parse(Console.ReadLine());

        int bit = (input >> position) & 1;
        Console.WriteLine("The bit at position {0} is {1}", position, bit);
    }
}
