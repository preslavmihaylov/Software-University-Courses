using System;
using System.Collections.Generic;

class PrimesInGivenRange
{
    static void Main()
    {
        int startNum = int.Parse(Console.ReadLine());
        int endNum = int.Parse(Console.ReadLine());

        List<int> primeNumbers = FindPrimesInRange(startNum, endNum);

        Console.WriteLine();
        Console.WriteLine("Result:");
        foreach (var number in primeNumbers)
        {
            Console.WriteLine(number);
        }
    }

    private static List<int> FindPrimesInRange(int startNum, int endNum)
    {
        List<int> numbers = new List<int>();

        for (int index = startNum; index <= endNum; index++)
        {
            bool isPrime = true;
            if (index < 2)
            {
                continue;
            }

            for (int count = 2; count <= Math.Sqrt(index); count++)
            {
                if (index % count == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime)
            {
                numbers.Add(index);
            }
        }

        return numbers;
    }
}
