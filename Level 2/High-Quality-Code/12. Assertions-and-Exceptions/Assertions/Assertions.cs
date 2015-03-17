using System;
using System.Diagnostics;

class Assertions
{
    public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
    {
        for (int index = 0; index < arr.Length - 1; index++)
        {
            int minelementIndex = FindMinelementIndexIndex(arr, index, arr.Length - 1);
            Swap(ref arr[index], ref arr[minelementIndex]);
        }
    }
  
    private static int FindMinelementIndexIndex<T>(T[] arr, int startIndex, int endIndex) 
        where T : IComparable<T>
    {
        int minelementIndexIndex = startIndex;
        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (arr[i].CompareTo(arr[minelementIndexIndex]) < 0)
            {
                minelementIndexIndex = i;
            }
        }
        return minelementIndexIndex;
    }

    public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
    {
        return BinarySearch(arr, value, 0, arr.Length - 1);
    }

    private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex) 
        where T : IComparable<T>
    {
        while (startIndex <= endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;
            if (arr[midIndex].Equals(value))
            {
                return midIndex;
            }
            if (arr[midIndex].CompareTo(value) < 0)
            {
                // Search on the right half
                startIndex = midIndex + 1;
            }
            else 
            {
                // Search on the right half
                endIndex = midIndex - 1;
            }
        }

        Debug.Assert(startIndex >= endIndex);
        // Searched value not found
        return -1;
    }

    static void Main()
    {
        int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
        Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
        SelectionSort(arr);
        Debug.Assert(arr[0] == -1);
        Debug.Assert(arr[arr.Length - 1] == 33);
        Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

        SelectionSort(new int[0]); // Test sorting empty array
        SelectionSort(new int[1]); // Test sorting single element array

        var elementIndex = BinarySearch(arr, -1000);
        Console.WriteLine(elementIndex);
        Debug.Assert(elementIndex == -1);

        elementIndex = BinarySearch(arr, 0);
        Console.WriteLine(elementIndex);
        Debug.Assert(elementIndex == 1);

        elementIndex = BinarySearch(arr, 17);
        Console.WriteLine(elementIndex);
        Debug.Assert(elementIndex == 6);

        Console.WriteLine(BinarySearch(arr, 10));
        Console.WriteLine(BinarySearch(arr, 1000));
    }
    private static void Swap<T>(ref T x, ref T y)
    {
        T oldX = x;
        x = y;
        y = oldX;
    }
}
