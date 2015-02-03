using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Problem 15.	* Bits Exchange
//Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer. 

    class BitExchange
    {
        static void Main()
        {
            uint input = uint.Parse(Console.ReadLine());

            for (int bit = 3; bit <= 5; bit++)
            {
                uint bitToBeChanged1 = (input >> bit) & 1;
                uint bitToBeChanged2 = (input >> bit + 21) & 1;

                if (bitToBeChanged1 != bitToBeChanged2)
                {
                    input ^= (uint)1 << bit;
                    input ^= (uint)1 << bit + 21;
                }
            }

            Console.WriteLine("Result: " + input);
            
        }
    }
