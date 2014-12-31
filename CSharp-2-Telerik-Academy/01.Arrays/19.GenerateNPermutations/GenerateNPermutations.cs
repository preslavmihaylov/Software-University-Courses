using System;
class GenerateNPermutations
{
    static int countOfNumbers;
    static int[] numbers;

    static void Main()
    {
        Console.Write("Enter number:");
        countOfNumbers = int.Parse(Console.ReadLine());

        numbers = new int[countOfNumbers];

        for (int index = 1; index <= countOfNumbers; index++)
        {
            numbers[index - 1] = index;
        }

        FindSubsets(0);
    }

    static void FindSubsets(int lastNumber)
    {
        if (lastNumber == numbers.Length)
        {
            Console.WriteLine(String.Join(", ", numbers));
            return;
        }

        for (int nextNumber = lastNumber; nextNumber < numbers.Length; nextNumber++)
        {
            swap(ref numbers[lastNumber], ref numbers[nextNumber]);
            FindSubsets(lastNumber + 1);
            swap(ref numbers[lastNumber], ref numbers[nextNumber]);
        }
    }

    private static void swap(ref int first, ref int second)
    {
        int temp = first;
        first = second;
        second = temp;
    }
}
