namespace _03.PriorityQueue
{
    using System;

    class PriorityQueueExample
    {
        static void Main()
        {
            PriorityQueue<int> queue = new PriorityQueue<int>(true);

            queue.Enqueue(20);
            queue.Enqueue(15);
            queue.Enqueue(40);
            queue.Enqueue(60);
            queue.Enqueue(50);
            queue.Enqueue(30);
            queue.Enqueue(25);
            queue.Enqueue(14);
            queue.Enqueue(7);
            queue.Enqueue(5);
            queue.Enqueue(4);
            queue.Enqueue(3);

            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }
        }
    }
}