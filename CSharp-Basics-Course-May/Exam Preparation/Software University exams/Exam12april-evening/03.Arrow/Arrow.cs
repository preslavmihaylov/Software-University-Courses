using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Arrow
{
    static void Main()
    {
        int width = int.Parse(Console.ReadLine());

        int leftPart = (width + width - 1) - (width + (width - 1) / 2);
        int rightPart = ((width + width - 1) - (width - 1) / 2) - 1;

        for (int row = 0; row < width; row++)
        {
            for (int col = 0; col < width + width - 1; col++)
            {
                if (col >= leftPart && col <= rightPart && row == 0)
                {
                    Console.Write("#");
                }
                else if (col == leftPart || col == rightPart)
                {
                    Console.Write("#");
                }
                else if ((col <= leftPart || col >= rightPart) && row == width - 1)
                {
                    Console.Write("#");
                }
                else
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
        }

        leftPart = 1;
        rightPart = width + width - 3;

        for (int row = 0; row < width - 1; row++)
        {
            for (int col = 0; col < width + width - 1; col++)
            {
                if (col != leftPart && col != rightPart)
                {
                    Console.Write(".");
                }
                else
                {
                    Console.Write("#");
                }
            }
            Console.WriteLine();
            leftPart++;
            rightPart--;
        }
    }
}
