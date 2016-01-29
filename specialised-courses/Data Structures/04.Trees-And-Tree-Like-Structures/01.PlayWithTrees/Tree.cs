using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

class Tree
{
    private int? SubtreeSum;

    public Tree(int value, params Tree[] children)
    {
        this.Value = value;
        this.Children = new List<Tree>();

        foreach (var child in children)
        {
            this.Children.Add(child);
            child.Parent = this;
        }
    }

    public int Value
    {
        get;
        set;
    }

    public Tree Parent
    {
        get;
        set;
    }

    public IList<Tree> Children
    {
        get;
        set;
    }

    public int FindRootNode()
    {
        if (this.Parent == null)
        {
            return this.Value;
        }
        else
        {
            return this.Parent.FindRootNode();
        }
    }

    public IList<int> FindLeafNodes()
    {
        List<int> leafNodes = new List<int>();

        if (this.Children.Count == 0)
        {
            leafNodes.Add(this.Value);
        }
        else
        {
            foreach (var child in this.Children)
            {
                leafNodes.AddRange(child.FindLeafNodes());
            }
        }

        // Sort all the leaf nodes in increasing order if this is the root node
        if (this.Parent == null)
        {
            leafNodes.Sort();
        }
        return leafNodes;
    }

    public IList<int> FindMiddleNodes()
    {
        List<int> middleNodes = new List<int>();

        if (this.Children.Count > 0 && this.Parent != null)
        {
            middleNodes.Add(this.Value);
        }

        foreach (var child in this.Children)
        {
            middleNodes.AddRange(child.FindMiddleNodes());
        }

        // Sort all the leaf nodes in increasing order if this is the root node
        if (this.Parent == null)
        {
            middleNodes.Sort();
        }
        return middleNodes;
    }

    public IList<int> FindLongestPath()
    {
        IList<int> longestPath = new List<int>();
        IList<int> currentPath;

        foreach (var child in this.Children)
        {
            currentPath = child.FindLongestPath();
            if (currentPath.Count > longestPath.Count)
            {
                longestPath = currentPath;
            }
        }

        longestPath.Insert(0, this.Value);

        return longestPath;
    }

    public IList<IList<int>> FindPathsWithSum(int sum)
    {
        IList<IList<int>> paths = new List<IList<int>>();

        foreach (var child in this.Children)
        {
            IList<IList<int>> currentpaths = child.FindPathsWithSum(sum - this.Value);

            foreach (var path in currentpaths)
            {
                paths.Add(path);
            }
        }

        foreach (var path in paths)
        {
            path.Insert(0, this.Value);
        }

        if (paths.Count == 0 && this.Value == sum)
        {
            paths.Add(new List<int>() { this.Value });
        }

        return paths;
    }

    public List<Tree> FindSubtreesWithSum(int sum)
    {
        List<Tree> currentSubtrees = new List<Tree>();

        foreach (var child in this.Children)
        {
            foreach (var tree in child.FindSubtreesWithSum(sum))
            {
                currentSubtrees.Add(tree);
            }
        }

        if (this.FindSubtreeSum() == sum)
        {
            currentSubtrees.Add(this);
        }

        return currentSubtrees;
    }

    /* 
     * This method is for optimisation. Once a Subtree finds its sum,
     * it keeps it in a variable and returns that variable everytime
     * the method is invoked again instead of calcullating its sum all over
     * again. 
     */
    public int? FindSubtreeSum()
    {
        if (this.SubtreeSum != null)
        {
            return this.SubtreeSum;
        }
        else
        {
            this.SubtreeSum = 0;
            foreach (var child in this.Children)
            {
                this.SubtreeSum += child.FindSubtreeSum();
            }

            this.SubtreeSum += Convert.ToInt32(this.Value);

            return this.SubtreeSum;
        }
    }

    public override string ToString()
    {
        StringBuilder output = new StringBuilder();

        if (this.Children.Count == 0)
        {
            output.AppendFormat(this.Value.ToString());
        }
        else
        {
            output.AppendFormat("{0} + ", this.Value);   
        }

        output.Append(string.Join(" + ", this.Children));

        return output.ToString();
    }
}
