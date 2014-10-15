using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Problem 13.	Check a Bit at Given Position
//Write a Boolean expression that returns if the bit at position p 
//(counting from 0, starting from the right) in given integer number n has value of 1

    class CheckBitAtGivenPosition
    {
        static void Main()
        {
            int input = int.Parse(Console.ReadLine());
            int position = int.Parse(Console.ReadLine());

            int bit = (input >> position) & 1;
            if (bit == 1)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
    }
