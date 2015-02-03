using System;
class SortArray
{
    static void Main()
    {
        int[] array = { 3, 7, 1, 6, 2, 5, 9, 9};

        sortArray(ref array);

        for (int index = 0; index < array.Length; index++)
        {
            Console.Write(array[index] + " ");
        }
    }

    private static void sortArray(ref int[] array)
    {
        for (int start = 0; start < array.Length - 1; start++)
        {
            int indexOfSmallestElement = 0;
            int smallestElementValue = int.MaxValue;
            for (int element = start; element < array.Length; element++)
            {
                if (array[element] < smallestElementValue)
                {
                    smallestElementValue = array[element];
                    indexOfSmallestElement = element;
                }
            }

            if (array[start] != array[indexOfSmallestElement])
            {
                array[start] ^= array[indexOfSmallestElement];
                array[indexOfSmallestElement] ^= array[start];
                array[start] ^= array[indexOfSmallestElement];   
            }
        }
    }
}
