using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class NewHouse
{
    static void Main()
    {
        int height = int.Parse(Console.ReadLine());

        int leftPart = height / 2;
        int rightPart = leftPart;

        while (leftPart >= 0)
        {
            for (int col = 0; col < height; col++)
            {
                if (col >= leftPart && col <= rightPart)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write("-");
                }
            }
            Console.WriteLine();
            leftPart--;
            rightPart++;
        }

        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < height; col++)
            {
                if (col != 0 && col != height - 1)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write("|");
                }
            }
            Console.WriteLine();
        }
    }
}
