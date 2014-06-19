using System;

//Problem 5.	Third Digit is 7?
//Write an expression that checks for given integer if its third digit from right-to-left is 7

class ThirdDigitIs7
{
    static void Main()
    {
        string input = Console.ReadLine();
        if (input.Length >= 3)
        {
            if (Convert.ToInt32(Convert.ToString(input[input.Length - 3])) == 7)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
        else
        {
            Console.WriteLine("False");
        }

    }
}
