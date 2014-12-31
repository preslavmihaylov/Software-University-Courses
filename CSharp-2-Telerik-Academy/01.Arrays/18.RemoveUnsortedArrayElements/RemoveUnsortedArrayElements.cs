using System;
class RemoveUnsortedArrayElements
{
    static int numberOfLoops;
    static int countOfNumbers;

    static int[] loops;
    static int[] numbers;

    static void Main()
    {
        Console.Write("Enter numbers:");
        string[] input = Console.ReadLine().Split();

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
        bool isSorted = true;

        for (int index = 0; index < loops.Length - 1; index++)
        {
            if (loops[index] > loops[index + 1])
            {
                isSorted = false;
                break;
            }
        }

        if (isSorted)
        {
            Console.Write(String.Join(", ", loops));
            Console.WriteLine();
            Environment.Exit(0);
        }
    }
}
