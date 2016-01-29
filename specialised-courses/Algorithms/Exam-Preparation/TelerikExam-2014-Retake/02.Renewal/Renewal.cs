using System;
using System.Collections.Generic;

class Renewal
{
    private const int SmallLettersOffset = 26;

    private static HashSet<string> duplicateEdges = new HashSet<string>(); 
    private static bool[,] matrix;
    private static int[,] buildingCosts;
    private static int[,] destructionCosts;
    private static bool[] visited;

    private static int verticesCount;

    static void Main()
    {
        ProcessInput();
        int result = FindMinSumForRenewal(0);
        PrintOutput(result);
    }

    // Implementing Prim's Min spanning tree
    static int FindMinSumForRenewal(int startVertex)
    {
        BinaryHeap<Edge> heap = new BinaryHeap<Edge>();
        int result = 0;
        visited[startVertex] = true;

        // chI - childIndex
        AddChildrenToHeap(startVertex, heap);

        while (heap.Count > 0)
        {
            Edge currentEdge = heap.ExtractMin();
            int source = currentEdge.Source;
            int dest = currentEdge.Destination;

            if (visited[source] ^ visited[dest])
            {
                if (!currentEdge.Exists)
                {
                    result += currentEdge.Cost;
                }

                visited[dest] = true;

                AddChildrenToHeap(dest, heap);
            }
            else if (currentEdge.Exists)
            {
                result += currentEdge.Cost;
            }
        }

        return result;
    }

    private static void AddChildrenToHeap(int startVertex, BinaryHeap<Edge> heap)
    {
        for (int chI = 0; chI < verticesCount; chI++)
        {
            if (chI == startVertex)
            {
                continue;
            }

            Edge edge = new Edge(startVertex, chI, destructionCosts[startVertex, chI], true);

            if (duplicateEdges.Contains(edge.ToString()))
            {
                continue;
            }

            duplicateEdges.Add(edge.ToString());

            if (matrix[startVertex, chI])
            {
                heap.Insert(edge);
            }
            else
            {
                edge.Cost = buildingCosts[startVertex, chI];
                edge.Exists = false;
                heap.Insert(edge);
            }
        }
    }

    static void PrintOutput(int result)
    {
        Console.WriteLine(result);
    }

    static void ProcessInput()
    {
        string input;
        verticesCount = int.Parse(Console.ReadLine());
        matrix = new bool[verticesCount, verticesCount];
        buildingCosts = new int[verticesCount, verticesCount];
        destructionCosts = new int[verticesCount, verticesCount];
        visited = new bool[verticesCount];

        for (int row = 0; row < verticesCount; row++)
        {
            input = Console.ReadLine();

            for (int col = 0; col < verticesCount; col++)
            {
                matrix[row, col] = input[col] == '1' ? true : false;
            }
        }

        for (int row = 0; row < verticesCount; row++)
        {
            input = Console.ReadLine();

            for (int col = 0; col < verticesCount; col++)
            {
                int cost = 0;
                if (IsSmallLetter(input[col]))
                {
                    cost = (input[col] - 'a') + SmallLettersOffset;
                }
                else
                {
                    cost = input[col] - 'A';
                }

                buildingCosts[row, col] = cost;
            }
        }

        for (int row = 0; row < verticesCount; row++)
        {
            input = Console.ReadLine();

            for (int col = 0; col < verticesCount; col++)
            {
                int cost = 0;
                if (IsSmallLetter(input[col]))
                {
                    cost = (input[col] - 'a') + SmallLettersOffset;
                }
                else
                {
                    cost = input[col] - 'A';
                }

                destructionCosts[row, col] = cost;
            }
        }
    }

    static bool IsSmallLetter(char ch)
    {
        return ch >= 'a' && ch <= 'z';
    }
}

#region Edge
class Edge : IComparable<Edge>
{
    public int Source { get; set; }
    public int Destination { get; set; }
    public bool Exists { get; set; }
    public int Cost { get; set; }

    public Edge(int source, int destination, int cost, bool exists)
    {
        this.Source = source;
        this.Destination = destination;
        this.Cost = cost;
        this.Exists = exists;
    }

    public int CompareTo(Edge other)
    {
        if (this.Exists && !other.Exists)
        {
            return -1;
        }
        else if (!this.Exists && other.Exists)
        {
            return 1;
        }

        if (this.Exists)
        {
            return other.Cost - this.Cost;
        }
        else
        {
            return this.Cost - other.Cost;
        }
    }

    public override string ToString()
    {
        int first;
        int second;

        if (this.Source > this.Destination)
        {
            first = this.Source;
            second = this.Destination;
        }
        else
        {
            first = this.Destination;
            second = this.Source;
        }

        return first.ToString() + second;
    }
}
#endregion

#region Binary Heap
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

        Heapify();
    }

    public int Count
    {
        get
        {
            return this.heap.Count;
        }
    }

    public void Heapify()
    {
        for (int i = this.heap.Count / 2; i >= 0; i--)
        {
            this.HeapifyDown(i);
        }
    }

    public T ExtractMin()
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

    public T PeekMin()
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
            this.heap[leftChildIndex].CompareTo(this.heap[largest]) < 0)
        {
            largest = leftChildIndex;
        }

        if (rightChildIndex < this.Count &&
            this.heap[rightChildIndex].CompareTo(this.heap[largest]) < 0)
        {
            largest = rightChildIndex;
        }

        if (largest != i)
        {
            this.Swap(ref largest, ref i);
            HeapifyDown(largest);
        }
    }

    private void HeapifyUp(int i)
    {
        int parent = (i - 1) / 2;

        if (parent >= 0 && this.heap[parent].CompareTo(this.heap[i]) > 0)
        {
            this.Swap(ref parent, ref i);
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
#endregion