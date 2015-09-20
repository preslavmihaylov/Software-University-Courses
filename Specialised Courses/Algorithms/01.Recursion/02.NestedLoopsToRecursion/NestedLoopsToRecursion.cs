namespace _02.NestedLoopsToRecursion
{
    using System;

    class NestedLoopsToRecursion
    {
        private static int[] numbers;

        static void Main()
        {
            Setup();
            SimulateNestedLoops(0);
        }

        static void Setup()
        {
            int numCount = int.Parse(Console.ReadLine());
            numbers = new int[numCount];
        }

        static void SimulateNestedLoops(int currentNumber)
        {
            if (currentNumber >= numbers.Length)
            {
                Print();
                return;
            }

            for (int count = 0; count < numbers.Length; count++)
            {
                numbers[currentNumber] = count + 1;
                SimulateNestedLoops(currentNumber + 1);
            }
        }

        static void Print()
        {
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}