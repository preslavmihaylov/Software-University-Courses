namespace _05.PathsBetweenCellsInMatrix
{
    using System;
    using System.Collections.Generic;

    class PathsBetweenCellsInMatrix
    {
        /*
        private static char[,] labyrinth = new char[,]
        {
            { 's', ' ', ' ', ' '},
            { ' ', '*', '*', ' '},
            { ' ', '*', '*', ' '},
            { ' ', '*', 'e', ' '},
            { ' ', ' ', ' ', ' '}
        };
        */

        private static char[,] labyrinth = new char[,]
        {
            { 's', ' ', ' ', ' ', ' ', ' '},
            { ' ', '*', '*', ' ', '*', ' '},
            { ' ', '*', '*', ' ', '*', ' '},
            { ' ', '*', 'e', ' ', ' ', ' '},
            { ' ', ' ', ' ', '*', ' ', ' '}
        };

        private static int startPosRow = 0;
        private static int startPosCol = 0;
        private static List<char> directions = new List<char>();
        private static int pathsFound = 0;

        static void Main()
        {
            FindPath(startPosRow, startPosCol);
            PrintLabyrinth();
            PrintPathsFound();
        }

        static void FindPath(int row, int col)
        {
            if (!IsValidPosition(row, col))
            {
                return;
            }

            if (labyrinth[row, col] == 'e')
            {
                PrintSolution();
                return;
            }

            if (labyrinth[row, col] != ' ' && labyrinth[row, col] != 's')
            {
                return;
            }

            labyrinth[row, col] = 'x';

            directions.Add('R');
            FindPath(row, col + 1); // right
            directions.RemoveAt(directions.Count - 1);

            directions.Add('D');
            FindPath(row + 1, col); // down
            directions.RemoveAt(directions.Count - 1);

            directions.Add('L');
            FindPath(row, col - 1); // left
            directions.RemoveAt(directions.Count - 1);

            directions.Add('U');
            FindPath(row - 1, col); // up
            directions.RemoveAt(directions.Count - 1);

            labyrinth[row, col] = ' ';
        }

        static bool IsValidPosition(int row, int col)
        {
            bool validRowPosition = row >= 0 && row < labyrinth.GetLength(0);
            bool validColPosition = col >= 0 && col < labyrinth.GetLength(1);

            return validRowPosition && validColPosition;
        }

        static void PrintSolution()
        {
            foreach (var direction in directions)
            {
                Console.Write(direction);
            }
            Console.WriteLine();
            pathsFound++;
        }

        static void PrintPathsFound()
        {
            Console.WriteLine("Total paths found: {0}", pathsFound);
        }

        static void PrintLabyrinth()
        {
            Console.WriteLine(new string('^', labyrinth.GetLength(1) + 2));
            
            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                Console.Write("|");
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    Console.Write(labyrinth[row, col]);
                }
                Console.WriteLine("|");
            }

            Console.WriteLine(new string('^', labyrinth.GetLength(1) + 2));
        }
    }
}