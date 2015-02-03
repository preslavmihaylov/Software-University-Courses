using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Recursive solution for this problem. 
// If you want to know more about recursions - http://www.introprogramming.info/intro-csharp-book/read-online/glava10-rekursia/
// a deeper look into this solution here - https://mihayloff14.wordpress.com/2014/06/30/zero-subset-problem/
// modified the task a little. The input can be more or less than 5 numbers and on one line.
// Furthermore, the condition (0 + 0 + 0 + 0 + 0 = 0) is wrong and therefore, I have not completed it.

class ZeroSubset
{
    static int numberOfLoops;
    static int countOfNumbers;
    static int[] loops;
    static int[] numbers;
    static bool resultFound = false;

    static void Main()
    {
        Console.Write("Enter numbers:");
        string[] input = Console.ReadLine().Split();

        countOfNumbers = input.Length;
        numberOfLoops = countOfNumbers;
        numbers = new int[countOfNumbers];

        for (int index = 0; index < input.Length; index++)
        {
            numbers[index] = Convert.ToInt32(input[index]);
        }

        while (numberOfLoops > 1)
        {
           loops = new int[numberOfLoops];
           FindSubsets(0, 0);
           numberOfLoops--;
        }

        if (resultFound == false)
        {
            Console.WriteLine("no zero subsets");
        }
    }

    static void FindSubsets(int currentLoop, int lastNumber)
    {
        if (currentLoop == numberOfLoops)
        {
            if (loops.Sum() == 0)
            {
                PrintNumbers();
            }
            return;
        }

        for (int nextNumber = lastNumber; nextNumber < countOfNumbers; nextNumber++)
        {
            loops[currentLoop] = numbers[nextNumber];
            FindSubsets(currentLoop + 1, nextNumber + 1);
        }
    }

    static void PrintNumbers()
    {
        resultFound = true;
        Console.Write(loops[0]);
        for (int index = 1; index < loops.Length; index++)
        {
            Console.Write(" + {0}", loops[index]);
        }
        Console.Write(" = 0");
        Console.WriteLine();
    }
}
