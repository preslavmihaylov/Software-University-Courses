using System;
using System.Linq;

//Problem 6.	Four-Digit Number
//Write a program that takes as input a four-digit number in format abcd (e.g. 2011) and performs the following:
//•	Calculates the sum of the digits (in our example 2+0+1+1 = 4).
//•	Prints on the console the number in reversed order: dcba (in our example 1102).
//•	Puts the last digit in the first position: dabc (in our example 1201).
//•	Exchanges the second and the third digits: acbd (in our example 2101).
//The number has always exactly 4 digits and cannot start with 0. 

class FourDigitNumber
{
    static void Main()
    {
        string input = Console.ReadLine();

        int[] digits = new int[input.Length];

        for (int index = 0; index < input.Length; index++)
        {
            digits[index] = Convert.ToInt32(Convert.ToString(input[index]));
        }

        Console.WriteLine("The sum of the digits is {0}", digits.Sum());

        Console.Write("Reversed number:");
        for (int index = input.Length - 1; index >= 0; index--)
        {
            Console.Write(input[index]);
        }
        Console.WriteLine();

        Console.WriteLine("Last digit infront: {0}{1}{2}{3}", digits[3], digits[0], digits[1], digits[2]);

        Console.WriteLine("Second and third digit exchanged: {0}{1}{2}{3}", digits[0], digits[2], digits[1], digits[3]);
        
    }
}
