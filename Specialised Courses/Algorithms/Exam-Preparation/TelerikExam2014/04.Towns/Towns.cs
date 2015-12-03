using System;

class Towns
{
    private static string[] towns;
    private static int[] populations;
    private static int[] ascPathLengths;
    private static int[] descPathLengths;

    private static int maxPathLength;

    static void Main()
    {
        ProcessInput();
        FindOptimalPath();
        PrintResult();
        // PrintInfo();
    }

    private static void FindOptimalPath()
    {
        PreprocessData();

        for (int townIndex = 0; 
            townIndex < towns.Length; 
            ++townIndex)
        {
            for (int prevIndex = 0; prevIndex < townIndex; ++prevIndex)
            {
                if ( ( populations[prevIndex] < populations[townIndex] && 
                      ascPathLengths[townIndex] <= ascPathLengths[prevIndex] ) )
                {
                    ascPathLengths[townIndex] = ascPathLengths[prevIndex] + 1;
                }

                if (populations[prevIndex] > populations[townIndex])
                {
                    descPathLengths[townIndex] = 
                        Math.Max(
                            Math.Max(descPathLengths[prevIndex], 
                                     ascPathLengths[prevIndex]) + 1, 
                            descPathLengths[townIndex]);
                }
            }

            CheckMaxPath(ascPathLengths[townIndex]);
            CheckMaxPath(descPathLengths[townIndex]);
        }
    }

    private static void CheckMaxPath(int length)
    {
        maxPathLength = Math.Max(maxPathLength, length);
    }

    private static void PreprocessData()
    {
        for (int cnt = 0; cnt < ascPathLengths.Length; cnt++)
        {
            ascPathLengths[cnt] = 1;
            descPathLengths[cnt] = 1;
        }
    }

    private static void ProcessInput()
    {
        string[] input;
        int townsCount = int.Parse(Console.ReadLine());
        towns = new string[townsCount];
        populations = new int[townsCount];
        ascPathLengths = new int[townsCount];
        descPathLengths = new int[townsCount];

        for (int cnt = 0; cnt < townsCount; ++cnt)
        {
            input = Console.ReadLine().Split(' ');
            towns[cnt] = input[1];
            populations[cnt] = int.Parse(input[0]);
        }
    }

    private static void PrintResult()
    {
        Console.WriteLine(maxPathLength);
    }

    // Used for debugging
    private static void PrintInfo()
    {
        for (int cnt = 0; cnt < towns.Length; cnt++)
        {
            Console.WriteLine("{0} -> P: {1} AL: {2} DL: {3}", 
                towns[cnt], 
                populations[cnt], 
                ascPathLengths[cnt],
                descPathLengths[cnt]);
        }
    }
}