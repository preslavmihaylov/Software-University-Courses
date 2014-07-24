using System;
using System.Numerics;

class AngryFemaleGPS
{
    static void Main()
    {
        string input = Console.ReadLine();
        BigInteger oddSum = 0;
        BigInteger evenSum = 0;

        for (int index = 0; index < input.Length; index++)
        {
            long number;
            if (long.TryParse(Convert.ToString(input[index]), out number))
            {
                if (number % 2 == 1)
                {
                    oddSum += number;
                }
                else
                {
                    evenSum += number;
                }
            }
        }

        string direction = "";
        BigInteger result = 0;

        if (oddSum < evenSum)
        {
            direction = "right";
            result = evenSum;
        }
        else if (oddSum > evenSum)
        {
            direction = "left";
            result = oddSum;
        }
        else
        {
            direction = "straight";
            result = oddSum;
        }

        Console.WriteLine("{0} {1}", direction, result);
    }
}
