using System;
class CompareCharArrays
{
    static void Main()
    {
        char[] first = { 'P', 'e', 's', 'h', 'o' };
        char[] second = { 'G', 'o', 's', 'h', 'o' };

        compareCharArrays(first, second);
    }

    private static void compareCharArrays(char[] first, char[] second)
    {
        for (int index = 0; index < Math.Min(first.Length, second.Length); index++)
        {
            if (first[index] != second[index])
            {
                Console.WriteLine("The arrays are not equal");
                return;
            }
        }

        Console.WriteLine("The arrays are equal");
        return;
    }
}
