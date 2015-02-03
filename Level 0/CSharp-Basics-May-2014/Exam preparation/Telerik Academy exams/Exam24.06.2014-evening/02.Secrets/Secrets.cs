using System;
using System.Numerics;

class Secrets
{
    static void Main()
    {
        string input = Console.ReadLine();

        BigInteger specialSum = 0;
        int count = 1;

        for (int index = input.Length - 1; index >= 0; index--)
        {
            long digit;
            if (long.TryParse(Convert.ToString(input[index]), out digit))
            {


                if (count % 2 == 1)
                {
                    specialSum += digit * (BigInteger)Math.Pow(count, 2);
                }
                else
                {
                    specialSum += (BigInteger)Math.Pow(digit, 2) * count;
                }
            }
            count++;
        }

        Console.WriteLine(specialSum);

        if (specialSum % 10 == 0)
        {
            Console.WriteLine(input + " " + "has no secret alpha-sequence");
        }
        else
        {
            // starts at 65
            BigInteger currentLetter = 64;

            BigInteger alphaSequenceLength = specialSum % 10;
            BigInteger R = specialSum % 26;
            currentLetter += R + 1;

            for (int i = 0; i < alphaSequenceLength; i++)
            {
                if (currentLetter == 91)
                {
                    currentLetter = 65;
                }
                Console.Write((char)currentLetter);
                currentLetter++;
            }
        }

        Console.WriteLine();
    }
}
