using System;
using System.Collections.Generic;
using System.Linq;
class FitBoxInBox
{
    static void Main()
    {
        List<int> firstBox = new List<int>();
        List<int> secondBox = new List<int>();
        for (int i = 0; i < 3; i++)
        {
            firstBox.Add(int.Parse(Console.ReadLine()));
        }

        for (int i = 0; i < 3; i++)
        {
            secondBox.Add(int.Parse(Console.ReadLine()));
        }



        if (firstBox.Sum() > secondBox.Sum())
        {
            for (int i = 0; i < 3; i++)
            {
                int temp = firstBox[i];
                firstBox[i] = secondBox[i];
                secondBox[i] = temp;
            }
        }

        for (int i = 0; i < 3; i++)
        {
            if (firstBox[0] < secondBox[0] && firstBox[1] < secondBox[1] && firstBox[2] < secondBox[2])
            {
                Console.WriteLine("({0}, {1}, {2}) < ({3}, {4}, {5})", firstBox[0], firstBox[1], firstBox[2],
                        secondBox[0], secondBox[1], secondBox[2]);
            }
            int temp = secondBox[1];
            secondBox[1] = secondBox[2];
            secondBox[2] = temp;

            if (firstBox[0] < secondBox[0] && firstBox[1] < secondBox[1] && firstBox[2] < secondBox[2])
            {
                Console.WriteLine("({0}, {1}, {2}) < ({3}, {4}, {5})", firstBox[0], firstBox[1], firstBox[2],
                        secondBox[0], secondBox[1], secondBox[2]);
            }

            temp = secondBox[0];
            secondBox[0] = secondBox[1];
            secondBox[1] = temp;
        }
    }
}
