using System;
using System.Collections;

class TreeNode : IEnumerable, ICloneable
{
    private TreeNode leftNode;
    private TreeNode rightNode;
    private int value;

    public TreeNode(int value)
    {
        this.Value = value;
    }

    public int Value
    {
        get
        {
            return this.value;
        }
        set
        {
            this.value = value;
        }
    }

    public TreeNode LeftNode
    {
        get
        {
            return this.leftNode;
        }
        set
        {
            this.leftNode = value;
        }
    }

    public TreeNode RightNode
    {
        get
        {
            return this.rightNode;
        }
        set
        {
            this.rightNode = value;
        }
    }

    public void Add(int value)
    {
        if (this.Value >= value)
        {
            if (this.LeftNode == null)
            {
                this.LeftNode = new TreeNode(value);   
            }
            else
            {
                this.LeftNode.Add(value);
            }
        }
        else if (this.Value < value) 
        {
            if (this.RightNode == null)
            {
                this.RightNode = new TreeNode(value);
            }
            else
            {
                this.RightNode.Add(value);
            }
        }
    }

    public int? Search(int value)
    {
        if (value == this.Value)
        {
            return this.Value;
        }
        else if (value > this.Value)
        {
            if (this.RightNode == null) 
            {
                return null;
            }

            return this.RightNode.Search(value);
        }
        else
        {
            if (this.LeftNode == null)
            {
                return null;
            }

            return this.LeftNode.Search(value);
        }
    }

    public void Delete(int value)
    {
        if (this.Value > value)
        {
            if (this.LeftNode != null)
            {
                if (this.LeftNode.Value == value)
                {
                    RearrangeNodes(ref this.leftNode);
                }
                else
                {
                    this.LeftNode.Delete(value);
                }
            }
        }
        else
        {
            if (this.RightNode != null)
            {
                if (this.RightNode.Value == value)
                {
                    RearrangeNodes(ref this.rightNode);
                }
                else
                {
                    this.RightNode.Delete(value);
                }
            }
        }
    }

    private void RearrangeNodes(ref TreeNode node)
    {
        TreeNode BrokenNode = node.LeftNode;
        if (node.RightNode != null)
        {
            node = node.RightNode;

            if (BrokenNode != null)
            {
                foreach (int number in BrokenNode)
                {
                    node.Add(number);
                }
            }
        }
        else
        {
            node = BrokenNode;
        }
    }

    public IEnumerator GetEnumerator()
    {
        if (this.LeftNode != null)
        {
            foreach (var number in this.LeftNode)
            {
                yield return number;
            }
        }

        yield return this.Value;

        if (this.RightNode != null)
        {
            foreach (var number in this.RightNode)
            {
                yield return number;
            }
        }
    }
    
    public override int GetHashCode()
    {
        int leftNodeHashCode = 0;
        int rightNodeHashCode = 0;

        if (this.LeftNode != null)
        {
            leftNodeHashCode = this.LeftNode.GetHashCode();
        }

        if (this.RightNode != null)
        {
            rightNodeHashCode = this.RightNode.GetHashCode();
        }

        return leftNodeHashCode ^ rightNodeHashCode ^ this.Value.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        if (!(obj is TreeNode))
        {
            return false;
        }
        TreeNode otherNode = (TreeNode)obj;

        bool leftNodeComparison = false;
        bool rightNodeComparison = false;

        if (this.LeftNode != null)
        {
            leftNodeComparison = this.LeftNode.Equals(otherNode.LeftNode);
        }
        else if (otherNode.LeftNode == null)
        {
            leftNodeComparison = true;
        }

        if (this.RightNode != null)
	    {
            rightNodeComparison = this.RightNode.Equals(otherNode.RightNode);
	    }
        else if (otherNode.RightNode == null)
        {
            rightNodeComparison = true;
        }

        if (leftNodeComparison &&
            rightNodeComparison &&
            this.Value == otherNode.Value)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override string ToString()
    {
        string output = "";
        if (this.LeftNode != null)
        {
            output += this.LeftNode.ToString();
        }

        output += this.Value + " ";

        if (this.RightNode != null)
        {
            output += this.RightNode.ToString();
        }

        return output;
    }

    public object Clone()
    {
        TreeNode newNode = new TreeNode(this.Value);
        if (this.LeftNode != null)
        {
            newNode.LeftNode = (TreeNode)this.LeftNode.Clone();
        }
        if (this.RightNode != null)
        {
            newNode.RightNode = (TreeNode)this.RightNode.Clone();
        }

        return newNode;
    }
}