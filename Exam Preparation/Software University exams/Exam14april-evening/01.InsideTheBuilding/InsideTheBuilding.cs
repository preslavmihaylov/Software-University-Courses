using System;

class InsideTheBuilding
{
    static void Main()
    {
        int height = int.Parse(Console.ReadLine());

        if (height >= 0)
        {
            for (int line = 0; line < 5; line++)
            {
                int x = int.Parse(Console.ReadLine());
                int y = int.Parse(Console.ReadLine());

                if (y <= height && y >= 0 && x >= 0 && x <= height * 3)
                {
                    Console.WriteLine("inside");
                }
                else if (y > height && y <= height * 4 && x >= height && x <= height * 2)
                {
                    Console.WriteLine("inside");
                }
                else
                {
                    Console.WriteLine("outside");
                }
            }
        }
    }
}
