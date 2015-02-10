using System;

class CustomTreeExample
{
    static void Main()
    {
        BinarySearchTree tree = new BinarySearchTree();
        tree.Add(2);
        tree.Add(5);
        tree.Add(10);
        tree.Add(6);
        tree.Add(4);
        tree.Add(15);

        tree.Delete(10);
        tree.Delete(15);
        Console.WriteLine(tree.Search(6));
        Console.WriteLine(tree.Search(10));

        foreach (var item in tree)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine(tree);

        BinarySearchTree secondTree = new BinarySearchTree();
        secondTree.Add(2);
        secondTree.Add(5);
        secondTree.Add(10);
        secondTree.Add(6);
        secondTree.Add(4);
        secondTree.Add(15);

        secondTree.Delete(10);
        secondTree.Delete(15);

        Console.WriteLine(tree.Equals(secondTree));
        Console.WriteLine(Object.ReferenceEquals(tree, secondTree));
        Console.WriteLine(tree.GetHashCode() == secondTree.GetHashCode());
        Console.WriteLine();

        BinarySearchTree clonedTree = (BinarySearchTree)tree.Clone();
        Console.WriteLine(tree.Equals(clonedTree));
        Console.WriteLine(Object.ReferenceEquals(tree, clonedTree));
    }
}