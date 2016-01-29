using System;

public class BinaryTree<T>
{
    public T Value { get; set; }
    public BinaryTree<T> LeftChild { get; set; }
    public BinaryTree<T> RightChild { get; set; }

    public BinaryTree(T value, BinaryTree<T> leftChild = null, BinaryTree<T> rightChild = null)
    {
        this.Value = value;
        this.LeftChild = leftChild;
        this.RightChild = rightChild;
    }

    public void PrintIndentedPreOrder(int indent = 0)
    {
        Console.Write(new string(' ', 2 * indent));
        Console.WriteLine(this.Value);

        if (LeftChild != null)
        {
            LeftChild.PrintIndentedPreOrder(indent + 1);
        }

        if (RightChild != null)
        {
            RightChild.PrintIndentedPreOrder(indent + 1);
        }
    }

    public void EachInOrder(Action<T> action)
    {
        if (LeftChild != null)
        {
            LeftChild.EachInOrder(action);
        }

        action(this.Value);

        if (RightChild != null)
        {
            RightChild.EachInOrder(action);
        }
    }

    public void EachPostOrder(Action<T> action)
    {
        if (LeftChild != null)
        {
            LeftChild.EachPostOrder(action);
        }

        if (RightChild != null)
        {
            RightChild.EachPostOrder(action);
        }

        action(this.Value);
    }
}
