using System;
class QuickSort
{
    static void Main()
    {
        string[] array = { "pesho", "gosh", "stefan", "pres", "atanas", "nakov", "qqqq", "zzz", "peeee", "bbbb" };

        quickSort(ref array, 0, array.Length - 1);
        for (int index = 0; index < array.Length; index++)
        {
            Console.WriteLine(array[index] + " ");
        }
    }

    private static void quickSort(ref string[] array, int start, int end)
    {
        if (start >= end)
        {
            return;
        }

        int pivotIndex = partition(ref array, start, end);

        quickSort(ref array, start, pivotIndex - 1);
        quickSort(ref array, pivotIndex + 1, end);
    }

    private static int partition(ref string[] array, int start, int end)
    {
        int pivotIndex = start;
        string pivot = array[end];

        for (int index = start; index <= end; index++)
        {
            if (String.Compare(array[index], pivot) == -1)
            {
                swap(ref array[pivotIndex++], ref array[index]);
            }
        }

        return pivotIndex;
    }

    private static void swap(ref string first, ref string second)
    {
        if (first != second)
        {
            string temp = first;
            first = second;
            second = temp;
        }
    }
}
