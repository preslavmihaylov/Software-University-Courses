using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

class OddOrEvenCounter
{
    static void Main()
    {
        int setCount = int.Parse(Console.ReadLine());
        int numberSet = int.Parse(Console.ReadLine());
        string type = Console.ReadLine();

        int[] totalCount = new int[setCount];
        for (int index = 0; index < setCount; index++)
        {
            for (int innerIndex = 0; innerIndex < numberSet; innerIndex++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                if (type == "odd")
                {
                    if (currentNumber % 2 == 1)
                    {
                        totalCount[index]++;
                    }
                }
                else
                {
                    if (currentNumber % 2 == 0)
                    {
                        totalCount[index]++;
                    }
                }
            }
        }

        int maxCount = 0;
        int maxIndex = -1;

        for (int index = 0; index < totalCount.Length; index++)
        {
            if (totalCount[index] > maxCount)
            {
                maxCount = totalCount[index];
                maxIndex = index;
            }
        }

        if (maxCount == 0)
        {
            Console.WriteLine("No");
        }
        else
        {
            switch (maxIndex + 1)
            {
                case 1:
                    Console.Write("First");
                    break;
                case 2:
                    Console.Write("Second");
                    break;
                case 3:
                    Console.Write("Third");
                    break;
                case 4:
                    Console.Write("Fourth");
                    break;
                case 5:
                    Console.Write("Fifth");
                    break;
                case 6:
                    Console.Write("Sixth");
                    break;
                case 7:
                    Console.Write("Seventh");
                    break;
                case 8:
                    Console.Write("Eighth");
                    break;
                case 9:
                    Console.Write("Ninth");
                    break;
                case 10:
                    Console.Write("Tenth");
                    break;
            }
            // "First", "Second", "Third", "Fourth", "Fifth", "Sixth", "Seventh", "Eighth", "Ninth", "Tenth"
            Console.WriteLine(" set has the most {0} numbers: {1}", type, maxCount);
        }

    }
}
