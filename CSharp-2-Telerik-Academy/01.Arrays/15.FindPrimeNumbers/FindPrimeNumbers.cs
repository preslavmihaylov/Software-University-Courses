using System;

class FindPrimeNumbers
{
    static void Main()
    {
        long length = 1000000;
        bool[] numbers = new bool[length];

        for (int primeIndex = 2; primeIndex < length; primeIndex++)
		{
            if (!numbers[primeIndex])
            {
                for (int nonPrimeIndex = 2; (nonPrimeIndex * primeIndex) < length; nonPrimeIndex++)
                {
                    numbers[primeIndex * nonPrimeIndex] = true;
                }
            }
		}

        for (int index = 2; index < length; index++)
        {
            if (!numbers[index])
            {
                Console.Write(index + " ");
            }
        }
    }
}
