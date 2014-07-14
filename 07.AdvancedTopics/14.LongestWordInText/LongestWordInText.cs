using System;

class LongestWordInText
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();

        string longestWord = "";

        foreach (var item in input)
        {
            if (longestWord.Length < item.Length)
            {
                longestWord = item;
            } 
        }
        Console.WriteLine("Longest Word: {0}", longestWord);
    }
}
