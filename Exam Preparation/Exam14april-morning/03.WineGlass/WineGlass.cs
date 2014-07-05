using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class WineGlass
{
    static void Main()
    {
        int height = int.Parse(Console.ReadLine());

        int leftPart = 0;
        int rightPart = height - 1;
        int count = 0;

        for (int row = 0; row < height / 2; row++)
        {
            for (int col = 0; col < height; col++)
            {
                if (col < leftPart || col > rightPart)
                {
                    Console.Write(".");
                }
                else if (col == leftPart)
                {
                    Console.Write(@"\");
                }
                else if (col == rightPart)
                {
                    Console.Write(@"/");
                }
                else
                {
                    Console.Write("*");
                }
            }
            Console.WriteLine();
            count++;
            leftPart++;
            rightPart--;
        }

        for (int row = 0; row < height - count; row++)
        {
            for (int col = 0; col < height; col++)
            {
                if ((row == height - count - 1 || row == height - count - 2) && height >= 12)
                {
                    Console.Write("-");
                    continue;
                }
                if (row == height - count - 1)
                {
                    Console.Write("-");
                }
                else if (col != height / 2 && col != height / 2 - 1)
                {
                    Console.Write(".");
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
