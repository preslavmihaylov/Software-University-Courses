
using System;
using System.Collections.Generic;

class CountOfOccurences
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        List<int> collection = new List<int>(input.Length);

        foreach (string number in input)
        {
            collection.Add(int.Parse(number));
        }

        Dictionary<int, int> numberOccurences = new Dictionary<int, int>();

        int currentNumber;
        int currentOccurencesCount = 0;
        for (int indexToCheck = 0; indexToCheck < collection.Count; indexToCheck++)
        {
            currentNumber = collection[indexToCheck];
            if (numberOccurences.ContainsKey(currentNumber))
            {
                continue;
            }

            for (int currentIndex = indexToCheck; 
                currentIndex < collection.Count; 
                currentIndex++)
            {
                if (collection[currentIndex] == currentNumber)
                {
                    currentOccurencesCount++;
                }
            }

            numberOccurences[currentNumber] = currentOccurencesCount;
            currentOccurencesCount = 0;
        }

        foreach (KeyValuePair<int, int> keyValuePair in numberOccurences)
        {
            Console.WriteLine(keyValuePair.Key + " --> " + keyValuePair.Value + " times");
        }
    }
}