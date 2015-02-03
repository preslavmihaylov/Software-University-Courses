using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Please note that the examples in the homework.doc file are false (some of them).
// For example: in the sequence 1 1 1 2 2 2 2, the longest non-decreasing subsequence is  1 1 1 2 2 2 2 not 2 2 2 2.
// It's logical isn't it? It's a longest non-decreasing subsequence 
// and not a longest non-decreasing subsequence with equal elements or something like that.
// Furthermore, the output of the last example (11 12 13 3 14 4 15 5 6 7 8 7 16 9 8) is false again, because it prints out
// 3 4 5 6 7 8 9 and not 3 4 5 6 7 8 16. The second output is the correct one because in the task it is said:
// "In case of several longest non-decreasing sequences, print the leftmost of them"

// Anyways, for this example I have used recursion in order to solve it. You can read more about it here:
// http://www.introprogramming.info/intro-csharp-book/read-online/glava10-rekursia/

class LongestNonDecreasingSubsequence
{
    static int numberOfLoops;
    static int countOfNumbers;
    static int[] loops;
    static int[] numbers;
    static int[] longestPositiveSequence = new int[0];

    static void Main()
    {
        Console.Write("Enter numbers:");
        string[] input = Console.ReadLine().Split();

        countOfNumbers = input.Length;
        numberOfLoops = countOfNumbers;
        numbers = new int[countOfNumbers];

        for (int index = 0; index < input.Length; index++)
        {
            numbers[index] = Convert.ToInt32(input[index]);
        }

        while (numberOfLoops > 0)
        {
            loops = new int[numberOfLoops];
            FindSubsets(0, 0);
            numberOfLoops--;
        }

        Console.WriteLine();
        foreach (var item in longestPositiveSequence)
        {
            Console.Write(item + " ");
        }
    }

    static void FindSubsets(int currentLoop, int lastNumber)
    {
        if (currentLoop == numberOfLoops)
        {
            CheckSequence();
            return;
        }

        for (int nextNumber = lastNumber; nextNumber < countOfNumbers; nextNumber++)
        {
            loops[currentLoop] = numbers[nextNumber];
            FindSubsets(currentLoop + 1, nextNumber + 1);
        }
    }

    private static void CheckSequence()
    {
        bool positiveSequence = true;

        for (int index = 0; index < loops.Length - 1; index++)
        {
            if (loops[index] > loops[index + 1])
            {
                positiveSequence = false;
                break;
            }
        }

        if (positiveSequence)
        {
            if (loops.Length > longestPositiveSequence.Length)
            {
                longestPositiveSequence = new int[loops.Length];
                for (int index = 0; index < loops.Length; index++)
                {
                    longestPositiveSequence[index] = loops[index];
                }
            }
        }
    }
}
