using System;
using System.Collections.Generic;

class JoinLists
{
    static void Main()
    {
        string[] input1 = Console.ReadLine().Split();
        string[] input2 = Console.ReadLine().Split();

        List<int> list1 = new List<int>();
        List<int> list2 = new List<int>();

        for (int index = 0; index < input1.Length; index++)
        {
            if (!list1.Contains(Convert.ToInt32(Convert.ToString(input1[index]))))
            {
                list1.Add(Convert.ToInt32(Convert.ToString(input1[index])));
            }
        }

        for (int index = 0; index < input2.Length; index++)
        {
            list2.Add(Convert.ToInt32(Convert.ToString(input2[index])));
        }

        foreach (var item in list2)
        {
            if (!list1.Contains(item))
            {
                list1.Add(item);
            }
        }

        Console.WriteLine();
        Console.WriteLine("Result:");
        list1.Sort();
        foreach (var item in list1)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}
