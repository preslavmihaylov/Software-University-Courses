using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

class GirlsGoneBad
{
    private const int SkirtsMaxCount = 31;

    private static SortedSet<char> skirts = new SortedSet<char>(); 
    private static bool[] takenShirts;
    private static int[] skirtsQuantity = new int[SkirtsMaxCount];

    private static int[] shirtsSequence;
    private static char[] skirtsSequence;

    private static int shirtsCount;
    private static int girlsCount;
    private static int variationsCount;

    private static StringBuilder output = new StringBuilder();

    static void Main()
    {
        ProcessInput();
        GeneratePossibleDressUps(0, 0);
        PrintOutput();
    }

    static void GeneratePossibleDressUps(int girlIndex, int shirtIndex)
    {
        if (girlIndex >= girlsCount)
        {
            StoreCurrentSequence();
            return;
        }

        for (int cnt = shirtIndex; cnt < shirtsCount; cnt++)
        {
            if (takenShirts[cnt])
            {
                continue;
            }

            takenShirts[cnt] = true;
            shirtsSequence[girlIndex] = cnt;

            foreach (var skirt in skirts)
            {
                if (skirtsQuantity[skirt - 'a'] > 0)
                {
                    skirtsSequence[girlIndex] = skirt;
                    --skirtsQuantity[skirt - 'a'];

                    GeneratePossibleDressUps(girlIndex + 1, cnt + 1);
                    ++skirtsQuantity[skirt - 'a'];
                }
            }

            takenShirts[cnt] = false;
        }
    }

    static void StoreCurrentSequence()
    {
        for (int index = 0; index < girlsCount; index++)
        {
            output.AppendFormat("{0}{1}", shirtsSequence[index], skirtsSequence[index]);
            if (index != girlsCount - 1)
            {
                output.Append("-");
            }
        }

        output.AppendLine();
        ++variationsCount;
    }

    static void PrintOutput()
    {
        Console.WriteLine(variationsCount);
        Console.Write(output.ToString());
    }

    static void ProcessInput()
    {
        shirtsCount = int.Parse(Console.ReadLine());
        takenShirts = new bool[shirtsCount];

        string inputSkirts = Console.ReadLine();
        girlsCount = int.Parse(Console.ReadLine());
        shirtsSequence = new int[girlsCount];
        skirtsSequence = new char[girlsCount];

        for (int index = 0; index < inputSkirts.Length; ++index)
        {
            skirts.Add(inputSkirts[index]);
            skirtsQuantity[inputSkirts[index] - 'a']++;
        }
    }
}