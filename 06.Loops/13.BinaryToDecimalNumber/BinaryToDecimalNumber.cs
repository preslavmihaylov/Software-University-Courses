using System;

class BinaryToDecimalNumber
{
    static void Main()
    {
        string input = Console.ReadLine();

        long sum = 0;
        int position = 0;

        for (int count = input.Length - 1; count >= 0; count--)
        {
            if (input[count] == '1')
            {
                sum += (long)Math.Pow(2, position);
            }
            position++;
        }

        Console.WriteLine(sum);
    }
}
