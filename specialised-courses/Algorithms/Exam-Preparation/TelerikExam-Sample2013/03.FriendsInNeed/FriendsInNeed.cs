using System;
using System.Collections.Generic;
using System.Linq;

class Edge
{
    public int Distance
    {
        get;
        set;
    }
    public int Vertex
    {
        get;
        set;
    }
}

class Vertex : IComparable<Vertex>
{
    public int Index { get; set; }

    public int CompareTo(Vertex other)
    {
        if (FriendsInNeed.distances[this.Index] == null && FriendsInNeed.distances[other.Index] == null)
        {
            return 0;
        }

        if (FriendsInNeed.distances[this.Index] == null)
        {
            return -1;
        }

        if (FriendsInNeed.distances[other.Index] == null)
        {
            return 1;
        }

        return (int)FriendsInNeed.distances[this.Index] - (int)FriendsInNeed.distances[other.Index];
    }
}

class FriendsInNeed
{
    const int InvalidValue = int.MaxValue;

    static bool[] isHospital;
    static int[] hospitals;
    public static int?[] distances;
    static bool[] visited;
    static List<Edge>[] neighbours;
    static BinaryHeap<Vertex> operationStruct = new BinaryHeap<Vertex>();

    static int minDistance = InvalidValue;

    static void Main()
    {
        ProcessInput();
        ProcessAlgorithm();
        // PrintInfo();
    }

    static void ProcessAlgorithm()
    {
        for (int i = 0; i < hospitals.Length; i++)
        {
            distances = new int?[neighbours.Length];
            visited = new bool[neighbours.Length];

            int hospitalIndex = hospitals[i];
            CalculatePathsBetweenVertices(hospitalIndex);
            FindMinDistanceFromHospitalToHome();
        }

        PrintOutput();
    }
    
    static void CalculatePathsBetweenVertices(int startVertex)
    {
        Edge currentEdge;
        Vertex currentVertex;

        operationStruct.Insert(new Vertex() { Index = startVertex });
        distances[startVertex] = 0;

        while (operationStruct.Count > 0)
        {
            currentVertex = operationStruct.ExtractMin();

            // cI - childIndex
            for (int cI = 0; cI < neighbours[currentVertex.Index].Count; cI++)
            {
                currentEdge = neighbours[currentVertex.Index][cI];
                if (!visited[currentEdge.Vertex])
                {
                    visited[currentEdge.Vertex] = true;
                    operationStruct.Insert(new Vertex { Index = currentEdge.Vertex });
                }

                int newDistance = (int)distances[currentVertex.Index] + currentEdge.Distance;

                if (distances[currentEdge.Vertex] == null || newDistance < distances[currentEdge.Vertex])
                {
                    distances[currentEdge.Vertex] = newDistance;
                    operationStruct.Insert(new Vertex { Index = currentEdge.Vertex });
                }
            }
        }
    }

    static void FindMinDistanceFromHospitalToHome()
    {
        int currentDistance = 0;
        // nI - neighbourIndex

        for (int nI = 0; nI < neighbours.Length; nI++)
        {
            if (!isHospital[nI])
            {
                currentDistance += (int)distances[nI];
            }

            if (currentDistance >= minDistance)
            {
                return;
            }
        }

        minDistance = Math.Min(minDistance, currentDistance);
    }

    static void PrintOutput()
    {
        Console.WriteLine(minDistance);
    }

    static void ProcessInput()
    {
        string[] input = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int totalVertices = int.Parse(input[0]);
        int edgesCount = int.Parse(input[1]);
        int hospitalsCount = int.Parse(input[2]);

        InitialiseData(totalVertices, hospitalsCount);

        // Hospitals processing
        input = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        for (int index = 0; index < input.Length; index++)
        {
            int value = int.Parse(input[index]) - 1;
            hospitals[index] = value;
            isHospital[value] = true;
        }

        // Edges processing
        for (int cnt = 0; cnt < edgesCount; cnt++)
        {
            input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int firstVertex = int.Parse(input[0]) - 1;
            int secondVertex = int.Parse(input[1]) - 1;
            int distance = int.Parse(input[2]);

            if (neighbours[firstVertex] == null)
            {
                neighbours[firstVertex] = new List<Edge>();
            }

            if (neighbours[secondVertex] == null)
            {
                neighbours[secondVertex] = new List<Edge>();
            }

            neighbours[firstVertex].Add(new Edge()
            {
                Distance = distance,
                Vertex = secondVertex
            });
            neighbours[secondVertex].Add(new Edge()
            {
                Distance = distance,
                Vertex = firstVertex
            });
        }
    }

    static void InitialiseData(int totalVertices, int hospitalsCount)
    {
        neighbours = new List<Edge>[totalVertices];
        hospitals = new int[hospitalsCount];
        isHospital = new bool[totalVertices];
    }

    // Used for debugging
    static void PrintInfo()
    {
        for (int index = 0; index < distances.Length; index++)
        {
            Console.Write(distances[index] + " ");
        }
    }
}

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
        get { return this.heap.Count; }
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