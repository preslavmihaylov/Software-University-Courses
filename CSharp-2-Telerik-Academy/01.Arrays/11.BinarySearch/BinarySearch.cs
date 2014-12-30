using System;
class BinarySearch
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

        Console.Write("Enter number to find: ");
        int numToFind = int.Parse(Console.ReadLine());

        sortArray(ref array);

        binarySearch(0, length - 1, array, numToFind);

        for (int index = 0; index < length; index++)
        {
            Console.WriteLine(index + " : " + array[index]);
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

    private static void binarySearch(int start, int end, int[] array, int numToFind)
    {
        if (start == end)
        {
            if (array[start] == numToFind)
            {
                Console.WriteLine(start);
                return;
            }
            else
            {
                Console.WriteLine(-1);
                return;
            }
        }
        else
        {
            int middle = (start + end) / 2;
            if (array[middle] < numToFind)
            {
                binarySearch(middle + 1, end, array, numToFind);
            }
            else if (array[middle] > numToFind) 
            {
                binarySearch(start, middle - 1, array, numToFind);
            }
            else
            {
                Console.WriteLine(middle);
                return;
            }
        }
    }
}
