using System;

class MatrixOfPalindromes
{
    static void Main()
    {
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());

        string[,] palindromes = new string[rows, cols];

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                palindromes[row, col] = "" + (char)('a' + row) + (char)('a' + row + col) + (char)('a' + row);
            }
        }

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Console.Write(palindromes[row, col] + " ");
            }
            Console.WriteLine();
        }
    }
}
