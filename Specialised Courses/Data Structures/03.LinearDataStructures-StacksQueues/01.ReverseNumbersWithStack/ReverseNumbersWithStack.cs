using System;
using System.Collections.Generic;
using System.Linq;

class ReverseNumbersWithStack
{
    static void Main()
    {
        Stack<int> stack = new Stack<int>();

        string[] input = Console.ReadLine().Split(' ');

        if (string.IsNullOrEmpty(input.FirstOrDefault()))
        {
            Console.WriteLine("(empty)");
            return;
        }

        for (int index = 0; index < input.Length; index++)
        {
            stack.Push(int.Parse(input[index]));
        }

        while (stack.Count > 0)
        {
            Console.WriteLine(stack.Pop());
        }
    }
}