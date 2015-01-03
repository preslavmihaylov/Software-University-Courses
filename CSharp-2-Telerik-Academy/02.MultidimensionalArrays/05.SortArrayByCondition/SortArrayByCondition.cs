using System;
class SortArrayByCondition
{
    static void Main()
    {
        Console.Write("Input strings to be sorted: ");
        string[] array = Console.ReadLine().Split();

        Array.Sort(array, (a, b) => (a.Length).CompareTo(b.Length));
        Console.WriteLine(new string('-', 20));
        Console.WriteLine(String.Join(", ", array));
    }
}