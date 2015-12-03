using System;

class AcademyTasks
{
    const int MaxSkipCount = 2;
    const int InvalidValue = int.MaxValue;

    static int[] pleasentness;
    static int[] lengths;
    static int[] minElements;
    static int[] maxElements;

    static bool finished = false;
    static int minLength = int.MaxValue;
    static int variety;

    static void Main()
    {
        ProcessInput();
        FindOptimalTaskCompletion();
        PrintOutput();
    }

    static void FindOptimalTaskCompletion()
    {
        // pI - pleasentnessIndex
        for (int pI = 0; pI < pleasentness.Length; pI++)
        {
            lengths[pI] = InvalidValue;

            for (int prevI = Math.Max(pI - MaxSkipCount, 0); prevI < pI; prevI++)
            {
                if (lengths[pI] > lengths[prevI] + 1 ||
                    IsPleasentnessOutOfRange(minElements[prevI], pleasentness[pI]) ||
                    IsPleasentnessOutOfRange(maxElements[prevI], pleasentness[pI]))
                {
                    lengths[pI] = lengths[prevI] + 1;
                    minElements[pI] = Math.Min(minElements[prevI], pleasentness[pI]);
                    maxElements[pI] = Math.Max(maxElements[prevI], pleasentness[pI]);

                    if (IsPleasentnessOutOfRange(maxElements[pI], minElements[pI]))
                    {
                        finished = true;
                        minLength = Math.Min(minLength, lengths[pI]);
                        return;
                    }
                }
            }

            if (lengths[pI] == InvalidValue)
            {
                lengths[pI] = 1;
                minElements[pI] = pleasentness[pI];
                maxElements[pI] = pleasentness[pI];
            }
        }
    }

    static bool IsPleasentnessOutOfRange(int max, int min)
    {
        return Math.Abs(max - min) >= variety;
    }

    static void PrintOutput()
    {
        if (finished)
        {
            Console.WriteLine(minLength);
        }
        else
        {
            Console.WriteLine(pleasentness.Length);
        }
    }
    
    static void ProcessInput()
    {
        string[] input = Console.ReadLine()
            .Split(new char[] { ',', ' ' }, 
            StringSplitOptions.RemoveEmptyEntries);
        variety = int.Parse(Console.ReadLine());

        InitialiseData(input.Length);

        for (int index = 0; index < input.Length; index++)
        {
            pleasentness[index] = int.Parse(input[index]);
        }
    }

    static void InitialiseData(int dataLength)
    {
        pleasentness = new int[dataLength];
        lengths = new int[dataLength];
        minElements = new int[dataLength];
        maxElements = new int[dataLength];
    }
}