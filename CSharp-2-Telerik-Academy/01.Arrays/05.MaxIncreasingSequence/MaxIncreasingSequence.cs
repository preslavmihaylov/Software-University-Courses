using System;
class MaxIncreasingSequence
{
    static void Main()
    {
        int[] array = { 2, 1, 1, 5, 2, 10, 15, 2 };

        int start = 0;
        int end = 0;
        int maxSequenceCount = 0;

        for (int first = 0; first < array.Length - 1; first++)
        {
            for (int second = first + 1; second < array.Length; second++)
            {
                if (array[second] <= array[second - 1])
                {
                    if (maxSequenceCount < (second - 1) - first)
                    {
                        maxSequenceCount = (second - 1) - first;
                        start = first;
                        end = second - 1;
                    }

                    break;
                }
                else if (second == array.Length - 1)
                {
                    if (maxSequenceCount < second - first)
                    {
                        maxSequenceCount = second - first;
                        start = first;
                        end = second;
                    }
                }
            }
        }

        for (int index = start; index <= end; index++)
        {
            Console.Write(array[index] + " ");
        }
    }
}
