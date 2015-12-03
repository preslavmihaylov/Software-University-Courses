using System;
using System.Collections.Generic;

class Sorting
{
    private const int ResultNotFound = -1;

    private static HashSet<string> duplicates = new HashSet<string>();

    private static string expectedResult;
    private static string initialNumbers;
    private static int reverseCount;

    static void Main()
    {
        ProcessInput();
        FindMinOperationsToPerform();
    }

    static void FindMinOperationsToPerform()
    {
        string[] currentNumbers;
        string currentResult;

        Queue<Operation> operationQueue = new Queue<Operation>();
        Operation initial = new Operation()
        {
            Numbers = initialNumbers,
            Steps = 0
        };

        operationQueue.Enqueue(initial);
        duplicates.Add(initialNumbers);

        while (operationQueue.Count > 0)
        {
            Operation currentOperation = operationQueue.Dequeue();

            if (IsSolution(currentOperation.Numbers))
            {
                PrintResult(currentOperation.Steps);
                return;
            }

            currentNumbers = currentOperation.Numbers.Split(' ');

            for (int cnt = 0; cnt <= currentNumbers.Length - reverseCount; cnt++)
            {
                ReverseNumbers(currentNumbers, cnt, cnt + reverseCount - 1);
                currentResult = string.Join(" ", currentNumbers);

                if (!duplicates.Contains(currentResult))
                {
                    duplicates.Add(currentResult);
                    operationQueue.Enqueue(new Operation()
                    {
                        Numbers = currentResult,
                        Steps = currentOperation.Steps + 1
                    });
                }

                ReverseNumbers(currentNumbers, cnt, cnt + reverseCount - 1);
            }
        }

        PrintResult(ResultNotFound);
    }

    static bool IsSolution(string numbers)
    {
        return numbers == expectedResult;
    }

    static void ReverseNumbers(string[] numbers, int start, int end)
    {
        string temp;
        int backIndex = end;

        for (int index = start; index <= (start + end) / 2; index++)
        {
            if (numbers[index] != numbers[backIndex])
            {
                temp = numbers[index];
                numbers[index] = numbers[backIndex];
                numbers[backIndex] = temp;
            }

            --backIndex;
        }
    }

    static void PrintResult(int result)
    {
        Console.WriteLine(result);
    }

    static void ProcessInput()
    {
        Console.ReadLine(); // Skip unnecessary line
        initialNumbers = Console.ReadLine();
        reverseCount = int.Parse(Console.ReadLine());

        string[] numbers = initialNumbers.Split(' ');

        Array.Sort(numbers);
        expectedResult = string.Join(" ", numbers);
    }
}

class Operation
{
    public string Numbers { get; set; }

    public int Steps { get; set; }
}