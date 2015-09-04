using System;
using System.Collections.Generic;

public class BinaryHeap<T> where T : IComparable<T>
{
    private List<T> heap;

    public BinaryHeap()
    {
        this.heap = new List<T>();
    }

    public BinaryHeap(T[] elements)
    {
        this.heap = new List<T>(elements);

        for (int i = this.heap.Count / 2; i >= 0; i--)
        {
            this.HeapifyDown(i);
        }
    }

    public int Count
    {
        get { return this.heap.Count; }
    }

    public T ExtractMax()
    {
        T root = this.heap[0];
        this.heap[0] = this.heap[this.Count - 1];
        this.heap.RemoveAt(this.Count - 1);

        if (this.heap.Count > 0)
        {
            HeapifyDown(0);
        }

        return root;
    }

    public T PeekMax()
    {
        T root = this.heap[0];
        return root;
    }

    public void Insert(T node)
    {
        this.heap.Add(node);
        this.HeapifyUp(this.Count - 1);
    }

    private void HeapifyDown(int i)
    {
        int largest = i;
        int leftChildIndex = i * 2 + 1;
        int rightChildIndex = i * 2 + 2;

        // Left child is largest
        if (leftChildIndex < this.Count && 
            this.heap[leftChildIndex].CompareTo(this.heap[largest]) > 0)
        {
            largest = leftChildIndex;
        }

        if (rightChildIndex < this.Count && 
            this.heap[rightChildIndex].CompareTo(this.heap[largest]) > 0)
        {
            largest = rightChildIndex;
        }

        if (largest != i)
        {
            this.Swap(ref largest,ref i);
            HeapifyDown(largest);
        }
    }

    private void HeapifyUp(int i)
    {
        int parent = (i - 1) / 2;

        if (parent >= 0 && this.heap[parent].CompareTo(this.heap[i]) < 0)
        {
            this.Swap(ref parent,ref i);
            HeapifyUp(parent);
        }
    }

    private void Swap(ref int firstIndex, ref int secondIndex)
    {
        T temp = this.heap[firstIndex];
        this.heap[firstIndex] = this.heap[secondIndex];
        this.heap[secondIndex] = temp;
    }
}
