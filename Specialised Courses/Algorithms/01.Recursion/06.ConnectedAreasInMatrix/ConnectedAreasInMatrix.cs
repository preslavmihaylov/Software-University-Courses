namespace _06.ConnectedAreasInMatrix
{
    using System;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    class ConnectedAreasInMatrix
    {
        /*
        private static char[,] labyrinth = new char[,]
        {
            { ' ', ' ', ' ', '*', ' ', ' ', ' ', '*', ' '},
            { ' ', ' ', ' ', '*', ' ', ' ', ' ', '*', ' '},
            { ' ', ' ', ' ', '*', ' ', ' ', ' ', '*', ' '},
            { ' ', ' ', ' ', ' ', '*', ' ', '*', ' ', ' '}
        };
        */

        private static char[,] labyrinth = 
        {
            { '*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' '},
            { '*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' '},
            { '*', ' ', ' ', '*', '*', '*', '*', '*', ' ', ' '},
            { '*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' '},
            { '*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' '}
        };

        private static int currentAreaSize = 0;

        // SortedSet<areaSize, Tuple<row, col>>
        private static OrderedBag<Area> connectedAreas =
            new OrderedBag<Area>(new DescendingComparer<Area>());

        static void Main()
        {
            FindConnectedAreas();
            PrintLabyrinth();
            PrintFoundAreas();
        }

        static void FindConnectedAreas()
        {
            TraverseAndMarkConnectedCells();
            ClearMarkedPositions();
        }

        static void TraverseAndMarkConnectedCells()
        {
            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    if (labyrinth[row, col] == ' ')
                    {
                        MarkConnectedArea(row, col);
                        connectedAreas.Add(new Area()
                        {
                            Size = currentAreaSize,
                            Row = row,
                            Col = col
                        });

                        currentAreaSize = 0;
                    }
                }
            }
        }

        static void MarkConnectedArea(int row, 
                                      int col)
        {
            if (!IsValidPosition(row, col))
            {
                return;
            }

            if (labyrinth[row, col] != ' ')
            {
                return;
            }

            currentAreaSize++;

            labyrinth[row, col] = 'x';

            MarkConnectedArea(row, col + 1); // right
            MarkConnectedArea(row + 1, col); // down
            MarkConnectedArea(row, col - 1); // left
            MarkConnectedArea(row - 1, col); // up
        }

        static void ClearMarkedPositions()
        {
            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    if (labyrinth[row, col] == 'x')
                    {
                        labyrinth[row, col] = ' ';
                    }
                }
            }
        }

        static void PrintFoundAreas()
        {
            Console.WriteLine("Total areas found: {0}",
                connectedAreas.Count);

            int count = 1;
            foreach (var connectedArea in connectedAreas)
            {
                Console.WriteLine("Area #{0} at ({1}, {2}), size: {3}",
                    count,
                    connectedArea.Row,
                    connectedArea.Col,
                    connectedArea.Size);
                count++;
            }
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

        static bool IsValidPosition(int row, int col)
        {
            bool validRowPosition = row >= 0 && 
                row < labyrinth.GetLength(0);

            bool validColPosition = col >= 0 && 
                col < labyrinth.GetLength(1);

            return validRowPosition && validColPosition;
        }
    }

    class Area : IComparable<Area>
    {
        public int Size { get; set; }

        public int Row { get; set; }

        public int Col { get; set; }

        public int CompareTo(Area other)
        {
            return this.Size.CompareTo(other.Size);
        }
    }

    class DescendingComparer<T> : IComparer<T>
        where T : IComparable<T>
    {

        public int Compare(T x, T y)
        {
            return y.CompareTo(x);
        }
    }
}