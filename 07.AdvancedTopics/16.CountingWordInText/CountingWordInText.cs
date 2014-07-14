using System;
using System.Text.RegularExpressions;

class CountingWordInText
{
    static int test = 0;
    static void Main()
    {
        string wordToCount = Console.ReadLine();
        
        // there may be more symbols... If you know an easier method to do this, I would be grateful for a hint.
        string[] input = Console.ReadLine().Split(' ', ',', '.', '/', '\\', '@', '/', '(', ')', '"', '#', '!', '$', '%');

        int count = 0;
        test = 2;

        // note that the second example will not be valid since there is a limit to the amount of text input in a console
        foreach (var item in input)
        {
            Match wordFound = Regex.Match(item, "\\b" + wordToCount + "\\b", RegexOptions.IgnoreCase);
            if (wordFound.Success)
            {
                count++;
            }
        }
        Console.WriteLine("Output: {0}", count);
    }
}
