using System;

class CalculateGCD
{
    // using Euclidean algorithm
    static void Main()
    {
        int number1 = int.Parse(Console.ReadLine());
        int number2 = int.Parse(Console.ReadLine());

        int quotient = number1;
        int divisor = number2;

        while (divisor != 0)
        {
            int result = quotient % divisor;
            quotient = divisor;
            divisor = result;
        }

        Console.WriteLine(quotient);
    }
}
