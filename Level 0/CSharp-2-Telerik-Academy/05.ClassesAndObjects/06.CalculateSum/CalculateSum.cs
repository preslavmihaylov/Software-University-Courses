using System;
class CalculateSum
{
    static void Main()
    {
        Console.Write("Input numbers: ");
        string[] input = Console.ReadLine().Split();

        int sum = 0;
        for (int index = 0; index < input.Length; index++)
        {
            sum += int.Parse(input[index]);
        }

        Console.WriteLine("The sum is: {0}", sum);
    }
}
