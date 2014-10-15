using System;
using System.Text.RegularExpressions;

class ExtractURLfromText
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        Console.WriteLine();
        foreach (var item in input)
        {
            Match httpMatch = Regex.Match(item, "http.*");
            Match wwwMatch = Regex.Match(item, "www.*");
            if (httpMatch.Success || wwwMatch.Success)
            {
                Console.WriteLine(item);
            }
        }
    }
}
