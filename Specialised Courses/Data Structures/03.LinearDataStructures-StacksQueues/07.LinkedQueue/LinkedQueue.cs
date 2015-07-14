using System;

public class LinkedQueue<T>
{
    private QueueNode<T> head;
    private QueueNode<T> tail; 

    public int Count { get; private set; } 

    public void Enqueue(T element)
    {
        if (this.head == null)
        {
            this.head = new QueueNode<T>(element);
            this.tail = this.head;
        }
        else
        {
            this.tail.PrevNode = new QueueNode<T>(element);
            this.tail.PrevNode.NextNode = this.tail;
            this.tail = this.tail.PrevNode;
        }

        this.Count++;
    }

    public T Dequeue()
    {
        if (this.Count <= 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        T result = this.head.Value;
        this.head = this.head.PrevNode;

        this.Count--;
        return result;
    }

    public T[] ToArray()
    {
        T[] resultArray = new T[this.Count];

        QueueNode<T> currentNode = this.head;
        int resultArrayIndex = 0;

        while (currentNode != null)
        {
            resultArray[resultArrayIndex] = currentNode.Value;
            resultArrayIndex++;
            currentNode = currentNode.PrevNode;
        }

        return resultArray;
    }

    private class QueueNode<T>
    {
        public T Value { get; private set; }
        public QueueNode<T> NextNode { get; set; }
        public QueueNode<T> PrevNode { get; set; }

        public QueueNode(T value)
        {
            this.Value = value;
        } 
    }
}
