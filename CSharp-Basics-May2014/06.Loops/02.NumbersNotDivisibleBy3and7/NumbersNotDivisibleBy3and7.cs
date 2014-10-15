using System;

class NumbersNotDivisibleBy3and7
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        for (int index = 1; index <= number; index++)
        {
            if (index % 3 != 0 && index % 7 != 0)
            {
                Console.Write(index + " "); 
            }
        }
        Console.WriteLine();
    }
}
