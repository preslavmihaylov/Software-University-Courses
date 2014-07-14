using System;

class PrimeChecker
{
    static void Main()
    {
        long number = long.Parse(Console.ReadLine());

        bool result = isPrime(number);
        Console.WriteLine(result);
    }

    private static bool isPrime(long number)
    {
        if (number < 2)
        {
            return false;
        }

        for (int index = 2; index <= Math.Sqrt(number); index++)
        {
            if (number % index == 0)
            {
                return false;
            }
        }
        return true;
    }
}
