using System;
class MergeSort
{
    static void Main()
    {
        int[] array = { 5, 1, -2, 3, 10, 7, 9, 14};

        array = mergeSort(array);

        for (int index = 0; index < array.Length; index++)
        {
            Console.WriteLine(array[index] + " ");
        }
    }

    private static int[] mergeSort(int[] array)
    {
        if (array.Length < 2)
        {
            return array;
        }

        int middle = array.Length / 2;
        int[] first = new int[middle];
        int[] second = new int[array.Length - middle];

        int count = 0;
        for (int index = 0; index < first.Length; index++)
        {
            first[index] = array[count++];
        }

        for (int index = 0; index < second.Length; index++)
        {
            second[index] = array[count++];
        }

        first = mergeSort(first);
        second = mergeSort(second);

        return merge(first, second);
    }

    private static int[] merge(int[] first, int[] second)
    {
        int firstCount = 0;
        int secondCount = 0;
        int resultCount = 0;
        int[] result = new int[first.Length + second.Length];

        while (firstCount < first.Length && secondCount < second.Length)
        {
            if (first[firstCount] < second[secondCount])
            {
                result[resultCount++] = first[firstCount++];
            }
            else
            {
                result[resultCount++] = second[secondCount++];
            }
        }

        while (firstCount < first.Length)
        {
            result[resultCount++] = first[firstCount++];
        }

        while (secondCount < second.Length)
        {
            result[resultCount++] = second[secondCount++];
        }

        return result;
    }
}
