namespace _04.OrderedSet
{
    using System;

    class OrderedSetExample
    {
        static void Main()
        {
            OrderedSet<int> set = new OrderedSet<int>();
            set.Add(20);
            set.Add(25);
            set.Add(24);
            set.Add(23);
            set.Add(22);
            set.Remove(25);
            foreach (var i in set)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("Count : " + set.Count);
            Console.WriteLine();

            set = new OrderedSet<int>();

            set.Add(20);
            set.Add(15);
            set.Add(3);
            set.Add(4);
            set.Add(25);
            set.Add(30);
            set.Add(27);

            foreach (var element in set)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine("Count : " + set.Count);

            set.Remove(25);

            Console.WriteLine();
            foreach (var element in set)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine("Count : " + set.Count);

            set.Remove(20);

            Console.WriteLine();
            foreach (var element in set)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine("Count : " + set.Count);

            set.Remove(27);

            Console.WriteLine();
            foreach (var element in set)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine("Count : " + set.Count);
        }
    }
}
