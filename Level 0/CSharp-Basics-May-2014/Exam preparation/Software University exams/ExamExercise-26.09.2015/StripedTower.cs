namespace LiveDemo
{
    using System;

    class LiveDemo
    {
        static void Main()
        {
            int width = int.Parse(Console.ReadLine());

            int height = (int) (width * 1.5);

            int count = 0;

            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    if (count == 0)
                    {
                        count = 2;
                        Console.Write("#");   
                    }
                    else
                    {
                        count--;
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}