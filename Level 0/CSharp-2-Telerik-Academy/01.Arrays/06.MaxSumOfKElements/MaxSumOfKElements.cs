using System;
class MaxSumOfKElements
{
    static void Main()
    {
        Console.Write("Input array length: ");
        int arrayLength = int.Parse(Console.ReadLine());

        Console.Write("Input elements length: ");
        int elementsLength = int.Parse(Console.ReadLine());

        int[] array = new int[arrayLength];

        for (int index = 0; index < arrayLength; index++)
        {
            Console.Write("Input element " + (index + 1) + ": ");
            array[index] = int.Parse(Console.ReadLine());
        }

        int start = 0;
        int end = -1;
        int maxSum = 0;

        for (int first = 0; first <= arrayLength - elementsLength; first++)
        {
            int currentSum = 0;
            for (int second = first; second < first + elementsLength; second++)
            {
                currentSum += array[second];
            }

            if (maxSum < currentSum)
            {
                maxSum = currentSum;
                start = first;
                end = first + elementsLength;
            }
        }

        for (int index = start; index < end; index++)
        {
            Console.Write(array[index] + " ");
        }

    }
}
