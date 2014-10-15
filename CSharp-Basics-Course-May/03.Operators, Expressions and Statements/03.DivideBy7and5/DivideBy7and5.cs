using System;

//Problem 3.	Divide by 7 and 5
//Write a Boolean expression that checks for given integer if it can be divided 
//(without remainder) by 7 and 5 in the same time. 

class DivideBy7and5
{
    static void Main()
    {
        int input = int.Parse(Console.ReadLine());

        if (input % 7 == 0 && input % 5 == 0)
        {
            Console.WriteLine("True");
        }
        else
        {
            Console.WriteLine("False");
        }
    }
}
