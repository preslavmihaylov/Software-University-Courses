using System;
using System.Text;

public enum Direction
{
    Left,
    Right,
    Straight
}

class ShortestPath
{
    private const int DirectionsCount = 3;

    private static string map;
    private static char[] directions = { 'L', 'R', 'S' };
    private static int[] sequence;
    private static StringBuilder output = new StringBuilder();

    private static int k;
    private static int variationsCount;

    static void Main()
    {
        ProcessInput();
        GenerateVariations(0);
        PrintOutput();
    }

    static void GenerateVariations(int currentIndex)
    {
        if (currentIndex >= k)
        {
            ++variationsCount;
            PrintCurrentMap();
            return;
        }

        // dI - directionIndex
        for (int dI = 0; dI < DirectionsCount; dI++)
        {
            sequence[currentIndex] = dI;
            GenerateVariations(currentIndex + 1);
        }
    }

    static void PrintCurrentMap()
    {
        int sequenceIndex = 0;
        for (int index = 0; index < map.Length; index++)
        {
            if (map[index] != '*')
            {
                output.Append(map[index]);
            }
            else
            {
                output.Append(directions[sequence[sequenceIndex++]]);
            }
        }

        output.AppendLine();
    }

    static void PrintOutput()
    {
        Console.WriteLine(variationsCount);
        Console.Write(output.ToString());
    }

    static void ProcessInput()
    {
        map = Console.ReadLine();

        for (int index = 0; index < map.Length; index++)
        {
            if (map[index] == '*')
            {
                ++k;
            }
        }

        sequence = new int[k];
    }
}