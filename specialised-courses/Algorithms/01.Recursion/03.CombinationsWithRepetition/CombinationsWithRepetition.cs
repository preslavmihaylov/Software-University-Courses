namespace _03.CombinationsWithRepetition
{
    using System;

    class CombinationsWithRepetition
    {
        private static int[] loop;
        private static int numbersCount;

        private static void Main()
        {
            Setup();
            GenerateCombinations(0, 0);
        }

        private static void Setup()
        {
            int inputNumbersCount = int.Parse(Console.ReadLine());
            int inputCombinationsCount = int.Parse(Console.ReadLine());

            loop = new int[inputCombinationsCount];
            numbersCount = inputNumbersCount;
        }

        private static void GenerateCombinations(int currentNumber, int currentCombination)
        {
            if (currentCombination >= loop.Length)
            {
                Print();
                return;
            }

            for (int count = currentNumber; count < numbersCount; count++)
            {
                loop[currentCombination] = count + 1;
                GenerateCombinations(count, currentCombination + 1);
            }
        }

        private static void Print()
        {
            Console.WriteLine("({0})", string.Join(" ", loop));
        }
    }
}