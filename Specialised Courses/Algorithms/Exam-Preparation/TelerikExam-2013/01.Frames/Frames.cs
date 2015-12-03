using System;
using System.Collections.Generic;

class Frames
{
    static Frame[] frames;
    static Frame[] sequence;
    static List<string> output = new List<string>();
    static bool[] used;

    static HashSet<string> duplicates = new HashSet<string>();

    static int sequencesCount;

    static void Main()
    {
        ProcessInput();
        GenerateVariations(0);
        PrintOutput();
    }

    static void GenerateVariations(int currentIndex)
    {
        if (currentIndex >= frames.Length)
        {
            StoreFrames();
            return;
        }

        for (int index = 0; index < frames.Length; index++)
        {
            if (!used[index])
            {
                used[index] = true;
                sequence[currentIndex] = frames[index];

                GenerateVariations(currentIndex + 1);

                if (sequence[currentIndex].Left != sequence[currentIndex].Right)
                {
                    int temp = sequence[currentIndex].Left;
                    sequence[currentIndex].Left = sequence[currentIndex].Right;
                    sequence[currentIndex].Right = temp;

                    GenerateVariations(currentIndex + 1);

                    temp = sequence[currentIndex].Left;
                    sequence[currentIndex].Left = sequence[currentIndex].Right;
                    sequence[currentIndex].Right = temp;
                }

                used[index] = false;
            }
        }
    }
    
    static void ProcessInput()
    {
        string[] input;
        int framesCount = int.Parse(Console.ReadLine());
        frames = new Frame[framesCount];
        sequence = new Frame[framesCount];
        used = new bool[framesCount];

        for (int cnt = 0; cnt < framesCount; cnt++)
        {
            input = Console.ReadLine().Split(' ');
            frames[cnt] = new Frame();
            frames[cnt].Left = int.Parse(input[0]);
            frames[cnt].Right = int.Parse(input[1]);
        }
    }

    static void StoreFrames()
    {
        string currentSequence = string.Join(" | ", (object[])sequence);

        if (!duplicates.Contains(currentSequence))
        {
            ++sequencesCount;
            output.Add(currentSequence);
            duplicates.Add(currentSequence);
        }
    }

    static void PrintOutput()
    {
        Console.WriteLine(sequencesCount);

        output.Sort();
        Console.WriteLine(string.Join(Environment.NewLine, output));
    }
}

class Frame
{
    public int Left { get; set; }

    public int Right { get; set; }

    public override string ToString()
    {
        return string.Format("({0}, {1})", this.Left, this.Right);
    }
}