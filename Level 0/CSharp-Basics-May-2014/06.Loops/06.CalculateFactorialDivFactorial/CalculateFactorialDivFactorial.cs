using System;

class CalculateFactorialDivFactorial
{
    static void Main()
    {
        int number1 = int.Parse(Console.ReadLine());
        int number2 = int.Parse(Console.ReadLine());

        int fact1 = 1;
        int fact2 = 1;

        for (int count = 1; count <= Math.Max(number1, number2); count++)
        {
            if (count <= Math.Min(number1, number2))
            {
                fact2 *= count;
            }

            fact1 *= count;
        }

        Console.WriteLine((double)fact1 / fact2);
    }
}
