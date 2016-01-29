
using System;

class ReversedListExample
{
    static void Main()
    {
        ReversedList<int> collection = new ReversedList<int>();
        collection.Add(1);
        collection.Add(2);
        collection.Add(3);
        collection.Add(4);
        collection.Add(5);

        collection.Remove(0);
        Console.WriteLine(collection.Count);
        Console.WriteLine(collection.Capacity);
        Console.WriteLine(string.Join(", ", collection));
    }
}