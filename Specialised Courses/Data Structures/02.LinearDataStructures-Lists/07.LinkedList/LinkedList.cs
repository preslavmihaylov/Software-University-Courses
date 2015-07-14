
using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedList<T> : IEnumerable<T>
{
    public ListNode<T> Head
    {
        get;
        set;
    }

    public int Count
    {
        get;
        private set;
    }

    public T this[int index]
    {
        get
        {
            int currentIndex = 0;
            ListNode<T> currentNode = this.Head;
            if (currentNode == null)
            {
                throw new IndexOutOfRangeException("The specified index is out of range.");
            }

            while (currentIndex != index)
            {
                currentIndex++;
                currentNode = currentNode.NextNode;

                if (currentNode == null)
                {
                    throw new IndexOutOfRangeException("The specified index is out of range.");
                }
            }

            return currentNode.Value;
        }
        set
        {
            int currentIndex = 0;
            ListNode<T> currentNode = this.Head;
            if (currentNode == null)
            {
                throw new IndexOutOfRangeException("The specified index is out of range.");
            }

            while (currentIndex != index)
            {
                currentIndex++;
                currentNode = currentNode.NextNode;

                if (currentNode == null)
                {
                    throw new IndexOutOfRangeException("The specified index is out of range.");
                }
            }

            currentNode.Value = value;
        }
    }

    public void Add(T element)
    {
        ListNode<T> currentNode = this.Head;
        if (currentNode == null)
        {
            this.Head = new ListNode<T>(element);
            this.Count++;
            return;
        }

        while (currentNode.NextNode != null)
        {
            currentNode = currentNode.NextNode;
        }

        currentNode.NextNode = new ListNode<T>(element);
        this.Count++;
    }

    // It is awkward that the assignment requires indexing 
    // since LinkedList is not an indexed structure
    public T Remove(int index)
    {
        int currentIndex = 0;
        ListNode<T> currentNode = this.Head;
        if (currentNode == null)
        {
            throw new ArgumentOutOfRangeException("There is no element at the specified index.");
        }
        else if (currentIndex == index)
        {
            T value = this.Head.Value;
            this.Head = null;
            this.Count--;
            return value;
        }

        while (index != currentIndex)
        {
            currentIndex++;
            
            if (currentNode.NextNode == null && currentIndex != index)
            {
                throw new ArgumentOutOfRangeException("There is no element at the specified index.");
            } 
            else if (currentIndex == index)
            {
                if (currentNode.NextNode == null)
                {
                    throw new ArgumentOutOfRangeException("There is no element at the specified index.");
                }

                T value = currentNode.NextNode.Value;
                currentNode.NextNode = null;
                this.Count--;
                return value;
            }

            currentNode = currentNode.NextNode;
        }

        return default(T);
    }

    public int FirstIndexOf(T element)
    {
        int currentIndex = 0;
        ListNode<T> currentNode = this.Head;
        while (currentNode != null)
        {
            if (currentNode.Value.Equals(element))
            {
                return currentIndex;
            }

            currentIndex++;
            currentNode = currentNode.NextNode;
        }

        return -1;
    }

    public int LastIndexOf(T element)
    {
        int currentIndex = 0;
        int lastIndex = -1;
        ListNode<T> currentNode = this.Head;
        while (currentNode != null)
        {
            if (currentNode.Value.Equals(element))
            {
                lastIndex = currentIndex;
            }

            currentIndex++;
            currentNode = currentNode.NextNode;
        }

        return lastIndex;
    }

    public IEnumerator<T> GetEnumerator()
    {
        ListNode<T> currentNode = this.Head;
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
}