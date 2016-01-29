using System;
using System.Collections.Generic;

class LongestPathInTree
{
    private static Dictionary<int, List<int>> nodesWithchildren;
    private static Dictionary<int, int?> nodesWithParents; 

    static void Main()
    {
        int nodeCount = int.Parse(Console.ReadLine());
        int edgesCount = int.Parse(Console.ReadLine());

        nodesWithchildren = new Dictionary<int, List<int>>();
        nodesWithParents = new Dictionary<int, int?>();

        ReadInput(edgesCount);

        int? root = FindRootNode();

        if (root == null)
        {
            throw new ArgumentException("There is no root node.");
        }

        int longestPath = FindLongestPathInTree(Convert.ToInt32(root));
        Console.WriteLine("Result: " + longestPath);
    }

    private static int FindLongestPathInTree(int root)
    {
        int longestLeafPath = int.MinValue;
        int secondLongestLeafPath = int.MinValue;

        foreach (var child in nodesWithchildren[root])
        {
            int currentPath = FindLongestPathInNode(child);

            if (currentPath >= longestLeafPath)
            {
                secondLongestLeafPath = longestLeafPath;
                longestLeafPath = currentPath;
            } 
            else if (currentPath > secondLongestLeafPath)
            {
                secondLongestLeafPath = currentPath;
            }
        }

        return longestLeafPath + secondLongestLeafPath + root;
    }

    private static int FindLongestPathInNode(int node)
    {
        int longestPath = int.MinValue;

        foreach (var currentNode in nodesWithchildren[node])
        {
            int currentPath = FindLongestPathInNode(currentNode);

            if (longestPath < currentPath)
            {
                longestPath = currentPath;
            }
        }

        return longestPath + node;
    }

    private static int? FindRootNode()
    {
        foreach (var node in nodesWithParents)
        {
            if (node.Value == null)
            {
                return node.Key;
            }
        }

        return null;
    }

    private static void ReadInput(int edgesCount)
    {
        for (int count = 0; count < edgesCount; count++)
        {
            string[] inputLine = Console.ReadLine().Split(' ');
            int parent = int.Parse(inputLine[0]);
            int child = int.Parse(inputLine[1]);

            if (!nodesWithchildren.ContainsKey(parent))
            {
                nodesWithchildren[parent] = new List<int>();
            }

            if (!nodesWithchildren.ContainsKey(child))
            {
                nodesWithchildren[child] = new List<int>();
            }

            nodesWithchildren[parent].Add(child);

            if (!nodesWithParents.ContainsKey(parent))
            {
                nodesWithParents[parent] = null;
            }

            if (!nodesWithParents.ContainsKey(child))
            {
                nodesWithParents[child] = parent;
            }
            else
            {
                nodesWithParents[child] = parent;
            }
        }
    }
}