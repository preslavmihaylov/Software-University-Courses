using System;
class LettersOfAlphabet
{
    static void Main()
    {
        char[] alphabet = new char[26];

        int count = 0;
        for (int index = 0; index < alphabet.Length; index++)
        {
            alphabet[index] = (char)('a' + count);
            count++;
        }
        // 97 122

        Console.Write("Enter a word: ");
        string word = Console.ReadLine();

        for (int index = 0; index < word.Length; index++)
        {
            Console.Write(word[index] + " : ");
            binarySearch(0, alphabet.Length - 1, alphabet, (int)word[index]);
        }


    }

    private static void binarySearch(int start, int end, char[] array, int numToFind)
    {
        if (start == end)
        {
            if (array[start] == numToFind)
            {
                Console.WriteLine(start);
                return;
            }
            else
            {
                Console.WriteLine(-1);
                return;
            }
        }
        else
        {
            int middle = (start + end) / 2;
            if (array[middle] < numToFind)
            {
                binarySearch(middle + 1, end, array, numToFind);
            }
            else if (array[middle] > numToFind)
            {
                binarySearch(start, middle - 1, array, numToFind);
            }
            else
            {
                Console.WriteLine(middle);
                return;
            }
        }
    }
}
