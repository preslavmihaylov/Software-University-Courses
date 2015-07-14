
using System;
using System.Collections.Generic;
using System.Linq;

class LongestSubsequence
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        List<int> collection = new List<int>(input.Length);

        int currentCount = 0;
        int maxCount = -1;
        int currentNumber = int.MinValue;
        int maxNumberInSequence = int.MinValue;

        foreach (string number in input)
        {
            collection.Add(int.Parse(number));
            if (collection.Last() == currentNumber)
            {
                currentCount++;
            }
            else
            {
                if (maxCount < currentCount)
                {
                    maxCount = currentCount;
                    maxNumberInSequence = currentNumber;
                }
                currentCount = 1;
                currentNumber = collection.Last();
            }
        }

        if (maxCount < currentCount)
        {
            maxCount = currentCount;
            maxNumberInSequence = currentNumber;
        }

        List<int> result = Enumerable.Repeat(maxNumberInSequence, maxCount).ToList();
        Console.WriteLine(string.Join(", ", result));
    }
}