using System;

class ProgrammerDNA
{
    static void Main()
    {
        int length = int.Parse(Console.ReadLine());
        string letter = Console.ReadLine();
        int currentChar = (int)Convert.ToChar(letter);
        // A = 65 ... G = 71

        int leftPart = 3;
        int rightPart = 3;
        bool backwards = false;

        for (int row = 0; row < length; row++)
        {
            if (row % 7 == 0)
            {
                leftPart = 3;
                rightPart = 3;
                backwards = false;
            }

            for (int col = 0; col < 7; col++)
            {
                if (col >= leftPart && col <= rightPart)
                {
                    Console.Write((char)currentChar);
                    currentChar++;
                    if (currentChar > 71)
                    {
                        currentChar = 65;
                    }
                }
                else
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
            if (!backwards)
            {
                leftPart--;
                rightPart++;
            }
            else
            {
                leftPart++;
                rightPart--;
            }

            if (leftPart == 0 || leftPart == 3)
            {
                backwards = !backwards;
            }
        }
    }
}
