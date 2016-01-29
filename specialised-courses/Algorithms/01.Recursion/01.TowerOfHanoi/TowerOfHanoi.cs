namespace _01.TowerOfHanoi
{
    using System;
    using System.Collections.Generic;

    class TowerOfHanoi
    {
        private static Stack<int> source = new Stack<int>();
        private static Stack<int> destination = new Stack<int>();
        private static Stack<int> spare = new Stack<int>();

        private static ulong stepsTaken = 0;

        static void Main()
        {
            int bottomDisk = Setup();
            MoveDisk(bottomDisk, source, destination, spare);
            Print(bottomDisk);
        }

        static int Setup()
        {
            int diskNum = int.Parse(Console.ReadLine());

            for (int count = diskNum; count >= 1; count--)
            {
                source.Push(count);
            }

            return diskNum;
        }

        static void MoveDisk(int bottomDisk, Stack<int> source, Stack<int> destination, Stack<int> spare)
        {
            if (bottomDisk == 1)
            {
                destination.Push(source.Pop());
                stepsTaken++;
            }
            else
            {
                MoveDisk(bottomDisk - 1, source, spare, destination);
                destination.Push(source.Pop());
                stepsTaken++;
                MoveDisk(bottomDisk - 1, spare, destination, source);
            }
        }

        static void Print(int diskCount)
        {
            Console.WriteLine("Source:");
            Console.Write(new string('|', source.Count));
            Console.Write(new string('-', diskCount - source.Count));
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Destination:");
            Console.Write(new string('|', destination.Count));
            Console.Write(new string('-', diskCount - destination.Count));
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Spare:");
            Console.Write(new string('|', spare.Count));
            Console.Write(new string('-', diskCount - spare.Count));
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Steps taken: {0}", stepsTaken);
        }
    }
}