using System;
using System.Collections.Generic;
using System.Linq;

/* A very unoptimised solution. It works, but it takes an awful amount of time. */
class Sorting
{
    class SequenceNode
    {
        public SequenceNode(int[] sequence, int iterationCount)
        {
            this.Sequence = sequence;
            this.IterationCount = iterationCount;
        }

        public int[] Sequence { get; set; }
        public int IterationCount { get; set; }
    }

    private static int[] sequence;
    private static int consecutiveElements;

    static void Main()
    {
        ReadInput();

        int requiredOperations = RequiredOperationsForSorting();

        Console.WriteLine("Required Operations: " + requiredOperations);
    }

    private static int RequiredOperationsForSorting()
    {
        Queue<SequenceNode> operationQueue = new Queue<SequenceNode>();
        List<SequenceNode> usedSequences = new List<SequenceNode>();

        operationQueue.Enqueue(new SequenceNode(sequence, 0));
        usedSequences.Add(new SequenceNode(sequence, 0));

        int operationsCount = -1;
        int usedSequencesCount = 0;
        while (operationQueue.Count > 0)
        {
            SequenceNode currentNode = operationQueue.Dequeue();
            int[] currentSequence = currentNode.Sequence;
            operationsCount++;

            if (IsSorted(currentSequence))
            {
                return currentNode.IterationCount;
            }

            for (int index = 0; index <= currentSequence.Length - consecutiveElements; index++)
            {
                int[] newSequence = new int[currentSequence.Length];
                Array.Copy(currentSequence, newSequence, currentSequence.Length);

                ReverseElements(newSequence, index, index + (consecutiveElements - 1));

                if (!usedSequences.Where(s => Enumerable.SequenceEqual(s.Sequence, newSequence)).Any())
                {
                    operationQueue.Enqueue(new SequenceNode(newSequence, currentNode.IterationCount + 1));
                    usedSequences.Add(new SequenceNode(newSequence, currentNode.IterationCount + 1));
                }
            }

        }

        return -1;
    }

    private static bool IsSorted(int[] array)
    {
        for (int index = 1; index < array.Length; index++)
        {
            if (array[index] < array[index - 1])
            {
                return false;
            }
        }

        return true;
    }

    private static void ReverseElements(int[] array, int start, int end)
    {
        for (int index = start; index <= (end + start) / 2; index++)
        {
            int temp = array[index];
            array[index] = array[end - (index - start)];
            array[end - (index - start)] = temp;
        }
    }

    private static void ReadInput()
    {
        int inputCount = int.Parse(Console.ReadLine());
        string[] inputNumbers = Console.ReadLine().Split(' ');
        consecutiveElements = int.Parse(Console.ReadLine());

        sequence = new int[inputCount];
        for (int count = 0; count < inputNumbers.Length; count++)
        {
            sequence[count] = int.Parse(inputNumbers[count]);
        }
    }
}