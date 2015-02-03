﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _13.SnakeGame
{
    struct Position
    {
        public int row;
        public int col;
        public Position(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
    }
    class Program
    {
        static void Main()
        {
            byte right = 0, left = 1, down = 2, up = 3;

            int lastFoodTime = 0;
            int FoodDissapearTime = 8000;
            double NegativePoints = 0;

            Position[] directions = new Position[]
            {
                new Position(0, 1), // right
                new Position(0, -1), // left
                new Position(1, 0), // down
                new Position(-1, 0), // up
            };
            double sleeptime = 100;
            int direction = 0;
            Random randomNumbersGenerator = new Random();
            Console.BufferHeight = Console.WindowHeight;

            Position food = new Position(randomNumbersGenerator.Next(0, Console.WindowHeight),
                    randomNumbersGenerator.Next(0, Console.WindowWidth));

            List<Position> Obstacles = new List<Position>()
            {
                new Position(12,12),
                new Position(13,12),
                new Position(14,12),
                new Position(15,12),
                new Position(16,12),
            };

            foreach (Position obstacle in Obstacles)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(obstacle.col, obstacle.row);
                Console.Write("|");
            }
            Queue<Position> snakeElements = new Queue<Position>();
            for (int i = 0; i <= 5; i++)
            {
                snakeElements.Enqueue(new Position(0, i));
            }

            foreach (Position position in snakeElements)
            {
                Console.SetCursorPosition(position.col, position.row);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("*");
            }

            do
            {
                food = new Position(randomNumbersGenerator.Next(0, Console.WindowHeight),
                    randomNumbersGenerator.Next(0, Console.WindowWidth));
                lastFoodTime = Environment.TickCount;
                Console.SetCursorPosition(food.col, food.row);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("@");
            }
            while (snakeElements.Contains(food) || Obstacles.Contains(food));

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo userInput = Console.ReadKey();
                    while (Console.KeyAvailable)
                    {
                        userInput = Console.ReadKey(true);
                    }
                    if (userInput.Key == ConsoleKey.LeftArrow && direction != right)
                    {
                        direction = left;
                    }
                    if (userInput.Key == ConsoleKey.RightArrow && direction != left)
                    {
                        direction = right;
                    }
                    if (userInput.Key == ConsoleKey.UpArrow && direction != down)
                    {
                        direction = up;
                    }
                    if (userInput.Key == ConsoleKey.DownArrow && direction != up)
                    {
                        direction = down;
                    }
                }
                Position snakeHead = snakeElements.Last();
                Position nextDirection = directions[direction];
                Position snakeNewHead = new Position(snakeHead.row + nextDirection.row,
                    snakeHead.col + nextDirection.col);

                if (snakeNewHead.col < 0) snakeNewHead.col = Console.WindowWidth - 1;
                if (snakeNewHead.row < 0) snakeNewHead.row = Console.WindowHeight - 1;
                if (snakeNewHead.col >= Console.WindowWidth) snakeNewHead.col = 0;
                if (snakeNewHead.row >= Console.WindowHeight) snakeNewHead.row = 0;

                if (snakeElements.Contains(snakeNewHead) || Obstacles.Contains(snakeNewHead))
                {
                    Console.SetCursorPosition(0, 0);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Game over!");
                    int userpoints = (snakeElements.Count - 6) * 100 - (int)NegativePoints;
                    userpoints = Math.Max(userpoints, 0);
                    Console.WriteLine("Your points are: {0}", userpoints);
                    Console.ReadLine();
                    return;
                }

                snakeElements.Enqueue(snakeNewHead);
                Console.SetCursorPosition(snakeNewHead.col, snakeNewHead.row);
                Console.ForegroundColor = ConsoleColor.Green;
                if (direction == left) { Console.Write("<"); }
                if (direction == right) { Console.Write(">"); }
                if (direction == down) { Console.Write("v"); }
                if (direction == up) { Console.Write("^"); }

                Console.SetCursorPosition(snakeHead.col, snakeHead.row);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("*");

                if (snakeNewHead.col == food.col && snakeNewHead.row == food.row)
                {
                    // feeding
                    do
                    {
                        food = new Position(randomNumbersGenerator.Next(0, Console.WindowHeight),
                            randomNumbersGenerator.Next(0, Console.WindowWidth));
                    }
                    while (snakeElements.Contains(food) || Obstacles.Contains(food));
                    lastFoodTime = Environment.TickCount;
                    Console.SetCursorPosition(food.col, food.row);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("@");
                    Position obstacle;
                    do
                    {
                        obstacle = new Position(randomNumbersGenerator.Next(0, Console.WindowHeight),
                        randomNumbersGenerator.Next(0, Console.WindowWidth));
                    }
                    while (snakeElements.Contains(obstacle) || Obstacles.Contains(obstacle) ||
                        (food.row != obstacle.row && food.col != obstacle.col));
                    Obstacles.Add(obstacle);
                    Console.SetCursorPosition(obstacle.col, obstacle.row);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("=");
                }
                else
                {
                    //moving
                    Position last = snakeElements.Dequeue();
                    Console.SetCursorPosition(last.col, last.row);
                    Console.Write(" ");
                }

                if (Environment.TickCount - lastFoodTime >= FoodDissapearTime)
                {
                    NegativePoints = NegativePoints + 50;
                    Console.SetCursorPosition(food.col, food.row);
                    Console.Write(" ");
                    do
                    {
                        food = new Position(randomNumbersGenerator.Next(0, Console.WindowHeight),
                            randomNumbersGenerator.Next(0, Console.WindowWidth));
                    }
                    while (snakeElements.Contains(food));
                    lastFoodTime = Environment.TickCount;
                    Console.SetCursorPosition(food.col, food.row);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("@");
                }

                Console.SetCursorPosition(food.col, food.row);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("@");

                sleeptime -= 0.01;
                NegativePoints += 0.2;

                Thread.Sleep((int)sleeptime);

            }
        }
    }
}


