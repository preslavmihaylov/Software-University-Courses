
using System;

class LinkedListExample
{
    static void Main()
    {
        LinkedList<int> linkedList = new LinkedList<int>();
        linkedList.Add(5);
        linkedList.Add(10);

        Console.WriteLine(linkedList.Head.Value);
        Console.WriteLine(linkedList.Head.NextNode.Value);
        linkedList.Remove(1);

        Console.WriteLine(linkedList.Head.Value);
        Console.WriteLine(linkedList.Count);

        linkedList.Remove(0);
        Console.WriteLine(linkedList.Count);

        linkedList.Add(1);
        linkedList.Add(2);
        linkedList.Add(3);
        linkedList.Add(4);
        linkedList.Add(5);
        linkedList.Add(1);
        Console.WriteLine(linkedList.FirstIndexOf(1));
        Console.WriteLine(linkedList.FirstIndexOf(20));
        Console.WriteLine(linkedList.LastIndexOf(1));
        Console.WriteLine(linkedList.LastIndexOf(20));

        Console.WriteLine();
        Console.WriteLine("Foreached: ");
        foreach (int value in linkedList)
        {
            Console.WriteLine(value);
        }

        Console.WriteLine();
        Console.WriteLine("Indexes: ");
        Console.WriteLine(linkedList[0]);
        Console.WriteLine(linkedList[1]);
        Console.WriteLine(linkedList[2]);
        Console.WriteLine(linkedList[3]);
        Console.WriteLine(linkedList[4]);
        Console.WriteLine(linkedList[5]);
        // Console.WriteLine(linkedList[6]); // Exception

        Console.WriteLine("Changing the values");
        linkedList[0] = 20;
        linkedList[1] = 30;
        Console.WriteLine(linkedList[0]);
        Console.WriteLine(linkedList[1]);
    }
}