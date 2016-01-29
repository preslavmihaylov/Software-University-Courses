using System;
using System.Collections.Generic;
using System.Text;

class MessagesInBottle
{
    const char InvalidCharacter = '\0';

    static string message;
    static char[] sequence;
    static List<string> output = new List<string>();
    static Dictionary<string, char> cipher = new Dictionary<string, char>();

    static int totalSequencesCount = 0;

    static void Main()
    {
        ProcessInput();
        FindPossibleCiphers(0, message.Length - 1, 0);
        PrintOutput();
    }

    static void FindPossibleCiphers(int start, int end, int sequenceIndex)
    {
        if (start > end || end >= message.Length)
        {
            StoreSequence(sequenceIndex);
            return;
        }

        for (int cnt = start; cnt <= end; cnt++)
        {
            string currentSubsequence = message.Substring(start, cnt - start + 1);
            if (cipher.ContainsKey(currentSubsequence))
            {
                sequence[sequenceIndex] = cipher[currentSubsequence];
                FindPossibleCiphers(cnt + 1, end, sequenceIndex + 1);
            }
        }
    }

    static void StoreSequence(int sequenceCount)
    {
        ++totalSequencesCount;
        StringBuilder currentSequence = new StringBuilder();
        for (int index = 0; index < sequenceCount; index++)
        {
            currentSequence.Append(sequence[index]);
        }

        output.Add(currentSequence.ToString());
    }

    static void PrintOutput()
    {
        Console.WriteLine(totalSequencesCount);
        output.Sort();
        Console.WriteLine(string.Join(Environment.NewLine, output));
    }

    static void ProcessInput()
    {
        message = Console.ReadLine();
        sequence = new char[message.Length];

        StringBuilder builder = new StringBuilder();
        char currentChar = InvalidCharacter;

        string inputCipher = Console.ReadLine();

        for (int index = 0; index < inputCipher.Length; index++)
        {
            if (inputCipher[index] >= 'A' && inputCipher[index] <= 'Z')
            {
                if (currentChar != InvalidCharacter)
                {
                    cipher[builder.ToString()] = currentChar;
                }

                currentChar = inputCipher[index];
                builder.Clear();
            }
            else
            {
                builder.Append(inputCipher[index]);
            }
        }

        if (builder.Length > 0 && currentChar != InvalidCharacter)
        {
            cipher[builder.ToString()] = currentChar;
        }
    }
}