namespace Minesweeper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Minesweeper
    {
        private static void Main(string[] args)
        {
            string command = string.Empty;
            char[,] field = CreateGameField();
            char[,] bombs = InputBombs();
            int counter = 0;
            bool isBoom = false;
            List<Score> champions = new List<Score>(6);
            int row = 0;
            int col = 0;
            bool hasLost = true;
            const int max = 35;
            bool hasWon = false;

            do
            {
                if (hasLost)
                {
                    Console.WriteLine(
                        "Let's Play Minesweeper. Try finding the field without mines."
                        + " The command 'top' shows the ShowScoreboard, 'restart' restarts the game, 'exit' quits the current game!");
                    DisplayGameField(field);
                    hasLost = false;
                }

                Console.Write("Please insert a row and col: ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) && int.TryParse(command[2].ToString(), out col)
                        && row <= field.GetLength(0) && col <= field.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        ShowScoreboard(champions);
                        break;
                    case "restart":
                        field = CreateGameField();
                        bombs = InputBombs();
                        DisplayGameField(field);
                        isBoom = false;
                        hasLost = false;
                        break;
                    case "exit":
                        Console.WriteLine("Farewell, stranger!");
                        break;
                    case "turn":
                        if (bombs[row, col] != '*')
                        {
                            if (bombs[row, col] == '-')
                            {
                                ChangePlayerTurn(field, bombs, row, col);
                                counter++;
                            }

                            if (max == counter)
                            {
                                hasWon = true;
                            }
                            else
                            {
                                DisplayGameField(field);
                            }
                        }
                        else
                        {
                            isBoom = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nError. Wrong command.\n");
                        break;
                }

                if (isBoom)
                {
                    DisplayGameField(bombs);
                    Console.Write("\nSuch a tragic death... " + "Well, atleast give us your nickname: ", counter);
                    string nickname = Console.ReadLine();
                    Score currentScore = new Score(nickname, counter);
                    if (champions.Count < 5)
                    {
                        champions.Add(currentScore);
                    }
                    else
                    {
                        for (int i = 0; i < champions.Count; i++)
                        {
                            if (champions[i].Points < currentScore.Points)
                            {
                                champions.Insert(i, currentScore);
                                champions.RemoveAt(champions.Count - 1);
                                break;
                            }
                        }
                    }

                    champions.Sort((Score r1, Score r2) => r2.Player.CompareTo(r1.Player));
                    champions.Sort((Score r1, Score r2) => r2.Points.CompareTo(r1.Points));
                    ShowScoreboard(champions);

                    field = CreateGameField();
                    bombs = InputBombs();
                    counter = 0;
                    isBoom = false;
                    hasLost = true;
                }

                if (hasWon)
                {
                    Console.WriteLine("\nCongratulations! You have successfully found all the mines on the field.");
                    DisplayGameField(bombs);
                    Console.WriteLine("Plase, insert your name: ");
                    string name = Console.ReadLine();
                    Score points = new Score(name, counter);
                    champions.Add(points);
                    ShowScoreboard(champions);
                    field = CreateGameField();
                    bombs = InputBombs();
                    counter = 0;
                    hasWon = false;
                    hasLost = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("This game has been created in Bulgaria.");
            Console.WriteLine("Farewell.");
            Console.Read();
        }

        private static void ShowScoreboard(List<Score> points)
        {
            Console.WriteLine("\nPoints:");
            if (points.Count > 0)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} boxes", i + 1, points[i].Player, points[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("The scoreboard is empty\n");
            }
        }

        private static void ChangePlayerTurn(char[,] field, char[,] bombs, int row, int col)
        {
            char BombsPoints = GetAdjacentMinesCount(bombs, row, col);
            bombs[row, col] = BombsPoints;
            field[row, col] = BombsPoints;
        }

        private static void DisplayGameField(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateGameField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] InputBombs()
        {
            int rows = 5;
            int cols = 10;
            char[,] gameField = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    gameField[i, j] = '-';
                }
            }

            List<int> bombsPositions = new List<int>();
            while (bombsPositions.Count < 15)
            {
                Random random = new Random();
                int bombPosition = random.Next(50);
                if (!bombsPositions.Contains(bombPosition))
                {
                    bombsPositions.Add(bombPosition);
                }
            }

            foreach (int position in bombsPositions)
            {
                int col = position / cols;
                int row = position % cols;
                if (row == 0 && position != 0)
                {
                    col--;
                    row = cols;
                }
                else
                {
                    row++;
                }

                gameField[col, row - 1] = '*';
            }

            return gameField;
        }

        private static void GetCurrentPositionNumber(char[,] field)
        {
            int rows = field.GetLength(0);
            int cols = field.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (field[i, j] != '*')
                    {
                        char points = GetAdjacentMinesCount(field, i, j);
                        field[i, j] = points;
                    }
                }
            }
        }

        private static char GetAdjacentMinesCount(char[,] gameField, int row, int col)
        {
            int minesCount = 0;
            int rows = gameField.GetLength(0);
            int cols = gameField.GetLength(1);

            if (row - 1 >= 0)
            {
                if (gameField[row - 1, col] == '*')
                {
                    minesCount++;
                }
            }

            if (row + 1 < rows)
            {
                if (gameField[row + 1, col] == '*')
                {
                    minesCount++;
                }
            }

            if (col - 1 >= 0)
            {
                if (gameField[row, col - 1] == '*')
                {
                    minesCount++;
                }
            }

            if (col + 1 < cols)
            {
                if (gameField[row, col + 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (gameField[row - 1, col - 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((row - 1 >= 0) && (col + 1 < cols))
            {
                if (gameField[row - 1, col + 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (gameField[row + 1, col - 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((row + 1 < rows) && (col + 1 < cols))
            {
                if (gameField[row + 1, col + 1] == '*')
                {
                    minesCount++;
                }
            }

            return char.Parse(minesCount.ToString());
        }
    }
}