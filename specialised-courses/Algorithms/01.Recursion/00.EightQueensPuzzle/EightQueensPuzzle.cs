namespace _00.EightQueensPuzzle
{
    using System;
    using System.Collections.Generic;

    public class EightQueensPuzzle
    {
        private const int Size = 9;
        static bool[,] chessboard = new bool[Size, Size];
        static bool[] attackedCols = new bool[Size];
        static bool[] attackedLeftDiagonals = new bool[(Size - 1) * 2 + 1];
        static bool[] attackedRightDiagonals = new bool[(Size - 1) * 2 + 1];

        private static int count = 0;

        static void Main()
        {
            Console.BufferHeight = 1000;
            PutQueens(0);
            Console.WriteLine(count);
        }

        static void PutQueens(int row)
        {
            if (row >= Size)
            {
                PrintSolution();
                return;
            }

            for (int col = 0; col < Size; col++)
            {
                if (IsValidPosition(row, col))
                {
                    MarkAttackedPositions(row, col);
                    PutQueens(row + 1);
                    UnmarkAttackedPositions(row, col);
                }    
            }
        }

        static void MarkAttackedPositions(int row, int col)
        {
            attackedCols[col] = true;
            attackedLeftDiagonals[(col - row) + (Size - 1)] = true;
            attackedRightDiagonals[row + col] = true;
            chessboard[row, col] = true;
        }

        static void UnmarkAttackedPositions(int row, int col)
        {
            attackedCols[col] = false;
            attackedLeftDiagonals[(col - row) + (Size - 1)] = false;
            attackedRightDiagonals[row + col] = false;
            chessboard[row, col] = false;
        }

        static void PrintSolution()
        {
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    var symbol = !chessboard[row, col] ? '-' : 'Q';
                    Console.Write(symbol + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            count++;
        }

        static bool IsValidPosition(int row, int col)
        {
            return !attackedCols[col] &&
                   !attackedLeftDiagonals[(col - row) + (Size - 1)] &&
                   !attackedRightDiagonals[row + col];
        }
    }
}