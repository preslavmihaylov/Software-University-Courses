using System;
class FindSubsetWithGivenSum
{
    static int numberOfLoops;
    static int countOfNumbers;
    static int givenSum;

    static int[] loops;
    static int[] numbers;

    static void Main()
    {
        Console.Write("Enter numbers:");
        string[] input = Console.ReadLine().Split();
        Console.Write("Enter given Sum: ");
        givenSum = int.Parse(Console.ReadLine());

        countOfNumbers = input.Length;
        numberOfLoops = countOfNumbers;
        numbers = new int[countOfNumbers];

        for (int index = 0; index < input.Length; index++)
        {
            numbers[index] = int.Parse(input[index]);
        }

        while (numberOfLoops > 0)
        {
            loops = new int[numberOfLoops];
            FindSubsets(0, 0);
            numberOfLoops--;
        }

        Console.WriteLine();
    }

    static void FindSubsets(int currentLoop, int lastNumber)
    {
        if (currentLoop == numberOfLoops)
        {
            CheckSubset();
            return;
        }

        for (int nextNumber = lastNumber; nextNumber < countOfNumbers; nextNumber++)
        {
            loops[currentLoop] = numbers[nextNumber];
            FindSubsets(currentLoop + 1, nextNumber + 1);
        }
    }

    private static void CheckSubset()
    {
        int sum = 0;
        for (int index = 0; index < loops.Length; index++)
        {
            sum += loops[index];
        }

        if (sum == givenSum)
        {
            Console.Write(String.Join(" + ", loops));
            Console.Write(" = " + givenSum);
            Console.WriteLine();
        }
    }
}
