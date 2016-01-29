using System;
using System.Collections.Generic;

class OddOccurences
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        List<int> collection = new List<int>(input.Length);

        foreach (string number in input)
        {
            collection.Add(int.Parse(number));
        }

        int currentNumber;
        int currentOccurencesCount = 0;
        List<int> checkedNumbers = new List<int>();
        for (int indexToCheck = 0; indexToCheck < collection.Count; indexToCheck++)
        {
            currentNumber = collection[indexToCheck];
            if (checkedNumbers.Contains(currentNumber))
            {
                continue;
            }

            for (int currentIndex = indexToCheck; currentIndex < collection.Count; currentIndex++)
            {
                if (collection[currentIndex] == currentNumber)
                {
                    currentOccurencesCount++;
                }
            }

            if (currentOccurencesCount % 2 == 1)
            {
                collection.RemoveAll((num) => num == currentNumber);
                indexToCheck--;
            }
            else
            {
                checkedNumbers.Add(currentNumber);
            }
            currentOccurencesCount = 0;
        }

        Console.WriteLine(string.Join(", ", collection));
    }
}