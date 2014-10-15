using System;
using System.Collections.Generic;
using System.Linq;

class StudentCables
{
    static void Main()
    {
        int cablesCount = int.Parse(Console.ReadLine());
        List<int> cables = new List<int>();
        int numOfConnections = 0;

        for (int count = 0; count < cablesCount; count++)
        {
            int cableLength = int.Parse(Console.ReadLine());
            string cableMeasure = Console.ReadLine();

            if (cableMeasure == "meters")
            {
                cableLength *= 100;
            }

            if (cableLength >= 20)
            {
                cables.Add(cableLength);
                numOfConnections++;
            }
        }

        int result = cables.Sum() - (3 * (numOfConnections - 1));
        int remainings = result % 504;
        result = result / 504;

        Console.WriteLine(result);
        Console.WriteLine(remainings);
    }
}
