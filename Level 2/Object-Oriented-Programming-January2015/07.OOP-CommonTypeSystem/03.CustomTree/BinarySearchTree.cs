using System;
using System.Collections;

class BinarySearchTree : IEnumerable, ICloneable
{
    private TreeNode mainNode;

    public BinarySearchTree()
    {
    }

    public BinarySearchTree(int value)
    {
        this.MainNode = new TreeNode(value);
    }

    private TreeNode MainNode 
    {
        get
        {
            return this.mainNode;
        }
        set
        {
            this.mainNode = value;
        }
    }

    public void Add(int value)
    {
        if (this.MainNode == null)
        {
            this.MainNode = new TreeNode(value);
        }
        else
        {
            this.MainNode.Add(value);
        }
    }

    public int? Search(int value)
    {
        int? result = this.MainNode.Search(value);
        return result;
    }

    public void Delete(int value)
    {
        if (this.MainNode != null)
        {
            
            if (this.MainNode.Value == value)
            {
                TreeNode BrokenNode = this.MainNode.LeftNode;
                this.MainNode = this.MainNode.RightNode;
                foreach (int number in BrokenNode)
                {
                    if (number != value)
                    {
                        this.MainNode.Add(number);
                    }
                }   
            }
            else
            {
                this.MainNode.Delete(value);
            }
        }
    }

    public IEnumerator GetEnumerator()
    {
        foreach (var number in this.MainNode)
        {
            yield return number;
        }
    }

    public override bool Equals(object obj)
    {
        if (!(obj is BinarySearchTree))
	    {
            return false;
	    }

        BinarySearchTree tree = (BinarySearchTree)obj;

        return this.MainNode.Equals(tree.MainNode);
    }

    public override int GetHashCode()
    {
        return this.MainNode.GetHashCode();
    }

    public override string ToString()
    {
        return this.MainNode.ToString();
    }

    public object Clone()
    {
        BinarySearchTree newTree = new BinarySearchTree();
        newTree.MainNode = (TreeNode)this.MainNode.Clone();

        return newTree;
    }
}