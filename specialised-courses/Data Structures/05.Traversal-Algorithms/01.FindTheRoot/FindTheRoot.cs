using System;

class FindTheRoot
{
    private static bool[] nodes;  

    static void Main()
    {
        int inputCount = int.Parse(Console.ReadLine());

        // Note that some of the examples are incorrect. 
        // It is given that the elements will be from 0 to N inclusive,
        // while that is not the case in the last two examples.
        nodes = new bool[inputCount + 1];

        for (int count = 0; count < inputCount; count++)
        {
            string[] currentLine = Console.ReadLine().Split(' ');
            int childValue = int.Parse(currentLine[1]);

            nodes[childValue] = true;
            
        }

        int rootsCount = 0;
        int rootValue = -1;

        for (int index = 0; index < nodes.Length; index++)
        {
            if (!nodes[index])
            {
                rootsCount++;
                rootValue = index;
            }
        }

        if (rootsCount == 0)
        {
            Console.WriteLine("No root!");
        }
        else if (rootsCount > 1)
        {
            Console.WriteLine("Forest is not a tree!");
        }
        else
        {
            Console.WriteLine("Root: " + rootValue);
        }
    }
}