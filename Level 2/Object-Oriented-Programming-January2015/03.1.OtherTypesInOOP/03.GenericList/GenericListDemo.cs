using System;

class GenericListDemo
{
    static void Main()
    {
        GenericList<int> nums = new GenericList<int>() { 1, 2, 5, 7 };
        Console.WriteLine("All elements: " + nums.ToString());

        Console.WriteLine("Num at index 1: " + nums[1]);
        nums.Remove(0);
        Console.WriteLine("Element at index 0 has been removed");
        Console.WriteLine("Num at index 1: " + nums[1]);
        Console.WriteLine("The index of 5 is: " + nums.Find(5));
        Console.WriteLine("Nums contains 7? " + nums.Contains(7));
        for (int index = 0; index < 50; index++)
        {
            nums.Add(9);
            Console.Write("Element added: " + nums[nums.Count - 1]);
            Console.WriteLine(" Count: " + nums.Count + " Capacity: " + nums.Capacity);
        }
        nums.Insert(14, 0);
        nums.Insert(14, 0);
        nums.Insert(14, 0);
        nums.Insert(20, 20);
        Console.WriteLine(nums);
        Console.WriteLine("Min: " + nums.Min());
        Console.WriteLine("Max: " + nums.Max());

        Console.WriteLine("The version of this class is: " + nums.Version());
    }
}
