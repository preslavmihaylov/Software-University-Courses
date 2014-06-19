using System;
using System.Linq;

//Problem 1.	Odd or Even Integers
//Write an expression that checks if given integer is odd or even. 

class OddOrEvenIntegers
{
    static void Main()
    {
        int input = int.Parse(Console.ReadLine());
        if (input % 2 == 0)
        {
            Console.WriteLine("The integer is Even");
        }
        else
        {
            Console.WriteLine("The integer is Odd");
        }
    }
}
