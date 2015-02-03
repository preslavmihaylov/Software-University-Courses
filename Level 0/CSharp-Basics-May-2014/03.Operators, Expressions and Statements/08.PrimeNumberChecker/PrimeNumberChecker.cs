using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Problem 8.	Prime Number Check
//Write an expression that checks if given positive integer number n (n ≤ 100)
//is prime (i.e. it is divisible without remainder only to itself and 1). 

class PrimeNumberChecker
{
    static void Main()
    {
        int input = int.Parse(Console.ReadLine());
        bool isPrime = true;

        if (input <= 1)
        {
            Console.WriteLine("Not prime");
            return;
        }

        for (int count = 2; count <= Math.Sqrt(input); count++)
        {
            if (input % count == 0)
            {
                isPrime = false;
                break;
            }
        }

        if (isPrime == true)
        {
            Console.WriteLine("Prime");
        }
        else
        {
            Console.WriteLine("Not Prime");
        }
    }
}
