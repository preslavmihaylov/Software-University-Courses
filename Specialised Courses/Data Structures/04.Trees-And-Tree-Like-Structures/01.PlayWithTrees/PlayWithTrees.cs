using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class PlayWithTrees
{
    private static Dictionary<int, Tree> nodes; 

    static void Main()
    {
        nodes = new Dictionary<int, Tree>();
        int inputCount = int.Parse(Console.ReadLine());

        while (nodes.Count < inputCount)
        {
            string[] input = Console.ReadLine().Split(' ');
            
            int parentNodeValue = int.Parse(input[0]);
            int childNodeValue = int.Parse(input[1]);

            Tree child;
            Tree parent;

            if (!nodes.ContainsKey(childNodeValue))
            {
                child = new Tree(childNodeValue);
                nodes.Add(childNodeValue, child);
            }
            else
            {
                child = nodes[childNodeValue];
            }

            if (!nodes.ContainsKey(parentNodeValue))
            {
                if (child.Parent != null)
                {
                    throw new InvalidOperationException("Invalid Tree.");
                }

                parent = new Tree(parentNodeValue, child);
                nodes.Add(parentNodeValue, parent);
            }
            else
            {
                parent = nodes[parentNodeValue];
                parent.Children.Add(child);
                child.Parent = parent;
            }
        }

        var rootNodes = nodes.Where(n => n.Value.Parent == null);
        if (rootNodes.Count() != 1)
        {
            throw new InvalidOperationException("Invalid Tree.");
        }

        Tree resultTree = rootNodes.First().Value;

        Console.WriteLine("Root Node: {0}", resultTree.FindRootNode());
        Console.WriteLine("Leaf Nodes: {0}", 
            string.Join(", ", resultTree.FindLeafNodes()) );
        Console.WriteLine("Middle Nodes: {0}",
            string.Join(", ", resultTree.FindMiddleNodes()));
        Console.WriteLine("Longest Path: {0}",
            string.Join(" -> ", resultTree.FindLongestPath()));

        IList<IList<int>> pathsWithValue = resultTree.FindPathsWithSum(27);
        Console.WriteLine("Paths With Value 27:");
        foreach (var path in pathsWithValue)
        {
            Console.WriteLine(string.Join(" -> ", path));
        }

        IList<Tree> subtreesWithValue = resultTree.FindSubtreesWithSum(43);
        Console.WriteLine("Subtrees With Value 43:");
        foreach (var tree in subtreesWithValue)
        {
            Console.WriteLine(tree);
        }
    }
}
