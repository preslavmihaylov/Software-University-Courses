using System;

class DecimalToBinaryNumber
{
    static void Main()
    {
        long number = long.Parse(Console.ReadLine());
        string result = "";

        // use do-while instead of while when you want the loop to be executed at least once.
        do
        {
            int bit = (int)(number % 2);
            number /= 2;
            result += bit;
        } while (number > 0);

        string output = "";
        for (int index = result.Length - 1; index >= 0; index--)
        {
            output += result[index];
        }

        Console.WriteLine(output);
    }
}
