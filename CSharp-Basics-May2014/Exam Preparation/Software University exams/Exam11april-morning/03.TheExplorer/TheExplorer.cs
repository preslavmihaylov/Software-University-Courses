using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class TheExplorer
{
    static void Main()
    {
        int diamondWidth = int.Parse(Console.ReadLine());

        int leftPart = diamondWidth / 2;
        int rightPart = leftPart;
        bool backwards = false;

        for (int row = 0; row < diamondWidth; row++)
        {
            for (int col = 0; col < diamondWidth; col++)
            {
                if (col == leftPart || col == rightPart)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write("-");
                }
            }
            Console.WriteLine();
            if (leftPart == 0)
            {
                backwards = true;
            }

            if (backwards == true)
            {
                leftPart++;
                rightPart--;
            }
            else
            {
                leftPart--;
                rightPart++;
            }
        }
    }
}
