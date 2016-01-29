using System;

class LinkedStackExample
{
    static void Main(string[] args)
    {

        LinkedStack<int> stack = new LinkedStack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        stack.Push(4);
        stack.Push(5);
        stack.Push(6);
        stack.Push(7);
        Console.WriteLine(stack.Count == 7);
        Console.WriteLine();
        while (stack.Count > 0)
        {
            Console.WriteLine(stack.Pop());
        }

        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        stack.Push(4);
        stack.Push(5);
        stack.Push(6);
        stack.Push(7);
        stack.Push(8);
        stack.Push(9);
        stack.Push(10);
        stack.Push(11);
        stack.Push(12);
        stack.Push(13);
        stack.Push(14);
        stack.Push(15);
        stack.Push(16);
        stack.Push(17);
        stack.Push(18);
        stack.Push(19);
        stack.Push(20);
        stack.Push(21);

        Console.WriteLine(string.Join(", ", stack.ToArray()));
        Console.WriteLine(stack.Count == 21);
        while (stack.Count > 0)
        {
            Console.WriteLine(stack.Pop());
        }
    }
}