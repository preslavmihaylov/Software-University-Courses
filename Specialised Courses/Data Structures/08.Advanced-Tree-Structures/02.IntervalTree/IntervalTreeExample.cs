namespace _02.IntervalTree
{
    using System;

    class IntervalTreeExample
    {
        static void Main()
        {
            IntervalTree tree = new IntervalTree();

            tree.Add(new Interval(20, true, 40, true));
            tree.Add(new Interval(15, true, 25, true));
            tree.Add(new Interval(10, true, 35, true));
            tree.Add(new Interval(5, true, 30, true));

            tree.Print();
            Console.WriteLine();

            Interval result = tree.FindOverlappingInterval(new Interval(26, true, 80, true));
            Console.WriteLine(result);
        }
    }
}