using System;
using System.Collections.Generic;
using System.Linq;

public class GraphConnectedComponents
{
    private static bool[] visitedNodes;
    private static Graph graph;

    public static void Main()
    {
        int inputCount = int.Parse(Console.ReadLine());

        graph = new Graph(inputCount);

        visitedNodes = new bool[inputCount];
        for (int index = 0; index < visitedNodes.Length; index++)
        {
            visitedNodes[index] = false;
        }

        for (int count = 0; count < inputCount; count++)
        {
            Node currentNode = new Node(count);

            if (graph.Nodes[count] == null)
            {
                graph.Nodes[count] = currentNode;
            }

            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                continue;
            }

            IEnumerable<int> numbers = input
                .Split()
                .Select(s => int.Parse(s));

            foreach (var number in numbers)
            {
                Node neighbour;

                if (graph.Nodes[number] == null)
                {
                    neighbour = new Node(number);
                    graph.Nodes[number] = neighbour;
                }
                else
                {
                    neighbour = graph.Nodes[number];
                }


                if (!currentNode.NeighbourIndexes.Contains(neighbour.Value))
                {
                    currentNode.NeighbourIndexes.Add(neighbour.Value);
                }

                if (!neighbour.NeighbourIndexes.Contains(currentNode.Value))
                {
                    neighbour.NeighbourIndexes.Add(currentNode.Value);
                }
            }
        }

        for (int index = 0; index < visitedNodes.Length; index++)
        {
            if (!visitedNodes[index])
            {
                Console.Write("Connected component:");
                PrintConnectedComponents(index);
                Console.WriteLine();
            }
        }
    }

    static void PrintConnectedComponents(int nodeIndex)
    {
        if (visitedNodes[nodeIndex])
        {
            return;
        }

        Node currentNode = graph.Nodes[nodeIndex];
        visitedNodes[nodeIndex] = true;

        foreach (var neighbourIndex in currentNode.NeighbourIndexes)
        {
            PrintConnectedComponents(neighbourIndex);
        }

        Console.Write(" {0}", currentNode.Value);
    }
}
