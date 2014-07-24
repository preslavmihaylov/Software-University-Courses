using System;
using System.Collections.Generic;
class BitsKiller
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        List<int> numbers = new List<int>();
        for (int index = 0; index < input.Length; index++)
        {
            numbers.Add(int.Parse(input[index]));
        }

        int[] results = new int[numbers.Count / 2];
        int resultsCount = 0; 
        for (int count = 0; count < numbers.Count; count+=2)
        {
            results[resultsCount] = numbers[count] + numbers[count + 1];
            resultsCount++;
        }

        int sumOfResults = results[0];
        bool resultsEqual = true;

        foreach (var result in results)
        {
            if (sumOfResults != result)
            {
                resultsEqual = false;
            }
        }

        int maxDifference = int.MinValue;
        for (int index = results.Length - 1; index > 0; index--)
        {
            if (Math.Abs(results[index] - results[index - 1]) > maxDifference)
            {
                maxDifference = Math.Abs(results[index] - results[index - 1]);
            }
        }

        if (resultsEqual == true)
        {
            Console.WriteLine("Yes, value={0}", sumOfResults);
        }
        else
        {
            Console.WriteLine("No, maxdiff={0}", maxDifference);
        }
    }
}
