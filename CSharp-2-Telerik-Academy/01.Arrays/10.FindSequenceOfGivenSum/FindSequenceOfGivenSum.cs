using System;
class FindSequenceOfGivenSum
{
    static void Main()
    {
        Console.Write("Enter arr length: ");
        int length = int.Parse(Console.ReadLine());
        int[] array = new int[length];
        //enter array elements
        for (int i = 0; i < length; i++)
        {
            Console.Write("Enter element " + (i + 1) + ":");
            array[i] = int.Parse(Console.ReadLine());
        }

        Console.Write("Enter Sum to find: ");
        int givenSum = int.Parse(Console.ReadLine());
        int start = -1;
        int end = -1;
        bool resultFound = false;

        for (int first = 0; first < length; first++)
        {
            int currentSum = 0;
            for (int second = first; second < length; second++)
            {
                currentSum += array[second];
                if (currentSum == givenSum)
                {
                    resultFound = true;
                    start = first;
                    end = second;
                }

                if (resultFound)
                {
                    break;
                }
            }

            if (resultFound)
            {
                break;
            }
        }

        if (resultFound)
        {
            Console.WriteLine("Sequence of given sum: ");
            for (int index = start; index <= end; index++)
            {
                Console.Write(array[index] + " ");
            }
        }
        else
        {
            Console.WriteLine("No result found");
        }
    }
}
