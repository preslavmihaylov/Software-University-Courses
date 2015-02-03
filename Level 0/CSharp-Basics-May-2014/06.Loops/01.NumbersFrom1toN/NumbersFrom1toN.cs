using System;

    class NumbersFrom1toN
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            for (int index = 1; index <= number; index++)
            {
                Console.Write(index + " ");
            }
            Console.WriteLine();
        }
    }
