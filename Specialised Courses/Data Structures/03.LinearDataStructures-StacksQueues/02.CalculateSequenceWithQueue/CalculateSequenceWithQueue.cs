using System;
using System.Collections.Generic;

class CalculateSequenceWithQueue
{
    private const int TotalElementsCount = 50;

    static void Main()
    {
        int input = int.Parse(Console.ReadLine());

        Queue<int> queue = new Queue<int>();

        queue.Enqueue(input);

        for (int count = 0; count <= ( TotalElementsCount / 3 ) - 1; count++)
        {
            int currentElement = queue.Dequeue();
            Console.Write(currentElement + ", ");

            queue.Enqueue(currentElement + 1);
            queue.Enqueue( (currentElement * 2) + 1);
            queue.Enqueue(currentElement + 2);
        }

        while (queue.Count > 0)
        {
            Console.Write(queue.Dequeue() + ", ");
        }
    }
}