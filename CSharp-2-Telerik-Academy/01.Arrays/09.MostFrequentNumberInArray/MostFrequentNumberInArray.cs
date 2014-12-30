using System;
class MostFrequentNumberInArray
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

        int mostFrequentNumber = int.MinValue;
        int count = 0;
        for (int first = 0; first < length; first++)
        {
            int currentCount = 0;
            for (int second = first; second < length; second++)
            {
                if (array[first] == array[second])
                {
                    currentCount++;
                }
            }

            if (count < currentCount)
            {
                count = currentCount;
                mostFrequentNumber = array[first];
            }
        }

        Console.WriteLine("Most frequent number: " + mostFrequentNumber);
        Console.WriteLine("Frequencies: " + count);

    }
}
