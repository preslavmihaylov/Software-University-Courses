using System;
using System.Collections.Generic;

class Sorting
{
    class SequenceNode
    {
        public SequenceNode(string sequence, int iterationCount)
        {
            this.Sequence = sequence;
            this.IterationCount = iterationCount;
        }

        public string Sequence { get; set; }
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
        HashSet<string> usedSequences = new HashSet<string>();

        string sequenceAsString = string.Join("-", sequence);

        operationQueue.Enqueue(new SequenceNode(sequenceAsString, 0));
        usedSequences.Add(sequenceAsString);

        int operationsCount = -1;
        int usedSequencesCount = 0;
        while (operationQueue.Count > 0)
        {
            SequenceNode currentNode = operationQueue.Dequeue();
            string[] currentSequence = currentNode.Sequence.Split('-');
            operationsCount++;

            if (IsSorted(currentSequence))
            {
                return currentNode.IterationCount;
            }

            for (int index = 0; index <= currentSequence.Length - consecutiveElements; index++)
            {
                string[] newSequence = new string[currentSequence.Length];
                Array.Copy(currentSequence, newSequence, currentSequence.Length);

                ReverseElements(newSequence, index, index + (consecutiveElements - 1));
                sequenceAsString = string.Join("-", newSequence);

                if (!usedSequences.Contains(sequenceAsString))
                {
                    operationQueue.Enqueue(new SequenceNode(sequenceAsString, currentNode.IterationCount + 1));
                    usedSequences.Add(sequenceAsString);
                }
            }

        }

        return -1;
    }

    private static bool IsSorted(string[] array)
    {
        for (int index = 1; index < array.Length; index++)
        {
            if (array[index].CompareTo(array[index - 1]) < 0)
            {
                return false;
            }
        }

        return true;
    }

    private static void ReverseElements(string[] array, int start, int end)
    {
        for (int index = start; index <= (end + start) / 2; index++)
        {
            string temp = array[index];
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