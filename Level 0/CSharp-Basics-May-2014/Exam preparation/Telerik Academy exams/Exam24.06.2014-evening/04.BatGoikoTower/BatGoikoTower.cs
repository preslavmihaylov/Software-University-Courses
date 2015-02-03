using System;

class BatGoikoTower
{
    static void Main()
    {
        int height = int.Parse(Console.ReadLine());

        int width = 2 * height;

        int left = height - 1;
        int right = height;
        int count = 0;
        int crossBeamsPos = 1;
        bool crossBeamReady = false;

        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                if (col == left)
                {
                    Console.Write("/");
                }
                else if (col == right)
                {
                    Console.Write("\\");
                }
                else if (col >= left && col <= right && count == crossBeamsPos)
                {
                    Console.Write("-");
                    crossBeamReady = true;
                }
                else
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
            left--;
            right++;
            count++;

            if (crossBeamReady)
            {
                count = 1;
                crossBeamsPos++;
                crossBeamReady = false;
            }
        }
    }
}
