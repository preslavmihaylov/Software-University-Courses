using System;
class BinarySearchByCondition
{
    static void Main()
    {
        Console.Write("Input numbers for array: ");
        string[] input = Console.ReadLine().Split();
        Console.Write("Input target Number: ");
        int targetNumber = int.Parse(Console.ReadLine());

        int[] array = new int[input.Length];

        for (int index = 0; index < input.Length; index++)
        {
            array[index] = Convert.ToInt32(input[index]);
        }

        Array.Sort(array);

        Console.WriteLine(String.Join(", ", array));
        Console.WriteLine(new string('-', 20));
        int target = Array.BinarySearch(array, targetNumber);
        if (target < 0)
        {
           target = ~target - 1;
        }
        Console.WriteLine(target);

    }
}
