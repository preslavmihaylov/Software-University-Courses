using System;
using System.Collections.Generic;

class Vertex
{
    public char Character { get; set; }

    public List<int> Children { get; set; }

    public int ParentsCount { get; set; }
}

class RecoverMessage
{
    const int InvalidValue = -1;
    const int SmallLettersOffset = ('Z' - 'A') + 1;
    const int TotalLettersCount = 2 * SmallLettersOffset;

    // first half of array is for the capital letters and the second half is for the small ones
    static int[] lettersOccurences = new int[TotalLettersCount];
    static List<Vertex> vertices = new List<Vertex>();

    static bool[] usedLetters = new bool[TotalLettersCount];
    static int usedLettersCount;

    static void Main()
    {
        ProcessInput();
        // PrintGraph();
        FindShortestPossibleMessage();
    }

    // Implementing topological sorting
    static void FindShortestPossibleMessage()
    {
        while (usedLettersCount < vertices.Count)
        {
            int smallestIndex = InvalidValue;
            int smallestCharValue = 'z' + 1;

            for (int index = 0; index < vertices.Count; index++)
            {
                int charIndex = GetCharIndex(vertices[index].Character);
                if (vertices[index].ParentsCount == 0 && !usedLetters[charIndex])
                {
                    if (vertices[index].Character < smallestCharValue)
                    {
                        smallestCharValue = vertices[index].Character;
                        smallestIndex = index;
                    }
                }
            }

            if (smallestIndex != InvalidValue)
            {
                Console.Write((char)smallestCharValue);

                Vertex vertex = vertices[smallestIndex];

                int charIndex = GetCharIndex(vertex.Character);
                usedLetters[charIndex] = true;
                ++usedLettersCount;

                foreach (var childIndex in vertex.Children)
                {
                    --vertices[childIndex].ParentsCount;
                }
            }
            else
            {
                return;
            }
        }

        Console.WriteLine();
    }

    static void ProcessInput()
    {
        InitialiseData();

        int messagesCount = int.Parse(Console.ReadLine());
        string input;

        for (int cnt = 0; cnt < messagesCount; cnt++)
        {
            input = Console.ReadLine();

            for (int ch = 0; ch < input.Length; ch++)
            {
                int index = GetCharIndex(input[ch]);
                int parentIndex = InvalidValue;

                if (ch - 1 >= 0)
                {
                    parentIndex = GetCharIndex(input[ch - 1]);
                }
                
                Vertex vertex;
                if (lettersOccurences[index] == InvalidValue)
                {
                    vertex = new Vertex()
                    {
                        Character = input[ch],
                        Children = new List<int>(),
                        ParentsCount = 0
                    };

                    vertices.Add(vertex);
                    lettersOccurences[index] = vertices.Count - 1;
                }
                else
                {
                    vertex = vertices[lettersOccurences[index]];
                }

                if (parentIndex != InvalidValue)
                {
                    Vertex parentVertex = vertices[lettersOccurences[parentIndex]];
                    parentVertex.Children.Add(lettersOccurences[index]);
                    ++vertex.ParentsCount;
                }
            }
        }
    }

    static int GetCharIndex(char ch)
    {
        int index;
        if (IsSmallLetter(ch))
        {
            index = (ch - 'a') + SmallLettersOffset;
        }
        else
        {
            index = ch - 'A';
        }

        return index;
    }

    static bool IsSmallLetter(char ch)
    {
        return ch >= 'a' && ch <= 'z';
    }

    // Used for debugging
    static void PrintGraph()
    {
        for (int cnt = 0; cnt < vertices.Count; cnt++)
        {
            Vertex vertex = vertices[cnt];


            Console.WriteLine("ParentsCnt: {0}, Character: {1}, Children: {2}",
                vertex.ParentsCount,
                vertex.Character,
                string.Join(", ", vertex.Children));
        }
    }

    static void InitialiseData()
    {
        for (int cnt = 0; cnt < lettersOccurences.Length; cnt++)
        {
            lettersOccurences[cnt] = InvalidValue;
        }
    }
}