using System;

public class LinkedStack<T>
{
    private Node<T> firstNode;

    public int Count { get; private set; }

    public void Push(T element)
    {
        if (this.firstNode == null)
        {
            this.firstNode = new Node<T>(element);
        }
        else
        {
            this.firstNode = new Node<T>(element, this.firstNode);    
        }

        this.Count++;
    }

    public T Pop()
    {
        if (this.Count <= 0)
        {
            throw new InvalidOperationException("The stack is empty");
        }

        T result = this.firstNode.Value;
        this.firstNode = this.firstNode.NextNode;

        this.Count--;
        return result;
    }

    public T[] ToArray()
    {
        T[] resultArray = new T[this.Count];
        Node<T> currentNode = this.firstNode;

        int currentIndex = 0;
        while (currentNode != null)
        {
            resultArray[currentIndex] = currentNode.Value;

            currentNode = currentNode.NextNode;
            currentIndex++;
        }

        return resultArray;
    }

    private class Node<T>
    {
        public T Value { get; set; }

        public Node<T> NextNode { get; set; }

        public Node(T value, Node<T> nextNode = null)
        {
            this.Value = value;
            this.NextNode = nextNode;
        }
    }
}
