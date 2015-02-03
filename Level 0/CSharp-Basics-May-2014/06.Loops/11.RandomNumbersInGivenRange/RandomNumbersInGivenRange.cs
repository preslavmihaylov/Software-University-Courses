using System;

class RandomNumbersInGivenRange
{
    static void Main()
    {
        int count = int.Parse(Console.ReadLine());
        int min = int.Parse(Console.ReadLine());
        int max = int.Parse(Console.ReadLine());

        Random randomGenerator = new Random();

        Console.WriteLine();
        Console.WriteLine("Result");
        for (int index = 0; index < count; index++)
        {
            Console.WriteLine(randomGenerator.Next(min, max + 1));
        }
    }
}
