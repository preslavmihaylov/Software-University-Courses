using System.Collections.Generic;

class Node
{
    public int Value
    {
        get;
        set;
    }

    public SortedSet<int> NeighbourIndexes;

    public Node(int value, params Node[] nodes)
    {
        this.Value = value;

        this.NeighbourIndexes = new SortedSet<int>();
        foreach (var node in nodes)
        {
            this.NeighbourIndexes.Add(node.Value);
        }
    }
}