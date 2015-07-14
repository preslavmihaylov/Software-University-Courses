using System;
using System.Collections;
using System.Collections.Generic;

public class DoublyLinkedList<T> : IEnumerable<T>
{
    private class ListNode<T>
    {
        public T Value { get; set; }
        public ListNode<T> NextNode
        {
            get;
            set;
        }

        public ListNode<T> PreviousNode
        {
            get;
            set;
        }

        public ListNode(T value)
        {
            this.Value = value;
        } 
    }

    private ListNode<T> head;
    private ListNode<T> tail;

    public int Count { get; private set; }

    public void AddFirst(T element)
    {
        ListNode<T> newNode = new ListNode<T>(element);

        if (head == null)
        {
            this.head = newNode;
            this.tail = newNode;
        }
        else
        {
            newNode.NextNode = this.head;
            this.head.PreviousNode = newNode;
            this.head = newNode;
        }
        this.Count++;
    }

    public void AddLast(T element)
    {
        ListNode<T> newNode = new ListNode<T>(element);

        if (this.tail == null)
        {
            this.head = newNode;
            this.tail = newNode;
        }
        else
        {
            newNode.PreviousNode = this.tail;
            this.tail.NextNode = newNode;
            this.tail = newNode;
        }

        this.Count++;
    }

    public T RemoveFirst()
    {
        if (this.head == null)
        {
            throw new InvalidOperationException("Cannot remove the first element of an empty list.");
        }
        else
        {
            ListNode<T> newHeadNode = this.head.NextNode;
            T removedNodeValue = this.head.Value;
            if (newHeadNode != null)
            {
                newHeadNode.PreviousNode = null;
                this.head = newHeadNode;
            }
            else
            {
                this.head = null;
                this.tail = null;
            }

            this.Count--;
            return removedNodeValue;
        }

    }

    public T RemoveLast()
    {
        if (this.tail == null)
        {
            throw new InvalidOperationException("Cannot remove the last element of an empty list.");
        }
        else
        {
            ListNode<T> newTailNode = this.tail.PreviousNode;
            T removedNodeValue = this.tail.Value;

            if (newTailNode != null)
            {
                newTailNode.NextNode = null;
                this.tail = newTailNode;
            }
            else
            {
                this.head = null;
                this.tail = null;
            }

            this.Count--;
            return removedNodeValue;;
        }
    }

    public void ForEach(Action<T> action)
    {
        ListNode<T> currentNode = this.head;
        while (currentNode != null)
        {
            action(currentNode.Value);
            currentNode = currentNode.NextNode;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        ListNode<T> currentNode = this.head;
        while (currentNode != null)
        {
            yield return currentNode.Value;
            currentNode = currentNode.NextNode;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public T[] ToArray()
    {
        T[] array = new T[this.Count];
        int currentIndex = 0;

        ListNode<T> currentNode = this.head;
        while (currentNode != null)
        {
            array[currentIndex] = currentNode.Value;
            currentIndex++;
            currentNode = currentNode.NextNode;
        }

        return array;
    }
}


class Example
{
    static void Main()
    {
        var list = new DoublyLinkedList<int>();

        list.AddFirst(5);
        list.AddFirst(4);
        list.AddFirst(3);
        list.AddFirst(2);
        list.ForEach(Console.WriteLine);

        return;

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.AddLast(5);
        list.AddFirst(3);
        list.AddFirst(2);
        list.AddLast(10);
        Console.WriteLine("Count = {0}", list.Count);

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveFirst();
        list.RemoveLast();
        list.RemoveFirst();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveLast();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");
    }
}
