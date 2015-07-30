using System;
using System.Collections.Generic;

class RoundDance
{
    private static Dictionary<int, List<int>> nodes;
    private static int leaderNode;

    static void Main()
    {
        nodes = new Dictionary<int, List<int>>();

        ReadInput();

        // Note: The second example is wrong since the longest connected nodes are 7-1-4-5
        int longestRoundDance = FindLongestRoundDance(leaderNode, -1);

        Console.WriteLine("Longest Round Dance: " + longestRoundDance);
    }

    /* Implementing DFS */
    private static int FindLongestRoundDance(int start, int previousNode)
    {
        int count = 0;
        int currentCount = 0;

        foreach (var currentNode in nodes[start])
        {
            if (currentNode != previousNode)
            {
                currentCount = FindLongestRoundDance(currentNode, start);
                if (currentCount > count)
                {
                    count = currentCount;
                }
            }
        }

        return ++count;
    }

    private static void ReadInput()
    {
        int friendshipsCount = int.Parse(Console.ReadLine());
        int leader = int.Parse(Console.ReadLine());
        leaderNode = leader;

        nodes[leader] = new List<int>();

        for (int count = 0; count < friendshipsCount; count++)
        {
            string[] inputLine = Console.ReadLine().Split(' ');

            int first = int.Parse(inputLine[0]);
            int second = int.Parse(inputLine[1]);

            if (!nodes.ContainsKey(first))
            {
                nodes[first] = new List<int>();
            }

            if (!nodes.ContainsKey(second))
            {
                nodes[second] = new List<int>();
            }

            nodes[first].Add(second);
            nodes[second].Add(first);
        }
    }
}