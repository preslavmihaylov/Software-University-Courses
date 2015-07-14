
using System;
using System.Collections.Generic;

class SequenceNM
{
    static void Main()
    {
        int start = int.Parse(Console.ReadLine());
        int goal = int.Parse(Console.ReadLine());

        Queue<Item> queue = new Queue<Item>();
        queue.Enqueue(new Item(start));
        bool solutionFound = false;

        while (queue.Count > 0)
        {
            Item currentItem = queue.Dequeue();
            if (currentItem.Value < goal)
            {
                queue.Enqueue(new Item(currentItem.Value + 1, currentItem));
                queue.Enqueue(new Item(currentItem.Value + 2, currentItem));
                queue.Enqueue(new Item(currentItem.Value * 2, currentItem));
            }
            else if (currentItem.Value == goal)
            {
                PrintSequence(currentItem);
                solutionFound = true;
                break;
            }
        }

        if (!solutionFound)
        {
            Console.WriteLine("No solution");
        }
    }

    static void PrintSequence(Item inputItem)
    {
        Stack<int> resultStack = new Stack<int>();
        Item currentItem = inputItem;

        while (currentItem != null)
        {
            resultStack.Push(currentItem.Value);

            currentItem = currentItem.PreviousItem;
        }

        while (resultStack.Count > 0)
        {
            if (resultStack.Count == 1)
            {
                Console.Write(resultStack.Pop());
            }
            else
            {
                Console.Write(resultStack.Pop() + " --> ");
            }
        }

        Console.WriteLine();
    }
}