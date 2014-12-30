using System;
class CompareArrays
{
    static void Main()
    {
        Console.Write("Input the length of the first array: ");
        int firstLength = int.Parse(Console.ReadLine());
        int[] first = new int[firstLength];

        for (int index = 0; index < firstLength; index++)
        {
            Console.Write("Input element at index " + index + 1 + ":");
            first[index] = int.Parse(Console.ReadLine());
        }

        Console.Write("Input the length of the second array: ");
        int secondLength = int.Parse(Console.ReadLine());
        int[] second = new int[firstLength];

        for (int index = 0; index < secondLength; index++)
        {
            Console.Write("Input element at index " + index + 1 + ":");
            second[index] = int.Parse(Console.ReadLine());
        }

        compareArrays(first, second);
    }

    private static void compareArrays(int[] first, int[] second)
    {
        if (first.Length != second.Length)
        {
            Console.WriteLine("The arrays have different length");
            return;
        }

        for (int i = 0; i < first.Length; i++)
        {
            if (first[i] != second[i])
            {
                Console.WriteLine("The arrays are not equal");
                return;
            }
        }

        Console.WriteLine("The arrays are equal");
    }
}
