using System;

class MatrixOfNumbers
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        for (int row = 0; row < number; row++)
        {
            for (int col = row + 1; col <= row + number; col++)
            {
                Console.Write(col + " ");
            }
            Console.WriteLine();
        }
    }
}
