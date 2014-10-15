using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BiggestTriple
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();

        List<List<int>> triples = new List<List<int>>();

        int count = 0;
        int listCount = 0;
        triples.Add(new List<int>());

        for (int index = 0; index < input.Length; index++)
        {
            if (count != 3)
            {
                triples[listCount].Add(Convert.ToInt32(Convert.ToString(input[index])));
                count++;
            }
            else
            {
                count = 0;
                listCount++;
                triples.Add(new List<int>());
                index--;
            }
        }

        int biggestTriple = 0;
        int biggestSum = int.MinValue;

        for (int index = 0; index < triples.Count; index++)
        {
            if (triples[index].Sum() > biggestSum)
            {
                biggestTriple = index;
                biggestSum = triples[index].Sum();
            }
        }

        for (int index = 0; index < triples[biggestTriple].Count; index++)
        {
            Console.Write(triples[biggestTriple][index] + " ");
        }
    }
}
