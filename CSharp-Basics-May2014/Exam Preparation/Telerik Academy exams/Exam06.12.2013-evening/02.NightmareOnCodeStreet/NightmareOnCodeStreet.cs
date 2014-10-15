using System;
using System.Text.RegularExpressions;
using System.Numerics;

class NightmareOnCodeStreet
{
    static void Main()
    {
        string input = Console.ReadLine();
        

        BigInteger sum = 0;
        BigInteger count = 0;

        
        input = input.Replace("-", "");

        for (int index = 0; index < input.Length; index++)
        {

            if (index % 2 != 0)
            {
                int number = 0;
                if (int.TryParse(Convert.ToString(input[index]), out number))
                {
                    count++;
                    sum += number;
                }
            }
        }
        Console.WriteLine("{0} {1}", count, sum);
    }
}
