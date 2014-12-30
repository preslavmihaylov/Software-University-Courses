using System;
class MaxSumSequence
{
    static void Main()
    {
        Console.WriteLine("Enter arr length:");
        int length = int.Parse(Console.ReadLine());
        int[] array = new int[length];
        //enter array elements
        for (int i = 0; i < length; i++)
        {
            Console.Write("Enter element " + (i + 1) + ":");
            array[i] = int.Parse(Console.ReadLine());
        }

        int maxSumCurrent = int.MinValue;
        int currentStart = 0;
        int currentEnd = 0;

        int maxSum = int.MinValue;
        int start = 0;
        int end = 0;

        for (int index = 0; index < length; index++)
        {
            if (maxSumCurrent < 0)
            {
                maxSumCurrent = array[index];
                currentStart = index;
                currentEnd = index;
            }
            else
            {
                maxSumCurrent += array[index];
                currentEnd = index;
            }

            if (maxSumCurrent > maxSum)
            {
                maxSum = maxSumCurrent;
                start = currentStart;
                end = currentEnd;
            }
        }

        Console.WriteLine("Max sum sequence:");
        for (int index = start; index <= end; index++)
        {
            Console.Write(array[index] + " ");
        }
    }
}
