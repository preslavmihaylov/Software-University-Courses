namespace _01.AA_Tree
{
    using System;

    class AATreeExample
    {
        static void Main()
        {
            InsertDeleteExample();
            SearchExample();
            return;
        }

        static void InsertDeleteExample()
        {
            var tree = new AATree<int>();
            tree.Add(4);
            tree.Add(10);
            tree.Add(2);
            tree.Add(6);
            tree.Add(12);
            tree.Add(3);
            tree.Add(1);
            tree.Add(8);
            tree.Add(13);
            tree.Add(11);
            tree.Add(5);
            tree.Add(9);
            tree.Add(7);

            tree.Remove(1);
            tree.Print();

            tree.Remove(5);
            Console.WriteLine(new string('-', 40));
            tree.Print();
        }

        static void SearchExample()
        {
            var tree = new AATree<int>();
            tree.Add(4);
            tree.Add(10);
            tree.Add(2);
            tree.Add(6);
            tree.Add(12);
            tree.Add(3);
            tree.Add(1);
            tree.Add(8);
            tree.Add(13);
            tree.Add(11);
            tree.Add(5);
            tree.Add(9);
            tree.Add(7);

            Console.WriteLine("All results should be true");
            Console.WriteLine(tree.Find(4));
            Console.WriteLine(!tree.Find(-5));
            Console.WriteLine(!tree.Find(100));
            Console.WriteLine(!tree.Find(15));
            Console.WriteLine(tree.Find(13));
            Console.WriteLine(tree.Find(7));
        }
    }
}