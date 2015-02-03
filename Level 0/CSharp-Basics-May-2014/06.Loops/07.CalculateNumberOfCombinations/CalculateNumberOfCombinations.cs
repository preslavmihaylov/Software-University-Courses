using System;
using System.Numerics;

class CalculateNumberOfCombinations
{
    static void Main()
    {
        int elementsCount = int.Parse(Console.ReadLine());
        int membersCount = int.Parse(Console.ReadLine());

        BigInteger factElements = 1;
        BigInteger factMembers = 1;
        BigInteger factSubtraction = 1;

        for (long count = 1; count <= elementsCount; count++)
        {
            if (count <= membersCount)
            {
                factMembers *= count;
            }

            if (count <= elementsCount - membersCount)
            {
                factSubtraction *= count;
            }

            factElements *= count;
        }

        Console.WriteLine(factElements / (factMembers * factSubtraction));

        
    }
}
