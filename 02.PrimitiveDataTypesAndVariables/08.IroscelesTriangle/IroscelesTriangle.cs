using System;
class IroscelesTriangle
{
    static void Main()
    {
        char symbol = '©';
        int leftPart = 5;
        int rightPart = leftPart;
        for (int row = 0; row < 3; row++)
        {
            for (int col = 2; col < 10; col++)
            {
                if (col == leftPart || col == rightPart)
                {
                    Console.Write(symbol);
                }
                else
                {
                    Console.Write(" ");
                }
            }
            leftPart--;
            rightPart++;
            Console.WriteLine();
        }

        for (int col = 2; col < 10; col++)
        {
            if (col % 2 == 0)
            {
                Console.Write(symbol);
            }
            else
            {
                Console.Write(" ");
            }
        }
    }
}
