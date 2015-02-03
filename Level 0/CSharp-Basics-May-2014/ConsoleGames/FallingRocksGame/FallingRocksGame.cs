using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class FallingRocksGame
{
    struct GameObject
    {
        public int row;
        public int col;
        public string ch;
        public ConsoleColor color;
    }
    static void Main()
    {
        Console.WindowHeight = 20;
        Console.WindowWidth = 30;
        Console.BufferHeight = Console.WindowHeight;
        Console.BufferWidth = Console.WindowWidth;
        Console.CursorVisible = false;
        Console.Title = "Falling Rocks";

        Random randomGenerator = new Random();
        int score = 0;
        double sleepTime = 150;
        int lives = 5;

        List<GameObject> dwarf = new List<GameObject>();
        dwarf.Add(new GameObject() { row = Console.WindowHeight - 1, col = 14, ch = "(", color = ConsoleColor.White });
        dwarf.Add(new GameObject() { row = Console.WindowHeight - 1, col = 15, ch = "0", color = ConsoleColor.White });
        dwarf.Add(new GameObject() { row = Console.WindowHeight - 1, col = 16, ch = ")", color = ConsoleColor.White });

        List<GameObject> rocks = new List<GameObject>();

        // instructions at the start of the game
        PrintOnPosition(4, 2, "The aim of this game is", ConsoleColor.Red);
        PrintOnPosition(5, 2, "to avoid all the rocks.", ConsoleColor.Red);
        PrintOnPosition(7, 2, "Do your best to survive", ConsoleColor.Yellow);
        PrintOnPosition(8, 2, "as long as possible.", ConsoleColor.Yellow);

        PrintOnPosition(10, 2, "Collect", ConsoleColor.Magenta);
        PrintOnPosition(10, 10, "♥", ConsoleColor.Red);
        PrintOnPosition(10, 12, "for lives.", ConsoleColor.Magenta);
        PrintOnPosition(11, 2, "Collect", ConsoleColor.Magenta);
        PrintOnPosition(11, 10, "$", ConsoleColor.Green);
        PrintOnPosition(11, 12, "for money.", ConsoleColor.Magenta);
        PrintOnPosition(13, 7, "Good luck!", ConsoleColor.Cyan);
        Console.ReadLine();
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.Clear();

        // accessories
        foreach (var item in dwarf)
        {
            PrintOnPosition(item.row, item.col, item.ch, item.color);
        }

        for (int index = 0; index < Console.WindowWidth; index++)
        {
            PrintOnPosition(4, index, "_", ConsoleColor.White);
        }
        for (int index = 5; index < Console.WindowHeight - 1; index++)
        {
            PrintOnPosition(index, 0, "]", ConsoleColor.White);
            PrintOnPosition(index, Console.WindowWidth - 1, "[", ConsoleColor.White);
        }

        PrintOnPosition(3, 3, "Lives:", ConsoleColor.Cyan);
        PrintOnPosition(3, 15, "Score:", ConsoleColor.Magenta);

        while (true)
        {
            dwarf = MoveDwarf(dwarf);


            bool breakLoop = false;
            foreach (var element in dwarf)
            {
                foreach (var rock in rocks)
                {
                    if (rock.row + 1 == element.row && rock.col == element.col && rock.ch == "@")
                    {
                        PrintOnPosition(element.row, element.col, "X", ConsoleColor.Red);
                        lives = HitConsequences(lives, dwarf, rocks);
                        if (lives == 0)
                        {
                            return;
                        }
                        breakLoop = true;
                        break;
                    }
                    else if (rock.row + 1 == element.row && rock.col == element.col && rock.ch == "$")
                    {
                        score += 500;
                    }
                    else if (rock.row + 1 == element.row && rock.col == element.col && rock.ch == "♥")
                    {
                        lives++;
                    }
                }
                if (breakLoop == true)
                {
                    break;
                }
            }

            rocks = moveRocks(rocks, randomGenerator);

            PrintElements(dwarf, rocks);

            score += randomGenerator.Next(15, 69);
            sleepTime -= 0.05;
            if (sleepTime < 70)
            {
                sleepTime = 70;
            }
            PrintOnPosition(3, 21, Convert.ToString(score), ConsoleColor.Green);
            PrintOnPosition(3, 9, Convert.ToString(lives), ConsoleColor.Yellow);
            Thread.Sleep((int)sleepTime);
        }
    }

    private static void PrintElements(List<GameObject> dwarf, List<GameObject> rocks)
    {
        foreach (var item in rocks)
        {
            PrintOnPosition(item.row, item.col, item.ch, item.color);
        }

        for (int index = 0; index < dwarf.Count; index++)
        {
            PrintOnPosition(dwarf[index].row, dwarf[index].col, dwarf[index].ch, ConsoleColor.White);
        }
    }

    private static int HitConsequences(int lives, List<GameObject> dwarf, List<GameObject> rocks)
    {
        if (lives > 1)
        {
            PrintOnPosition(0, 0, "You have been hit!", ConsoleColor.Red);
            PrintOnPosition(1, 0, "Be careful next time...", ConsoleColor.Red);
            PrintOnPosition(2, 0, "Press enter to continue", ConsoleColor.White);
            Console.ReadLine();

            PrintOnPosition(0, 0, "                  ", ConsoleColor.Red);
            PrintOnPosition(1, 0, "                       ", ConsoleColor.Red);
            PrintOnPosition(2, 0, "                       ", ConsoleColor.White);

            foreach (var element in dwarf)
            {
                PrintOnPosition(element.row, element.col, " ", ConsoleColor.Yellow);
            }
            foreach (var rock in rocks)
            {
                PrintOnPosition(rock.row, rock.col, " ", ConsoleColor.Yellow);
            }
            rocks.Clear();
            dwarf.Clear();

            dwarf.Add(new GameObject()
            {
                row = Console.WindowHeight - 1,
                col = 14,
                ch = "(",
                color = ConsoleColor.White
            });
            dwarf.Add(new GameObject()
            {
                row = Console.WindowHeight - 1,
                col = 15,
                ch = "0",
                color = ConsoleColor.White
            });
            dwarf.Add(new GameObject()
            {
                row = Console.WindowHeight - 1,
                col = 16,
                ch = ")",
                color = ConsoleColor.White
            });
            lives--;
        }
        else
        {
            PrintOnPosition(0, 10, "Game Over!", ConsoleColor.Red);
            PrintOnPosition(1, 9, "Press enter", ConsoleColor.White);
            Console.Beep();
            Console.ReadLine();
            lives--;
        }
        return lives;
    }

    private static List<GameObject> moveRocks(List<GameObject> rocks, Random randomGenerator)
    {
        List<GameObject> newRocks = new List<GameObject>();

        foreach (var rock in rocks)
        {
            if (rock.row < Console.WindowHeight - 1)
            {
                newRocks.Add(new GameObject() { row = rock.row + 1, col = rock.col, ch = rock.ch, color = rock.color });
            }
            PrintOnPosition(rock.row, rock.col, " ", rock.color);
        }
        rocks.Clear();
        rocks = newRocks;
        int chance = randomGenerator.Next(0, 201);

        if (chance > 10)
        {
            rocks.Add(new GameObject()
            {
                row = 5,
                col = randomGenerator.Next(1, Console.WindowWidth - 1),
                ch = "@",
                color = ConsoleColor.Yellow
            });
        }
        else if (chance <= 10 && chance > 1)
        {
            rocks.Add(new GameObject()
            {
                row = 5,
                col = randomGenerator.Next(1, Console.WindowWidth - 1),
                ch = "$",
                color = ConsoleColor.Green
            });
        }
        else
        {
            rocks.Add(new GameObject()
            {
                row = 5,
                col = randomGenerator.Next(1, Console.WindowWidth - 1),
                ch = "♥",
                color = ConsoleColor.Red
            });
        }
        return rocks;
    }

    private static List<GameObject> MoveDwarf(List<GameObject> dwarf)
    {
        if (Console.KeyAvailable)
        {

            ConsoleKeyInfo userInput = Console.ReadKey();

            if (userInput.Key == ConsoleKey.LeftArrow && dwarf[0].col > 1)
            {
                List<GameObject> newDwarf = new List<GameObject>();

                for (int index = 0; index < dwarf.Count; index++)
                {
                    PrintOnPosition(dwarf[index].row, dwarf[index].col, " ", ConsoleColor.Black);

                    newDwarf.Add(new GameObject()
                    {
                        row = dwarf[index].row,
                        col = dwarf[index].col - 1,
                        ch = dwarf[index].ch,
                        color = dwarf[index].color
                    });
                }
                dwarf.Clear();
                dwarf = newDwarf;
            }

            if (userInput.Key == ConsoleKey.RightArrow && dwarf[2].col < Console.WindowWidth - 2)
            {
                List<GameObject> newDwarf = new List<GameObject>();

                for (int index = 0; index < dwarf.Count; index++)
                {
                    PrintOnPosition(dwarf[index].row, dwarf[index].col, " ", ConsoleColor.Black);

                    newDwarf.Add(new GameObject()
                    {
                        row = dwarf[index].row,
                        col = dwarf[index].col + 1,
                        ch = dwarf[index].ch,
                        color = dwarf[index].color
                    });
                }
                dwarf.Clear();
                dwarf = newDwarf;
            }
        }

        return dwarf;
    }

    static void PrintOnPosition(int row, int col, string str, ConsoleColor color)
    {
        Console.SetCursorPosition(col, row);
        Console.ForegroundColor = color;
        Console.Write(str);
    }
}